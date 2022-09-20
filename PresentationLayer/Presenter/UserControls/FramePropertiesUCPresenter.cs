using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Variables;
using PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.FrameServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Frame.FrameModel;

namespace PresentationLayer.Presenter.UserControls
{
    public class FramePropertiesUCPresenter : IFramePropertiesUCPresenter, IPresenterCommon
    {
        IFramePropertiesUC _framePropertiesUC;

        IFP_BottomFramePropertyUCPresenter _fp_botFramePropertyUCP;
        IFP_SlidingRailsPropertyUCPresenter _fp_slidingRailsPropertyUCPresenter;

        private IMainPresenter _mainPresenter;
        private IFrameModel _frameModel;
        //private IFrameUC _frameUC;
        private IFrameServices _frameServices;
        IUnityContainer _unityC;

        ConstantVariables constants = new ConstantVariables();

        public FramePropertiesUCPresenter(IFramePropertiesUC framePropertiesUC,
                                          IFrameServices frameServices,
                                          IFP_BottomFramePropertyUCPresenter fp_botFramePropertyUCP,
                                          IFP_SlidingRailsPropertyUCPresenter fp_slidingRailsPropertyUCPresenter)
        {
            _framePropertiesUC = framePropertiesUC;
            _frameServices = frameServices;
            _fp_botFramePropertyUCP = fp_botFramePropertyUCP;
            _fp_slidingRailsPropertyUCPresenter = fp_slidingRailsPropertyUCPresenter;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _framePropertiesUC.FramePropertiesLoadEventRaised += new EventHandler(OnFramePropertiesLoadEventRaised);
            _framePropertiesUC.NumFHeightValueChangedEventRaised += new EventHandler(OnNumFHeightValueChangedEventRaised);
            _framePropertiesUC.NumFWidthValueChangedEventRaised += new EventHandler(OnNumFWidthValueChangedEventRaised);
            _framePropertiesUC.RdBtnCheckedChangedEventRaised += new EventHandler(OnRdBtnCheckedChangedEventRaised);
            _framePropertiesUC.cmbFrameProfileSelectedValueChangedEventRaised += _framePropertiesUC_cmbFrameProfileSelectedValueChangedEventRaised;
            _framePropertiesUC.cmbFrameReinfSelectedValueChangedEventRaised += _framePropertiesUC_cmbFrameReinfSelectedValueChangedEventRaised;
        }

        private void _framePropertiesUC_cmbFrameReinfSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _frameModel.Frame_ReinfArtNo = (FrameReinf_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        bool RailsDeductHt = false, RailsAdditionalHt = false;
        string prev_frameArtNo = "";
        private void _framePropertiesUC_cmbFrameProfileSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _frameModel.Frame_ArtNo = (FrameProfile_ArticleNo)((ComboBox)sender).SelectedValue;
             
            if (_frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6050 ||
                _frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6052)
            { 
                if (RailsAdditionalHt == true)
                {
                    _frameModel.Frame_SlidingRailsQtyVisibility = true;
                    _frameModel.FrameProp_Height += constants.frame_SlidingRailsQtyproperty_PanelHeight;
                    _framePropertiesUC.AddHT_PanelBody(constants.frame_SlidingRailsQtyproperty_PanelHeight);

                    RailsAdditionalHt = false;
                }


                RailsDeductHt = true;
            }
            else
            {
                if (RailsDeductHt == true)
                {
                    _frameModel.Frame_SlidingRailsQtyVisibility = false;
                    _frameModel.FrameProp_Height -= constants.frame_SlidingRailsQtyproperty_PanelHeight;
                    _framePropertiesUC.AddHT_PanelBody(-constants.frame_SlidingRailsQtyproperty_PanelHeight);

                    RailsDeductHt = false;
                }

                RailsAdditionalHt = true;
            }

            prev_frameArtNo = _frameModel.Frame_ArtNo.ToString();
        }

        string curr_rbtnText = "";
        private void OnRdBtnCheckedChangedEventRaised(object sender, EventArgs e)
        {
            RadioButton rbtn = (RadioButton)sender;

            _frameModel.Frame_Type = (Frame_Padding)Enum.Parse(typeof(Frame_Padding), rbtn.Text, true);

            if (curr_rbtnText == "Window" || curr_rbtnText == "Concrete")
            {
                _frameModel.Frame_BotFrameVisible = true;
                if (rbtn.Text == "Door" && rbtn.Checked == true)
                {
                    _frameModel.FrameProp_Height += constants.frame_botframeproperty_PanelHeight;
                    _framePropertiesUC.AddHT_PanelBody(constants.frame_botframeproperty_PanelHeight);
                }
            }
            else if (curr_rbtnText == "Door")
            {
                _frameModel.Frame_BotFrameVisible = false;
                if ((rbtn.Text == "Window" || rbtn.Text == "Concrete") &&
                    rbtn.Checked == true)
                {
                    _frameModel.FrameProp_Height -= constants.frame_botframeproperty_PanelHeight;
                    _framePropertiesUC.AddHT_PanelBody(-constants.frame_botframeproperty_PanelHeight);
                }
            }

            curr_rbtnText = rbtn.Text;

            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            _mainPresenter.basePlatform_MainPresenter.Invalidate_flpMainControls();
        }

