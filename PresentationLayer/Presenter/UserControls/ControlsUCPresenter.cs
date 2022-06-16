using Microsoft.VisualBasic;
using ModelLayer.Model.Quotation;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class ControlsUCPresenter : IControlsUCPresenter
    {
        IControlsUC _controlUC;

        private IFixedPanelUCPresenter _fixedUCP;

        private IUnityContainer _unityC;
        private IQuotationModel _quotationModel;
        // private IWindoorModel _windorModel;
        public List<string> Lst_PanelType { get; set; }
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
            _controlUC.iterationToolStripMenuItemClickEventRaised += _controlUC_iterationToolStripMenuItemClickEventRaised;
        }

        private void _controlUC_iterationToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Input no. of times the panel will be added", "WinDoor Maker", "1");
            if (input != "" && input != "0")
            {
                try
                {
                    int int_input = Convert.ToInt32(input);
                    if (int_input > 0)
                    {
                        _controlUC.Iteration = int_input;
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
            _controlUC.Iteration = 1;
        }

        private void OnControlsUCMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {
                List<object> lst_obj = new List<object>();
                lst_obj.Add(_controlUC.CustomText);
                lst_obj.Add(_controlUC.DivCount);
                lst_obj.Add(_controlUC.Iteration);

                ctrl.DoDragDrop(lst_obj, DragDropEffects.Move);
               // this.Lst_PanelType.Add(_controlUC.CustomText);
            }

            //for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
            //{
            //    IWindoorModel wdm = _quotationModel.Lst_Windoor[i];
            //    string desc = wdm.WD_description;

            //    desc = desc + " " + _controlUC.CustomText;
            //}


            //   _windorModel.lst_frame[i].Frame_Name.Contains("Fixed");
        }

        public IControlsUCPresenter GetNewInstance(IUnityContainer unityC,
                                                   IQuotationModel quotationModel,
                                                   //IWindoorModel windorModel,
                                                   string customtext,
                                                   UserControl usercontrol
                                                   )
        {
            unityC
                .RegisterType<IControlsUC, ControlsUC>()
                .RegisterType<IControlsUCPresenter, ControlsUCPresenter>();
            ControlsUCPresenter controlUCP = unityC.Resolve<ControlsUCPresenter>();
            controlUCP.customText = customtext;
            controlUCP.AddWinDoorPanel(usercontrol);
            controlUCP.WireAllControls((UserControl)controlUCP.GetControlUC());
            controlUCP._quotationModel = quotationModel;
            controlUCP._unityC = unityC;
            //controlUCP._windorModel = windorModel;

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
