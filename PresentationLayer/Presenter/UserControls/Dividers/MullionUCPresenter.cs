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

namespace PresentationLayer.Presenter.UserControls.Dividers
{
    public class MullionUCPresenter : IMullionUCPresenter, IPresenterCommon
    {
        IMullionUC _mullionUC;

        private IDividerModel _divModel;

        bool _mouseDown;
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
        }

        private void _mullionUC_mullionUCPaintEventRaised(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            UserControl mul = (UserControl)sender;
            Graphics g = e.Graphics;

            int lineHT = mul.ClientRectangle.Height - 6,
                lineWd = mul.ClientRectangle.Width - 2;

            g.SmoothingMode = SmoothingMode.HighQuality;

            GraphicsPath gpath = new GraphicsPath();

            Point[] topCurve = {
                                    new Point(lineWd, 5),
                                    new Point(mul.ClientRectangle.Width / 2, 1),
                                    new Point(0, 5)
                               };

            Point[] botCurve = {
                                    new Point(0, lineHT),
                                    new Point(mul.ClientRectangle.Width / 2, mul.ClientRectangle.Height - 3),
                                    new Point(lineWd, lineHT)
                               };

            
            gpath.AddLine(new Point(0, 5), new Point(0, lineHT));
            gpath.AddCurve(botCurve);
            gpath.AddLine(new Point(lineWd, 5), new Point(lineWd, lineHT));
            gpath.AddCurve(topCurve);

            Pen pen = new Pen(Color.Black, 2);

            g.DrawPath(pen, gpath);
            g.FillPath(Brushes.PowderBlue, gpath);


            //Color col = Color.Black;
            //int w = 1;
            //int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            //g.DrawRectangle(new Pen(col, w), new Rectangle(0,
            //                                               0,
            //                                               mul.ClientRectangle.Width - w,
            //                                               mul.ClientRectangle.Height - w));
        }

        private void _mullionUC_mullionUCMouseUpEventRaised(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void _mullionUC_mullionUCMouseMoveEventRaised(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            UserControl me = (UserControl)sender;
            FlowLayoutPanel flp = (FlowLayoutPanel)me.Parent;

            int me_indx = flp.Controls.IndexOf(me);
                                                             //dapat dito yung condition na di dapat siya lumagpas sa bounds
            if (e.Button == MouseButtons.Left && _mouseDown) //&& me.Location.X <= flp.Width - me.Width)
            {
                flp.Controls[me_indx - 1].Width += (e.X - _point_of_origin.X);
                flp.Controls[me_indx + 1].Width -= (e.X - _point_of_origin.X);
                //flp.Invalidate();
                //flp.Parent.Parent.Invalidate(); //invalidate frameUC
                //_mullionUC.Mullion_Left += (e.X - _point_of_origin.X);

                //dito ilagay yung calling ng function sa Frame para mag-create ng illusion sa OVERLAPPING
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

        public IMullionUCPresenter GetNewInstance(IUnityContainer unityC, IDividerModel divModel)
        {
            unityC
                .RegisterType<IMullionUC, MullionUC>()
                .RegisterType<IMullionUCPresenter, MullionUCPresenter>();
            MullionUCPresenter mullionUCP = unityC.Resolve<MullionUCPresenter>();
            mullionUCP._divModel = divModel;

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
    }
}
