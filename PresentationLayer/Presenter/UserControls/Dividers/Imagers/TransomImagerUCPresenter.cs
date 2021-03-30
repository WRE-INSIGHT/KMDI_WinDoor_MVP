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
    public class TransomImagerUCPresenter : ITransomImagerUCPresenter, IPresenterCommon
    {
        ITransomImagerUC _transomImagerUC;

        private IFrameModel _frameModel;
        private IDividerModel _divModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelTransomImagerUCPresenter _multiTransomImagerUCP;

        CommonFunctions _commonfunc = new CommonFunctions();

        public TransomImagerUCPresenter(ITransomImagerUC transomImagerUC)
        {
            _transomImagerUC = transomImagerUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _transomImagerUC.transomUCPaintEventRaised += _transomImagerUC_transomUCPaintEventRaised;
            _transomImagerUC.transomUCVisibleChangedEventRaised += _transomImagerUC_transomUCVisibleChangedEventRaised;
        }

        private void _transomImagerUC_transomUCVisibleChangedEventRaised(object sender, EventArgs e)
        {
            if (((UserControl)sender).Visible == false)
            {
                if (_multiTransomImagerUCP != null)
                {
                    _multiTransomImagerUCP.DeleteControl((UserControl)_transomImagerUC);
                }
            }
        }

        private void _transomImagerUC_transomUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl transom = (UserControl)sender;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath gpath = new GraphicsPath();

            int this_ndx = _multiPanelModel.MPanelLst_Objects.IndexOf(transom);
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

            List<Point[]> TPoints = _commonfunc.GetTransomDrawingPoints(transom.Width,
                                                                        transom.Height,
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

        public ITransomImagerUC GetTransomImager()
        {
            _transomImagerUC.ThisBinding(CreateBindingDictionary());
            return _transomImagerUC;
        }
        public ITransomImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IDividerModel divModel,
                                                        IMultiPanelModel multiPanelModel,
                                                        IFrameModel frameModel,
                                                        IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP)
        {
            unityC
                .RegisterType<ITransomImagerUC, TransomImagerUC>()
                .RegisterType<ITransomImagerUCPresenter, TransomImagerUCPresenter>();
            TransomImagerUCPresenter transomImagerUCP = unityC.Resolve<TransomImagerUCPresenter>();
            transomImagerUCP._divModel = divModel;
            transomImagerUCP._multiPanelModel = multiPanelModel;
            transomImagerUCP._frameModel = frameModel;
            transomImagerUCP._multiTransomImagerUCP = multiTransomImagerUCP;

            return transomImagerUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> divBinding = new Dictionary<string, Binding>();
            divBinding.Add("Div_ID", new Binding("Div_ID", _divModel, "Div_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Visible", new Binding("Visible", _divModel, "Div_Visible", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("DivImageRenderer_Width", new Binding("Width", _divModel, "DivImageRenderer_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("DivImageRenderer_Height", new Binding("Height", _divModel, "DivImageRenderer_Height", true, DataSourceUpdateMode.OnPropertyChanged));

            return divBinding;
        }
    }
}
