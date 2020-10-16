using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MediaManager;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using XamRadio.Interface;
using XamRadio.Model;
using XamRadio.Service;

namespace XamRadio.ViewModel
{
    public class LandingPageViewModel : BaseViewModel
    {
        int count = 0;
        PlayListService playList = new PlayListService();
        public ObservableCollection<PlayListModel> PlayLists { get; set; }

        public LandingPageViewModel(INavigationService navigationPage) : base(navigationPage)
        {
            PlayLists = playList.GetPlayList();
            GlobalConstants.PlayLists = new ObservableCollection<PlayListModel>(PlayLists);
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
                    obj.IsPlaying = false;
                }
                else
                {
                    count++;
                    if (count == 1)
                        await CrossMediaManager.Current.Play(item);
                    else
                        await CrossMediaManager.Current.Play();
                    obj.IsPlaying = true;
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
        }

        public void LoadData()
        {
            //ItemCollection = new ObservableCollection<PlayListModel>()
            //{
            //    new PlayListModel() { Id = "A1", Name = "Playlist item 1", Editor = "DJ Bravo", Url = GlobalConstants.PlayUrl, Duration = 270, ArtWork = "https://t4.ftcdn.net/jpg/01/88/79/61/240_F_188796114_Pl86RbwnZz9vnJLcSz0FtBdaPU6DdJes.jpg", PlayPauseIcon = "play" },
            //    new PlayListModel() { Id = "B2", Name = "Playlist item 2", Editor = "DJ Bravo", Url = GlobalConstants.PlayUrl, Duration = 270, ArtWork = "https://t4.ftcdn.net/jpg/01/88/79/61/240_F_188796114_Pl86RbwnZz9vnJLcSz0FtBdaPU6DdJes.jpg", PlayPauseIcon = "play" },
            //    new PlayListModel() { Id = "C3", Name = "Playlist item 3", Editor = "DJ Bravo", Url = GlobalConstants.PlayUrl, Duration = 270, ArtWork = "https://t4.ftcdn.net/jpg/00/73/23/79/240_F_73237971_sA6qmDPEqrQCAAnUHFYUngtnVQr8Hmn0.jpg", PlayPauseIcon = "play" },
            //    new PlayListModel() { Id = "D4", Name = "Playlist item 4", Editor = "DJ Bravo", Url = GlobalConstants.PlayUrl, Duration = 270, ArtWork = "https://t4.ftcdn.net/jpg/00/73/23/79/240_F_73237971_sA6qmDPEqrQCAAnUHFYUngtnVQr8Hmn0.jpg", PlayPauseIcon = "play" }
            //};

            Device.BeginInvokeOnMainThread(() =>
            {
                Xamarin.Forms.DependencyService.Get<ICarPlayService>().InitCarPlay();
            });
        }
    }
}
