using System;
using Foundation;
using UIKit;

namespace XamRadio.iOS.Helpers
{
    public static class ExtractArtWork
    {
        public static UIImage UIImageFromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }
    }
}
