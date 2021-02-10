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

namespace PresentationLayer.Presenter.UserControls.Dividers
{
    public class TransomUCPresenter : ITransomUCPresenter, IPresenterCommon
    {
        ITransomUC _transomUC;

        private IDividerModel _divModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelTransomUCPresenter _multiTransomUCP;

        bool _mouseDown;
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
            _transomUC.deleteToolStripMenuItemClickedEventRaised += _transomUC_deleteToolStripMenuItemClickedEventRaised;
            _transomUC.transomUCMouseEnterEventRaised += _transomUC_transomUCMouseEnterEventRaised;
            _transomUC.transomUCMouseLeaveEventRaised += _transomUC_transomUCMouseLeaveEventRaised;
            _transomUC.transomUCSizeChangedEventRaised += _transomUC_transomUCSizeChangedEventRaised;
        }

        private void _transomUC_transomUCSizeChangedEventRaised(object sender, EventArgs e)
        {
            try
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

        private void _transomUC_deleteToolStripMenuItemClickedEventRaised(object sender, EventArgs e)
        {
            _divModel.Div_Visible = false;
            _multiTransomUCP.DeletePanel((UserControl)_transomUC);
            _multiTransomUCP.Invalidate_MultiPanelMullionUC();
        }

        List<Point> GetTransomPoints()
        {
            List<Point> Transom_Points = new List<Point>();

            return Transom_Points;
        }

        private void _transomUC_transomUCPaintEventRaised(object sender, PaintEventArgs e)
        {

            UserControl transom = (UserControl)sender;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            GraphicsPath gpath = new GraphicsPath();

            int lineHT = transom.ClientRectangle.Height - 2,
                lineWd = transom.ClientRectangle.Width - 6;
            Point[] upperLine = new Point[2];
            Point[] botLine = new Point[2];
            Point[] leftCurve = new Point[3];
            Point[] rightCurve = new Point[3];
            

            if (_divModel.Div_FrameType == "Window")
            {
                if (_multiPanelModel.MPanel_Type == "Transom")
                {
                    if (_divModel.Div_Height == 10)
                    {
                        upperLine[0] = new Point(5, -9); //para lumagpas sa control
                        upperLine[1] = new Point(lineWd + 2, -9);

                        rightCurve[0] = new Point(lineWd + 2, -9);
                        rightCurve[1] = new Point(transom.ClientRectangle.Width - 2, lineHT / 2);
                        rightCurve[2] = new Point(lineWd + 2, lineHT + 5);

                        botLine[0] = new Point(lineWd + 2, lineHT + 8); //para lumagpas sa control
                        botLine[1] = new Point(5, lineHT + 8);

                        leftCurve[0] = new Point(5, lineHT + 8);
                        leftCurve[1] = new Point(1, lineHT / 2);
                        leftCurve[2] = new Point(5, -9);
                    }
                    else if (_divModel.Div_Height == 18)
                    {
                        upperLine[0] = new Point(5, -9);
                        upperLine[1] = new Point(lineWd + 2, -9);

                        rightCurve[0] = new Point(lineWd + 2, -9);
                        rightCurve[1] = new Point(transom.ClientRectangle.Width - 2, (lineHT / 2) + 9); //+9 Para makuha ang drawing Height
                        rightCurve[2] = new Point(lineWd + 2, lineHT);

                        botLine[0] = new Point(lineWd + 2, lineHT);
                        botLine[1] = new Point(5, lineHT);

                        leftCurve[0] = new Point(5, lineHT);
                        leftCurve[1] = new Point(1, lineHT / 2);
                        leftCurve[2] = new Point(5, -9);
                    }
                    else if (_divModel.Div_Height == 26)
                    {
                        upperLine[0] = new Point(5, 1);
                        upperLine[1] = new Point(lineWd, 1);

                        rightCurve[0] = new Point(lineWd, 1);
                        rightCurve[1] = new Point(transom.ClientRectangle.Width - 2, lineHT / 2);
                        rightCurve[2] = new Point(lineWd, lineHT);

                        botLine[0] = new Point(lineWd, lineHT);
                        botLine[1] = new Point(5, lineHT);

                        leftCurve[0] = new Point(5, lineHT);
                        leftCurve[1] = new Point(1, lineHT / 2);
                        leftCurve[2] = new Point(5, 1);
                    }
                }
            }
            else if (_divModel.Div_FrameType == "Door")
            {

            }
            
            gpath.AddLine(upperLine[0], upperLine[1]);
            gpath.AddCurve(rightCurve);
            gpath.AddLine(botLine[0], botLine[1]);
            gpath.AddCurve(leftCurve);

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

        public ITransomUC GetMullion(string test) //for Testing
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
            _transomUC.ThisBinding(CreateBindingDictionary());
            return _transomUC;
        }

        public ITransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                                  IDividerModel divModel,
                                                  IMultiPanelModel multiPanelModel,
                                                  IMultiPanelTransomUCPresenter multiTransomUCP)
        {
            unityC
                .RegisterType<ITransomUC, TransomUC>()
                .RegisterType<ITransomUCPresenter, TransomUCPresenter>();
            TransomUCPresenter transomUCP = unityC.Resolve<TransomUCPresenter>();
            transomUCP._divModel = divModel;
            transomUCP._multiPanelModel = multiPanelModel;
            transomUCP._multiTransomUCP = multiTransomUCP;

            return transomUCP;
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
    }
}
