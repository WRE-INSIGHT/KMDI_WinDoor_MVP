using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_RollerPropertyUCPresenter : IPP_RollerPropertyUCPresenter
    {
        IPP_RollerPropertyUC _rollerPropertyUC;

        private IUnityContainer _unityC;
        private IPanelModel _panelModel;
        private IMainPresenter _mainPresenter;

        public PP_RollerPropertyUCPresenter(IPP_RollerPropertyUC rollerPropertyUC)
        {
            _rollerPropertyUC = rollerPropertyUC;

            SubribeToEventSetUp();
        }

        private void SubribeToEventSetUp()
        {
            _rollerPropertyUC.PPRollerPropertyUCLoadEventRaised += _rollerPropertyUC_PPRollerPropertyUCLoadEventRaised;
            _rollerPropertyUC.cmbRollerSelectedValueChangedEventRaised += _rollerPropertyUC_cmbRollerSelectedValueChangedEventRaised;
        }

        private void _rollerPropertyUC_cmbRollerSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            _panelModel.Panel_RollersTypes = (RollersTypes)cmb.SelectedValue;
        }

        private void _rollerPropertyUC_PPRollerPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _rollerPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_RollerPropertyUC GetRollerTypePropertyUC()
        {
            return _rollerPropertyUC;
        }

        public IPP_RollerPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IPanelModel panelModel,
                                                            IMainPresenter mainPresenter)
        {
            unityC
                  .RegisterType<IPP_RollerPropertyUC, PP_RollerPropertyUC>()
                  .RegisterType<IPP_RollerPropertyUCPresenter, PP_RollerPropertyUCPresenter>();
            PP_RollerPropertyUCPresenter roller = unityC.Resolve<PP_RollerPropertyUCPresenter>();
            roller._unityC = unityC;
            roller._panelModel = panelModel;
            roller._mainPresenter = mainPresenter;
            return roller;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_RollersTypesVisibility", new Binding("Visible", _panelModel, "Panel_RollersTypesVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_RollersTypes", new Binding("Text", _panelModel, "Panel_RollersTypes", true, DataSourceUpdateMode.OnPropertyChanged));


            return binding;
        }



    }
}
