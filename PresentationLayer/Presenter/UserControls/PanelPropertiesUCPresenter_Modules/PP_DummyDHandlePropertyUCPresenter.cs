using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_DummyDHandlePropertyUCPresenter : IPP_DummyDHandlePropertyUCPresenter
    {
        IPP_DummyDHandlePropertyUC _pp_DummyDHandlePropertyUCPresenter;

        private IUnityContainer _unityC;
        private IPanelModel _panelModel;
        private IMainPresenter _mainPresenter;

        public PP_DummyDHandlePropertyUCPresenter(IPP_DummyDHandlePropertyUC pp_DummyDHandlePropertyUCPresenter)
        {
            _pp_DummyDHandlePropertyUCPresenter = pp_DummyDHandlePropertyUCPresenter;

            SubscribeToEventSetUp();
        }

        private void SubscribeToEventSetUp()
        {
            _pp_DummyDHandlePropertyUCPresenter.PPDummyDHandlePropertyUCLoadEventRaised += _pp_DummyDHandlePropertyUCPresenter_PPDummyDHandlePropertyUCLoadEventRaised;
            _pp_DummyDHandlePropertyUCPresenter.cmbDummyDArtNoSelectedValueChangedEventRaised += _pp_DummyDHandlePropertyUCPresenter_cmbDummyDArtNoSelectedValueChangedEventRaised;
        }

        private void _pp_DummyDHandlePropertyUCPresenter_cmbDummyDArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_DummyDHandleArtNo = (DummyD_HandleArtNo)((ComboBox)sender).SelectedValue;
        }

        private void _pp_DummyDHandlePropertyUCPresenter_PPDummyDHandlePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_DummyDHandlePropertyUCPresenter.ThisBinding(CreateBindingDictionary());
        }

        public IPP_DummyDHandlePropertyUC GetDummyDHandlePropertyUC()
        {
            return _pp_DummyDHandlePropertyUCPresenter;
        }


        public IPP_DummyDHandlePropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                     IPanelModel panelModel,
                                                                     IMainPresenter mainPresenter)
        {
            unityC
                   .RegisterType<IPP_DummyDHandlePropertyUC, PP_DummyDHandlePropertyUC>()
                   .RegisterType<IPP_DummyDHandlePropertyUCPresenter, PP_DummyDHandlePropertyUCPresenter>();
            PP_DummyDHandlePropertyUCPresenter DummyDHandle = unityC.Resolve<PP_DummyDHandlePropertyUCPresenter>();

            return DummyDHandle;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_DummyDHandleArtNo", new Binding("Text", _panelModel, "Panel_DummyDHandleArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_DummyDHandleOptionVisibilty", new Binding("Visible", _panelModel, "Panel_DummyDHandleOptionVisibilty", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
