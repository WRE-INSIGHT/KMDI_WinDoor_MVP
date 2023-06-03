using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_SlidingTypePropertyUCPresenter : IPP_SlidingTypePropertyUCPresenter
    {
        IPP_SlidingTypePropertyUC _slidingTypePropertyUC;
        private IPanelModel _panelModel;
        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;

        public PP_SlidingTypePropertyUCPresenter(IPP_SlidingTypePropertyUC slidingTypePropertyUC)
        {
            _slidingTypePropertyUC = slidingTypePropertyUC;

            SubcribeToEventSetup();
        }

        private void SubcribeToEventSetup()
        {
            _slidingTypePropertyUC.PPSlidingTypePropertyUCLoadEventRaised += _slidingTypePropertyUC_PPSlidingTypePropertyUCLoadEventRaised;
            _slidingTypePropertyUC.cmbSlidingTypeSelectedValueChangedEventRaised += _slidingTypePropertyUC_cmbSlidingTypeSelectedValueChangedEventRaised;
        }

        private void _slidingTypePropertyUC_cmbSlidingTypeSelectedValueChangedEventRaised(object sender, System.EventArgs e)
        {
            if (_mainPresenter.ItemLoad == false)
            {
                _mainPresenter.SetChangesMark();
                ComboBox cmbSlidingType = (ComboBox)sender;
                _panelModel.Panel_SlidingTypes = (SlidingTypes)cmbSlidingType.SelectedValue;
                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            }
        }

        private void _slidingTypePropertyUC_PPSlidingTypePropertyUCLoadEventRaised(object sender, System.EventArgs e)
        {
            _slidingTypePropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_SlidingTypePropertyUC GetSlidingTypePropertyUC()
        {
            return _slidingTypePropertyUC;
        }
        public IPP_SlidingTypePropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                 IPanelModel panelModel,
                                                                 IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IPP_SlidingTypePropertyUC, PP_SlidingTypePropertyUC>()
                .RegisterType<IPP_SlidingTypePropertyUCPresenter, PP_SlidingTypePropertyUCPresenter>();
            PP_SlidingTypePropertyUCPresenter SlidingTypePresenter = unityC.Resolve<PP_SlidingTypePropertyUCPresenter>();
            SlidingTypePresenter._unityC = unityC;
            SlidingTypePresenter._panelModel = panelModel;
            SlidingTypePresenter._mainPresenter = mainPresenter;

            return SlidingTypePresenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_SlidingTypes", new Binding("Text", _panelModel, "Panel_SlidingTypes", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_SlidingTypeVisibility", new Binding("Visible", _panelModel, "Panel_SlidingTypeVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
