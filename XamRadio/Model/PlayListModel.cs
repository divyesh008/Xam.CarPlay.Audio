using System;
using Prism.Mvvm;

namespace XamRadio.Model
{
    public class PlayListModel : BindableBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Editor { get; set; }
        public string Url { get; set; }
        public double Duration { get; set; }
        public string ArtWork { get; set; }
        private bool _isPlaying = false;
        public bool IsPlaying
        {
            get { return _isPlaying; }
            set
            {
                SetProperty(ref _isPlaying, value);
                if (value)
                {
                    PlayPauseIcon = "pause";
                }
                else
                {
                    PlayPauseIcon = "play";
                }
            }
        }

        private string _playPauseIcon = "play";
        public string PlayPauseIcon
        {
            get { return _playPauseIcon; }
            set { SetProperty(ref _playPauseIcon, value); }
        }
    }
}
