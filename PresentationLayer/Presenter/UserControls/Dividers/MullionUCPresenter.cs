using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views.UserControls.Dividers;
using Unity;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using ModelLayer.Model.Quotation.Divider;
using CommonComponents;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.CommonMethods;
using PresentationLayer.Views.UserControls.WinDoorPanels;

namespace PresentationLayer.Presenter.UserControls.Dividers
{
    public class MullionUCPresenter : IMullionUCPresenter, IPresenterCommon
    {
        IMullionUC _mullionUC;

        private IFrameModel _frameModel;
        private IDividerModel _divModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelMullionUCPresenter _multiMullionUCP;
        private IMultiPanelTransomUCPresenter _multiTransomUCP;
        private IMainPresenter _mainPresenter;
        //private IBasePlatformImagerUCPresenter _basePlatformImagerUCP;

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

        public MullionUCPresenter(IMullionUC mullionUC)
        {
            _mullionUC = mullionUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _mullionUC.mullionUCMouseDownEventRaised += _mullionUC_mullionUCMouseDownEventRaised;
            _mullionUC.mullionUCMouseMoveEventRaised += _mullionUC_mullionUCMouseMoveEventRaised;
            _mullionUC.mullionUCMouseUpEventRaised += _mullionUC_mullionUCMouseUpEventRaised;
            _mullionUC.mullionUCPaintEventRaised += _mullionUC_mullionUCPaintEventRaised;
            _mullionUC.mullionUCMouseEnterEventRaised += _mullionUC_mullionUCMouseEnterEventRaised;
            _mullionUC.mullionUCMouseLeaveEventRaised += _mullionUC_mullionUCMouseLeaveEventRaised;
            _mullionUC.mullionUCSizeChangedEventRaised += _mullionUC_mullionUCSizeChangedEventRaised;
            _mullionUC.mullionUCKeyDownEventRaised += _mullionUC_mullionUCKeyDownEventRaised;
            _mullionUC.mullionUCMouseDoubleClickedEventRaised += _mullionUC_mullionUCMouseDoubleClickedEventRaised;
        }

