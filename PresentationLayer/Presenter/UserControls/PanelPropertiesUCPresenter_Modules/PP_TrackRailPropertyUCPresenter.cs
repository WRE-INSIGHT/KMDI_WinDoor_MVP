using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_TrackRailPropertyUCPresenter : IPP_TrackRailPropertyUCPresenter
    {
        IPP_TrackRailPropertyUC _pp_TrackRailPropertyUC;

        private IUnityContainer _unityC;
        private IPanelModel _panelModel;

        public PP_TrackRailPropertyUCPresenter(IPP_TrackRailPropertyUC pp_TrackRailPropertyUC)
        {
            _pp_TrackRailPropertyUC = pp_TrackRailPropertyUC;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _pp_TrackRailPropertyUC.cmbTrackRailArtNoSelectedValueChangedEventRaised += _pp_TrackRailPropertyUC_cmbTrackRailArtNoSelectedValueChangedEventRaised;
            _pp_TrackRailPropertyUC.PPTrackRailPropertyUCLoadEventRaised += _pp_TrackRailPropertyUC_PPTrackRailPropertyUCLoadEventRaised;
        }

        private void _pp_TrackRailPropertyUC_PPTrackRailPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_TrackRailPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        private void _pp_TrackRailPropertyUC_cmbTrackRailArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_TrackRailArtNo = (TrackRail_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        public IPP_TrackRailPropertyUC GetTrackRailPropertyUC()
        {
            return _pp_TrackRailPropertyUC;
        }

        public IPP_TrackRailPropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                  IPanelModel panelModel)
        {
            unityC
                    .RegisterType<IPP_TrackRailPropertyUC, PP_TrackRailPropertyUC>()
                    .RegisterType<IPP_TrackRailPropertyUCPresenter, PP_TrackRailPropertyUCPresenter>();
            PP_TrackRailPropertyUCPresenter TrackRail = unityC.Resolve<PP_TrackRailPropertyUCPresenter>();
            TrackRail._unityC = unityC;
            TrackRail._panelModel = panelModel;

            return TrackRail;
        }


        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_TrackRailArtNo", new Binding("Text", _panelModel, "Panel_TrackRailArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_TrackRailArtNoVisibility", new Binding("Visible", _panelModel, "Panel_TrackRailArtNoVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
