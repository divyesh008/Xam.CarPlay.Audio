using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MediaManager;
using Xamarin.Forms;
using XamRadio.Interface;

namespace XamRadio
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPage()
        {
            DependencyService.Get<ICarPlayService>().InitCarPlay();
            InitializeComponent();
        }

        async void  TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await PlayPauseAsync();
        }

        private async Task PlayPauseAsync()
        {
            try
            {
               
                var item = await CrossMediaManager.Current.Extractor.CreateMediaItem(GlobalConstants.PlayUrl);
                item.MediaType = MediaManager.Library.MediaType.Audio;

                if (CrossMediaManager.Current.IsPlaying())
                {
                    Action.Source = "play";
                    await CrossMediaManager.Current.Pause();
                    GlobalConstants.IsPlaying = false;
                }
                else
                {
                    count++;
                    Action.Source = "pause";
                    GlobalConstants.IsPlaying = true;
                    if (count == 1) 
                        await CrossMediaManager.Current.Play(item);
                    else
                        await CrossMediaManager.Current.Play();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            count = 0;
        }
    }
}
