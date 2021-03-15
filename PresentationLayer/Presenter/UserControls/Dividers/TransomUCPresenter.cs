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

namespace PresentationLayer.Presenter.UserControls.Dividers
{
    public class TransomUCPresenter : ITransomUCPresenter, IPresenterCommon
    {
        ITransomUC _transomUC;

        private IFrameModel _frameModel;
        private IDividerModel _divModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelTransomUCPresenter _multiTransomUCP;

        bool _mouseDown, _initialLoad;
        private Point _point_of_origin;

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
            //_transomUC.deleteToolStripMenuItemClickedEventRaised += _transomUC_deleteToolStripMenuItemClickedEventRaised;
            _transomUC.transomUCMouseEnterEventRaised += _transomUC_transomUCMouseEnterEventRaised;
            _transomUC.transomUCMouseLeaveEventRaised += _transomUC_transomUCMouseLeaveEventRaised;
            _transomUC.transomUCSizeChangedEventRaised += _transomUC_transomUCSizeChangedEventRaised;
        }

        private void _transomUC_transomUCSizeChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (!_initialLoad)
                {
                    int thisWd = ((UserControl)sender).Width,
                    thisHt = ((UserControl)sender).Height,
                    divModelWd = _divModel.Div_Width,
                    divModelHt = _divModel.Div_Height;

                    if (thisWd != divModelWd)
                    {
                        _divModel.Div_Width = thisWd;
                    }
                    if (thisHt != divModelHt)
                    {
                        _divModel.Div_Height = thisHt;
                    }
                    ((UserControl)sender).Invalidate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        //private void _transomUC_deleteToolStripMenuItemClickedEventRaised(object sender, EventArgs e)
        //{
        //    Control parent_ctrl = ((UserControl)_transomUC).Parent;

        //    _divModel.Div_Visible = false;
        //    _multiPanelModel.DeleteControl_MPanelLstObjects((UserControl)_transomUC, _frameModel.Frame_Type.ToString());
        //    _multiTransomUCP.DeletePanel((UserControl)_transomUC);
        //    _multiTransomUCP.Invalidate_MultiPanelMullionUC();


        //    if (parent_ctrl.Name.Contains("flp_Multi"))
        //    {
        //        foreach (Control ctrl in parent_ctrl.Controls)
        //        {
        //            ctrl.Invalidate();
        //        }
        //    }
        //}

        List<Point[]> GetTransomDrawingPoints(int width, 
                                              int height,
                                              string prev_obj,
                                              string nxt_obj)
        {
            List<Point[]> Transom_Points = new List<Point[]>();

            int accessible_Wd = width - 2,
                accessible_Ht = height - 2,
                Wd_beforeCurve = width - 5;

            Point[] upperLine = new Point[2];
            Point[] botLine = new Point[2];
            Point[] leftCurve = new Point[3];
            Point[] rightCurve = new Point[3];

            int pointY_Mid = ((int)(_frameModel.Frame_Type) - 2) / 2;

            int pixels_count = 0;
            if (height == 18)
            {
                pixels_count = 26;
            }
            else if (height == 23)
            {
                pixels_count = 33;
            }
            else if (height == 10)
            {
                pixels_count = 18;
            }
            else if (height == 13)
            {
                pixels_count = 23;
            }

            if (height == 26 || height == 33)
            {
                upperLine[0] = new Point(5, 1);
                upperLine[1] = new Point(Wd_beforeCurve, 1);

                rightCurve[0] = new Point(Wd_beforeCurve, 1);
                rightCurve[1] = new Point(accessible_Wd, accessible_Ht / 2);
                rightCurve[2] = new Point(Wd_beforeCurve, accessible_Ht);

                botLine[0] = new Point(Wd_beforeCurve, accessible_Ht);
                botLine[1] = new Point(5, accessible_Ht);

                leftCurve[0] = new Point(5, accessible_Ht);
                leftCurve[1] = new Point(1, accessible_Ht / 2);
                leftCurve[2] = new Point(5, 1);
            }
            else if (height == 18 || height == 23)
            {
                if (((prev_obj.Contains("MultiTransom") || prev_obj.Contains("MultiMullion")) && nxt_obj.Contains("PanelUC")) ||
                    (((prev_obj.Contains("MultiTransom") || prev_obj.Contains("MultiMullion")) && nxt_obj == "")))
                {
                    upperLine[0] = new Point(5, (height - pixels_count) + 1);
                    upperLine[1] = new Point(Wd_beforeCurve, (height - pixels_count) + 1);

                    rightCurve[0] = new Point(Wd_beforeCurve, (height - pixels_count) + 1);
                    rightCurve[1] = new Point(accessible_Wd, (height - pixels_count) + pointY_Mid);
                    rightCurve[2] = new Point(Wd_beforeCurve, accessible_Ht);

                    botLine[0] = new Point(Wd_beforeCurve, accessible_Ht);
                    botLine[1] = new Point(5, accessible_Ht);

                    leftCurve[0] = new Point(5, accessible_Ht);
                    leftCurve[1] = new Point(1, (height - pixels_count) + pointY_Mid);
                    leftCurve[2] = new Point(5, (height - pixels_count) + 1);
                }
                else if (prev_obj.Contains("PanelUC") && (nxt_obj.Contains("MultiTransom") || nxt_obj.Contains("MultiMullion")))
                {
                    upperLine[0] = new Point(5, 1);
                    upperLine[1] = new Point(Wd_beforeCurve, 1);

                    rightCurve[0] = new Point(Wd_beforeCurve, 1);
                    rightCurve[1] = new Point(accessible_Wd, pointY_Mid);
                    rightCurve[2] = new Point(Wd_beforeCurve, accessible_Ht + (pixels_count - height));

                    botLine[0] = new Point(Wd_beforeCurve, accessible_Ht + (pixels_count - height));
                    botLine[1] = new Point(5, accessible_Ht + (pixels_count - height));

                    leftCurve[0] = new Point(5, accessible_Ht + (pixels_count - height));
                    leftCurve[1] = new Point(1, pointY_Mid + 1);
                    leftCurve[2] = new Point(5, 1);
                }
                else
                {
                    upperLine[0] = new Point(5, 1);
                    upperLine[1] = new Point(Wd_beforeCurve, 1);

                    rightCurve[0] = new Point(Wd_beforeCurve, 1);
                    rightCurve[1] = new Point(accessible_Wd, accessible_Ht / 2);
                    rightCurve[2] = new Point(Wd_beforeCurve, accessible_Ht);

                    botLine[0] = new Point(Wd_beforeCurve, accessible_Ht);
                    botLine[1] = new Point(5, accessible_Ht);

                    leftCurve[0] = new Point(5, accessible_Ht);
                    leftCurve[1] = new Point(1, accessible_Ht / 2);
                    leftCurve[2] = new Point(5, 1);
                }
            }
            else if (height == 10 || height == 13)
            {
                upperLine[0] = new Point(4, (height - pixels_count) + 1);
                upperLine[1] = new Point(Wd_beforeCurve, (height - pixels_count) + 1);

                rightCurve[0] = new Point(Wd_beforeCurve, (height - pixels_count) + 1);
                rightCurve[1] = new Point(accessible_Wd, (height - pixels_count) + pointY_Mid);
                rightCurve[2] = new Point(Wd_beforeCurve, accessible_Ht + 8);

                botLine[0] = new Point(Wd_beforeCurve, accessible_Ht + 8);
                botLine[1] = new Point(4, accessible_Ht + 8);

                leftCurve[0] = new Point(4, accessible_Ht + 8);
                leftCurve[1] = new Point(1, (height - pixels_count) + pointY_Mid);
                leftCurve[2] = new Point(4, (height - pixels_count) + 1);
            }

            Transom_Points.Add(upperLine);
            Transom_Points.Add(rightCurve); 
            Transom_Points.Add(botLine);
            Transom_Points.Add(leftCurve);

            return Transom_Points;
        }

        private void _transomUC_transomUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl transom = (UserControl)sender;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath gpath = new GraphicsPath();

            int this_ndx  = _multiPanelModel.MPanelLst_Objects.IndexOf(transom);
            int prev_obj_ndx = this_ndx - 1,
                next_obj_ndx = this_ndx + 1;
            string prev_obj_name = "",
                   next_obj_name = "";

            if (prev_obj_ndx >= 0)
            {
                prev_obj_name = _multiPanelModel.MPanelLst_Objects[prev_obj_ndx].Name;
            }
            if (next_obj_ndx <= _multiPanelModel.MPanelLst_Objects.Count - 1)
            {
                next_obj_name = _multiPanelModel.MPanelLst_Objects[next_obj_ndx].Name;
            }

            List<Point[]> TPoints = GetTransomDrawingPoints(transom.Width,
                                                            transom.Height,
                                                            prev_obj_name,
                                                            next_obj_name);

            gpath.AddLine(TPoints[0][0], TPoints[0][1]);
            gpath.AddCurve(TPoints[1]);
            gpath.AddLine(TPoints[2][0], TPoints[2][1]);
            gpath.AddCurve(TPoints[3]);

            Pen pen = new Pen(penColor, 2);

            g.DrawPath(pen, gpath);
            g.FillPath(Brushes.PowderBlue, gpath);
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
                FlowLayoutPanel flp = (FlowLayoutPanel)me.Parent; //MultiPanel Container

                int me_indx = flp.Controls.IndexOf(me);
                if (e.Button == MouseButtons.Left && _mouseDown)
                {
                    if (me_indx != 0 && flp.Controls.Count > (me_indx + 1))
                    {
                        int expected_Panel1MinHT = flp.Controls[me_indx - 1].Height + (e.Y - _point_of_origin.Y),
                            expected_Panel2MinHT = flp.Controls[me_indx + 1].Height - (e.Y - _point_of_origin.Y);

                        if (expected_Panel1MinHT >= 30 && expected_Panel2MinHT >= 30)
                        {
                            flp.Controls[me_indx - 1].Height += (e.Y - _point_of_origin.Y);
                            flp.Controls[me_indx + 1].Height -= (e.Y - _point_of_origin.Y);

                            flp.Controls[me_indx - 1].Invalidate();
                            flp.Controls[me_indx + 1].Invalidate();
                        }
                    }
                    flp.Invalidate();
                }
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
                                                  IFrameModel frameModel)
        {
            unityC
                .RegisterType<ITransomUC, TransomUC>()
                .RegisterType<ITransomUCPresenter, TransomUCPresenter>();
            TransomUCPresenter transomUCP = unityC.Resolve<TransomUCPresenter>();
            transomUCP._divModel = divModel;
            transomUCP._multiPanelModel = multiPanelModel;
            transomUCP._multiTransomUCP = multiTransomUCP;
            transomUCP._frameModel = frameModel;

            return transomUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> divBinding = new Dictionary<string, Binding>();
            divBinding.Add("Div_ID", new Binding("Div_ID", _divModel, "Div_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Name", new Binding("Name", _divModel, "Div_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Visible", new Binding("Visible", _divModel, "Div_Visible", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Width", new Binding("Width", _divModel, "Div_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Height", new Binding("Height", _divModel, "Div_Height", true, DataSourceUpdateMode.OnPropertyChanged));

            return divBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }
    }
}
