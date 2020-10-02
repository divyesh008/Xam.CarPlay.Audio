using System;
using System.Diagnostics;
using Foundation;
using MediaPlayer;

namespace XamRadio.iOS.Helpers
{
    public class PlayableContentDataSource : MPPlayableContentDataSource
    {
        public override MPContentItem ContentItem(NSIndexPath indexPath)
        {
            try
            {
                if (indexPath.Length == 1)
                {
                    //Container
                    var item = new MPContentItem("11111");
                    item.Title = "PlayList";
                    item.Container = true;
                    item.Playable = false;
                    return item;
                }
                else
                {
                    //Items
                    var song = GlobalConstants.PlayLists[indexPath.Row];
                    var item = new MPContentItem(song.Id);
                    item.Title = song.Name;
                    item.Subtitle = song.Editor;
                    item.Playable = true;
                    item.StreamingContent = true;
                    item.Artwork = new MPMediaItemArtwork(image: ExtractArtWork.UIImageFromUrl(song.ArtWork));
                    return item;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public override nint NumberOfChildItems(NSIndexPath indexPath)
        {
            if (indexPath.GetIndexes().Length == 0)
            {
                return 1;
            }
            return GlobalConstants.PlayLists.Count;
        }
    }
}
