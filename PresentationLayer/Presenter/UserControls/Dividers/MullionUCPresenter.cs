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

namespace PresentationLayer.Presenter.UserControls.Dividers
{
    public class MullionUCPresenter : IMullionUCPresenter, IPresenterCommon
    {
        IMullionUC _mullionUC;

        private IFrameModel _frameModel;
        private IDividerModel _divModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelMullionUCPresenter _multiMullionUCP;

        bool _mouseDown, _initialLoad;
        private Point _point_of_origin;

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
            _mullionUC.deleteToolStripMenuItemClickedEventRaised += _mullionUC_deleteToolStripMenuItemClickedEventRaised;
            _mullionUC.mullionUCMouseEnterEventRaised += _mullionUC_mullionUCMouseEnterEventRaised;
            _mullionUC.mullionUCMouseLeaveEventRaised += _mullionUC_mullionUCMouseLeaveEventRaised;
            _mullionUC.mullionUCSizeChangedEventRaised += _mullionUC_mullionUCSizeChangedEventRaised;
        }

        private void _mullionUC_mullionUCSizeChangedEventRaised(object sender, EventArgs e)
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

        private void _mullionUC_deleteToolStripMenuItemClickedEventRaised(object sender, EventArgs e)
        {
            Control parent_ctrl = ((UserControl)_mullionUC).Parent;

            _divModel.Div_Visible = false;
            _multiPanelModel.DeleteControl_MPanelLstObjects((UserControl)_mullionUC);
            _multiMullionUCP.DeletePanel((UserControl)_mullionUC);
            _multiMullionUCP.Invalidate_MultiPanelMullionUC();

            if (parent_ctrl.Name.Contains("flp_Multi"))
            {
                foreach (Control ctrl in parent_ctrl.Controls)
                {
                    ctrl.Invalidate();
                }
            }
        }

        List<Point[]> GetMullionDrawingPoints(int width,
                                              int height,
                                              string prev_obj,
                                              string nxt_obj)
        {
            List<Point[]> Mullion_Points = new List<Point[]>();

            int accessible_Wd = width - 2,
                accessible_Ht = height - 2,
                Ht_beforeCurve = height - 5;

            Point[] leftLine = new Point[2];
            Point[] botCurve = new Point[3];
            Point[] rightLine = new Point[2];
            Point[] upperCurve = new Point[3];

            int pointX_Mid = ((int)(_frameModel.Frame_Type) - 2) / 2;

            if (width == 26 || width == 33)
            {
                leftLine[0] = new Point(1, 5);
                leftLine[1] = new Point(1, Ht_beforeCurve);

                botCurve[0] = new Point(1, Ht_beforeCurve);
                botCurve[1] = new Point(accessible_Wd / 2, accessible_Ht);
                botCurve[2] = new Point(accessible_Wd, Ht_beforeCurve);

                rightLine[0] = new Point(accessible_Wd, Ht_beforeCurve);
                rightLine[1] = new Point(accessible_Wd, 5);

                upperCurve[0] = new Point(accessible_Wd, 5);
                upperCurve[1] = new Point(accessible_Wd / 2, 1);
                upperCurve[2] = new Point(1, 5);
            }
            else if (width == 18)
            {
                if ((prev_obj.Contains("MultiPanel") && nxt_obj.Contains("PanelUC")) ||
                    ((prev_obj.Contains("MultiPanel") && nxt_obj == "")))
                {
                    leftLine[0] = new Point((width - 26) + 1, 5);
                    leftLine[1] = new Point((width - 26) + 1, Ht_beforeCurve);

                    botCurve[0] = new Point((width - 26) + 1, Ht_beforeCurve);
                    botCurve[1] = new Point((width - 26) + pointX_Mid, accessible_Ht);
                    botCurve[2] = new Point(accessible_Wd, Ht_beforeCurve);

                    rightLine[0] = new Point(accessible_Wd, Ht_beforeCurve);
                    rightLine[1] = new Point(accessible_Wd, 5);

                    upperCurve[0] = new Point(accessible_Wd, 5);
                    upperCurve[1] = new Point((width - 26) + pointX_Mid, 1);
                    upperCurve[2] = new Point((width - 26) + 1, 5);
                }
                else if (prev_obj.Contains("PanelUC") && nxt_obj.Contains("MultiPanel"))
                {
                    leftLine[0] = new Point(1, 5);
                    leftLine[1] = new Point(1, Ht_beforeCurve);

                    botCurve[0] = new Point(1, Ht_beforeCurve);
                    botCurve[1] = new Point(pointX_Mid, accessible_Ht);
                    botCurve[2] = new Point(accessible_Wd + (26 - width), Ht_beforeCurve);

                    rightLine[0] = new Point(accessible_Wd + (26 - width), Ht_beforeCurve);
                    rightLine[1] = new Point(accessible_Wd + (26 - width), 5);

                    upperCurve[0] = new Point(accessible_Wd + (26 - width), 5);
                    upperCurve[1] = new Point(pointX_Mid + 1, 1);
                    upperCurve[2] = new Point(1, 5);
                }
            }
            else if (width == 10)
            {

                leftLine[0] = new Point((width - 18) + 1, 4);
                leftLine[1] = new Point((width - 18) + 1, Ht_beforeCurve);

                botCurve[0] = new Point((width - 18) + 1, Ht_beforeCurve);
                botCurve[1] = new Point((width - 18) + pointX_Mid, accessible_Ht);
                botCurve[2] = new Point(accessible_Wd + 8, Ht_beforeCurve);

                rightLine[0] = new Point(accessible_Wd + 8, Ht_beforeCurve);
                rightLine[1] = new Point(accessible_Wd + 8, 4);

                upperCurve[0] = new Point(accessible_Wd + 8, 4);
                upperCurve[1] = new Point((width - 18) + pointX_Mid, 1);
                upperCurve[2] = new Point((width - 18) + 1, 4);
            }

            Mullion_Points.Add(leftLine);
            Mullion_Points.Add(botCurve);
            Mullion_Points.Add(rightLine);
            Mullion_Points.Add(upperCurve);

            return Mullion_Points;
        }

