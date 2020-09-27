using System;
using System.Diagnostics;
using CarPlay;
using MediaPlayer;
using Xamarin.Forms;
using XamRadio.Interface;
using XamRadio.iOS.Helpers;
using XamRadio.iOS.Services;

[assembly: Dependency(typeof(CarPlayService))]
namespace XamRadio.iOS.Services
{
    public class CarPlayService : ICarPlayService
    {
        public MPPlayableContentManager _playableContentManager;
        public CPTemplateApplicationScene CPTemplateApplicationScene;

        public void InitCarPlay()
        {
            try
            {
                CPTemplateApplicationScene = new CPTemplateApplicationScene();
                CPTemplateSceneDelegate templateSceneDelegate = new CPTemplateSceneDelegate();
                templateSceneDelegate.Connected = Connected;
                CPTemplateApplicationScene.Delegate = templateSceneDelegate;

                _playableContentManager = MPPlayableContentManager.Shared;

                PlayableContentDelegate playableContentDelegate = new PlayableContentDelegate();
                _playableContentManager.Delegate = playableContentDelegate;

                PlayableContentDataSource playableContentDataSource = new PlayableContentDataSource();
                _playableContentManager.DataSource = playableContentDataSource;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void Connected(CPTemplateApplicationScene templateApplicationScene, CPInterfaceController interfaceController, CPWindow window)
        {
            //throw new NotImplementedException();
        }
    }
}
