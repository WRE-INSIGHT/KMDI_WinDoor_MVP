using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_LouverGalleryPropertyUCPresenter : IPP_LouverGalleryPropertyUCPresenter
    {
        IPP_LouverGalleryPropertyUC _louverGalleryPropertyUC;
        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;

        public PP_LouverGalleryPropertyUCPresenter(IPP_LouverGalleryPropertyUC louverGalleryPropertyUC)
        {
            _louverGalleryPropertyUC = louverGalleryPropertyUC;

            SubscribeToEventSetUp();
        }

        private void SubscribeToEventSetUp()
        {
            _louverGalleryPropertyUC.LouverBladesCombinationPropertyUCLoadEventRaised += _louverGalleryPropertyUC_LouverBladesCombinationPropertyUCLoadEventRaised;
            _louverGalleryPropertyUC.cmbBladeTypeSelectedValueChangedEventRaised += _louverGalleryPropertyUC_cmbBladeTypeSelectedValueChangedEventRaised;
            _louverGalleryPropertyUC.chkSecurityGrillCheckedChangedEventRaised += _louverGalleryPropertyUC_chkSecurityGrillCheckedChangedEventRaised;
            _louverGalleryPropertyUC.chkRingpullLeverHandleCheckedChangedEventRaised += _louverGalleryPropertyUC_chkRingpullLeverHandleCheckedChangedEventRaised;
        }

        private void _louverGalleryPropertyUC_chkRingpullLeverHandleCheckedChangedEventRaised(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked == false)
            {
                chk.Text = "No";
                _panelModel.Panel_LouverRPLeverHandleCheck = false;
            }
            else if (chk.Checked == true)
            {
                chk.Text = "Yes";
                _panelModel.Panel_LouverRPLeverHandleCheck = true;
            }
            _mainPresenter.GetCurrentPrice();
        }

        private void _louverGalleryPropertyUC_chkSecurityGrillCheckedChangedEventRaised(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            if (chk.Checked == false)
            {
                chk.Text = "No";
                _panelModel.Panel_LouverSecurityGrillCheck = false;
            }
            else if (chk.Checked == true)
            {
                chk.Text = "Yes";
                _panelModel.Panel_LouverSecurityGrillCheck = true;
            }
            _mainPresenter.GetCurrentPrice();
        }

        private void _louverGalleryPropertyUC_cmbBladeTypeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_LouverBladeTypeOption = (BladeType_Option)((ComboBox)sender).SelectedValue;
        }

        private void _louverGalleryPropertyUC_LouverBladesCombinationPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            //_panelModel.Panel_LouverRPLeverHandleCheck = true;
            _panelModel.Panel_LouverBladeTypeOption = BladeType_Option._glass;
            _louverGalleryPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_LouverGalleryPropertyUC GetLouverGalleryPropertyUC()
        {
            return _louverGalleryPropertyUC;
        }

        public IPP_LouverGalleryPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                    IMainPresenter mainPresenter,
                                                                    IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_LouverGalleryPropertyUC, PP_LouverGalleryPropertyUC>()
                .RegisterType<IPP_LouverGalleryPropertyUCPresenter, PP_LouverGalleryPropertyUCPresenter>();

            PP_LouverGalleryPropertyUCPresenter louverGallerySet = unityC.Resolve<PP_LouverGalleryPropertyUCPresenter>();
            louverGallerySet._unityC = unityC;
            louverGallerySet._mainPresenter = mainPresenter;
            louverGallerySet._panelModel = panelModel;

            return louverGallerySet;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_LouverGalleryVisibility", new Binding("Visible", _panelModel, "Panel_LouverGalleryVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_LouverBladeTypeOption", new Binding("Text", _panelModel, "Panel_LouverBladeTypeOption", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_LouverRPLeverHandleCheck", new Binding("Checked", _panelModel, "Panel_LouverRPLeverHandleCheck", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_LouverSecurityGrillCheck", new Binding("Checked", _panelModel, "Panel_LouverSecurityGrillCheck", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
