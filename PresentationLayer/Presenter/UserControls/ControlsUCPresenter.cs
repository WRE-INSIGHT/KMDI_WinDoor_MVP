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
using ModelLayer.Model.Quotation.Panel;

namespace PresentationLayer.Presenter.UserControls
{
    public class ControlsUCPresenter : IControlsUCPresenter
    {
        IControlsUC _controlUC;

        private IFixedPanelUCPresenter _fixedUCP;

        private IUnityContainer _unityC;

        private string customText;
        private Panel _pnlWindoorPanel;

        public ControlsUCPresenter(IControlsUC controlUC,
                                   IFixedPanelUCPresenter fixedUCP)
        {
            _controlUC = controlUC;
            _fixedUCP = fixedUCP;
            _pnlWindoorPanel = _controlUC.GetWinDoorPanel();
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _controlUC.controlsUCMouseDownEventRaised += new MouseEventHandler(OnControlsUCMouseDownEventRaised);
            _controlUC.controlsUCLoadEventRaised += new EventHandler(OnControlsUCLoadEventRaised);
        }

        private void OnControlsUCLoadEventRaised(object sender, EventArgs e)
        {
            
        }

        private void OnControlsUCMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {
                ctrl.DoDragDrop(_controlUC.CustomText, DragDropEffects.Move);
            }
        }
        public IControlsUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                   string customtext, 
                                                   UserControl WinDoorPanel)
        {
            unityC
                .RegisterType<IControlsUC, ControlsUC>()
                .RegisterType<IControlsUCPresenter, ControlsUCPresenter>();
            ControlsUCPresenter controlUCP = unityC.Resolve<ControlsUCPresenter>();
            controlUCP.customText = customtext;
            controlUCP.AddWinDoorPanel(WinDoorPanel);
            controlUCP.WireAllControls((UserControl)controlUCP.GetControlUC());
            controlUCP._unityC = unityC;

            return controlUCP;
        }

        public IControlsUC GetControlUC()
        {
            _controlUC.CustomText = customText;
            return _controlUC;
        }

        private void AddWinDoorPanel(UserControl WindoorPanel)
        {
            _pnlWindoorPanel.Controls.Add(WindoorPanel);
        }

        private void WireAllControls(Control cont)
        {
            foreach (Control ctl in cont.Controls)
            {
                ctl.MouseDown += OnControlsUCMouseDownEventRaised;
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
        }
    }
}
