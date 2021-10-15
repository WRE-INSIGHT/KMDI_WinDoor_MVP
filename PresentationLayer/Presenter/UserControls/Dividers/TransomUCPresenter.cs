using CommonComponents;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.Dividers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.CommonMethods;
using ModelLayer.Model.Quotation.Panel;

namespace PresentationLayer.Presenter.UserControls.Dividers
{
    public class TransomUCPresenter : ITransomUCPresenter, IPresenterCommon
    {
        ITransomUC _transomUC;

        private IFrameModel _frameModel;
        private IDividerModel _divModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelTransomUCPresenter _multiTransomUCP;
        private IMultiPanelMullionUCPresenter _multiMullionUCP;
        private IMainPresenter _mainPresenter;

        bool _mouseDown, _initialLoad, _keydown;
        private Point _point_of_origin;

        CommonFunctions _commonfunc = new CommonFunctions();

        public bool boolKeyDown
        {
            set
            {
                _keydown = value;
            }
        }

        public TransomUCPresenter(ITransomUC transomUC)
        {
            _transomUC = transomUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _transomUC.transomUCMouseDownEventRaised += _transomUC_transomUCMouseDownEventRaised;
            _transomUC.transomUCMouseMoveEventRaised += _transomUC_transomUCMouseMoveEventRaised;
            _transomUC.transomUCMouseUpEventRaised += _transomUC_transomUCMouseUpEventRaised;
            _transomUC.transomUCPaintEventRaised += _transomUC_transomUCPaintEventRaised;
            _transomUC.transomUCMouseEnterEventRaised += _transomUC_transomUCMouseEnterEventRaised;
            _transomUC.transomUCMouseLeaveEventRaised += _transomUC_transomUCMouseLeaveEventRaised;
            _transomUC.transomUCSizeChangedEventRaised += _transomUC_transomUCSizeChangedEventRaised;
            _transomUC.transomUCMouseDoubleClickedEventRaised += _transomUC_transomUCMouseDoubleClickedEventRaised;
            _transomUC.transomUCKeyDownEventRaised += _transomUC_transomUCKeyDownEventRaised;
        }

        private void _transomUC_transomUCKeyDownEventRaised(object sender, KeyEventArgs e)
        {
            UserControl me = (UserControl)sender;
            int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)sender);
            FlowLayoutPanel flp = (FlowLayoutPanel)me.Parent; //MultiPanel Container

