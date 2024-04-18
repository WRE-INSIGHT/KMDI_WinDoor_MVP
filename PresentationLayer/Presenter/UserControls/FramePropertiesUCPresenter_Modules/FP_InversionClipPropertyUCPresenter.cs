using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public class FP_InversionClipPropertyUCPresenter : IFP_InversionClipPropertyUCPresenter
    {
        IFP_InversionClipPropertyUC _InversionClipPropertyUC;

        private IFrameModel _frameModel;
        private IUnityContainer _unityC;

        public FP_InversionClipPropertyUCPresenter(IFP_InversionClipPropertyUC InversionClipPropertyUC)
        {
            _InversionClipPropertyUC = InversionClipPropertyUC;

            SubscribeToEventSetUp();
        }

        private void SubscribeToEventSetUp()
        {
            _InversionClipPropertyUC.InversionClipPropertyUCLoadEventRaised += _InversionClipPropertyUC_InversionClipPropertyUCLoadEventRaised;
            _InversionClipPropertyUC.InversionClipCheckedChangedEventRaised += _InversionClipPropertyUC_InversionClipCheckedChangedEventRaised;

        }


        private void _InversionClipPropertyUC_InversionClipPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _InversionClipPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        private void _InversionClipPropertyUC_InversionClipCheckedChangedEventRaised(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            if (chk.Checked == false)
            {
                chk.Text = "No";
                _frameModel.Frame_InversionClipOption = false;
            }
            else if (chk.Checked == true)
            {
                chk.Text = "Yes";
                _frameModel.Frame_InversionClipOption = true;
            }
        }

        public IFP_InversionClipPropertyUC GetInversionClipPropertyUC()
        {
            return _InversionClipPropertyUC;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Frame_InversionClipVisibility", new Binding("Visible", _frameModel, "Frame_InversionClipVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_InversionClipOption", new Binding("Checked", _frameModel, "Frame_InversionClipOption", true, DataSourceUpdateMode.OnPropertyChanged));


            return binding;
        }

        public IFP_InversionClipPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                      IFrameModel frameModel)
        {
            unityC
                .RegisterType<IFP_InversionClipPropertyUCPresenter, FP_InversionClipPropertyUCPresenter>()
                .RegisterType<IFP_InversionClipPropertyUC, FP_InversionClipPropertyUC>();
             
            FP_InversionClipPropertyUCPresenter InversionClipPropertyUCP = unityC.Resolve<FP_InversionClipPropertyUCPresenter>();
            InversionClipPropertyUCP._unityC = unityC;
            InversionClipPropertyUCP._frameModel = frameModel;

            return InversionClipPropertyUCP;
        }

    }
}
