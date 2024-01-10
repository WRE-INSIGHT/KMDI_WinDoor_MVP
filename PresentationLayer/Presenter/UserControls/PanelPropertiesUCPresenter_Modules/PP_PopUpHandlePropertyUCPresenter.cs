using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_PopUpHandlePropertyUCPresenter : IPP_PopUpHandlePropertyUCPresenter
    {
        IPP_PopUpHandlePropertyUC _pp_PopUpHandlePropertyUC;

        private IUnityContainer _unityC;
        private IPanelModel _panelModel;

        public PP_PopUpHandlePropertyUCPresenter(IPP_PopUpHandlePropertyUC pp_PopUpHandlePropertyUC)
        {
            _pp_PopUpHandlePropertyUC = pp_PopUpHandlePropertyUC;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _pp_PopUpHandlePropertyUC.PPPopUpHandlePropertyUCLoadEventRaiased += _pp_PopUpHandlePropertyUC_PPPopUpHandlePropertyUCLoadEventRaiased;
            _pp_PopUpHandlePropertyUC.cmbPopUpArtNoSelectedValueChangedEventRaiased += _pp_PopUpHandlePropertyUC_cmbPopUpArtNoSelectedValueChangedEventRaiased;
        }

        private void _pp_PopUpHandlePropertyUC_cmbPopUpArtNoSelectedValueChangedEventRaiased(object sender, EventArgs e)
        {
            if (!_panelModel.PanelModelIsFromLoad)
            {
                _panelModel.Panel_PopUpHandleArtNo = (PopUp_HandleArtNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _pp_PopUpHandlePropertyUC_PPPopUpHandlePropertyUCLoadEventRaiased(object sender, EventArgs e)
        {
            _pp_PopUpHandlePropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_PopUpHandlePropertyUC GetPopUpHandlePropertyUC()
        {
            return _pp_PopUpHandlePropertyUC;
        }

        public IPP_PopUpHandlePropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                 IPanelModel panelModel)
        {
            unityC
                    .RegisterType<IPP_PopUpHandlePropertyUC, PP_PopUpHandlePropertyUC>()
                    .RegisterType<IPP_PopUpHandlePropertyUCPresenter, PP_PopUpHandlePropertyUCPresenter>();
            PP_PopUpHandlePropertyUCPresenter PopUp = unityC.Resolve<PP_PopUpHandlePropertyUCPresenter>();
            PopUp._unityC = unityC;
            PopUp._panelModel = panelModel;

            return PopUp;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> Binding = new Dictionary<string, Binding>();

            Binding.Add("Panel_PopUpHandleArtNo", new Binding("Text", _panelModel, "Panel_PopUpHandleArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            Binding.Add("Panel_PopUpHandleOptionVisibilty", new Binding("Visible", _panelModel, "Panel_PopUpHandleOptionVisibilty", true, DataSourceUpdateMode.OnPropertyChanged));

            return Binding;
        }
    }
}
