using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.Frame;
using Unity;
using System.Windows.Forms;
using CommonComponents;
using System.Drawing;
using System.Drawing.Drawing2D;
using ModelLayer.Model.Quotation.MultiPanel;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class FixedPanelUCPresenter : IFixedPanelUCPresenter, IPresenterCommon
    {

        IFixedPanelUC _fixedPanelUC;

        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;
        private IFrameModel _frameModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelMullionUCPresenter _multiPanelUCP;
        private IFrameUCPresenter _frameUCP;

        bool _initialLoad;

        public FixedPanelUCPresenter(IFixedPanelUC fixedPanelUC)
        {
            _fixedPanelUC = fixedPanelUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _fixedPanelUC.fixedPanelUCSizeChangedEventRaised += new EventHandler(OnFixedPanelUCSizeChangedEventRaised);
            _fixedPanelUC.deleteToolStripClickedEventRaised += _fixedPanelUC_deleteToolStripClickedEventRaised;
            _fixedPanelUC.fixedPanelUCPaintEventRaised += _fixedPanelUC_fixedPanelUCPaintEventRaised;
            _fixedPanelUC.fixedPanelMouseLeaveEventRaised += _fixedPanelUC_fixedPanelMouseLeaveEventRaised;
            _fixedPanelUC.fixedPanelMouseEnterEventRaised += _fixedPanelUC_fixedPanelMouseEnterEventRaised;
        }

        private void _fixedPanelUC_fixedPanelMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            _fixedPanelUC.InvalidateThis();
        }

        private void _fixedPanelUC_fixedPanelMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            _fixedPanelUC.InvalidateThis();
        }

        Color color = Color.Black;
        private void _fixedPanelUC_fixedPanelUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl fixedpnl = (UserControl)sender;

            Graphics g = e.Graphics;
            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            g.SmoothingMode = SmoothingMode.HighQuality;

            Font drawFont = new Font("Times New Roman", 30);// * zoom);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            g.DrawString("F", drawFont, new SolidBrush(Color.Black), fixedpnl.ClientRectangle, drawFormat);

            g.DrawRectangle(new Pen(color, w), new Rectangle(0,
                                                             0,
                                                             fixedpnl.ClientRectangle.Width - w,
                                                             fixedpnl.ClientRectangle.Height - w));

            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(10,
                                                                   10,
                                                                   (fixedpnl.ClientRectangle.Width - 20) - w,
                                                                   (fixedpnl.ClientRectangle.Height - 20) - w));

            if (_panelModel.Panel_Orient == true)
            {
                g.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(15,
                                                                       15,
                                                                       (fixedpnl.ClientRectangle.Width - 30) - w,
                                                                       (fixedpnl.ClientRectangle.Height - 30) - w));

            }
        }

        private void _fixedPanelUC_deleteToolStripClickedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_Visibility = false;
            _frameModel.FrameProp_Height -= 148;
            if (_multiPanelModel != null)
            {
                _multiPanelModel.Reload_PanelMargin();
            }
            if (_multiPanelUCP != null)
            {
                _multiPanelUCP.DeletePanel((UserControl)_fixedPanelUC);
            }
            if (_frameUCP != null)
            {
                _frameUCP.ViewDeleteControl((UserControl)_fixedPanelUC);
            }
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
        }

        private void OnFixedPanelUCSizeChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (!_initialLoad)
                {
                    int thisWd = ((UserControl)sender).Width,
                        thisHt = ((UserControl)sender).Height,
                        pnlModelWd = _panelModel.Panel_Width,
                        pnlModelHt = _panelModel.Panel_Height;

                    if (thisWd != pnlModelWd)
                    {
                        _panelModel.Panel_Width = thisWd;
                    }
                    if (thisHt != pnlModelHt)
                    {
                        _panelModel.Panel_Height = thisHt;
                    }
                }
                ((UserControl)sender).Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                     IPanelModel panelModel, 
                                                     IFrameModel frameModel,
                                                     IMainPresenter mainPresenter,
                                                     IFrameUCPresenter frameUCP)
        {
            unityC
                .RegisterType<IFixedPanelUC, FixedPanelUC>()
                .RegisterType<IFixedPanelUCPresenter, FixedPanelUCPresenter>();
            FixedPanelUCPresenter fixedPanelUCP = unityC.Resolve<FixedPanelUCPresenter>();
            fixedPanelUCP._panelModel = panelModel;
            fixedPanelUCP._frameModel = frameModel;
            fixedPanelUCP._mainPresenter = mainPresenter;
            fixedPanelUCP._frameUCP = frameUCP;

            return fixedPanelUCP;
        }

        public IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                     IPanelModel panelModel,
                                                     IFrameModel frameModel,
                                                     IMainPresenter mainPresenter,
                                                     IMultiPanelModel multiPanelModel,
                                                     IMultiPanelMullionUCPresenter multiPanelUCP)
        {
            unityC
                .RegisterType<IFixedPanelUC, FixedPanelUC>()
                .RegisterType<IFixedPanelUCPresenter, FixedPanelUCPresenter>();
            FixedPanelUCPresenter fixedPanelUCP = unityC.Resolve<FixedPanelUCPresenter>();
            fixedPanelUCP._panelModel = panelModel;
            fixedPanelUCP._frameModel = frameModel;
            fixedPanelUCP._mainPresenter = mainPresenter;
            fixedPanelUCP._multiPanelModel = multiPanelModel;
            fixedPanelUCP._multiPanelUCP = multiPanelUCP;

            return fixedPanelUCP;
        }

        public IFixedPanelUC GetFixedPanelUC()
        {
            _initialLoad = true;
            _fixedPanelUC.ThisBinding(CreateBindingDictionary());
            return _fixedPanelUC;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Dock", new Binding("Dock", _panelModel, "Panel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Width", new Binding("Width", _panelModel, "Panel_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Height", new Binding("Height", _panelModel, "Panel_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Orient", new Binding("pnl_Orientation", _panelModel, "Panel_Orient", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Margin", new Binding("Margin", _panelModel, "Panel_Margin", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }

//for Testing
        //public IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IFrameModel frameModel)
        //{ 
        //    unityC
        //        .RegisterType<IFixedPanelUC, FixedPanelUC>()
        //        .RegisterType<IFixedPanelUCPresenter, FixedPanelUCPresenter>();
        //    FixedPanelUCPresenter fixedPanelUCP = unityC.Resolve<FixedPanelUCPresenter>();
        //    fixedPanelUCP._panelModel = panelModel;
        //    fixedPanelUCP._frameModel = frameModel;

        //    return fixedPanelUCP;
        //}
    }
}
