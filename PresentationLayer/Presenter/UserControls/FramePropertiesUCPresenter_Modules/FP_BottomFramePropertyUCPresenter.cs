using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public class FP_BottomFramePropertyUCPresenter : IFP_BottomFramePropertyUCPresenter, IPresenterCommon
    {
        IFP_BottomFramePropertyUC _fp_bottomFramePropertiesUC;

        private IFrameModel _frameModel;
        private IMainPresenter _mainPresenter;


        bool _initialLoad = true;

        public FP_BottomFramePropertyUCPresenter(IFP_BottomFramePropertyUC fp_bottomFramePropertiesUC)
        {
            _fp_bottomFramePropertiesUC = fp_bottomFramePropertiesUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _fp_bottomFramePropertiesUC.bottomFramePropertyLoadEventRaised += _fp_bottomFramePropertiesUC_bottomFramePropertyLoadEventRaised;
            _fp_bottomFramePropertiesUC.cmbbotFrameProfileSelectedValueChangedRaised += _fp_bottomFramePropertiesUC_cmbbotFrameProfileSelectedValueChangedRaised;
        }

        private void _fp_bottomFramePropertiesUC_cmbbotFrameProfileSelectedValueChangedRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _frameModel.Frame_BotFrameArtNo = (BottomFrameTypes)((ComboBox)sender).SelectedValue;

                BottomFrameTypes botft = (BottomFrameTypes)((ComboBox)sender).SelectedValue;

                Padding fpadding = _frameModel.Frame_Padding_int;
                Padding fpads_imgr = _frameModel.FrameImageRenderer_Padding_int;
                float fzoom = _frameModel.Frame_Zoom,
                      fzoom_imgr = _frameModel.FrameImageRenderer_Zoom;

                if (fzoom >= 0.50f)
                {
                    if (botft == BottomFrameTypes._None || botft == BottomFrameTypes._7789)
                    {
                        _frameModel.Frame_Padding_int = new Padding(fpadding.Left, fpadding.Top, fpadding.Right, 0);
                    }
                    else if (botft == BottomFrameTypes._7507)
                    {
                        _frameModel.Frame_Padding_int = new Padding(fpadding.Left, fpadding.Top, fpadding.Right, fpadding.Top);
                    }
                    else if (botft == BottomFrameTypes._7502)
                    {
                        _frameModel.Frame_Padding_int = new Padding(fpadding.Left, fpadding.Top, fpadding.Right, Convert.ToInt32(26 * fzoom));
                    }
                }
                else if (fzoom <= 0.26f)
                {
                    if (botft == BottomFrameTypes._7507)
                    {
                        _frameModel.Frame_Padding_int = new Padding(20);
                    }
                    else if (botft == BottomFrameTypes._7502)
                    {
                        _frameModel.Frame_Padding_int = new Padding(20, 20, 20, 15);
                    }
                    else if (botft == BottomFrameTypes._7789 || botft == BottomFrameTypes._None)
                    {
                        _frameModel.Frame_Padding_int = new Padding(20, 20, 20, 0);
                    }
                }

                if (fzoom_imgr >= 0.50f)
                {
                    if (botft == BottomFrameTypes._None || botft == BottomFrameTypes._7789)
                    {
                        _frameModel.FrameImageRenderer_Padding_int = new Padding(fpads_imgr.Left, fpads_imgr.Top, fpads_imgr.Right, 0);
                    }
                    else if (botft == BottomFrameTypes._7507)
                    {
                        _frameModel.FrameImageRenderer_Padding_int = new Padding(fpads_imgr.Left, fpads_imgr.Top, fpads_imgr.Right, fpads_imgr.Top);
                    }
                    else if (botft == BottomFrameTypes._7502)
                    {
                        _frameModel.FrameImageRenderer_Padding_int = new Padding(fpads_imgr.Left, fpads_imgr.Top, fpads_imgr.Right, Convert.ToInt32(26 * fzoom_imgr));
                    }
                }
                else if (fzoom_imgr <= 0.26f)
                {
                    if (botft == BottomFrameTypes._7507)
                    {
                        _frameModel.FrameImageRenderer_Padding_int = new Padding(20);
                    }
                    else if (botft == BottomFrameTypes._7502)
                    {
                        _frameModel.FrameImageRenderer_Padding_int = new Padding(20, 20, 20, 15);
                    }
                    else if (botft == BottomFrameTypes._7789 || botft == BottomFrameTypes._None)
                    {
                        _frameModel.FrameImageRenderer_Padding_int = new Padding(20, 20, 20, 0);
                    }
                }

                _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            }
        }

        private void _fp_bottomFramePropertiesUC_bottomFramePropertyLoadEventRaised(object sender, EventArgs e)
        {
            _fp_bottomFramePropertiesUC.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
        }

        public IFP_BottomFramePropertyUC GetFP_BottomFramePropertiesUC()
        {
            return _fp_bottomFramePropertiesUC;
        }

        public IFP_BottomFramePropertyUCPresenter GetNewInstance(IFrameModel frameModel,
                                                                 IUnityContainer unityC,
                                                                 IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IFP_BottomFramePropertyUC, FP_BottomFramePropertyUC>()
                .RegisterType<IFP_BottomFramePropertyUCPresenter, FP_BottomFramePropertyUCPresenter>();
            FP_BottomFramePropertyUCPresenter fp_bottomframePropertiesUCP = unityC.Resolve<FP_BottomFramePropertyUCPresenter>();
            fp_bottomframePropertiesUCP._frameModel = frameModel;
            fp_bottomframePropertiesUCP._mainPresenter = mainPresenter;

            return fp_bottomframePropertiesUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> botframePropBinding = new Dictionary<string, Binding>();
            botframePropBinding.Add("Frame_BotFrameArtNo", new Binding("Text", _frameModel, "Frame_BotFrameArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            botframePropBinding.Add("Frame_BotFrameEnable", new Binding("Enabled", _frameModel, "Frame_BotFrameEnable", true, DataSourceUpdateMode.OnPropertyChanged));
            botframePropBinding.Add("Frame_BotFrameVisible", new Binding("Visible", _frameModel, "Frame_BotFrameVisible", true, DataSourceUpdateMode.OnPropertyChanged));

            return botframePropBinding;
        }
    }
}