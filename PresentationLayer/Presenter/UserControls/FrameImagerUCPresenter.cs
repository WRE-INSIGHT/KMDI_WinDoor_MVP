using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace PresentationLayer.Presenter.UserControls
{
    public class FrameImagerUCPresenter : IFrameImagerUCPresenter, IPresenterCommon
    {
        IFrameImagerUC _frameImagerUC;
        private IUnityContainer _unityC;

        private IFrameModel _frameModel;

        public FrameImagerUCPresenter(IFrameImagerUC frameImagerUC)
        {
            _frameImagerUC = frameImagerUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _frameImagerUC.frameLoadEventRaised += _frameImagerUC_frameLoadEventRaised;
            _frameImagerUC.outerFramePaintEventRaised += _frameImagerUC_outerFramePaintEventRaised;
        }

        private void _frameImagerUC_outerFramePaintEventRaised(object sender, PaintEventArgs e)
        {
            Pen blkPen = new Pen(Color.Black);

            Graphics g = e.Graphics;

            UserControl pfr = (UserControl)sender;

            int fr_pads = 0;
            if (_frameModel.Frame_Type.ToString().Contains("Window"))
            {
                fr_pads = 26;
            }
            else if (_frameModel.Frame_Type.ToString().Contains("Door"))
            {
                fr_pads = 33;
            }

            Rectangle pnl_inner = new Rectangle(new Point(fr_pads, fr_pads),
                                                new Size(pfr.ClientRectangle.Width - (fr_pads * 2),
                                                         pfr.ClientRectangle.Height - (fr_pads * 2)));

            g.SmoothingMode = SmoothingMode.AntiAlias;


            int pInnerX = pnl_inner.Location.X,
            pInnerY = pnl_inner.Location.Y,
            pInnerWd = pnl_inner.Width,
            pInnerHt = pnl_inner.Height;

            Point[] corner_points = new[]
            {
                new Point(0,0),
                new Point(pInnerX,pInnerY),
                new Point(pfr.ClientRectangle.Width,0),
                new Point(pInnerX + pInnerWd,pInnerY),
                new Point(0,pfr.ClientRectangle.Height),
                new Point(pInnerX,pInnerY + pInnerHt),
                new Point(pfr.ClientRectangle.Width,pfr.ClientRectangle.Height),
                new Point(pInnerX + pInnerWd,pInnerY + pInnerHt)
            };

            for (int i = 0; i < corner_points.Length - 1; i += 2)
            {
                g.DrawLine(blkPen, corner_points[i], corner_points[i + 1]);
            }

            g.DrawRectangle(blkPen, pnl_inner);

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                   0,
                                                                   pfr.ClientRectangle.Width - w,
                                                                   pfr.ClientRectangle.Height - w));
        }

        private void _frameImagerUC_frameLoadEventRaised(object sender, EventArgs e)
        {
            _frameImagerUC.ThisBinding(CreateBindingDictionary());
        }

        public IFrameImagerUC GetFrameImagerUC()
        {
            return _frameImagerUC;
        }

        public IFrameImagerUCPresenter GetNewInstance(IUnityContainer unityC, IFrameModel frameModel)//, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IFrameImagerUC, FrameImagerUC>()
                .RegisterType<IFrameImagerUCPresenter, FrameImagerUCPresenter>();
            FrameImagerUCPresenter frameImagerPresenter = unityC.Resolve<FrameImagerUCPresenter>();
            frameImagerPresenter._frameModel = frameModel;
            //framePresenter._mainPresenter = mainPresenter;
            frameImagerPresenter._unityC = unityC;

            return frameImagerPresenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> frameBinding = new Dictionary<string, Binding>();
            frameBinding.Add("Frame_Visible", new Binding("Visible", _frameModel, "Frame_Visible", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("FrameImageRenderer_Width", new Binding("Width", _frameModel, "FrameImageRenderer_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("FrameImageRenderer_Height", new Binding("Height", _frameModel, "FrameImageRenderer_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Padding", new Binding("Padding", _frameModel, "FrameImageRenderer_Padding_int", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_ID", new Binding("frameID", _frameModel, "Frame_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Name", new Binding("Name", _frameModel, "Frame_Name", true, DataSourceUpdateMode.OnPropertyChanged));

            return frameBinding;
        }

        public void AddControl(UserControl userctrlObj)
        {
            _frameImagerUC.AddImagerControl(userctrlObj);
        }

        public void DeleteControl(UserControl userctrlObj)
        {
            _frameImagerUC.DeleteImagerControl(userctrlObj);
        }
    }
}
