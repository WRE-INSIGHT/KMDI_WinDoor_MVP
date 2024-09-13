using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_CremonHandleOptionPropertyUCPresenter : IPP_CremonHandleOptionPropertyUCPresenter
    {
        IPP_CremonHandleOptionPropertyUC _CremonHandleOptionPropertyUC;
        
        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;

        public PP_CremonHandleOptionPropertyUCPresenter(IPP_CremonHandleOptionPropertyUC CremonHandleOptionPropertyUC)
        {
            _CremonHandleOptionPropertyUC = CremonHandleOptionPropertyUC;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _CremonHandleOptionPropertyUC.PPCremonHandleOptionPropertyUCLoadEventRaised += _CremonHandleOptionPropertyUC_PPCremonHandleOptionPropertyUCLoadEventRaised;
            _CremonHandleOptionPropertyUC.cmbCremonArtNoSelectedValueChangedEventRaised += _CremonHandleOptionPropertyUC_cmbCremonArtNoSelectedValueChangedEventRaised;
        }

        private void _CremonHandleOptionPropertyUC_cmbCremonArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            Cremon_HandleArtNo cremon = (Cremon_HandleArtNo)((ComboBox)sender).SelectedValue;
            _panelModel.Panel_CremonArtNo = cremon;
        }

        private void _CremonHandleOptionPropertyUC_PPCremonHandleOptionPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _CremonHandleOptionPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_CremonHandleOptionPropertyUC GetCremonHandleOptionPropertyUC()
        {
            return _CremonHandleOptionPropertyUC;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_CremonHandleArtNoVisibility", new Binding("Visible", _panelModel, "Panel_CremonHandleArtNoVisibility", true,DataSourceUpdateMode.OnPropertyChanged));
            //binding.Add("Panel_CremonArtNo", new Binding("Text",_panelModel, "Panel_CremonArtNo", true,DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

        public IPP_CremonHandleOptionPropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                           IMainPresenter mainPresenter,
                                                                           IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_CremonHandleOptionPropertyUCPresenter, PP_CremonHandleOptionPropertyUCPresenter>()
                .RegisterType<IPP_CremonHandleOptionPropertyUC, PP_CremonHandleOptionPropertyUC>();

            PP_CremonHandleOptionPropertyUCPresenter cremon = unityC.Resolve<PP_CremonHandleOptionPropertyUCPresenter>();
            cremon._unityC = unityC;
            cremon._mainPresenter = mainPresenter;
            cremon._panelModel = panelModel;

            return cremon;

        }
    }
}
