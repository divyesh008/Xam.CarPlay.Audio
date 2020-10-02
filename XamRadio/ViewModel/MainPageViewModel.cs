using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MediaManager;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;
using XamRadio.Interface;
using XamRadio.Model;

namespace XamRadio.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        int count = 0;

        public MainPageViewModel(INavigationService navigationPage) : base(navigationPage)
        {
        }

        private ObservableCollection<PlayListModel> _itemCollection = new ObservableCollection<PlayListModel>();
        public ObservableCollection<PlayListModel> ItemCollection
        {
            get { return _itemCollection; }
            set { SetProperty(ref _itemCollection, value); }
        }

        public DelegateCommand<PlayListModel> PlayCommand { get { return new DelegateCommand<PlayListModel>(async (obj) => await PlayPause(obj)); } }

        private async Task PlayPause(PlayListModel obj)
        {
            try
            {
                var item = await CrossMediaManager.Current.Extractor.CreateMediaItem(obj.Url);
                item.MediaType = MediaManager.Library.MediaType.Audio;

                if (CrossMediaManager.Current.IsPlaying())
                {
                    await CrossMediaManager.Current.Pause();
                    obj.PlayPauseIcon = "play";
                }
                else
                {
                    count++;
                    if (count == 1)
                        await CrossMediaManager.Current.Play(item);
                    else
                        await CrossMediaManager.Current.Play();
                    obj.PlayPauseIcon = "pause";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            LoadData();
        }

        public void LoadData()
        {
            ItemCollection = new ObservableCollection<PlayListModel>();
            ItemCollection.Add(new PlayListModel() { Id = "A1", Name = "Playlist item 1", Editor = "DJ Bravo", Url = GlobalConstants.PlayUrl, Duration = 270, ArtWork = "https://p7.hiclipart.com/preview/184/530/423/acoustic-wave-computer-icons-sound-wave-thumbnail.jpg", PlayPauseIcon = "play" });
            ItemCollection.Add(new PlayListModel() { Id = "B2", Name = "Playlist item 2", Editor = "DJ Bravo", Url = GlobalConstants.PlayUrl, Duration = 270, ArtWork = "https://p1.hiclipart.com/preview/50/460/924/icon-2-music-blue-and-black-audio-file-png-clipart-thumbnail.jpg", PlayPauseIcon = "play" });
            ItemCollection.Add(new PlayListModel() { Id = "C3", Name = "Playlist item 3", Editor = "DJ Bravo", Url = GlobalConstants.PlayUrl, Duration = 270, ArtWork = "https://pastoralproject.org/wp-content/plugins/mediapress/templates/mediapress/default/assets/images/audio-thumbnail.png", PlayPauseIcon = "play" });
            ItemCollection.Add(new PlayListModel() { Id = "D4", Name = "Playlist item 4", Editor = "DJ Bravo", Url = GlobalConstants.PlayUrl, Duration = 270, ArtWork = "https://p7.hiclipart.com/preview/184/530/423/acoustic-wave-computer-icons-sound-wave-thumbnail.jpg", PlayPauseIcon = "play" });

            Device.BeginInvokeOnMainThread(() =>
            {
                Xamarin.Forms.DependencyService.Get<ICarPlayService>().InitCarPlay();
            });
        }
    }
}