        Color penColor = Color.Black;
        private void _mullionUC_mullionUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl mul = (UserControl)sender;
            Graphics g = e.Graphics;

            int lineHT = mul.ClientRectangle.Height - 6,
                lineWd = mul.ClientRectangle.Width - 2;

            g.SmoothingMode = SmoothingMode.HighQuality;

            GraphicsPath gpath = new GraphicsPath();

            int this_ndx = _multiPanelModel.MPanelLst_Objects.IndexOf(mul);
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

            List<Point[]> TPoints = GetMullionDrawingPoints(mul.Width,
                                                            mul.Height,
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

        private void _mullionUC_mullionUCMouseUpEventRaised(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void _mullionUC_mullionUCMouseMoveEventRaised(object sender, MouseEventArgs e)
        {
            try
            {
                UserControl me = (UserControl)sender;
                FlowLayoutPanel flp = (FlowLayoutPanel)me.Parent; //MultiPanel Container

                int me_indx = flp.Controls.IndexOf(me);
                //dapat dito yung condition na di dapat siya lumagpas sa bounds
                if (e.Button == MouseButtons.Left && _mouseDown) 
                {
                    if (me_indx != 0 && flp.Controls.Count > (me_indx + 1))
                    {
                        int expected_Panel1MinWD = flp.Controls[me_indx - 1].Width + (e.X - _point_of_origin.X),
                            expected_Panel2MinWD = flp.Controls[me_indx + 1].Width - (e.X - _point_of_origin.X);
                        if (expected_Panel1MinWD >= 30 && expected_Panel2MinWD >= 30)
                        {
                            flp.Controls[me_indx - 1].Width += (e.X - _point_of_origin.X);
                            flp.Controls[me_indx + 1].Width -= (e.X - _point_of_origin.X);
                        }
                    }
                    flp.Invalidate();
                    //flp.Parent.Parent.Invalidate(); //invalidate frameUC
                    //_mullionUC.Mullion_Left += (e.X - _point_of_origin.X);
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
                                                  IFrameModel frameModel)
        {
            unityC
                .RegisterType<IMullionUC, MullionUC>()
                .RegisterType<IMullionUCPresenter, MullionUCPresenter>();
            MullionUCPresenter mullionUCP = unityC.Resolve<MullionUCPresenter>();
            mullionUCP._divModel = divModel;
            mullionUCP._multiPanelModel = multiPanelModel;
            mullionUCP._multiMullionUCP = multiMullionUCP;
            mullionUCP._frameModel = frameModel;

            return mullionUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> divBinding = new Dictionary<string, Binding>();
            divBinding.Add("Div_ID", new Binding("Div_ID", _divModel, "Div_ID", true, DataSourceUpdateMode.OnPropertyChanged));
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
