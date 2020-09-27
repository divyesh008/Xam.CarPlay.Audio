using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CoreFoundation;
using Foundation;
using MediaPlayer;
using ObjCRuntime;
using UIKit;

namespace XamRadio.iOS.Helpers
{
    public class PlayableContentDelegate : MPPlayableContentDelegate
    {
        public override void PlayableContentManager(MPPlayableContentManager contentManager, NSIndexPath indexPath, Action<NSError> completionHandler)
        {
            base.PlayableContentManager(contentManager, indexPath, completionHandler);
        }

        public override void InitiatePlaybackOfContentItem(MPPlayableContentManager contentManager, NSIndexPath indexPath, Action<NSError> completionHandler)
        {
            try
            {
                DispatchQueue.MainQueue.DispatchAsync(() =>
                {
                    UIApplication.SharedApplication.EndReceivingRemoteControlEvents();
                    UIApplication.SharedApplication.BeginReceivingRemoteControlEvents();

                    var itemToPlay = GlobalConstants.PlayUrl;
                    var NowPlayingInfoCenter = MPNowPlayingInfoCenter.DefaultCenter;

                    MPNowPlayingInfo playingInfo = new MPNowPlayingInfo();
                    playingInfo.Title = "Global News Podcast";
                    playingInfo.Artist = "Global News";
                    playingInfo.AlbumTitle = "Podcast";
                    playingInfo.PlaybackDuration = 270;  
                    playingInfo.PlaybackRate = GlobalConstants.IsPlaying ? 1 : 0;
                    playingInfo.MediaType = MPNowPlayingInfoMediaType.Audio;

                    NowPlayingInfoCenter.NowPlaying = playingInfo;

                    var commandCenter = MPRemoteCommandCenter.Shared;
                    commandCenter.PlayCommand.Enabled = true;
                    commandCenter.StopCommand.Enabled = true;
                    commandCenter.PauseCommand.Enabled = false;
                    commandCenter.SkipForwardCommand.Enabled = true;
                    commandCenter.SkipBackwardCommand.Enabled = true;
                    commandCenter.TogglePlayPauseCommand.Enabled = true;

                    var podcastId = "11111";
                    string[] identifier = new string[1];
                    identifier[0] = podcastId;

                    contentManager = MPPlayableContentManager.Shared;
                    contentManager.NowPlayingIdentifiers = identifier;

                    completionHandler(null);

                    UIApplication.SharedApplication.EndReceivingRemoteControlEvents();

                    Task.Delay(1000);
                    UIApplication.SharedApplication.BeginReceivingRemoteControlEvents();
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
