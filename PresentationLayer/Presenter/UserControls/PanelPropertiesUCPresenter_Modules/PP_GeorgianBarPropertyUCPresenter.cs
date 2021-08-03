using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using ModelLayer.Model.Quotation.Panel;
using Unity;
using CommonComponents;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_GeorgianBarPropertyUCPresenter : IPP_GeorgianBarPropertyUCPresenter, IPresenterCommon
    {
        IPP_GeorgianBarPropertyUC _pp_georgianBarPropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

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
            int gbarThickness = 0;
            if (_panelModel.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
            {
                gbarThickness = 20;
            }
            else if (_panelModel.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
            {
                gbarThickness = 40;
            }

            NumericUpDown numHorizontal = (NumericUpDown)sender;
            int maxlimitqty = Convert.ToInt32(Math.Ceiling((decimal)(_panelModel.Panel_GlassWidth / gbarThickness)));

            if (numHorizontal.Value > maxlimitqty)
            {
                MessageBox.Show("Maximum quantity reached","", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numHorizontal.Value = maxlimitqty;
            }
        }

        private void _pp_georgianBarPropertyUC_numVerticalValueChangedEventRaised(object sender, EventArgs e)
        {
            int gbarThickness = 0;
            if (_panelModel.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
            {
                gbarThickness = 20;
            }
            else if (_panelModel.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
            {
                gbarThickness = 40;
            }

            NumericUpDown numVertical = (NumericUpDown)sender;
            int maxlimitqty = Convert.ToInt32(Math.Ceiling((decimal)(_panelModel.Panel_GlassHeight / gbarThickness)));

            if (numVertical.Value > maxlimitqty)
            {
                MessageBox.Show("Maximum quantity reached", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numVertical.Value = maxlimitqty;
            }
        }

        private void _pp_georgianBarPropertyUC_cmbGBArtNumSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _panelModel.Panel_GeorgianBarArtNo = (GeorgianBar_ArticleNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void OnPPGeorgianBarPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_georgianBarPropertyUC.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
        }

        public IPP_GeorgianBarPropertyUC GetPPGeorgianBarPropertyUC()
        {
            return _pp_georgianBarPropertyUC;
        }

        public IPP_GeorgianBarPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_GeorgianBarPropertyUC, PP_GeorgianBarPropertyUC>()
                .RegisterType<IPP_GeorgianBarPropertyUCPresenter, PP_GeorgianBarPropertyUCPresenter>();
            PP_GeorgianBarPropertyUCPresenter presenter = unityC.Resolve<PP_GeorgianBarPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

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
