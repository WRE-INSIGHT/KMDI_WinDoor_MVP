using CommonComponents;
using ModelLayer.Model.Quotation.Divider;
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

                float Ht_Allowance = 20 * _frameModel.Frame_Zoom; // tag 10px na allowance sa taas at baba if 100%
                double Lvr_GlassHt = 0;

                //side blade
                for (int ii = 0; ii < _panelModel.Panel_LouverBladesCount; ii++)
                {
                    Lvr_GlassHt = (((pInnerHt - (((int)NoOfBaldes))) / (int)NoOfBaldes) / 2) + (int)NoOfBaldes;
                    Lvr_NewLocation = ((pInnerY + (int)Ht_Allowance) + Lvr_Gap) + (int)Lvr_GlassHt;
                    Lvr_Gap += (pInnerHt - (int)Lvr_GlassHt) / ((int)NoOfBaldes);

                    Point[] LvrSideBlade =
                     {
                        new Point((pInnerY - 7) + pInnerWd - 2, Lvr_NewLocation-(int)Lvr_GlassHt),
                        new Point((pInnerY - 7) + pInnerWd + 4, Lvr_NewLocation+(int)Lvr_GlassHt),

                        new Point(pInnerY-2, Lvr_NewLocation-(int)Lvr_GlassHt),
                        new Point(pInnerY+4, Lvr_NewLocation+(int)Lvr_GlassHt),

                        new Point(pInnerY-4, Lvr_NewLocation-(int)Lvr_GlassHt-1),
                        new Point(pInnerY-4, Lvr_NewLocation+(int)Lvr_GlassHt+1)
                     };

                    for (int i = 0; i < LvrSideBlade.Length; i += 2)
                    {
                        if (i == 4)
                        {
                            g.DrawLine(LvrPen2, LvrSideBlade[i], LvrSideBlade[i + 1]);
                        }
                        else
                        {
                            g.DrawLine(LvrPen, LvrSideBlade[i], LvrSideBlade[i + 1]);
                        }
                    }

                    //blade
                    Point[] blade =
                    {
                        new Point(pInnerX, Lvr_NewLocation-(int)Lvr_GlassHt),
                        new Point((int)louver.Width - pInnerX - 7, Lvr_NewLocation-(int)Lvr_GlassHt),
                        new Point((int)louver.Width ,Lvr_NewLocation+(int)Lvr_GlassHt), // - 19 para mag slant yung blade
                        new Point(pInnerX, Lvr_NewLocation+(int)Lvr_GlassHt)
                    };
                    for (int i = 0; i < blade.Length; i += 2)
                    {
                        g.DrawLine(p, blade[i], blade[i + 1]);
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
            try
            {
                #region Delete Divider
                if (_multiPanelModel != null &&
                    _multiPanelModel.MPanel_DividerEnabled &&
                    _panelModel.Panel_Placement != "Last")
                {
                    int this_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((UserControl)_louverPanelUC);

                    Control divUC = _multiPanelModel.MPanelLst_Objects[this_indx + 1];
                    _multiPanelModel.MPanelLst_Objects.Remove((UserControl)divUC);

                    //string imgr_type = "";

                    if (_multiPanelMullionUCP != null)
                    {
                        _multiPanelMullionUCP.DeletePanel((UserControl)divUC);
                        //imgr_type = "MullionImager";
                    }
                    if (_multiPanelTransomUCP != null)
                    {
                        _multiPanelTransomUCP.DeletePanel((UserControl)divUC);
                        //imgr_type = "TransomImager";
                    }

                    IDividerModel div = _multiPanelModel.MPanelLst_Divider.Find(divd => divd.Div_Name == divUC.Name);
                    _mainPresenter.DeleteDividerPropertiesUC(div.Div_ID);
                    div.Div_MPanelParent.MPanelLst_Divider.Remove(div);
                    _frameModel.Lst_Divider.Remove(div);

                    _multiPanelModel.DeductPropertyPanelHeight(div.Div_PropHeight);
                    _frameModel.DeductPropertyPanelHeight(div.Div_PropHeight);
                }

                #endregion

                #region Delete Louver

                if (_multiPanelModel != null)
                {
                    _multiPanelModel.DeleteControl_MPanelLstObjects((UserControl)_louverPanelUC, _frameModel.Frame_Type.ToString());
                    Control imager = _commonFunctions.FindImagerControl(_panelModel.Panel_ID, "Panel", _multiPanelModel);
                    _multiPanelModel.MPanelLst_Imagers.Remove(imager);

                    _multiPanelModel.Reload_PanelMargin();

                    _multiPanelModel.DeductPropertyPanelHeight(_panelModel.Panel_PropertyHeight);
                }
                if (_multiPanelMullionUCP != null)
                {
                    _multiPanelMullionUCP.DeletePanel((UserControl)_louverPanelUC);
                }
                if (_multiPanelTransomUCP != null)
                {
                    _multiPanelTransomUCP.DeletePanel((UserControl)_louverPanelUC);
                }
                if (_frameUCP != null)
                {
                    _frameUCP.ViewDeleteControl((UserControl)_louverPanelUC);
                }

                if (_multiPanelModel != null && _multiPanelModel.MPanel_DividerEnabled)
                {
                    _multiPanelModel.Object_Indexer();
                    _multiPanelModel.Reload_PanelMargin();
                    _multiPanelModel.Reload_MultiPanelMargin();
                    _commonFunctions.Automatic_Div_Addition(_mainPresenter,
                                                            _frameModel,
                                                            _divServices,
                                                            //_frameUCP,
                                                            _transomUCP,
                                                            _unityC,
                                                            _mullionUCP,
                                                            _mainPresenter.GetDividerCount(),
                                                            _multiPanelModel,
                                                            _panelModel,
                                                            _multiPanelTransomUCP,
                                                            _multiPanelMullionUCP);
                }
                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();

                _mainPresenter.DeletePanelPropertiesUC(_panelModel.Panel_ID);
                _mainPresenter.SetChangesMark();
                if (_frameModel != null)
                {
                    _frameModel.Lst_Panel.Remove(_panelModel);
                    _mainPresenter.frameUC_MainPresenter.GetThis().Controls.Clear();
                }
                if (_multiPanelModel != null)
                {
                    _multiPanelModel.MPanelLst_Panel.Remove(_panelModel);
                }

                _frameModel.DeductPropertyPanelHeight(_panelModel.Panel_PropertyHeight);
                _mainPresenter.DeductPanelGlassID();
                _mainPresenter.SetPanelGlassID();
                _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                #endregion

                _mainPresenter.DeselectDivider();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        int prev_Width = 0,
            prev_Height = 0;

        bool _HeightChange = false,
             _WidthChange = false;
        private void _louverPanelUC_louverPanelUCSizeChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (!_initialLoad)
                {
                    int thisWd = ((UserControl)sender).Width,
                        thisHt = ((UserControl)sender).Height,
                        pnlModelWd = _panelModel.Panel_WidthToBind,
                        pnlModelHt = _panelModel.Panel_HeightToBind;

                    if (thisWd != pnlModelWd || prev_Width != pnlModelWd)
                    {
                        //_multiPanelModel.MPanel_Width = thisWd;
                        _WidthChange = true;
                    }
                    if (thisHt != pnlModelHt || prev_Height != pnlModelHt)
                    {
                        //_multiPanelModel.MPanel_Height = thisHt;
                        _HeightChange = true;
                    }
                }
                prev_Width = _panelModel.Panel_WidthToBind;
                prev_Height = _panelModel.Panel_HeightToBind;

                _tmr.Start();
                ((UserControl)sender).Invalidate();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
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

            _panelModel.Panel_OrientVisibility = false;
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

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }
    }
}