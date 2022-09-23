using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public class FP_FrameConnectionTypePropertyUCPresenter : IFP_FrameConnectionTypePropertyUCPresenter
    {
        IFP_FrameConnectionTypePropertyUC _fp_frameConnectionTypePropertyUC;

        private IUnityContainer _unityC;
        private IFrameModel _frameModel;
        private IMainPresenter _mainPresenter;

        public FP_FrameConnectionTypePropertyUCPresenter(IFP_FrameConnectionTypePropertyUC fp_frameConnectionTypePropertyUC)
        {
            _fp_frameConnectionTypePropertyUC = fp_frameConnectionTypePropertyUC;

            SubscribeToEventSetUp();
        }

        private void SubscribeToEventSetUp()
        {
            _fp_frameConnectionTypePropertyUC.FrameConnectionTypePropertyUCLoadEventRaised += _fp_frameConnectionTypePropertyUC_FrameConnectionTypePropertyUCLoadEventRaised;
            _fp_frameConnectionTypePropertyUC.cmbConnectionTypeSelectedValueChangedEventRaised += _fp_frameConnectionTypePropertyUC_cmbConnectionTypeSelectedValueChangedEventRaised;
        }

        private void _fp_frameConnectionTypePropertyUC_cmbConnectionTypeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _frameModel.Frame_ConnectionType = (FrameConnectionType)((ComboBox)sender).SelectedValue;
        }

        private void _fp_frameConnectionTypePropertyUC_FrameConnectionTypePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _fp_frameConnectionTypePropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IFP_FrameConnectionTypePropertyUC GetFrameConnectionTypePropertyUC()
        {
            return _fp_frameConnectionTypePropertyUC;
        }

        public IFP_FrameConnectionTypePropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                         IFrameModel frameModel,
                                                                         IMainPresenter mainPresenter)
        {
            unityC
                   .RegisterType<IFP_FrameConnectionTypePropertyUC, FP_FrameConnectionTypePropertyUC>()
                   .RegisterType<IFP_FrameConnectionTypePropertyUCPresenter, FP_FrameConnectionTypePropertyUCPresenter>();
            FP_FrameConnectionTypePropertyUCPresenter connector = unityC.Resolve<FP_FrameConnectionTypePropertyUCPresenter>();

            connector._unityC = unityC;
            connector._frameModel = frameModel;
            connector._mainPresenter = mainPresenter;

            return connector;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Frame_ConnectionType", new Binding("Text", _frameModel, "Frame_ConnectionType", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_ConnectionTypeVisibility", new Binding("Visible", _frameModel, "Frame_ConnectionTypeVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

    }
}
