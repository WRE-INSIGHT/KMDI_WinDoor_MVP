using CommonComponents;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.Dividers.Imagers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.Dividers.Imagers
{
    public class MullionImagerUCPresenter : IMullionImagerUCPresenter, IPresenterCommon
    {
        IMullionImagerUC _mullionImagerUC;

        private IFrameModel _frameModel;
        private IDividerModel _divModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelMullionImagerUCPresenter _multiMullionImagerUCP;

        CommonFunctions _commonfunc = new CommonFunctions();

        public MullionImagerUCPresenter(IMullionImagerUC mullionImagerUC)
        {
            _mullionImagerUC = mullionImagerUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _mullionImagerUC.mullionUCPaintEventRaised += _mullionImagerUC_mullionUCPaintEventRaised;
            _mullionImagerUC.mullionVisibleChangedEventRaised += _mullionImagerUC_mullionVisibleChangedEventRaised;
        }

        private void _mullionImagerUC_mullionVisibleChangedEventRaised(object sender, EventArgs e)
        {
            if (((UserControl)sender).Visible == false)
            {
                if (_multiMullionImagerUCP != null)
                {
                    _multiMullionImagerUCP.DeleteControl((UserControl)_mullionImagerUC);
                }
            }
        }

        private void _mullionImagerUC_mullionUCPaintEventRaised(object sender, System.Windows.Forms.PaintEventArgs e)
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

            List<Point[]> TPoints = _commonfunc.GetMullionDrawingPoints(mul.Width,
                                                                        mul.Height,
                                                                        prev_obj_name,
                                                                        next_obj_name,
                                                                        _frameModel);

            gpath.AddLine(TPoints[0][0], TPoints[0][1]);
            gpath.AddCurve(TPoints[1]);
            gpath.AddLine(TPoints[2][0], TPoints[2][1]);
            gpath.AddCurve(TPoints[3]);

            Pen pen = new Pen(Color.Black, 2);

            g.DrawPath(pen, gpath);
            g.FillPath(Brushes.PowderBlue, gpath);
        }

        public IMullionImagerUC GetMullionImager()
        {
            _mullionImagerUC.ThisBinding(CreateBindingDictionary());
            return _mullionImagerUC;
        }

        public IMullionImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IDividerModel divModel,
                                                        IMultiPanelModel multiPanelModel,
                                                        IFrameModel frameModel,
                                                        IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP)
        {
            unityC
                .RegisterType<IMullionImagerUC, MullionImagerUC>()
                .RegisterType<IMullionImagerUCPresenter, MullionImagerUCPresenter>();
            MullionImagerUCPresenter mullionImagerUCP = unityC.Resolve<MullionImagerUCPresenter>();
            mullionImagerUCP._divModel = divModel;
            mullionImagerUCP._multiPanelModel = multiPanelModel;
            mullionImagerUCP._frameModel = frameModel;
            mullionImagerUCP._multiMullionImagerUCP = multiMullionImagerUCP;

            return mullionImagerUCP;
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