        private void OnNumFWidthValueChangedEventRaised(object sender, EventArgs e)
        {
            NumericUpDown numW = (NumericUpDown)sender;
            _frameModel.Frame_Width = Convert.ToInt32(numW.Value);
            _frameModel.Set_DimensionsToBind_using_FrameZoom();
            _frameModel.Set_ImagerDimensions_using_ImagerZoom();

            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            _mainPresenter.basePlatform_MainPresenter.Invalidate_flpMainControls();
        }

        private void OnNumFHeightValueChangedEventRaised(object sender, EventArgs e)
        {
            NumericUpDown numH = (NumericUpDown)sender;
            _frameModel.Frame_Height = Convert.ToInt32(numH.Value);
            _frameModel.Set_DimensionsToBind_using_FrameZoom();
            _frameModel.Set_ImagerDimensions_using_ImagerZoom();

            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            _mainPresenter.basePlatform_MainPresenter.Invalidate_flpMainControls();
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> frameBinding = new Dictionary<string, Binding>();
            frameBinding.Add("Frame_ID", new Binding("FrameID", _frameModel, "Frame_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Name", new Binding("Text", _frameModel, "Frame_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Visible", new Binding("Visible", _frameModel, "Frame_Visible", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Width", new Binding("Value", _frameModel, "Frame_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Height", new Binding("Value", _frameModel, "Frame_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("FrameProp_Height", new Binding("Height", _frameModel, "FrameProp_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Type_Window", AddRadioCheckedBinding(_frameModel, "Frame_Type", FrameModel.Frame_Padding.Window));
            frameBinding.Add("Frame_Type_Door", AddRadioCheckedBinding(_frameModel, "Frame_Type", FrameModel.Frame_Padding.Door));
            frameBinding.Add("Frame_ArtNo", new Binding("Text", _frameModel, "Frame_ArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_ReinfArtNo", new Binding("Text", _frameModel, "Frame_ReinfArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Type", new Binding("Frame_Type", _frameModel, "Frame_Type", true, DataSourceUpdateMode.OnPropertyChanged));

            return frameBinding;
        }
        private Binding AddRadioCheckedBinding<T>(object dataSource, string dataMember, T trueValue)
        {
            var binding = new Binding(nameof(RadioButton.Checked), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += (s, a) => { if ((bool)a.Value) a.Value = trueValue; };
            binding.Format += (s, a) => a.Value = ((T)a.Value).Equals(trueValue);
            return binding;
        }

        private void OnFramePropertiesLoadEventRaised(object sender, EventArgs e)
        {
            _framePropertiesUC.ThisBinding(CreateBindingDictionary());

            curr_rbtnText = _frameModel.Frame_Type.ToString();
            prev_frameArtNo = _frameModel.Frame_ArtNo.ToString();

            IFP_BottomFramePropertyUCPresenter botFramePropUCP = _fp_botFramePropertyUCP.GetNewInstance(_frameModel, _unityC, _mainPresenter);
            UserControl botFramePropUC = (UserControl)botFramePropUCP.GetFP_BottomFramePropertiesUC();
            _framePropertiesUC.GetBodyPropertiesPNL().Controls.Add(botFramePropUC);
            botFramePropUC.Dock = DockStyle.Top;
            botFramePropUC.BringToFront();

            IFP_SlidingRailsPropertyUCPresenter RailsPropUCP = _fp_slidingRailsPropertyUCPresenter.GetNewInstance(_unityC, _frameModel, _mainPresenter);
            UserControl RailsPropUC = (UserControl)RailsPropUCP.GetSlidingRailsPropertyUC();
            _framePropertiesUC.GetBodyPropertiesPNL().Controls.Add(RailsPropUC);
            RailsPropUC.Dock = DockStyle.Top;
            RailsPropUC.BringToFront();

            if (_frameModel.Frame_Type == Frame_Padding.Door)
            {
                _frameModel.FrameProp_Height += constants.frame_botframeproperty_PanelHeight;
                _framePropertiesUC.AddHT_PanelBody(constants.frame_botframeproperty_PanelHeight);
            }

            if (_frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6050 || _frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6052)
            {
                _frameModel.FrameProp_Height += constants.frame_SlidingRailsQtyproperty_PanelHeight;
                _framePropertiesUC.AddHT_PanelBody(constants.frame_SlidingRailsQtyproperty_PanelHeight);
            }
            _framePropertiesUC.BringToFrontThis();
        }

        public IFramePropertiesUC GetFramePropertiesUC()
        {
            return _framePropertiesUC;
        }

        public IFramePropertiesUCPresenter GetNewInstance(IFrameModel frameModel,
                                                          IUnityContainer unityC,
                                                          //IFrameUC frameUC,
                                                          IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IFramePropertiesUC, FramePropertiesUC>()
                .RegisterType<IFramePropertiesUCPresenter, FramePropertiesUCPresenter>();
            FramePropertiesUCPresenter framePropertiesUCP = unityC.Resolve<FramePropertiesUCPresenter>();
            framePropertiesUCP._frameModel = frameModel;
            //framePropertiesUCP._frameUC = frameUC;
            framePropertiesUCP._mainPresenter = mainPresenter;
            framePropertiesUCP._unityC = unityC;

            return framePropertiesUCP;
        }

        public void SetFrameTypeRadioBtnEnabled(bool frameTypeEnabled)
        {
            _framePropertiesUC.SetFrameTypeRadioBtnEnabled(frameTypeEnabled);
        }
    }
}
