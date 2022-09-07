using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_DHandle_IOLockingPropertyUCPresenter : IPP_DHandle_IOLockingPropertyUCPresenter
    {
        IPP_DHandle_IOLockingPropertyUC _pp_DHandle_IOLockingPropertyUC;

        private IUnityContainer _unityC;
        private IPanelModel _panelModel;
        private IMainPresenter _mainPresenter;

        public PP_DHandle_IOLockingPropertyUCPresenter(IPP_DHandle_IOLockingPropertyUC pp_DHandle_IOLockingPropertyUC)
        {
            _pp_DHandle_IOLockingPropertyUC = pp_DHandle_IOLockingPropertyUC;

            SubscribeToEventSetUp();
        }

        private void SubscribeToEventSetUp()
        {
            _pp_DHandle_IOLockingPropertyUC.PPDHandleIOLockingPropertyUCLoadEventRaised += _pp_DHandle_IOLockingPropertyUC_PPDHandleIOLockingPropertyUCLoadEventRaised;
            _pp_DHandle_IOLockingPropertyUC.cmbD_IOLockingArtNoSelectedValueChangedEventRaised += _pp_DHandle_IOLockingPropertyUC_cmbD_IOLockingArtNoSelectedValueChangedEventRaised;
        }

        private void _pp_DHandle_IOLockingPropertyUC_cmbD_IOLockingArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_DHandleIOLockingArtNo = (D_Handle_IO_LockingArtNo)((ComboBox)sender).SelectedValue;
        }

        private void _pp_DHandle_IOLockingPropertyUC_PPDHandleIOLockingPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_DHandle_IOLockingPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_DHandle_IOLockingPropertyUC GetDHandle_IOLockingPropertyUC()
        {
            return _pp_DHandle_IOLockingPropertyUC;

        }
        public IPP_DHandle_IOLockingPropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                          IPanelModel panelModel,
                                                                          IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IPP_DHandle_IOLockingPropertyUC, PP_DHandle_IOLockingPropertyUC>()
                .RegisterType<IPP_DHandle_IOLockingPropertyUCPresenter, PP_DHandle_IOLockingPropertyUCPresenter>();
            PP_DHandle_IOLockingPropertyUCPresenter DHandle_IOL = unityC.Resolve<PP_DHandle_IOLockingPropertyUCPresenter>();
            DHandle_IOL._unityC = unityC;
            DHandle_IOL._panelModel = panelModel;
            DHandle_IOL._mainPresenter = mainPresenter;

            return DHandle_IOL;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_DHandleIOLockingArtNo", new Binding("Text", _panelModel, "Panel_DHandleIOLockingArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_DHandleIOLockingOptionVisibilty", new Binding("Visible", _panelModel, "Panel_DHandleIOLockingOptionVisibilty", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
