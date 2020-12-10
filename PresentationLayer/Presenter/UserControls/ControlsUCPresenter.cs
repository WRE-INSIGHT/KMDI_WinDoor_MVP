using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using Unity;
using System.Drawing;

namespace PresentationLayer.Presenter.UserControls
{
    public class ControlsUCPresenter : IControlsUCPresenter
    {
        IControlsUC _controlUC;

        private IFixedPanelUCPresenter _fixedUCP;

        private string customText;
        private Image customImage;

        public ControlsUCPresenter(IControlsUC controlUC,
                                   IFixedPanelUCPresenter fixedUCP)
        {
            _controlUC = controlUC;
            _fixedUCP = fixedUCP;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _controlUC.controlsUCMouseDownEventRaised += new MouseEventHandler(OnControlsUCMouseDownEventRaised);
        }

        private void OnControlsUCMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {
                ctrl.DoDragDrop(_fixedUCP.GetFixedPanelUC(), DragDropEffects.Move);
            }
        }
        public IControlsUCPresenter GetNewInstance(IUnityContainer unityC, string customtext, Image customimage)
        {
            unityC
                .RegisterType<IControlsUC, ControlsUC>()
                .RegisterType<IControlsUCPresenter, ControlsUCPresenter>();
            ControlsUCPresenter controlUCP = unityC.Resolve<ControlsUCPresenter>();
            controlUCP.customText = customtext;
            controlUCP.customImage = customimage;

            return controlUCP;
        }

        public IControlsUC GetControlUC()
        {
            _controlUC.CustomText = customText;
            _controlUC.CustomImage = customImage;
            return _controlUC;
        }
    }
}
