using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_GeorgianBarPropertyUCPresenter : IPP_GeorgianBarPropertyUCPresenter, IPresenterCommon
    {
        IPP_GeorgianBarPropertyUC _pp_georgianBarPropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;

        bool _initialLoad = true;

        public PP_GeorgianBarPropertyUCPresenter(IPP_GeorgianBarPropertyUC pp_georgianBarPropertyUC)
        {
            _pp_georgianBarPropertyUC = pp_georgianBarPropertyUC;
            SubcribeToEventSetUp();
        }

        private void SubcribeToEventSetUp()
        {
            _pp_georgianBarPropertyUC.PPGeorgianBarPropertyUCLoadEventRaised += OnPPGeorgianBarPropertyUCLoadEventRaised;
            _pp_georgianBarPropertyUC.cmbGBArtNumSelectedValueChangedEventRaised += _pp_georgianBarPropertyUC_cmbGBArtNumSelectedValueChangedEventRaised;
            _pp_georgianBarPropertyUC.numVerticalValueChangedEventRaised += _pp_georgianBarPropertyUC_numVerticalValueChangedEventRaised;
            _pp_georgianBarPropertyUC.numHorizontalValueChangedEventRaised += _pp_georgianBarPropertyUC_numHorizontalValueChangedEventRaised;
        }

        private void _pp_georgianBarPropertyUC_numHorizontalValueChangedEventRaised(object sender, EventArgs e)
        {
            NumericUpDown numHorizontal = (NumericUpDown)sender;
            _panelModel.Panel_GeorgianBar_HorizontalQty = (int)numHorizontal.Value;
            if (_panelModel.Panel_GlassWidth != 0)
            {
                int gbarThickness = 0;
                if (_panelModel.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
                {
                    gbarThickness = 20;
                }
                else if (_panelModel.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0726)
                {
                    gbarThickness = 40;
                }

                int maxlimitqty = Convert.ToInt32(Math.Ceiling((decimal)(_panelModel.Panel_GlassHeight / gbarThickness)));

                if (numHorizontal.Value > maxlimitqty)
                {
                    MessageBox.Show("Maximum quantity reached", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    numHorizontal.Value = maxlimitqty;
                }
                _mainPresenter.itemDescription();
                _mainPresenter.GetCurrentPrice();
            }
            else
            {
                MessageBox.Show("Please complete the design first", "Cant compute for glass", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numHorizontal.Value = 0;
            }

            if (_panelModel.Panel_ParentMultiPanelModel != null)
            {
                ((IPanelUC)_panelModel.Panel_ParentMultiPanelModel.MPanelLst_Objects.Find(pnl => pnl.Name == _panelModel.Panel_Name)).InvalidateThis();
            }
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
        }

        private void _pp_georgianBarPropertyUC_numVerticalValueChangedEventRaised(object sender, EventArgs e)
        {
            NumericUpDown numVertical = (NumericUpDown)sender;
            _panelModel.Panel_GeorgianBar_VerticalQty = (int)numVertical.Value;

            if (_panelModel.Panel_GlassHeight != 0)
            {
                int gbarThickness = 0;
                if (_panelModel.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
                {
                    gbarThickness = 20;
                }
                else if (_panelModel.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0726)
                {
                    gbarThickness = 40;
                }

                int maxlimitqty = Convert.ToInt32(Math.Ceiling((decimal)(_panelModel.Panel_GlassWidth / gbarThickness)));

                if (numVertical.Value > maxlimitqty)
                {
                    MessageBox.Show("Maximum quantity reached", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    numVertical.Value = maxlimitqty;
                }
                _mainPresenter.itemDescription();
                _mainPresenter.GetCurrentPrice();
            }
            else
            {
                MessageBox.Show("Please complete the design first", "Cant compute for glass", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numVertical.Value = 0;
            }
            if (_panelModel.Panel_ParentMultiPanelModel != null)
            {
                ((IPanelUC)_panelModel.Panel_ParentMultiPanelModel.MPanelLst_Objects.Find(pnl => pnl.Name == _panelModel.Panel_Name)).InvalidateThis();
            }
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
        }

        private void _pp_georgianBarPropertyUC_cmbGBArtNumSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            //if (!_initialLoad)
            //{
            //    _panelModel.Panel_GeorgianBarArtNo = (GeorgianBar_ArticleNo)((ComboBox)sender).SelectedValue;
            //    if (_panelModel.Panel_GeorgianBarArtNo != GeorgianBar_ArticleNo._None)
            //    {
            //        _pp_georgianBarPropertyUC.enable_num = true;
            //    }
            //    else
            //    {
            //        _pp_georgianBarPropertyUC.enable_num = false;
            //    }
            //}

            if (_mainPresenter.ItemLoad == false)
            {
                _panelModel.Panel_GeorgianBarArtNo = (GeorgianBar_ArticleNo)((ComboBox)sender).SelectedValue;
                if (_panelModel.Panel_GeorgianBarArtNo != GeorgianBar_ArticleNo._None)
                {
                    _pp_georgianBarPropertyUC.enable_num = true;
                }
                else
                {
                    _pp_georgianBarPropertyUC.enable_num = false;
                }
            }
        }

        private void OnPPGeorgianBarPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_georgianBarPropertyUC.ThisBinding(CreateBindingDictionary());
            if (_panelModel.Panel_GeorgianBarArtNo != GeorgianBar_ArticleNo._None)
            {
                _pp_georgianBarPropertyUC.enable_num = true;
            }
            else
            {
                _pp_georgianBarPropertyUC.enable_num = false;
            }
            _initialLoad = false;
        }

        public IPP_GeorgianBarPropertyUC GetPPGeorgianBarPropertyUC()
        {
            return _pp_georgianBarPropertyUC;
        }

        public IPP_GeorgianBarPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IPP_GeorgianBarPropertyUC, PP_GeorgianBarPropertyUC>()
                .RegisterType<IPP_GeorgianBarPropertyUCPresenter, PP_GeorgianBarPropertyUCPresenter>();
            PP_GeorgianBarPropertyUCPresenter presenter = unityC.Resolve<PP_GeorgianBarPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;
            presenter._mainPresenter = mainPresenter;
            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_GeorgianBarArtNo", new Binding("Text", _panelModel, "Panel_GeorgianBarArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_GeorgianBar_VerticalQty", new Binding("Value", _panelModel, "Panel_GeorgianBar_VerticalQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_GeorgianBar_HorizontalQty", new Binding("Value", _panelModel, "Panel_GeorgianBar_HorizontalQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_GeorgianBarOptionVisibility", new Binding("Visible", _panelModel, "Panel_GeorgianBarOptionVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
