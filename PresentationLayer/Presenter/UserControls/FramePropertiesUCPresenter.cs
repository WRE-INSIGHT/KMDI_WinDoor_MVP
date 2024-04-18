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

        private IFP_BottomFramePropertyUCPresenter _fp_botFramePropertyUCP;
        private IFP_SlidingRailsPropertyUCPresenter _fp_slidingRailsPropertyUCPresenter;
        private IFP_FrameConnectionTypePropertyUCPresenter _fp_frameConnectionTypePropertyUCPresenter;
        private IFP_TrackProfilePropertyUCPresenter _fp_TrackProfilePropertyUCPresenter;
        private IFP_ScreenPropertyUCPresenter _fp_ScreenPropertyUCPresenter;
        private IFP_TubularPropertyUCPresenter _fp_TubularPropertyUCPresenter;
        private IFP_CladdingQtyPropertyUCPresenter _fp_CladdingQtyPropertyUCPresenter;

        private IMainPresenter _mainPresenter;
        private IFrameModel _frameModel;
        //private IFrameUC _frameUC;
        private IFrameServices _frameServices;
        IUnityContainer _unityC;

        ConstantVariables constants = new ConstantVariables();

        public FramePropertiesUCPresenter(IFramePropertiesUC framePropertiesUC,
                                          IFrameServices frameServices,
                                          IFP_BottomFramePropertyUCPresenter fp_botFramePropertyUCP,
                                          IFP_SlidingRailsPropertyUCPresenter fp_slidingRailsPropertyUCPresenter,
                                          IFP_FrameConnectionTypePropertyUCPresenter fp_frameConnectionTypePropertyUCPresenter,
                                          IFP_TrackProfilePropertyUCPresenter fp_TrackProfilePropertyUCPresenter,
                                          IFP_ScreenPropertyUCPresenter fp_ScreenPropertyUCPresenter,
                                          IFP_TubularPropertyUCPresenter fp_TubularPropertyUCPresenter,
                                          IFP_CladdingQtyPropertyUCPresenter fp_CladdingQtyPropertyUCPresenter)
        {
            _framePropertiesUC = framePropertiesUC;
            _frameServices = frameServices;
            _fp_botFramePropertyUCP = fp_botFramePropertyUCP;
            _fp_slidingRailsPropertyUCPresenter = fp_slidingRailsPropertyUCPresenter;
            _fp_frameConnectionTypePropertyUCPresenter = fp_frameConnectionTypePropertyUCPresenter;
            _fp_TrackProfilePropertyUCPresenter = fp_TrackProfilePropertyUCPresenter;
            _fp_ScreenPropertyUCPresenter = fp_ScreenPropertyUCPresenter;
            _fp_TubularPropertyUCPresenter = fp_TubularPropertyUCPresenter;
            _fp_CladdingQtyPropertyUCPresenter = fp_CladdingQtyPropertyUCPresenter;

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

        //bool RailsDeductHt = false, RailsAdditionalHt = false;
        string prev_frameArtNo = "";
        private void _framePropertiesUC_cmbFrameProfileSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (initialized == true)
            {
                _frameModel.Frame_ArtNo = (FrameProfile_ArticleNo)((ComboBox)sender).SelectedValue;

                if ((_frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6050 ||
                    _frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6052) &&
                    _frameModel.Frame_WindoorModel.WD_profile.Contains("PremiLine"))
                {
                    //  if (RailsAdditionalHt == true)

                    if (_frameModel.Frame_SlidingRailsQtyVisibility == false)
                    {
                        _frameModel.Frame_SlidingRailsQtyVisibility = true;
                        _frameModel.FrameProp_Height += constants.frame_SlidingRailsQtyproperty_PanelHeight;
                        _framePropertiesUC.AddHT_PanelBody(constants.frame_SlidingRailsQtyproperty_PanelHeight);

                        //  RailsAdditionalHt = false;
                    }

                    if (_frameModel.Frame_ScreenVisibility == false)
                    {
                        _frameModel.Frame_ScreenVisibility = true;

                        //if (_frameModel.Frame_ScreenOption == true)
                        //{
                        //    _frameModel.FrameProp_Height += constants.frame_ScreenProperty_PanelHeight;
                        //    _framePropertiesUC.AddHT_PanelBody(constants.frame_ScreenProperty_PanelHeight);
                        //}
                        //else if (_frameModel.Frame_ScreenOption == false)
                        //{
                        _frameModel.FrameProp_Height += constants.frame_ScreenHeightProperty_PanelHeight;
                        _framePropertiesUC.AddHT_PanelBody(constants.frame_ScreenHeightProperty_PanelHeight);
                        //}
                    }


                    if (_frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6050)
                    {
                        #region premi 6050
                        if (_frameModel.Frame_ConnectionTypeVisibility == true)
                        {
                            _frameModel.Frame_ConnectionTypeVisibility = false;
                            _frameModel.FrameProp_Height -= constants.frame_ConnectionTypeproperty_PanelHeight;
                            _framePropertiesUC.AddHT_PanelBody(-constants.frame_ConnectionTypeproperty_PanelHeight);
                        }

                        if (_frameModel.Frame_TrackProfileArtNoVisibility == true &&
                       _frameModel.Frame_Type == Frame_Padding.Door)
                        {
                            _frameModel.Frame_TrackProfileArtNoVisibility = false;
                            _frameModel.FrameProp_Height -= constants.frame_TrackProfileproperty_PanelHeight;
                            _framePropertiesUC.AddHT_PanelBody(-constants.frame_TrackProfileproperty_PanelHeight);
                        }

                        //if (_frameModel.Frame_ScreenVisibility == true &&
                        //    _frameModel.Frame_Type == Frame_Padding.Door)
                        //{
                        //    _frameModel.Frame_ScreenVisibility = false;
                        //    if (_frameModel.Frame_ScreenOption == true)
                        //    {
                        //        _frameModel.FrameProp_Height -= constants.frame_ScreenProperty_PanelHeight;
                        //        _framePropertiesUC.AddHT_PanelBody(-constants.frame_ScreenProperty_PanelHeight);
                        //    }
                        //    else if (_frameModel.Frame_ScreenOption == false)
                        //    {
                        //        _frameModel.FrameProp_Height -= constants.frame_ScreenHeightProperty_PanelHeight;
                        //        _framePropertiesUC.AddHT_PanelBody(-constants.frame_ScreenHeightProperty_PanelHeight);
                        //    }
                        //}
                        #endregion
                    }
                    else if (_frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6052)
                    {
                        #region premi 6052
                        if (_frameModel.Frame_ConnectionTypeVisibility == false)
                        {
                            _frameModel.Frame_ConnectionTypeVisibility = true;
                            _frameModel.FrameProp_Height += constants.frame_ConnectionTypeproperty_PanelHeight;
                            _framePropertiesUC.AddHT_PanelBody(constants.frame_ConnectionTypeproperty_PanelHeight);
                        }

                        if (_frameModel.Frame_TrackProfileArtNoVisibility == false &&
                            _frameModel.Frame_Type == Frame_Padding.Door)
                        {
                            _frameModel.Frame_TrackProfileArtNoVisibility = true;
                            _frameModel.FrameProp_Height += constants.frame_TrackProfileproperty_PanelHeight;
                            _framePropertiesUC.AddHT_PanelBody(constants.frame_TrackProfileproperty_PanelHeight);
                        }

                        if (_frameModel.Frame_CladdingVisibility == false &&
                            _frameModel.Frame_Type == Frame_Padding.Door)
                        {
                            _frameModel.Frame_CladdingVisibility = true;
                            _frameModel.FrameProp_Height += constants.frame_CladdingProperty_PanelHeight;
                            _framePropertiesUC.AddHT_PanelBody(constants.frame_CladdingProperty_PanelHeight);
                        }


                        #endregion
                    }

                    #region old algo 
                    //if (_frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6052 && _frameModel.Frame_ConnectionTypeVisibility == false)
                    //{
                    //    _frameModel.Frame_ConnectionTypeVisibility = true;
                    //    _frameModel.FrameProp_Height += constants.frame_ConnectionTypeproperty_PanelHeight;
                    //    _framePropertiesUC.AddHT_PanelBody(constants.frame_ConnectionTypeproperty_PanelHeight);
                    //}
                    //else if (_frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6050 && _frameModel.Frame_ConnectionTypeVisibility == true)
                    //{
                    //    _frameModel.Frame_ConnectionTypeVisibility = false;
                    //    _frameModel.FrameProp_Height -= constants.frame_ConnectionTypeproperty_PanelHeight;
                    //    _framePropertiesUC.AddHT_PanelBody(-constants.frame_ConnectionTypeproperty_PanelHeight);
                    //}

                    //if (_frameModel.Frame_TrackProfileArtNoVisibility == false &&
                    //    _frameModel.Frame_Type == Frame_Padding.Door)
                    //{
                    //    _frameModel.Frame_TrackProfileArtNoVisibility = true;
                    //    _frameModel.FrameProp_Height += constants.frame_TrackProfileproperty_PanelHeight;
                    //    _framePropertiesUC.AddHT_PanelBody(constants.frame_TrackProfileproperty_PanelHeight);
                    //}

                    //RailsDeductHt = true;
                    #endregion

                }
                else if (!(_frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6050 ||
                           _frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6052))
                {
                    //  if (RailsDeductHt == true)
                    if (_frameModel.Frame_SlidingRailsQtyVisibility == true)
                    {
                        _frameModel.Frame_SlidingRailsQtyVisibility = false;
                        _frameModel.FrameProp_Height -= constants.frame_SlidingRailsQtyproperty_PanelHeight;
                        _framePropertiesUC.AddHT_PanelBody(-constants.frame_SlidingRailsQtyproperty_PanelHeight);

                        //   RailsDeductHt = false;
                    }

                    if (_frameModel.Frame_ConnectionTypeVisibility == true)
                    {
                        _frameModel.Frame_ConnectionTypeVisibility = false;
                        _frameModel.FrameProp_Height -= constants.frame_ConnectionTypeproperty_PanelHeight;
                        _framePropertiesUC.AddHT_PanelBody(-constants.frame_ConnectionTypeproperty_PanelHeight);
                    }
                    //  RailsAdditionalHt = true;

                    if (_frameModel.Frame_TrackProfileArtNoVisibility == true &&
                        _frameModel.Frame_Type == Frame_Padding.Door)
                    {
                        _frameModel.Frame_TrackProfileArtNoVisibility = false;
                        _frameModel.FrameProp_Height -= constants.frame_TrackProfileproperty_PanelHeight;
                        _framePropertiesUC.AddHT_PanelBody(-constants.frame_TrackProfileproperty_PanelHeight);
                    }

                    if (_frameModel.Frame_ScreenVisibility == true &&
                       _frameModel.Frame_Type == Frame_Padding.Door)
                    {
                        _frameModel.Frame_ScreenVisibility = false;
                        if (_frameModel.Frame_ScreenOption == true)
                        {
                            _frameModel.FrameProp_Height -= constants.frame_ScreenProperty_PanelHeight;
                            _framePropertiesUC.AddHT_PanelBody(-constants.frame_ScreenProperty_PanelHeight);
                        }
                        else if (_frameModel.Frame_ScreenOption == false)
                        {
                            _frameModel.FrameProp_Height -= constants.frame_ScreenHeightProperty_PanelHeight;
                            _framePropertiesUC.AddHT_PanelBody(-constants.frame_ScreenHeightProperty_PanelHeight);
                        }
                    }
                }

                _mainPresenter.GetCurrentPrice();
                prev_frameArtNo = _frameModel.Frame_ArtNo.ToString();
            }

        }

        string curr_rbtnText = "";
        private void OnRdBtnCheckedChangedEventRaised(object sender, EventArgs e)
        {
            RadioButton rbtn = (RadioButton)sender;

            _frameModel.Frame_Type = (Frame_Padding)Enum.Parse(typeof(Frame_Padding), rbtn.Text, true);
            if (_frameModel.Frame_WindoorModel.WD_profile.Contains("C70"))
            {
                _frameModel.Frame_TubularVisibility = true;
                _frameModel.FrameProp_Height += constants.frame_TubularOption;
                _framePropertiesUC.AddHT_PanelBody(constants.frame_TubularOption);

                if (curr_rbtnText == "Window" || curr_rbtnText == "Concrete")
                {
                    _frameModel.Frame_BotFrameVisible = true;
                    if (rbtn.Text == "Door" && rbtn.Checked == true)
                    {
                        _frameModel.Frame_ArtNo = FrameProfile_ArticleNo._7507;
                        _frameModel.Frame_ReinfArtNo = FrameReinf_ArticleNo._R677;
                        _frameModel.Frame_BotFrameArtNo = BottomFrameTypes._7507;

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
                        _frameModel.Frame_ArtNo = FrameProfile_ArticleNo._7502;
                        _frameModel.Frame_ReinfArtNo = FrameReinf_ArticleNo._R676;
                        _frameModel.Frame_BotFrameArtNo = BottomFrameTypes._7502;
                        _frameModel.FrameProp_Height -= constants.frame_botframeproperty_PanelHeight;
                        _framePropertiesUC.AddHT_PanelBody(-constants.frame_botframeproperty_PanelHeight);
                    }
                }
                else if (curr_rbtnText == "")
                {
                    if (_frameModel.Frame_Type == Frame_Padding.Window)
                    {
                        _frameModel.Frame_BotFrameVisible = false;
                    }
                    else if (_frameModel.Frame_Type == Frame_Padding.Door)
                    {
                        _frameModel.Frame_BotFrameVisible = true;
                    }

                }

                //if (_frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6050 ||
                //    _frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6052)
                //{
                //    if (_frameModel.Frame_BotFrameVisible == true)
                //    {
                //        _frameModel.Frame_BotFrameVisible = false;
                //    }
                //}

                curr_rbtnText = rbtn.Text;
            }
            else if (_frameModel.Frame_WindoorModel.WD_profile.Contains("PremiLine"))
            {
                _frameModel.Frame_TubularVisibility = false;

                if (curr_rbtnText == "Window" || curr_rbtnText == "Concrete")
                {
                    _frameModel.Frame_BotFrameVisible = true;

                    if (rbtn.Text == "Door" && rbtn.Checked == true)
                    {
                        _frameModel.Frame_ArtNo = FrameProfile_ArticleNo._6052;
                        _frameModel.Frame_ReinfArtNo = FrameReinf_ArticleNo._TV107;
                        _frameModel.Frame_BotFrameArtNo = BottomFrameTypes._6052;
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
                        _frameModel.Frame_ArtNo = FrameProfile_ArticleNo._6050;
                        _frameModel.Frame_ReinfArtNo = FrameReinf_ArticleNo._TV110;
                        _frameModel.Frame_BotFrameArtNo = BottomFrameTypes._6050;
                        _frameModel.FrameProp_Height -= constants.frame_botframeproperty_PanelHeight;
                        _framePropertiesUC.AddHT_PanelBody(-constants.frame_botframeproperty_PanelHeight);
                    }
                }
                else if (curr_rbtnText == "")
                {
                    if (_frameModel.Frame_Type == Frame_Padding.Window)
                    {
                        _frameModel.Frame_BotFrameVisible = false;
                    }
                    else if (_frameModel.Frame_Type == Frame_Padding.Door)
                    {
                        _frameModel.Frame_BotFrameVisible = true;
                    }

                }


                curr_rbtnText = rbtn.Text;
            }
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
            _mainPresenter.GetCurrentPrice();
        }

        private void OnNumFHeightValueChangedEventRaised(object sender, EventArgs e)
        {
            NumericUpDown numH = (NumericUpDown)sender;
            _frameModel.Frame_Height = Convert.ToInt32(numH.Value);
            _frameModel.Set_DimensionsToBind_using_FrameZoom();
            _frameModel.Set_ImagerDimensions_using_ImagerZoom();

            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            _mainPresenter.basePlatform_MainPresenter.Invalidate_flpMainControls();
            _mainPresenter.GetCurrentPrice();
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
            initialized = true;
            return frameBinding;
        }
        private Binding AddRadioCheckedBinding<T>(object dataSource, string dataMember, T trueValue)
        {
            var binding = new Binding(nameof(RadioButton.Checked), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += (s, a) => { if ((bool)a.Value) a.Value = trueValue; };
            binding.Format += (s, a) => a.Value = ((T)a.Value).Equals(trueValue);
            return binding;
        }
        bool initialized = false;
        private void OnFramePropertiesLoadEventRaised(object sender, EventArgs e)
        {

            _framePropertiesUC.ThisBinding(CreateBindingDictionary());

            if (_mainPresenter.ItemLoad == false)
            {
                if (_frameModel.Frame_Type == Frame_Padding.Window)
                {
                    if (_frameModel.Frame_WindoorModel.WD_profile.Contains("C70"))
                    {
                        _frameModel.Frame_ArtNo = FrameProfile_ArticleNo._7502;
                    }
                    else if (_frameModel.Frame_WindoorModel.WD_profile.Contains("PremiLine"))
                    {
                        _frameModel.Frame_ArtNo = FrameProfile_ArticleNo._6050;
                    }
                    else if (_frameModel.Frame_WindoorModel.WD_profile.Contains("G58"))
                    {
                        _frameModel.Frame_ArtNo = FrameProfile_ArticleNo._2060;
                    }
                    else if (_frameModel.Frame_WindoorModel.WD_profile.Contains("Alutek"))
                    {
                        _frameModel.Frame_ArtNo = FrameProfile_ArticleNo._84100;
                    }
                }
                else if (_frameModel.Frame_Type == Frame_Padding.Door)
                {

                    if (_frameModel.Frame_WindoorModel.WD_profile.Contains("C70"))
                    {
                        _frameModel.Frame_ArtNo = FrameProfile_ArticleNo._7507;
                    }
                    else if (_frameModel.Frame_WindoorModel.WD_profile.Contains("PremiLine"))
                    {
                        _frameModel.Frame_ArtNo = FrameProfile_ArticleNo._6052;
                    }
                    else if (_frameModel.Frame_WindoorModel.WD_profile.Contains("G58"))
                    {
                        _frameModel.Frame_ArtNo = FrameProfile_ArticleNo._2060;
                    }
                    else if (_frameModel.Frame_WindoorModel.WD_profile.Contains("Alutek"))
                    {
                        _frameModel.Frame_ArtNo = FrameProfile_ArticleNo._84100;
                    }
                }
            }

            if (_frameModel.Frame_Type == Frame_Padding.Door)
            {
                _frameModel.Frame_BotFrameVisible = true;
                _frameModel.FrameProp_Height += constants.frame_botframeproperty_PanelHeight;
                _framePropertiesUC.AddHT_PanelBody(constants.frame_botframeproperty_PanelHeight);
            }


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

            IFP_CladdingQtyPropertyUCPresenter cladding = _fp_CladdingQtyPropertyUCPresenter.GetNewInstance(_unityC, _mainPresenter, _frameModel);
            UserControl CladdingUC = (UserControl)cladding.GetCladdingQtyPropertyUC();
            _framePropertiesUC.GetBodyPropertiesPNL().Controls.Add(CladdingUC);
            CladdingUC.Dock = DockStyle.Top;
            CladdingUC.BringToFront();

            IFP_FrameConnectionTypePropertyUCPresenter connectorUCP = _fp_frameConnectionTypePropertyUCPresenter.GetNewInstance(_unityC, _frameModel, _mainPresenter);
            UserControl connectorPropUC = (UserControl)connectorUCP.GetFrameConnectionTypePropertyUC();
            _framePropertiesUC.GetBodyPropertiesPNL().Controls.Add(connectorPropUC);
            connectorPropUC.Dock = DockStyle.Top;
            connectorPropUC.BringToFront();


            IFP_TrackProfilePropertyUCPresenter TrackProfile = _fp_TrackProfilePropertyUCPresenter.GetNewInstance(_unityC, _frameModel, _mainPresenter);
            UserControl TrackProfilePropUC = (UserControl)TrackProfile.GetTrackProfilePropertyUC();
            _framePropertiesUC.GetBodyPropertiesPNL().Controls.Add(TrackProfilePropUC);
            TrackProfilePropUC.Dock = DockStyle.Top;
            TrackProfilePropUC.BringToFront();

            IFP_ScreenPropertyUCPresenter screen = _fp_ScreenPropertyUCPresenter.GetNewInstance(_unityC, _frameModel, _mainPresenter, this);
            UserControl ScreenPropUC = (UserControl)screen.GetScreenPropertyUC();
            _framePropertiesUC.GetBodyPropertiesPNL().Controls.Add(ScreenPropUC);
            ScreenPropUC.Dock = DockStyle.Top;
            ScreenPropUC.BringToFront();

            IFP_TubularPropertyUCPresenter tubular = _fp_TubularPropertyUCPresenter.GetNewInstance(_unityC, _frameModel, _mainPresenter, this);
            UserControl TubePropUC = (UserControl)tubular.GetTubularPropertyUC();
            _framePropertiesUC.GetBodyPropertiesPNL().Controls.Add(TubePropUC);
            TubePropUC.Dock = DockStyle.Top;
            TubePropUC.BringToFront();


            if (_frameModel.Frame_ScreenOption)
            {
                GetFramePropertiesUC().AddHT_PanelBody(constants.frame_ScreenHeightProperty_PanelHeight);
            }

            //if (_frameModel.Frame_Type == Frame_Padding.Door)
            //{
            //    _frameModel.FrameProp_Height += constants.frame_botframeproperty_PanelHeight;
            //    _framePropertiesUC.AddHT_PanelBody(constants.frame_botframeproperty_PanelHeight);
            //}


            //if ((_frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6050 ||
            //    _frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6052) &&
            //    _frameModel.Frame_WindoorModel.WD_profile.Contains("PremiLine") &&
            //    _frameModel.Frame_SlidingRailsQtyVisibility == true)
            //{
            //    _frameModel.FrameProp_Height += constants.frame_SlidingRailsQtyproperty_PanelHeight;
            //    _framePropertiesUC.AddHT_PanelBody(constants.frame_SlidingRailsQtyproperty_PanelHeight);

            //    if (_frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6052)
            //    {
            //        _frameModel.FrameProp_Height += constants.frame_ConnectionTypeproperty_PanelHeight;
            //        _framePropertiesUC.AddHT_PanelBody(constants.frame_ConnectionTypeproperty_PanelHeight);
            //    }
            //}

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
