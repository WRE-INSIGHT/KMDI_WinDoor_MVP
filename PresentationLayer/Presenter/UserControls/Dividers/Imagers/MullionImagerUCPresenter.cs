using CommonComponents;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.Dividers;
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
        private IMullionUC _mullionUC; //mullion counterpart on editor

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

        private void _mullionImagerUC_mullionUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl mul = (UserControl)sender;
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.HighQuality;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            Control mullionCounterpart = _multiPanelModel.MPanelLst_Objects.Find(obj => obj.Name == _divModel.Div_Name);
            int ctrl_ndx = _multiPanelModel.MPanelLst_Objects.IndexOf(mullionCounterpart);
            bool prevCtrl_isPanel = false;

            if (!_multiPanelModel.MPanelLst_Objects[ctrl_ndx - 1].Name.Contains("Multi"))
            {
                prevCtrl_isPanel = true;
            }
            else
            {
                prevCtrl_isPanel = false;
            }


            if (_divModel.Div_Width == (int)_frameModel.Frame_Type)
            {
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                       0,
                                                                       mul.ClientRectangle.Width - w,
                                                                       mul.ClientRectangle.Height - w));
            }
            else if (_divModel.Div_Width == (int)_frameModel.Frame_Type - _multiPanelModel.MPanel_AddPixel)
            {
                if (prevCtrl_isPanel == false)
                {
                    g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(-1,
                                                                           0,
                                                                           (mul.ClientRectangle.Width - w) + 1,
                                                                           mul.ClientRectangle.Height - w));
                }
                else if (prevCtrl_isPanel == true)
                {
                    g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                           0,
                                                                           (mul.ClientRectangle.Width - w) + 2,
                                                                           mul.ClientRectangle.Height - w));
                }
            }
            else if (_divModel.Div_Width == (int)_frameModel.Frame_Type - (_multiPanelModel.MPanel_AddPixel * 2))
            {
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(-1,
                                                                       0,
                                                                       (mul.ClientRectangle.Width - w) + 2,
                                                                       mul.ClientRectangle.Height - w));
            }
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
                                                        IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP,
                                                        IMullionUC mullionUC)
        {
            unityC
                .RegisterType<IMullionImagerUC, MullionImagerUC>()
                .RegisterType<IMullionImagerUCPresenter, MullionImagerUCPresenter>();
            MullionImagerUCPresenter mullionImagerUCP = unityC.Resolve<MullionImagerUCPresenter>();
            mullionImagerUCP._divModel = divModel;
            mullionImagerUCP._multiPanelModel = multiPanelModel;
            mullionImagerUCP._frameModel = frameModel;
            mullionImagerUCP._multiMullionImagerUCP = multiMullionImagerUCP;
            mullionImagerUCP._mullionUC = mullionUC;

            return mullionImagerUCP;
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
