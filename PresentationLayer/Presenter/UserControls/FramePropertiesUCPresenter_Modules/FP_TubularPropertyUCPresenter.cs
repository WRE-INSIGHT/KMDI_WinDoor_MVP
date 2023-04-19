using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Variables;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public class FP_TubularPropertyUCPresenter : IFP_TubularPropertyUCPresenter
    {
        IFP_TubularPropertyUC _tubularPropertyUC;
        private IMainPresenter _mainPresenter;
        private IFrameModel _frameModel;
        private IUnityContainer _unityC;
        private IFramePropertiesUCPresenter _framePropertiesUCPresenter;

        ConstantVariables constants = new ConstantVariables();

        public FP_TubularPropertyUCPresenter(IFP_TubularPropertyUC tubularPropertyUC)
        {
            _tubularPropertyUC = tubularPropertyUC;

            SubcribeToEventSetup();
        }

        private void SubcribeToEventSetup()
        {
            _tubularPropertyUC.FPTubularPropertyUCLoadEventRaised += _tubularPropertyUC_FPTubularPropertyUCLoadEventRaised;
            _tubularPropertyUC.chkTubularCheckedChangedEventRaised += _tubularPropertyUC_chkTubularCheckedChangedEventRaised;
            _tubularPropertyUC.nudTubularWidthValueChangedEventRaised += _tubularPropertyUC_nudTubularWidthValueChangedEventRaised;
            _tubularPropertyUC.nudTubularHeightValueChangedEventRaised += _tubularPropertyUC_nudTubularHeightValueChangedEventRaised;
        }

        private void _tubularPropertyUC_FPTubularPropertyUCLoadEventRaised(object sender, System.EventArgs e)
        {
            _tubularPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        private void _tubularPropertyUC_chkTubularCheckedChangedEventRaised(object sender, System.EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            if (chk.Checked == false)
            {
                chk.Text = "No";
                _frameModel.Frame_TubularWidthVisibility = false;
                _frameModel.Frame_TubularHeightVisibility = false;
                _frameModel.Frame_TubularOption = false;
                _frameModel.FrameProp_Height -= constants.frame_TubularHeightAndWidth;
                _framePropertiesUCPresenter.GetFramePropertiesUC().AddHT_PanelBody(-constants.frame_TubularHeightAndWidth);
            }
            else if (chk.Checked == true)
            {
                chk.Text = "Yes";
                _frameModel.Frame_TubularWidthVisibility = true;
                _frameModel.Frame_TubularHeightVisibility = true;
                _frameModel.Frame_TubularOption = true;
                _frameModel.FrameProp_Height += constants.frame_TubularHeightAndWidth;
                _framePropertiesUCPresenter.GetFramePropertiesUC().AddHT_PanelBody(constants.frame_TubularHeightAndWidth);
            }

            _mainPresenter.GetCurrentPrice();
        }

        private void _tubularPropertyUC_nudTubularWidthValueChangedEventRaised(object sender, System.EventArgs e)
        {
            _frameModel.Frame_TubularWidth = (int)((NumericUpDown)sender).Value;
            _mainPresenter.GetCurrentPrice();
        }

        private void _tubularPropertyUC_nudTubularHeightValueChangedEventRaised(object sender, System.EventArgs e)
        {
            _frameModel.Frame_TubularHeight = (int)((NumericUpDown)sender).Value;
            _mainPresenter.GetCurrentPrice();
        }

        public IFP_TubularPropertyUC GetTubularPropertyUC()
        {
            return _tubularPropertyUC;
        }

        public IFP_TubularPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                             IFrameModel frameModel,
                                                             IMainPresenter mainPresenter,
                                                             IFramePropertiesUCPresenter framePropertiesUCPresenter)
        {
            unityC
                 .RegisterType<IFP_TubularPropertyUCPresenter, FP_TubularPropertyUCPresenter>()
                 .RegisterType<IFP_TubularPropertyUC, FP_TubularPropertyUC>();
            FP_TubularPropertyUCPresenter tubular = unityC.Resolve<FP_TubularPropertyUCPresenter>();

            tubular._mainPresenter = mainPresenter;
            tubular._frameModel = frameModel;
            tubular._unityC = unityC;
            tubular._framePropertiesUCPresenter = framePropertiesUCPresenter;

            return tubular;
        }
        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Frame_TubularVisibility", new Binding("Visible", _frameModel, "Frame_TubularVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_TubularOption", new Binding("Checked", _frameModel, "Frame_TubularOption", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_TubularWidthVisibility", new Binding("Visible", _frameModel, "Frame_TubularWidthVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_TubularHeightVisibility", new Binding("Visible", _frameModel, "Frame_TubularHeightVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_TubularHeight", new Binding("Value", _frameModel, "Frame_TubularHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_TubularWidth", new Binding("Value", _frameModel, "Frame_TubularWidth", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
