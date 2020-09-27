using System;
using CarPlay;

namespace XamRadio.iOS.Helpers
{
    public class CPTemplateSceneDelegate : CPTemplateApplicationSceneDelegate
    {
        public delegate void CarPlayApplicationParameter(CPTemplateApplicationScene templateApplicationScene,
           CPInterfaceController interfaceController, CPWindow window);

        public CarPlayApplicationParameter Connected { get; set; }
        public CarPlayApplicationParameter Disconnected { get; set; }

        public override void DidConnect(CPTemplateApplicationScene templateApplicationScene,
            CPInterfaceController interfaceController, CPWindow window)
        {
            base.DidConnect(templateApplicationScene, interfaceController, window);
            Connected?.Invoke(templateApplicationScene, interfaceController, window);
        }

        public override void DidDisconnect(CPTemplateApplicationScene templateApplicationScene, CPInterfaceController interfaceController, CPWindow window)
        {
            base.DidDisconnect(templateApplicationScene, interfaceController, window);
        }
    }
}
