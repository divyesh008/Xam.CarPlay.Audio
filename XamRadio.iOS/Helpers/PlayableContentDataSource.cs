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
                    item.Title = "WebRadio";
                    item.Container = true;
                    item.Playable = false;
                    return item;
                }
                else
                {
                    //Items
                    var item = new MPContentItem("Test" + indexPath.Length);
                    item.Title = "Title" + indexPath.Length;
                    item.Subtitle = "Subtitle" + indexPath.Length;
                    item.Playable = true;
                    item.StreamingContent = true;
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
            return 1;
        }
    }
}
