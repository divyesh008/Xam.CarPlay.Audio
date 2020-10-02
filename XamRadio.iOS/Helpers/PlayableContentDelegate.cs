using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CoreFoundation;
using Foundation;
using MediaManager;
using MediaPlayer;
using ObjCRuntime;
using UIKit;

namespace XamRadio.iOS.Helpers
{
    public class PlayableContentDelegate : MPPlayableContentDelegate
    {
        public override void InitiatePlaybackOfContentItem(MPPlayableContentManager contentManager, NSIndexPath indexPath, Action<NSError> completionHandler)
        {
            try
            {
                DispatchQueue.MainQueue.DispatchAsync(async () =>
                {
                    UIApplication.SharedApplication.EndReceivingRemoteControlEvents();
                    UIApplication.SharedApplication.BeginReceivingRemoteControlEvents();

                    var itemToPlay = GlobalConstants.PlayLists[indexPath.Row];
                    var NowPlayingInfoCenter = MPNowPlayingInfoCenter.DefaultCenter;

                    MPNowPlayingInfo playingInfo = new MPNowPlayingInfo();
                    playingInfo.Title = GlobalConstants.PlayLists[indexPath.Row].Name;
                    playingInfo.Artist = GlobalConstants.PlayLists[indexPath.Row].Editor;
                    playingInfo.PlaybackDuration = GlobalConstants.PlayLists[indexPath.Row].Duration;  
                    playingInfo.MediaType = MPNowPlayingInfoMediaType.Audio;

                    NowPlayingInfoCenter.NowPlaying = playingInfo;

                    var commandCenter = MPRemoteCommandCenter.Shared;
                    commandCenter.PlayCommand.Enabled = true;
                    commandCenter.PauseCommand.Enabled = true;
                    commandCenter.PauseCommand.AddTarget(PauseButton);

                    var songId = "11111";
                    string[] identifier = new string[1];
                    identifier[0] = songId;

                    contentManager = MPPlayableContentManager.Shared;
                    contentManager.NowPlayingIdentifiers = identifier;

                    await CrossMediaManager.Current.Play(GlobalConstants.PlayLists[indexPath.Row].Url);

                    completionHandler(null);

                    UIApplication.SharedApplication.EndReceivingRemoteControlEvents();
                     
                    UIApplication.SharedApplication.BeginReceivingRemoteControlEvents();
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        
        public MPRemoteCommandHandlerStatus PauseButton(MPRemoteCommandEvent commandEvent)
        {
            Console.WriteLine("PauseButton : " + commandEvent.Command.Enabled.ToString());
            return MPRemoteCommandHandlerStatus.Success;
        }
    }
}