        private void _mullionUC_mullionUCKeyDownEventRaised(object sender, KeyEventArgs e)
        {
            UserControl me = (UserControl)sender;
            FlowLayoutPanel flp = (FlowLayoutPanel)me.Parent; //MultiPanel Container

            int me_indx = flp.Controls.IndexOf(me);

            if (_keydown)
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        _mainPresenter.DeselectDivider();
                        _keydown = false;
                        break;

                    case Keys.Up:
                        flp.Controls[me_indx - 1].Width++;
                        flp.Controls[me_indx + 1].Width--;

                        flp.Controls[me_indx - 1].Invalidate();
                        flp.Controls[me_indx + 1].Invalidate();
                        break;

                    case Keys.Down:
                        flp.Controls[me_indx - 1].Width--;
                        flp.Controls[me_indx + 1].Width++;

                        flp.Controls[me_indx - 1].Invalidate();
                        flp.Controls[me_indx + 1].Invalidate();
                        break;
                }
            }
        }

        private void _mullionUC_mullionUCMouseDoubleClickedEventRaised(object sender, MouseEventArgs e)
        {
            int thisIndx = _multiPanelModel.MPanelLst_Objects.IndexOf((UserControl)_mullionUC);
            if (thisIndx > 0 && thisIndx < _multiPanelModel.MPanelLst_Objects.Count() - 1)
            {
                _mainPresenter.SetSelectedDivider(_divModel, null, this);
            }
        }

        private void _mullionUC_mullionUCSizeChangedEventRaised(object sender, EventArgs e)
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

        private void _mullionUC_mullionUCMouseLeaveEventRaised(object sender, EventArgs e)
        {
            penColor = Color.Black;
            _mullionUC.InvalidateThis();
        }

        private void _mullionUC_mullionUCMouseEnterEventRaised(object sender, EventArgs e)
        {
            penColor = Color.Blue;
            _mullionUC.InvalidateThis();
        }

        Color penColor = Color.Black;

        private void _mullionUC_mullionUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl mul = (UserControl)sender;
            Graphics g = e.Graphics;

            //int lineHT = mul.ClientRectangle.Height - 6,
            //    lineWd = mul.ClientRectangle.Width - 2;

            g.SmoothingMode = SmoothingMode.HighQuality;

            //GraphicsPath gpath = new GraphicsPath();

            //int this_ndx = _multiPanelModel.MPanelLst_Objects.IndexOf(mul);
            //int prev_obj_ndx = this_ndx - 1,
            //    next_obj_ndx = this_ndx + 1;
            //string prev_obj_name = "",
            //       next_obj_name = "";

            //UserControl prev_obj = null, 
            //            nxt_obj = null;

            //if (prev_obj_ndx >= 0)
            //{
            //    prev_obj_name = _multiPanelModel.MPanelLst_Objects[prev_obj_ndx].Name;
            //    prev_obj = (UserControl)_multiPanelModel.MPanelLst_Objects[prev_obj_ndx];
            //}
            //if (next_obj_ndx <= _multiPanelModel.MPanelLst_Objects.Count - 1)
            //{
            //    next_obj_name = _multiPanelModel.MPanelLst_Objects[next_obj_ndx].Name;
            //    nxt_obj = (UserControl)_multiPanelModel.MPanelLst_Objects[next_obj_ndx];
            //}

            //List<Point[]> TPoints = _commonfunc.GetMullionDrawingPoints(mul.Width,
            //                                                            mul.Height,
            //                                                            prev_obj_name,
            //                                                            next_obj_name,
            //                                                            _frameModel,
            //                                                            _divModel.Div_Zoom);

            //List<Point[]> TPoints = _commonfunc.GetMullionDrawingPoints2(mul.Width,
            //                                                             mul.Height,
            //                                                             prev_obj,
            //                                                             nxt_obj,
            //                                                             _frameModel.Frame_Type,
            //                                                             _divModel.Div_Zoom);

            //gpath.AddLine(TPoints[0][0], TPoints[0][1]);
            //gpath.AddCurve(TPoints[1]);
            //gpath.AddLine(TPoints[2][0], TPoints[2][1]);
            //gpath.AddCurve(TPoints[3]);

            //Pen pen = new Pen(penColor, 2);

            //g.DrawPath(pen, gpath);
            //g.FillPath(Brushes.PowderBlue, gpath);

            Font drawFont = new Font("Segoe UI", 6.5f, FontStyle.Bold); //* zoom);
            Size s2 = TextRenderer.MeasureText(_divModel.Div_Name, drawFont);

            //int point_Y = (mul.Height / 2) - (s2.Height / 2); //0;

            SizeF sz = e.Graphics.VisibleClipBounds.Size;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;

            //90 degrees
            g.TranslateTransform(sz.Width, 0);
            g.RotateTransform(90);
            g.DrawString(_divModel.Div_Name, drawFont, Brushes.Black, new RectangleF(10, 0, s2.Width, s2.Height), format);
            g.ResetTransform();

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            if (_divModel.Div_Width == (int)_frameModel.Frame_Type)
            {
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                       0,
                                                                       mul.ClientRectangle.Width - w,
                                                                       mul.ClientRectangle.Height - w));
            }
            else if (_divModel.Div_Width == (int)_frameModel.Frame_Type - _multiPanelModel.MPanel_AddPixel)
            {
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(-1,
                                                                       0,
                                                                       (mul.ClientRectangle.Width - w) + 1,
                                                                       mul.ClientRectangle.Height - w));
            }
            else if (_divModel.Div_Width == (int)_frameModel.Frame_Type - (_multiPanelModel.MPanel_AddPixel * 2))
            {
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(-1,
                                                                       0,
                                                                       (mul.ClientRectangle.Width - w) + 2,
                                                                       mul.ClientRectangle.Height - w));
            }
        }

        private void _mullionUC_mullionUCMouseUpEventRaised(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void _mullionUC_mullionUCMouseMoveEventRaised(object sender, MouseEventArgs e)
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

                int expected_Panel1MinWD = 0,
                    expected_Panel2MinWD = 0;

                IMultiPanelModel prev_mpanel = null,
                                 nxt_mpnl = null;

                if (prev_ctrl is IMultiPanelUC)
                {
                    prev_mpanel = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == prev_ctrl.Name);
                    expected_Panel1MinWD = prev_mpanel.MPanel_Width + (e.X - _point_of_origin.X);
                }

                if (nxt_ctrl is IMultiPanelUC)
                {
                    nxt_mpnl = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == nxt_ctrl.Name);
                    expected_Panel2MinWD = nxt_mpnl.MPanel_Width - (e.X - _point_of_origin.X);
                }

                FlowLayoutPanel flp = (FlowLayoutPanel)me.Parent; //MultiPanel Container

                if (e.Button == MouseButtons.Left && _mouseDown) 
                {
                    if (me_indx != 0 && flp.Controls.Count > (me_indx + 1))
                    {
                        if (prev_ctrl is IMultiPanelUC)
                        {
                            prev_mpanel.MPanel_Width += (e.X - _point_of_origin.X);
                        }

                        if (nxt_ctrl is IMultiPanelUC)
                        {
                            nxt_mpnl.MPanel_Width -= (e.X - _point_of_origin.X);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, ex.HResult.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _mullionUC_mullionUCMouseDownEventRaised(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseDown = true;
                _point_of_origin = e.Location;
            }
        }

        public IMullionUC GetMullion()
        {
            _initialLoad = true;
            _mullionUC.ThisBinding(CreateBindingDictionary());
            return _mullionUC;
        }

        public IMullionUC GetMullion(string test) //for Testing
        {
            return _mullionUC;
        }

        public IMullionUCPresenter GetNewInstance(IUnityContainer unityC) //for Testing
        {
            unityC
                .RegisterType<IMullionUC, MullionUC>()
                .RegisterType<IMullionUCPresenter, MullionUCPresenter>();
            MullionUCPresenter mullionUCP = unityC.Resolve<MullionUCPresenter>();

            return mullionUCP;
        }

        public IMullionUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                  IDividerModel divModel,
                                                  IMultiPanelModel multiPanelModel,
                                                  IMultiPanelMullionUCPresenter multiMullionUCP,
                                                  IFrameModel frameModel,
                                                  IMainPresenter mainPresenter)//,
                                                  //IBasePlatformImagerUCPresenter basePlatformImagerUCP)
        {
            unityC
                .RegisterType<IMullionUC, MullionUC>()
                .RegisterType<IMullionUCPresenter, MullionUCPresenter>();
            MullionUCPresenter mullionUCP = unityC.Resolve<MullionUCPresenter>();
            mullionUCP._divModel = divModel;
            mullionUCP._multiPanelModel = multiPanelModel;
            mullionUCP._multiMullionUCP = multiMullionUCP;
            mullionUCP._frameModel = frameModel;
            mullionUCP._mainPresenter = mainPresenter;
            //mullionUCP._basePlatformImagerUCP = basePlatformImagerUCP;

            return mullionUCP;
        }

        public IMullionUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                  IDividerModel divModel, 
                                                  IMultiPanelModel multiPanelModel, 
                                                  IMultiPanelTransomUCPresenter multiTransomUCP, 
                                                  IFrameModel frameModel,
                                                  IMainPresenter mainPresenter)//,
                                                  //IBasePlatformImagerUCPresenter basePlatformImagerUCP)
        {
            unityC
               .RegisterType<IMullionUC, MullionUC>()
               .RegisterType<IMullionUCPresenter, MullionUCPresenter>();
            MullionUCPresenter mullionUCP = unityC.Resolve<MullionUCPresenter>();
            mullionUCP._divModel = divModel;
            mullionUCP._multiPanelModel = multiPanelModel;
            mullionUCP._multiTransomUCP = multiTransomUCP;
            mullionUCP._frameModel = frameModel;
            mullionUCP._mainPresenter = mainPresenter;
            //mullionUCP._basePlatformImagerUCP = basePlatformImagerUCP;

            return mullionUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> divBinding = new Dictionary<string, Binding>();
            divBinding.Add("Div_ID", new Binding("Div_ID", _divModel, "Div_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Name", new Binding("Name", _divModel, "Div_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Visible", new Binding("Visible", _divModel, "Div_Visible", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Width", new Binding("Width", _divModel, "Div_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Height", new Binding("Height", _divModel, "Div_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));

            return divBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }

        public void FocusOnThisMullionDiv()
        {
            _mullionUC.FocusOnThis();
        }
    }
}
