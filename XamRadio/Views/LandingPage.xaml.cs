using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamRadio.Interface;

namespace XamRadio.Views
{
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            DependencyService.Get<ICarPlayService>().InitCarPlay();
            InitializeComponent();
        }
    }
}
