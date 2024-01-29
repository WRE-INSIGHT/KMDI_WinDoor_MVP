using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_DHandlePropertyUCPresenter : IPP_DHandlePropertyUCPresenter
    {
        IPP_DHandlePropertyUC _pp_DHandlePropertyUC;

        private IUnityContainer _unityC;
        private IPanelModel _panelModel;

        public PP_DHandlePropertyUCPresenter(IPP_DHandlePropertyUC pp_DHandlePropertyUC)
        {
            _pp_DHandlePropertyUC = pp_DHandlePropertyUC;

            SubscribeToEventSetUp();
        }

        private void SubscribeToEventSetUp()
        {
            _pp_DHandlePropertyUC.PPDHandlePropertyUCLoadEventRaised += _pp_DHandlePropertyUC_PPDHandlePropertyUCLoadEventRaised;
            _pp_DHandlePropertyUC.cmb_DArtNoSelectedValueChangedEventRaised += _pp_DHandlePropertyUC_cmb_DArtNoSelectedValueChangedEventRaised;
        }

        private void _pp_DHandlePropertyUC_cmb_DArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_DHandleOutsideArtNo = (D_HandleArtNo)((ComboBox)sender).SelectedValue;
        }

        private void _pp_DHandlePropertyUC_PPDHandlePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_DHandlePropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_DHandlePropertyUC GetDHandlePropertyUC()
        {
            return _pp_DHandlePropertyUC;
        }


        public IPP_DHandlePropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_DHandlePropertyUC, PP_DHandlePropertyUC>()
                .RegisterType<IPP_DHandlePropertyUCPresenter, PP_DHandlePropertyUCPresenter>();
            PP_DHandlePropertyUCPresenter DHandle = unityC.Resolve<PP_DHandlePropertyUCPresenter>();
            DHandle._unityC = unityC;
            DHandle._panelModel = panelModel;

            return DHandle;
        }


        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_DHandleOutsideArtNo", new Binding("Text", _panelModel, "Panel_DHandleOutsideArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_DHandleOptionVisibilty", new Binding("Visible", _panelModel, "Panel_DHandleOptionVisibilty", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
