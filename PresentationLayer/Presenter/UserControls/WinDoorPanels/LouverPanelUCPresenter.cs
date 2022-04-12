using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using ServiceLayer.Services.DividerServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class LouverPanelUCPresenter : ILouverPanelUCPresenter, IPresenterCommon
    {
        ILouverPanelUC _louverPanelUC;

        private IUnityContainer _unityC;

        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;
        private IFrameModel _frameModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelMullionUCPresenter _multiPanelMullionUCP;
        private IMultiPanelTransomUCPresenter _multiPanelTransomUCP;
        private IFrameUCPresenter _frameUCP;

        private ITransomUCPresenter _transomUCP;
        private IMullionUCPresenter _mullionUCP;

        private IDividerServices _divServices;

        private CommonFunctions _commonFunctions = new CommonFunctions();
        Timer _tmr = new Timer();
        bool _initialLoad;

        public LouverPanelUCPresenter(ILouverPanelUC louverPanelUC,
                                      IDividerServices divServices,
                                      ITransomUCPresenter transomUCP,
                                      IMullionUCPresenter mullionUCP)
        {
            _louverPanelUC = louverPanelUC;
            _divServices = divServices;
            _transomUCP = transomUCP;
            _mullionUCP = mullionUCP;

            _tmr = new Timer();
            _tmr.Interval = 200;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _louverPanelUC.louverPanelUCLoadEventRaised += _louverPanelUC_louverPanelUCLoadEventRaised;
            _louverPanelUC.louverPanelUCMouseEnterEventRaised += _louverPanelUC_louverPanelUCMouseEnterEventRaised;
            _louverPanelUC.louverPanelUCMouseLeaveEventRaised += _louverPanelUC_louverPanelUCMouseLeaveEventRaised;
            _louverPanelUC.louverPanelUCSizeChangedEventRaised += _louverPanelUC_louverPanelUCSizeChangedEventRaised;
            _louverPanelUC.louverPanelUCPaintEventRaised += _louverPanelUC_louverPanelUCPaintEventRaised;
            _louverPanelUC.deleteToolStripClickedEventRaised += _louverPanelUC_deleteToolStripClickedEventRaised;
        }

        private void _louverPanelUC_louverPanelUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            try
            {
                UserControl louver = (UserControl)sender;

                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Pen p = new Pen(Color.Black);
                Pen p2 = new Pen(Color.Black, 2);
                Pen LvrPen = new Pen(Color.Black, 7);
                Pen LvrPen2 = new Pen(Color.FromArgb(240, 240, 240), 7);

                Brush b = new SolidBrush(Color.Black);

                int font_size = 30,
                    outer_line = 10,
                    inner_line = 15;

                int ndx_zoomPercentage = Array.IndexOf(_mainPresenter.windoorModel_MainPresenter.Arr_ZoomPercentage, _frameModel.Frame_Zoom);

                if (ndx_zoomPercentage == 3)
                {
                    font_size = 25;
                }
                else if (ndx_zoomPercentage == 2)
                {
                    font_size = 15;
                    outer_line = 5;
                    inner_line = 8;
                }
                else if (ndx_zoomPercentage == 1)
                {
                    font_size = 13;
                    outer_line = 3;
                    inner_line = 7;
                }
                else if (ndx_zoomPercentage == 0)
                {
                    font_size = 8;
                    outer_line = 3;
                    inner_line = 7;
                }


                g.DrawRectangle(new Pen(color, 2), new Rectangle(0,
                                                                 0,
                                                                 louver.ClientRectangle.Width - 2,
                                                                 louver.ClientRectangle.Height - 2));



                // jelusi

                int Lvr_NewLocation = 0,
                    Lvr_Gap = 0,
                    pInnerY = 0,
                    pInnerX = 0,
                    pInnerHt = louver.Height,
                    pInnerWd = louver.Width,
                    NoOfBaldes = _panelModel.Panel_LouverBladesCount;
                double Lvr_GlassHt = 0;


                //side blade
                for (int ii = 0; ii < _panelModel.Panel_LouverBladesCount; ii++)
                {
                    Lvr_GlassHt = (((pInnerHt - (((int)NoOfBaldes))) / (int)NoOfBaldes) / 2) + (int)NoOfBaldes;//33 + (33 * 0.75);
                    Lvr_NewLocation = ((pInnerY + 20) + Lvr_Gap) + (int)Lvr_GlassHt;
                    Lvr_Gap += (pInnerHt - (int)Lvr_GlassHt) / ((int)NoOfBaldes);


                    Point[] LvrSideBlade =
                     {
                        new Point(pInnerY + pInnerWd - 2, Lvr_NewLocation-(int)Lvr_GlassHt),
                        new Point(pInnerY + pInnerWd + 4, Lvr_NewLocation+(int)Lvr_GlassHt),

                        new Point(pInnerY-2, Lvr_NewLocation-(int)Lvr_GlassHt),
                        new Point(pInnerY+4, Lvr_NewLocation+(int)Lvr_GlassHt),

                        new Point(pInnerY-4, Lvr_NewLocation-(int)Lvr_GlassHt-1),
                        new Point(pInnerY-4, Lvr_NewLocation+(int)Lvr_GlassHt+1)
                     };

                    for (int i = 0; i < LvrSideBlade.Length; i += 2)
                    {
                        if (i == 4)
                        {
                            e.Graphics.DrawLine(LvrPen2, LvrSideBlade[i], LvrSideBlade[i + 1]);

                        }
                        else
                        {
                            e.Graphics.DrawLine(LvrPen, LvrSideBlade[i], LvrSideBlade[i + 1]);

                        }
                    }
                    //    //blade
                    Point[] blade =
                    {
                        new Point(pInnerX,Lvr_NewLocation-(int)Lvr_GlassHt),
                        new Point((int)louver.Height - pInnerX,Lvr_NewLocation-(int)Lvr_GlassHt),
                        new Point((int)louver.Width - 19,Lvr_NewLocation+(int)Lvr_GlassHt), // - 19 para mag slant yung blade
                        new Point(pInnerX,Lvr_NewLocation+(int)Lvr_GlassHt)
                    };
                    for (int i = 0; i < blade.Length; i += 2)
                    {
                        e.Graphics.DrawLine(p, blade[i], blade[i + 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void _louverPanelUC_deleteToolStripClickedEventRaised(object sender, EventArgs e)
        {

        }

        private void _louverPanelUC_louverPanelUCSizeChangedEventRaised(object sender, EventArgs e)
        {

        }

        Color color = Color.Black;

        private void _louverPanelUC_louverPanelUCMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            ((IPanelUC)_louverPanelUC).InvalidateThis();
        }

        private void _louverPanelUC_louverPanelUCMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            ((IPanelUC)_louverPanelUC).InvalidateThis();
        }

        private void _louverPanelUC_louverPanelUCLoadEventRaised(object sender, EventArgs e)
        {
            _louverPanelUC.ThisBinding(CreateBindingDictionary());
            _panelModel.Set_LouverBladesCount();
        }

        public ILouverPanelUC GetLouverPanelUC()
        {
            _initialLoad = true;
            return _louverPanelUC;
        }


        public ILouverPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                      IPanelModel panelModel,
                                                      IFrameModel frameModel,
                                                      IMainPresenter mainPresenter,
                                                      IFrameUCPresenter frameUCP)
        {
            unityC
                .RegisterType<ILouverPanelUC, LouverPanelUC>()
                .RegisterType<ILouverPanelUCPresenter, LouverPanelUCPresenter>();
            LouverPanelUCPresenter louverUCP = unityC.Resolve<LouverPanelUCPresenter>();
            louverUCP._panelModel = panelModel;
            louverUCP._frameModel = frameModel;
            louverUCP._mainPresenter = mainPresenter;
            louverUCP._frameUCP = frameUCP;
            louverUCP._unityC = unityC;

            return louverUCP;
        }

        public ILouverPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelMullionUCPresenter multiPanelUCP)
        {
            unityC
                .RegisterType<ILouverPanelUC, LouverPanelUC>()
                .RegisterType<ILouverPanelUCPresenter, LouverPanelUCPresenter>();
            LouverPanelUCPresenter louverUCP = unityC.Resolve<LouverPanelUCPresenter>();
            louverUCP._panelModel = panelModel;
            louverUCP._frameModel = frameModel;
            louverUCP._mainPresenter = mainPresenter;
            louverUCP._multiPanelModel = multiPanelModel;
            louverUCP._multiPanelMullionUCP = multiPanelUCP;
            louverUCP._unityC = unityC;

            return louverUCP;
        }

        public ILouverPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelTransomUCPresenter multiPanelTransomUCP)
        {
            unityC
                .RegisterType<ILouverPanelUC, LouverPanelUC>()
                .RegisterType<ILouverPanelUCPresenter, LouverPanelUCPresenter>();
            LouverPanelUCPresenter louverUCP = unityC.Resolve<LouverPanelUCPresenter>();
            louverUCP._panelModel = panelModel;
            louverUCP._frameModel = frameModel;
            louverUCP._mainPresenter = mainPresenter;
            louverUCP._multiPanelModel = multiPanelModel;
            louverUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            louverUCP._unityC = unityC;

            return louverUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Name", new Binding("Name", _panelModel, "Panel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Dock", new Binding("Dock", _panelModel, "Panel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_WidthToBind", new Binding("Width", _panelModel, "Panel_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_HeightToBind", new Binding("Height", _panelModel, "Panel_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Margin", new Binding("Margin", _panelModel, "Panel_MarginToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Placement", new Binding("Panel_Placement", _panelModel, "Panel_Placement", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_CmenuDeleteVisibility", new Binding("Panel_CmenuDeleteVisibility", _panelModel, "Panel_CmenuDeleteVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }
    }
}