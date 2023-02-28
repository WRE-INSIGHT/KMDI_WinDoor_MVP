using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

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
            _TrackProfilePropertyUC.TrackProfileSelectedValueChangedEventRaised += _TrackProfilePropertyUC_TrackProfileSelectedValueChangedEventRaised;
        }

        private void _TrackProfilePropertyUC_TrackProfileSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _frameModel.Frame_TrackProfileArtNo = (TrackProfile_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _TrackProfilePropertyUC_TrackProfilePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _frameModel.Frame_TrackProfileArtNo = TrackProfile_ArticleNo._none;
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
            Dictionary<string, Binding> bindingTrack = new Dictionary<string, Binding>();

            bindingTrack.Add("Frame_TrackProfileArtNoVisibility", new Binding("Visible", _frameModel, "Frame_TrackProfileArtNoVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            bindingTrack.Add("Frame_TrackProfileArtNo", new Binding("Text", _frameModel, "Frame_TrackProfileArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return bindingTrack;
        }
    }
}
