using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public class FP_TrackProfilePropertyUCPresenter : IFP_TrackProfilePropertyUCPresenter
    {
        IFP_TrackProfilePropertyUC _TrackProfilePropertyUC;

        private IUnityContainer _unityC;
        private IFrameModel _frameModel;
        private IMainPresenter _mainPresenter;

        public FP_TrackProfilePropertyUCPresenter(IFP_TrackProfilePropertyUC TrackProfilePropertyUC)
        {
            _TrackProfilePropertyUC = TrackProfilePropertyUC;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _TrackProfilePropertyUC.TrackProfilePropertyUCLoadEventRaised += _TrackProfilePropertyUC_TrackProfilePropertyUCLoadEventRaised;
        }

        private void _TrackProfilePropertyUC_TrackProfilePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _TrackProfilePropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IFP_TrackProfilePropertyUC GetTrackProfilePropertyUC()
        {
            return _TrackProfilePropertyUC;
        }

        public IFP_TrackProfilePropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                     IFrameModel frameModel,
                                                                     IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IFP_TrackProfilePropertyUCPresenter, FP_TrackProfilePropertyUCPresenter>()
                .RegisterType<IFP_TrackProfilePropertyUC, FP_TrackProfilePropertyUC>();
            FP_TrackProfilePropertyUCPresenter TrackProfile = unityC.Resolve<FP_TrackProfilePropertyUCPresenter>();

            TrackProfile._unityC = unityC;
            TrackProfile._frameModel = frameModel;
            TrackProfile._mainPresenter = mainPresenter;

            return TrackProfile;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Frame_TrackProfileArtNoVisibility", new Binding("VISIBLE", _frameModel, "Frame_TrackProfileArtNoVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_TrackProfileArtNo", new Binding("Text", _frameModel, "Frame_TrackProfileArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
