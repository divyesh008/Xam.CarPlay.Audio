using System;
using System.ComponentModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace XamRadio.ViewModel
{
    public class BaseViewModel : BindableBase, INavigationAware, IDestructible, INotifyPropertyChanged
    {
        protected INavigationService NavigationService { get; private set; }

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
             
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
