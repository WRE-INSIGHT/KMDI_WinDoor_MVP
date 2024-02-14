using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_RotoswingForSlidingPropertyUCPresenter : IPP_RotoswingForSlidingPropertyUCPresenter
    {
        IPP_RotoswingForSlidingPropertyUC _pp_RotoswingForSlidingPropertyUC;

        private IUnityContainer _unityC;
        private IPanelModel _panelModel;
        bool _initialLoad = true;

        public PP_RotoswingForSlidingPropertyUCPresenter(IPP_RotoswingForSlidingPropertyUC pp_RotoswingForSlidingPropertyUC)
        {
            _pp_RotoswingForSlidingPropertyUC = pp_RotoswingForSlidingPropertyUC;

            SubScribeToEventSetUp();
        }

        private void SubScribeToEventSetUp()
        {
            _pp_RotoswingForSlidingPropertyUC.PPRotoswingForSlidingPropertyUCLoadEventRaised += _pp_RotoswingForSlidingPropertyUC_PPRotoswingForSlidingPropertyUCLoadEventRaised;
            _pp_RotoswingForSlidingPropertyUC.cmbRotoswingForSlidingNoSelectedValueChangedEventRaised += _pp_RotoswingForSlidingPropertyUC_cmbRotoswingForSlidingNoSelectedValueChangedEventRaised;
        }

        private void _pp_RotoswingForSlidingPropertyUC_cmbRotoswingForSlidingNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (!_panelModel.PanelModelIsFromLoad)
            {
                _panelModel.Panel_RotoswingForSlidingHandleArtNo = (Rotoswing_Sliding_HandleArtNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _pp_RotoswingForSlidingPropertyUC_PPRotoswingForSlidingPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_RotoswingForSlidingPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_RotoswingForSlidingPropertyUC GetRotoswingForSlidingPropertyUC()
        {
            return _pp_RotoswingForSlidingPropertyUC;
        }

        public IPP_RotoswingForSlidingPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                            IPanelModel panelModel)
        {
            unityC
                    .RegisterType<IPP_RotoswingForSlidingPropertyUC, PP_RotoswingForSlidingPropertyUC>()
                    .RegisterType<IPP_RotoswingForSlidingPropertyUCPresenter, PP_RotoswingForSlidingPropertyUCPresenter>();
            PP_RotoswingForSlidingPropertyUCPresenter RotoswingSliding = unityC.Resolve<PP_RotoswingForSlidingPropertyUCPresenter>();
            RotoswingSliding._unityC = unityC;
            RotoswingSliding._panelModel = panelModel;

            return RotoswingSliding;
        }
        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_RotoswingForSlidingHandleArtNo", new Binding("Text", _panelModel, "Panel_RotoswingForSlidingHandleArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_RotoswingForSlidingHandleOptionVisibilty", new Binding("Visible", _panelModel, "Panel_RotoswingForSlidingHandleOptionVisibilty", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
