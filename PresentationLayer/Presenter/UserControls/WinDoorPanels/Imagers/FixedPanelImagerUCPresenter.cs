using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using ModelLayer.Model.Quotation.Panel;
using Unity;
using CommonComponents;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using PresentationLayer.CommonMethods;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Frame;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers
{
    public class FixedPanelImagerUCPresenter : IFixedPanelImagerUCPresenter, IPresenterCommon
    {
        IFixedPanelImagerUC _fixedPanelImagerUC;

        private IPanelModel _panelModel;

        private IFrameImagerUCPresenter _frameImagerUCP;
        private IMultiPanelMullionImagerUCPresenter _multiPanelMullionImagerUCP;
        private IMultiPanelTransomImagerUCPresenter _multiPanelTransomImagerUCP;

        public FixedPanelImagerUCPresenter(IFixedPanelImagerUC fixedPanelImagerUC)
        {
            _fixedPanelImagerUC = fixedPanelImagerUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _fixedPanelImagerUC.fixedPanelImagerUCPaintEventRaised += _fixedPanelImagerUC_fixedPanelImagerUCPaintEventRaised;
            _fixedPanelImagerUC.fixedPanelImagerUCVisibleChangedEventRaised += _fixedPanelImagerUC_fixedPanelImagerUCVisibleChangedEventRaised;
        }

        private void _fixedPanelImagerUC_fixedPanelImagerUCVisibleChangedEventRaised(object sender, EventArgs e)
        {
            if (((UserControl)sender).Visible == false)
            {
                if (_frameImagerUCP != null)
                {
                    _frameImagerUCP.DeleteControl((UserControl)_fixedPanelImagerUC);
                }
                else if (_multiPanelMullionImagerUCP != null)
                {
                    _multiPanelMullionImagerUCP.DeleteControl((UserControl)_fixedPanelImagerUC);
                }
                else if (_multiPanelTransomImagerUCP != null)
                {
                    _multiPanelTransomImagerUCP.DeleteControl((UserControl)_fixedPanelImagerUC);
                }
            }
        }

        private void _fixedPanelImagerUC_fixedPanelImagerUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl fixedpnl = (UserControl)sender;

            Graphics g = e.Graphics;
            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            g.SmoothingMode = SmoothingMode.HighQuality;

            int font_size = 30,
                outer_line = 10,
                inner_line = 15;

            if (_panelModel.Panel_Zoom == 0.28f)
            {
                font_size = 25;
            }
            else if (_panelModel.Panel_Zoom == 0.19f)
            {
                font_size = 15;
                outer_line = 5;
                inner_line = 8;
            }
            else if (_panelModel.Panel_Zoom == 0.14f)
            {
                font_size = 13;
                outer_line = 3;
                inner_line = 7;
            }
            else if (_panelModel.Panel_Zoom == 0.10f)
            {
                font_size = 8;
                outer_line = 3;
                inner_line = 7;
            }

            Font drawFont = new Font("Times New Roman", font_size);// * zoom);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            g.DrawString("F", drawFont, new SolidBrush(Color.Black), fixedpnl.ClientRectangle, drawFormat);

            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                   0,
                                                                   fixedpnl.ClientRectangle.Width - w,
                                                                   fixedpnl.ClientRectangle.Height - w));

            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(outer_line,
                                                                   outer_line,
                                                                   (fixedpnl.ClientRectangle.Width - (outer_line * 2)) - w,
                                                                   (fixedpnl.ClientRectangle.Height - (outer_line * 2)) - w));

            if (_panelModel.Panel_Orient == true)
            {
                g.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(inner_line,
                                                                       inner_line,
                                                                       (fixedpnl.ClientRectangle.Width - (inner_line * 2)) - w,
                                                                       (fixedpnl.ClientRectangle.Height - (inner_line * 2)) - w));

            }
        }

        public IFixedPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                           IPanelModel panelModel,
                                                           IFrameImagerUCPresenter frameImagerUCP)
        {
            unityC
                .RegisterType<IFixedPanelImagerUC, FixedPanelImagerUC>()
                .RegisterType<IFixedPanelImagerUCPresenter, FixedPanelImagerUCPresenter>();
            FixedPanelImagerUCPresenter imagerUCP = unityC.Resolve<FixedPanelImagerUCPresenter>();
            imagerUCP._panelModel = panelModel;
            imagerUCP._frameImagerUCP = frameImagerUCP;

            return imagerUCP;
        }

        public IFixedPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                           IPanelModel panelModel,
                                                           IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP)
        {
            unityC
                .RegisterType<IFixedPanelImagerUC, FixedPanelImagerUC>()
                .RegisterType<IFixedPanelImagerUCPresenter, FixedPanelImagerUCPresenter>();
            FixedPanelImagerUCPresenter imagerUCP = unityC.Resolve<FixedPanelImagerUCPresenter>();
            imagerUCP._panelModel = panelModel;
            imagerUCP._multiPanelMullionImagerUCP = multiPanelMullionImagerUCP;

            return imagerUCP;
        }

        public IFixedPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                           IPanelModel panelModel, 
                                                           IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP)
        {
            unityC
                .RegisterType<IFixedPanelImagerUC, FixedPanelImagerUC>()
                .RegisterType<IFixedPanelImagerUCPresenter, FixedPanelImagerUCPresenter>();
            FixedPanelImagerUCPresenter imagerUCP = unityC.Resolve<FixedPanelImagerUCPresenter>();
            imagerUCP._panelModel = panelModel;
            imagerUCP._multiPanelTransomImagerUCP = multiPanelTransomImagerUCP;

            return imagerUCP;
        }

        public IFixedPanelImagerUC GetFixedPanelImagerUC()
        {
            _fixedPanelImagerUC.ThisBinding(CreateBindingDictionary());
            return _fixedPanelImagerUC;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Dock", new Binding("Dock", _panelModel, "Panel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelImageRenderer_Width", new Binding("Width", _panelModel, "PanelImageRenderer_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelImageRenderer_Height", new Binding("Height", _panelModel, "PanelImageRenderer_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Orient", new Binding("pnl_Orientation", _panelModel, "Panel_Orient", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Margin", new Binding("Margin", _panelModel, "PanelImageRenderer_Margin", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            
            return panelBinding;
        }
    }

}
