using System;
using System.Collections.ObjectModel;
using XamRadio.Model;

namespace XamRadio.Service
{
    public class PlayListService
    {
        public ObservableCollection<PlayListModel> GetPlayList()
        {
            return new ObservableCollection<PlayListModel>()
            {
                new PlayListModel() { Id = "A1", Name = "Playlist item 1", Editor = "DJ Bravo", Url = GlobalConstants.PlayUrl, Duration = 270, ArtWork = "https://p1.hiclipart.com/preview/50/460/924/icon-2-music-blue-and-black-audio-file-png-clipart-thumbnail.jpg", PlayPauseIcon = "play" },
                new PlayListModel() { Id = "B2", Name = "Playlist item 2", Editor = "DJ Bravo", Url = GlobalConstants.PlayUrl, Duration = 270, ArtWork = "https://p7.hiclipart.com/preview/184/530/423/acoustic-wave-computer-icons-sound-wave-thumbnail.jpg", PlayPauseIcon = "play" },
                new PlayListModel() { Id = "C3", Name = "Playlist item 3", Editor = "DJ Bravo", Url = GlobalConstants.PlayUrl, Duration = 270, ArtWork = "https://pastoralproject.org/wp-content/plugins/mediapress/templates/mediapress/default/assets/images/audio-thumbnail.png", PlayPauseIcon = "play" },
                new PlayListModel() { Id = "D4", Name = "Playlist item 4", Editor = "DJ Bravo", Url = GlobalConstants.PlayUrl, Duration = 270, ArtWork = "https://p7.hiclipart.com/preview/184/530/423/acoustic-wave-computer-icons-sound-wave-thumbnail.jpg", PlayPauseIcon = "play" }
            };
        }
    }
}