            Control prev_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx - 1];
            Control nxt_ctrl = null;

            if (_multiPanelModel.MPanelLst_Objects.Count() > me_indx + 1)
            {
                nxt_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx + 1];
            }

            int expected_Panel1MinHT = 0,
                expected_Panel2MinHT = 0;

            IMultiPanelModel prev_mpanel = null,
                             nxt_mpnl = null;

            IPanelModel prev_pnl = null,
                        nxt_pnl = null;

            if (prev_ctrl is IMultiPanelUC)
            {
                prev_mpanel = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == prev_ctrl.Name);
            }
            else if (prev_ctrl is IPanelUC)
            {
                prev_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == prev_ctrl.Name);
            }

            if (nxt_ctrl is IMultiPanelUC)
            {
                nxt_mpnl = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == nxt_ctrl.Name);
            }
            else if (nxt_ctrl is IPanelUC)
            {
                nxt_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == nxt_ctrl.Name);
            }

            if (_keydown)
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        _mainPresenter.DeselectDivider();
                        _keydown = false;
                        break;

                    case Keys.Up:
                        if (me_indx != 0 && flp.Controls.Count > (me_indx + 1))
                        {
                            if (nxt_ctrl is IMultiPanelUC)
                            {
                                expected_Panel2MinHT = nxt_mpnl.MPanel_Height - 1;
                            }
                            else if (nxt_ctrl is IPanelUC)
                            {
                                expected_Panel2MinHT = nxt_pnl.Panel_Height - 1;
                            }

                            if (expected_Panel2MinHT >= 30)
                            {
                                if (prev_ctrl is IMultiPanelUC)
                                {
                                    prev_mpanel.MPanel_Height++;
                                    prev_mpanel.MPanel_DisplayHeight++;
                                }
                                else if (prev_ctrl is IPanelUC)
                                {
                                    prev_pnl.Panel_Height++;
                                    prev_pnl.Panel_DisplayHeight++;
                                }

                                if (nxt_ctrl is IMultiPanelUC)
                                {
                                    nxt_mpnl.MPanel_Height--;
                                    nxt_mpnl.MPanel_DisplayHeight--;
                                }
                                else if (nxt_ctrl is IPanelUC)
                                {
                                    nxt_pnl.Panel_Height--;
                                    nxt_pnl.Panel_DisplayHeight--;
                                }
                            }
                        }
                        
                        break;

                    case Keys.Down:
                        if (me_indx != 0 && flp.Controls.Count > (me_indx + 1))
                        {
                            if (prev_ctrl is IMultiPanelUC)
                            {
                                expected_Panel1MinHT = prev_mpanel.MPanel_Height - 1;
                            }
                            else if (prev_ctrl is IPanelUC)
                            {
                                expected_Panel1MinHT = prev_pnl.Panel_Height - 1;
                            }

                            if (expected_Panel1MinHT >= 30)
                            {
                                if (prev_ctrl is IMultiPanelUC)
                                {
                                    prev_mpanel.MPanel_Height--;
                                    prev_mpanel.MPanel_DisplayHeight--;
                                }
                                else if (prev_ctrl is IPanelUC)
                                {
                                    prev_pnl.Panel_Height--;
                                    prev_pnl.Panel_DisplayHeight--;
                                }

                                if (nxt_ctrl is IMultiPanelUC)
                                {
                                    nxt_mpnl.MPanel_Height++;
                                    nxt_mpnl.MPanel_DisplayHeight++;
                                }
                                else if (nxt_ctrl is IPanelUC)
                                {
                                    nxt_pnl.Panel_Height++;
                                    nxt_pnl.Panel_DisplayHeight++;
                                }
                            }
                        }
                        break;
                }
                _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
            }
        }

        private void _transomUC_transomUCMouseDoubleClickedEventRaised(object sender, MouseEventArgs e)
        {
            int thisIndx = _multiPanelModel.MPanelLst_Objects.IndexOf((UserControl)_transomUC);
            if (thisIndx > 0 && thisIndx < _multiPanelModel.MPanelLst_Objects.Count() - 1)
            {
                _mainPresenter.SetSelectedDivider(_divModel, this);
            }
        }

        private void _transomUC_transomUCSizeChangedEventRaised(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!_initialLoad)
            //    {
            //        int thisWd = ((UserControl)sender).Width,
            //        thisHt = ((UserControl)sender).Height,
            //        divModelWd = _divModel.Div_Width,
            //        divModelHt = _divModel.Div_Height;

            //        if (thisWd != divModelWd)
            //        {
            //            _divModel.Div_Width = thisWd;
            //        }
            //        if (thisHt != divModelHt)
            //        {
            //            _divModel.Div_Height = thisHt;
            //        }
            //        ((UserControl)sender).Invalidate();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        Color penColor = Color.Black;

        private void _transomUC_transomUCMouseLeaveEventRaised(object sender, EventArgs e)
        {
            penColor = Color.Black;
            _transomUC.InvalidateThis();
        }

        private void _transomUC_transomUCMouseEnterEventRaised(object sender, EventArgs e)
        {
            penColor = Color.Blue;
            _transomUC.InvalidateThis();
        }
        
        private void _transomUC_transomUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl transom = (UserControl)sender;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Font drawFont = new Font("Segoe UI", 6.5f, FontStyle.Bold); //* zoom);
            Size s2 = TextRenderer.MeasureText(_divModel.Div_Name, drawFont);

            //int point_Y = (transom.Height / 2) - (s2.Height / 2); //0;

            TextRenderer.DrawText(g,
                                  _divModel.Div_Name,
                                  drawFont,
                                  new Rectangle(new Point(10, 0),
                                                new Size(s2.Width,
                                                         s2.Height)),
                                  Color.Black,
                                  Color.Transparent,
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            int ctrl_ndx = _multiPanelModel.MPanelLst_Objects.IndexOf(transom);
            bool prevCtrl_isPanel = false;

            if (!_multiPanelModel.MPanelLst_Objects[ctrl_ndx - 1].Name.Contains("Multi"))
            {
                prevCtrl_isPanel = true;
            }
            else
            {
                prevCtrl_isPanel = false;
            }


            if (_divModel.Div_Height == (int)_frameModel.Frame_Type || _divModel.Div_Height == 13)
            {
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                       0,
                                                                       transom.ClientRectangle.Width - w,
                                                                       transom.ClientRectangle.Height - w));
            }
            else if (_divModel.Div_Height == (int)_frameModel.Frame_Type - _multiPanelModel.MPanel_AddPixel)
            {
                if (prevCtrl_isPanel == true)
                {
                    g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                           0,
                                                                           transom.ClientRectangle.Width - w,
                                                                           (transom.ClientRectangle.Height - w) + 2));
                }
                else if (prevCtrl_isPanel == false)
                {
                    g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                          -1,
                                                                          transom.ClientRectangle.Width - w,
                                                                          (transom.ClientRectangle.Height - w) + 1));
                }
                    
            }
            else if (_divModel.Div_Height == (int)_frameModel.Frame_Type - (_multiPanelModel.MPanel_AddPixel * 2))
            {
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                       -1,
                                                                       transom.ClientRectangle.Width - w,
                                                                       (transom.ClientRectangle.Height - w) + 2));
            }
        }

        private void _transomUC_transomUCMouseUpEventRaised(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void _transomUC_transomUCMouseMoveEventRaised(object sender, MouseEventArgs e)
        {
            try
            {
                UserControl me = (UserControl)sender;
                int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)sender);

                Control prev_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx - 1];
                Control nxt_ctrl = null;

                if (_multiPanelModel.MPanelLst_Objects.Count() > me_indx + 1)
                {
                    nxt_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx + 1];
                }

                int expected_Panel1MinHT = 0,
                    expected_Panel2MinHT = 0;

                IMultiPanelModel prev_mpanel = null, 
                                 nxt_mpnl = null;

                IPanelModel prev_pnl = null,
                            nxt_pnl = null;

                if (prev_ctrl is IMultiPanelUC)
                {
                    prev_mpanel = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == prev_ctrl.Name);
                    expected_Panel1MinHT = prev_mpanel.MPanel_Height + (e.Y - _point_of_origin.Y);
                }
                else if (prev_ctrl is IPanelUC)
                {
                    prev_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == prev_ctrl.Name);
                    expected_Panel1MinHT = prev_pnl.Panel_Height + (e.Y - _point_of_origin.Y);
                }

                if (nxt_ctrl is IMultiPanelUC)
                {
                    nxt_mpnl = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == nxt_ctrl.Name);
                    expected_Panel2MinHT = nxt_mpnl.MPanel_Height - (e.Y - _point_of_origin.Y);
                }
                else if (nxt_ctrl is IPanelUC)
                {
                    nxt_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == nxt_ctrl.Name);
                    expected_Panel2MinHT = nxt_pnl.Panel_Height - (e.Y - _point_of_origin.Y);
                }

                FlowLayoutPanel flp = (FlowLayoutPanel)me.Parent; //MultiPanel Container

                if (e.Button == MouseButtons.Left && _mouseDown)
                {
                    if (me_indx != 0 && flp.Controls.Count > (me_indx + 1))
                    {
                        if (expected_Panel1MinHT >= 30 && expected_Panel2MinHT >= 30)
                        {
                            if (prev_ctrl is IMultiPanelUC)
                            {
                                prev_mpanel.MPanel_Height += (e.Y - _point_of_origin.Y);
                                prev_mpanel.MPanel_DisplayHeight += (e.Y - _point_of_origin.Y);
                            }
                            else if (prev_ctrl is IPanelUC)
                            {
                                prev_pnl.Panel_Height += (e.Y - _point_of_origin.Y);
                                prev_pnl.Panel_DisplayHeight += (e.Y - _point_of_origin.Y);
                            }

                            if (nxt_ctrl is IMultiPanelUC)
                            {
                                nxt_mpnl.MPanel_Height -= (e.Y - _point_of_origin.Y);
                                nxt_mpnl.MPanel_DisplayHeight -= (e.Y - _point_of_origin.Y);
                            }
                            else if (nxt_ctrl is IPanelUC)
                            {
                                nxt_pnl.Panel_Height -= (e.Y - _point_of_origin.Y);
                                nxt_pnl.Panel_DisplayHeight -= (e.Y - _point_of_origin.Y);
                            }
                        }
                    }
                }
                _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, ex.HResult.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _transomUC_transomUCMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseDown = true;
                _point_of_origin = e.Location;
            }
        }

        public ITransomUC GetTransom(string test) //for Testing
        {
            return _transomUC;
        }

        public ITransomUCPresenter GetNewInstance(IUnityContainer unityC) //for Testing
        {
            unityC
                .RegisterType<ITransomUC, TransomUC>()
                .RegisterType<ITransomUCPresenter, TransomUCPresenter>();
            TransomUCPresenter transomUCP = unityC.Resolve<TransomUCPresenter>();

            return transomUCP;
        }

        public ITransomUC GetTransom()
        {
            _initialLoad = true;
            _transomUC.ThisBinding(CreateBindingDictionary());
            return _transomUC;
        }

        public ITransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                                  IDividerModel divModel,
                                                  IMultiPanelModel multiPanelModel,
                                                  IMultiPanelTransomUCPresenter multiTransomUCP,
                                                  IFrameModel frameModel,
                                                  IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<ITransomUC, TransomUC>()
                .RegisterType<ITransomUCPresenter, TransomUCPresenter>();
            TransomUCPresenter transomUCP = unityC.Resolve<TransomUCPresenter>();
            transomUCP._divModel = divModel;
            transomUCP._multiPanelModel = multiPanelModel;
            transomUCP._multiTransomUCP = multiTransomUCP;
            transomUCP._frameModel = frameModel;
            transomUCP._mainPresenter = mainPresenter;

            return transomUCP;
        }

        public ITransomUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                  IDividerModel divModel, 
                                                  IMultiPanelModel multiPanelModel, 
                                                  IMultiPanelMullionUCPresenter multiMullionUCP, 
                                                  IFrameModel frameModel,
                                                  IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<ITransomUC, TransomUC>()
                .RegisterType<ITransomUCPresenter, TransomUCPresenter>();
            TransomUCPresenter transomUCP = unityC.Resolve<TransomUCPresenter>();
            transomUCP._divModel = divModel;
            transomUCP._multiPanelModel = multiPanelModel;
            transomUCP._multiMullionUCP = multiMullionUCP;
            transomUCP._frameModel = frameModel;
            transomUCP._mainPresenter = mainPresenter;

            return transomUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> divBinding = new Dictionary<string, Binding>();
            divBinding.Add("Div_ID", new Binding("Div_ID", _divModel, "Div_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Name", new Binding("Name", _divModel, "Div_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Visible", new Binding("Visible", _divModel, "Div_Visible", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_WidthToBind", new Binding("Width", _divModel, "Div_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_HeightToBind", new Binding("Height", _divModel, "Div_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));

            return divBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }

        public void FocusOnThisTransomDiv()
        {
            _transomUC.FocusOnThis();
        }
    }
}
