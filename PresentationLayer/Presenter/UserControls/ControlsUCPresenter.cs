﻿using System;
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
using Microsoft.VisualBasic;

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
            _controlUC.divcountToolStripMenuItemClickEventRaised += _controlUC_divcountToolStripMenuItemClickEventRaised;
        }

        private void _controlUC_divcountToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Input no. of division", "WinDoor Maker", "1");
            if (input != "" && input != "0")
            {
                try
                {
                    int int_input = Convert.ToInt32(input);
                    if (int_input > 0)
                    {
                        _controlUC.DivCount = int_input;
                    }
                    else if (int_input < 0)
                    {
                        MessageBox.Show("Invalid number");
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146233033)
                    {
                        MessageBox.Show("Please input a number.");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, ex.HResult.ToString());
                    }
                }
            }
        }

        private void OnControlsUCLoadEventRaised(object sender, EventArgs e)
        {
            _controlUC.DivCount = 1;
        }

        private void OnControlsUCMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {
                List<object> lst_obj = new List<object>();
                lst_obj.Add(_controlUC.CustomText);
                lst_obj.Add(_controlUC.DivCount);

                ctrl.DoDragDrop(lst_obj, DragDropEffects.Move);
            }
        }

        public IControlsUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                   string customtext, 
                                                   UserControl usercontrol)
        {
            unityC
                .RegisterType<IControlsUC, ControlsUC>()
                .RegisterType<IControlsUCPresenter, ControlsUCPresenter>();
            ControlsUCPresenter controlUCP = unityC.Resolve<ControlsUCPresenter>();
            controlUCP.customText = customtext;
            controlUCP.AddWinDoorPanel(usercontrol);
            controlUCP.WireAllControls((UserControl)controlUCP.GetControlUC());
            controlUCP._unityC = unityC;

            return controlUCP;
        }

        public IControlsUC GetControlUC()
        {
            _controlUC.CustomText = customText;
            return _controlUC;
        }

        private void AddWinDoorPanel(UserControl usercontrol)
        {
            _pnlWindoorPanel.Controls.Add(usercontrol);
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
