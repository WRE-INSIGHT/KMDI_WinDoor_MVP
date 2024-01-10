using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_CenterProfilePropertyUCPresenter : IPP_CenterProfilePropertyUCPresenter
    {
        IPP_CenterProfilePropertyUC _centerProfilePropertyUC;

        private IMainPresenter _mainPresenter;
        private IUnityContainer _unityC;
        private IPanelModel _panelModel;

        public PP_CenterProfilePropertyUCPresenter(IPP_CenterProfilePropertyUC centerProfilePropertyUC)
        {
            _centerProfilePropertyUC = centerProfilePropertyUC;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _centerProfilePropertyUC.CenterProfilePropertyUCLoadEventRaised += _centerProfilePropertyUC_CenterProfilePropertyUCLoadEventRaised;
            _centerProfilePropertyUC.CenterProfileArtNoSelectedValueChangedEventRaised += _centerProfilePropertyUC_CenterProfileArtNoSelectedValueChangedEventRaised;
        }

        private void _centerProfilePropertyUC_CenterProfileArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if(_mainPresenter.ItemLoad == false)
            {
                _panelModel.Panel_CenterProfileArtNo = (CenterProfile_ArticleNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _centerProfilePropertyUC_CenterProfilePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _centerProfilePropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_CenterProfilePropertyUC GetCenterProfilePropertyUC()
        {
            return _centerProfilePropertyUC;
        }

        public IPP_CenterProfilePropertyUCPresenter CreateNewInstance(IMainPresenter mainPresenter,
                                                                      IUnityContainer unityC,
                                                                      IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_CenterProfilePropertyUC, PP_CenterProfilePropertyUC>()
                .RegisterType<IPP_CenterProfilePropertyUCPresenter, PP_CenterProfilePropertyUCPresenter>();
            PP_CenterProfilePropertyUCPresenter CenterProfile = unityC.Resolve<PP_CenterProfilePropertyUCPresenter>();
            CenterProfile._mainPresenter = mainPresenter;
            CenterProfile._unityC = unityC;
            CenterProfile._panelModel = panelModel;

            return CenterProfile;
        }
        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_CenterProfileVisibility", new Binding("Visible", _panelModel, "Panel_CenterProfileVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_CenterProfileArtNo", new Binding("Text", _panelModel, "Panel_CenterProfileArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
