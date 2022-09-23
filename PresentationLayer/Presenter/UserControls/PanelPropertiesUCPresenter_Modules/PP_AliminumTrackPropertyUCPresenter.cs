using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_AliminumTrackPropertyUCPresenter : IPP_AliminumTrackPropertyUCPresenter
    {
        IPP_AliminumTrackPropertyUC _aluminumTrackUC;

        private IUnityContainer _unityC;
        private IPanelModel _panelModel;
        private IMainPresenter _mainPresenter;


        public PP_AliminumTrackPropertyUCPresenter(IPP_AliminumTrackPropertyUC aluminumTrackUC)
        {
            _aluminumTrackUC = aluminumTrackUC;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _aluminumTrackUC.PPAliminumTrackPropertyUCLoadEventRaised += _aluminumTrackUC_PPAliminumTrackPropertyUCLoadEventRaised;
        }

        private void _aluminumTrackUC_PPAliminumTrackPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _aluminumTrackUC.ThisBinding(CreateBindingDictionary());
            _aluminumTrackUC.GetNudAluminumTrackQty().Value = 1;
        }

        public IPP_AliminumTrackPropertyUC GetAliminumTrackPropertyUC()
        {
            return _aluminumTrackUC;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_AluminumTrackQty", new Binding("Text", _panelModel, "Panel_AluminumTrackQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_AluminumTrackQtyVisibility", new Binding("Visible", _panelModel, "Panel_AluminumTrackQtyVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

        public IPP_AliminumTrackPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                   IPanelModel panelModel,
                                                                   IMainPresenter mainPresenter)
        {
            unityC
               .RegisterType<IPP_AliminumTrackPropertyUC, PP_AliminumTrackPropertyUC>()
               .RegisterType<IPP_AliminumTrackPropertyUCPresenter, PP_AliminumTrackPropertyUCPresenter>();
            PP_AliminumTrackPropertyUCPresenter alumTrack = unityC.Resolve<PP_AliminumTrackPropertyUCPresenter>();
            alumTrack._unityC = unityC;
            alumTrack._panelModel = panelModel;
            alumTrack._mainPresenter = mainPresenter;

            return alumTrack;

        }
    }
}
