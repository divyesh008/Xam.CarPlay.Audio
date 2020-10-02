using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Unity;
using Xamarin.Forms;
using XamRadio.ViewModel;
using XamRadio.Views;

namespace XamRadio
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(LandingPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LandingPage, LandingPageViewModel>();
        }
    }
}
