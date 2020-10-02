using System;
using System.Collections.ObjectModel;
using XamRadio.Model;

namespace XamRadio
{
    public static class GlobalConstants
    {
        public static string PlayUrl = "https://ia800605.us.archive.org/32/items/Mp3Playlist_555/AaronNeville-CrazyLove.mp3";
        public static bool IsPlaying;
        public static ObservableCollection<PlayListModel> PlayLists = new ObservableCollection<PlayListModel>();

    }
}
