using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Variables;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public class FP_ScreenPropertyUCPresenter : IFP_ScreenPropertyUCPresenter
    {
        IFP_ScreenPropertyUC _screenPropertyUC;

        private IUnityContainer _unityC;
        private IFrameModel _frameModel;
        private IMainPresenter _mainPresenter;
        private IFramePropertiesUCPresenter _FramePropertiesUCPresenter;

        public FP_ScreenPropertyUCPresenter(IFP_ScreenPropertyUC screenPropertyUC)
        {
            _screenPropertyUC = screenPropertyUC;


            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _screenPropertyUC.FScreenPropertyUCLoadEventRaised += _screenPropertyUC_FScreenPropertyUCLoadEventRaised;
            _screenPropertyUC.ScreenCheckedChangedEventRaised += _screenPropertyUC_ScreenCheckedChangedEventRaised;
            //_screenPropertyUC.screenHeightOptionCheckedChangedEventRaised += _screenPropertyUC_screenHeightOptionCheckedChangedEventRaised;
            _screenPropertyUC.nudScreenHeightValueChangedEventRaised += _screenPropertyUC_nudScreenHeightValueChangedEventRaised;
        }

        private void _screenPropertyUC_nudScreenHeightValueChangedEventRaised(object sender, EventArgs e)
        {
            _frameModel.Frame_ScreenFrameHeight = (int)((NumericUpDown)sender).Value;
            _mainPresenter.GetCurrentPrice();
        }



        ConstantVariables constants = new ConstantVariables();

        private void _screenPropertyUC_ScreenCheckedChangedEventRaised(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            if (_mainPresenter.ItemLoad == false)
            {
                if (chk.Checked == false)
                {
                    chk.Text = "No";
                    _frameModel.Frame_ScreenHeightVisibility = false;
                    _frameModel.Frame_ScreenOption = false;
                    _FramePropertiesUCPresenter.GetFramePropertiesUC().AddHT_PanelBody(-constants.frame_ScreenHeightProperty_PanelHeight);
                    _frameModel.Frame_ScreenHeightOption = false;
                }
                else if (chk.Checked == true)
                {
                    chk.Text = "Yes";
                    _frameModel.Frame_ScreenHeightVisibility = true;
                    _frameModel.Frame_ScreenOption = true;
                    _FramePropertiesUCPresenter.GetFramePropertiesUC().AddHT_PanelBody(constants.frame_ScreenHeightProperty_PanelHeight);
                }
            }
            else
            {
                if (chk.Checked == true)
                {
                    chk.Text = "Yes";
                    _frameModel.Frame_ScreenHeightVisibility = true;
                    _frameModel.Frame_ScreenOption = true;
                    _FramePropertiesUCPresenter.GetFramePropertiesUC().AddHT_PanelBody(-constants.frame_ScreenHeightProperty_PanelHeight);
                    _FramePropertiesUCPresenter.GetFramePropertiesUC().AddHT_PanelBody(constants.frame_ScreenHeightProperty_PanelHeight);
                }
            }

            _mainPresenter.GetCurrentPrice();
        }

        private void _screenPropertyUC_FScreenPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _screenPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IFP_ScreenPropertyUC GetScreenPropertyUC()
        {
            return _screenPropertyUC;
        }



        public IFP_ScreenPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IFrameModel frameModel,
                                                            IMainPresenter mainPresenter,
                                                            IFramePropertiesUCPresenter framePropertiesUCPresenter)
        {
            unityC
                    .RegisterType<IFP_ScreenPropertyUC, FP_ScreenPropertyUC>()
                    .RegisterType<IFP_ScreenPropertyUCPresenter, FP_ScreenPropertyUCPresenter>();
            FP_ScreenPropertyUCPresenter screen = unityC.Resolve<FP_ScreenPropertyUCPresenter>();

            screen._unityC = unityC;
            screen._frameModel = frameModel;
            screen._mainPresenter = mainPresenter;
            screen._FramePropertiesUCPresenter = framePropertiesUCPresenter;

            return screen;
        }


        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Frame_ScreenHeightOption", new Binding("Checked", _frameModel, "Frame_ScreenHeightOption", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_ScreenVisibility", new Binding("Visible", _frameModel, "Frame_ScreenVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_ScreenHeightVisibility", new Binding("Visible", _frameModel, "Frame_ScreenHeightVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_ScreenOption", new Binding("Checked", _frameModel, "Frame_ScreenOption", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_ScreenFrameHeightEnable", new Binding("Enabled", _frameModel, "Frame_ScreenFrameHeightEnable", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_ScreenFrameHeight", new Binding("Value", _frameModel, "Frame_ScreenFrameHeight", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
