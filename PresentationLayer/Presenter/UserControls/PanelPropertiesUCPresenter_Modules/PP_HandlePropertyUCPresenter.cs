using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_HandlePropertyUCPresenter : IPP_HandlePropertyUCPresenter, IPresenterCommon
    {
        IPP_HandlePropertyUC _pp_handlePropertyUC;

        private IPP_RotoswingPropertyUCPresenter _pp_rotoswingPropertyUCPresenter;
        private IPP_RotaryPropertyUCPresenter _pp_rotaryPropertyUCPresenter;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        Panel _pnlHandleType;
        bool _initialLoad = true;

        public PP_HandlePropertyUCPresenter(IPP_HandlePropertyUC pp_handlePropertyUC,
                                            IPP_RotoswingPropertyUCPresenter pp_rotoswingPropertyUCPresenter,
                                            IPP_RotaryPropertyUCPresenter pp_rotaryPropertyUCPresenter)
        {
            _pp_handlePropertyUC = pp_handlePropertyUC;
            _pp_rotoswingPropertyUCPresenter = pp_rotoswingPropertyUCPresenter;
            _pp_rotaryPropertyUCPresenter = pp_rotaryPropertyUCPresenter;
            _pnlHandleType = _pp_handlePropertyUC.GetHandleTypePNL();
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_handlePropertyUC.PPHandlePropertyLoadEventRaised += _pp_handlePropertyUC_PPHandlePropertyLoadEventRaised;
            _pp_handlePropertyUC.cmbHandleTypeSelectedValueEventRaised += _pp_handlePropertyUC_cmbHandleTypeSelectedValueEventRaised;
        }

        Handle_Type curr_handleType;
        private void _pp_handlePropertyUC_cmbHandleTypeSelectedValueEventRaised(object sender, EventArgs e)
        {
            Handle_Type sel_handleType = (Handle_Type)((ComboBox)sender).SelectedValue;

            if (curr_handleType != sel_handleType)
            {
                curr_handleType = sel_handleType;

                if (_initialLoad == false)
                {
                    _panelModel.Panel_HandleType = sel_handleType;
                    //    int fieldExtension_count = 0;

                    //    fieldExtension_count = (_panelModel.Panel_ExtTopChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
                    //    fieldExtension_count = (_panelModel.Panel_ExtBotChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
                    //    fieldExtension_count = (_panelModel.Panel_ExtLeftChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
                    //    fieldExtension_count = (_panelModel.Panel_ExtRightChk == true) ? fieldExtension_count += 1 : fieldExtension_count;

                    //    if (_panelModel.Panel_HandleType == Handle_Type._Rotoswing)
                    //    {
                    //        _panelModel.Panel_RotoswingOptionsVisibility = true;
                    //        _panelModel.Panel_RotaryOptionsVisibility = false;

                    //        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                    //        _panelModel.AdjustPropertyPanelHeight("minusRotary");
                    //        _panelModel.AdjustHandlePropertyHeight("minusRotary");

                    //        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                    //        _panelModel.AdjustPropertyPanelHeight("addRotoswing");
                    //        _panelModel.AdjustHandlePropertyHeight("addRotoswing");

                    //        if (_panelModel.Panel_ParentMultiPanelModel != null)
                    //        {
                    //            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                    //            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                    //        }

                    //        if (_panelModel.Panel_Type.Contains("Casement") || _panelModel.Panel_Height >= 2100)
                    //        {
                    //            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                    //            _panelModel.AdjustPropertyPanelHeight("addCornerDrive");
                    //            _panelModel.AdjustHandlePropertyHeight("addCornerDrive");
                    //            _panelModel.AdjustRotoswingPropertyHeight("addCornerDrive");

                    //            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                    //            _panelModel.AdjustPropertyPanelHeight("addExtension");
                    //            _panelModel.AdjustHandlePropertyHeight("addExtension");
                    //            _panelModel.AdjustRotoswingPropertyHeight("addExtension");

                    //            if (_panelModel.Panel_ParentMultiPanelModel != null)
                    //            {
                    //                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                    //                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                    //            }

                    //            for (int i = 0; i < fieldExtension_count; i++)
                    //            {
                    //                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtensionField");
                    //                _panelModel.AdjustPropertyPanelHeight("addExtensionField");
                    //                _panelModel.AdjustHandlePropertyHeight("addExtensionField");
                    //                _panelModel.AdjustRotoswingPropertyHeight("addExtensionField");

                    //                if (_panelModel.Panel_ParentMultiPanelModel != null)
                    //                {
                    //                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addExtensionField");
                    //                }
                    //            }
                    //        }
                    //    }
                    //    else if (_panelModel.Panel_HandleType == Handle_Type._Rotary)
                    //    {
                    //        _panelModel.Panel_RotoswingOptionsVisibility = false;
                    //        _panelModel.Panel_RotaryOptionsVisibility = true;

                    //        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                    //        _panelModel.AdjustPropertyPanelHeight("minusRotoswing");
                    //        _panelModel.AdjustHandlePropertyHeight("minusRotoswing");

                    //        if (_panelModel.Panel_ParentMultiPanelModel != null)
                    //        {
                    //            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                    //        }

                    //        if (_panelModel.Panel_Type.Contains("Casement") || _panelModel.Panel_Height >= 2100)
                    //        {
                    //            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                    //            _panelModel.AdjustPropertyPanelHeight("minusCornerDrive");
                    //            _panelModel.AdjustHandlePropertyHeight("minusCornerDrive");
                    //            _panelModel.AdjustRotoswingPropertyHeight("minusCornerDrive");

                    //            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtension");
                    //            _panelModel.AdjustPropertyPanelHeight("minusExtension");
                    //            _panelModel.AdjustHandlePropertyHeight("minusExtension");
                    //            _panelModel.AdjustRotoswingPropertyHeight("minusExtension");

                    //            if (_panelModel.Panel_ParentMultiPanelModel != null)
                    //            {
                    //                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                    //                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusExtension");
                    //            }

                    //            for (int i = 0; i < fieldExtension_count; i++)
                    //            {
                    //                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtensionField");
                    //                _panelModel.AdjustPropertyPanelHeight("minusExtensionField");
                    //                _panelModel.AdjustHandlePropertyHeight("minusExtensionField");
                    //                _panelModel.AdjustRotoswingPropertyHeight("minusExtensionField");

                    //                if (_panelModel.Panel_ParentMultiPanelModel != null)
                    //                {
                    //                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusExtensionField");
                    //                }

                    //            }
                    //        }

                    //        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                    //        _panelModel.AdjustPropertyPanelHeight("addRotary");
                    //        _panelModel.AdjustHandlePropertyHeight("addRotary");

                    //        if (_panelModel.Panel_ParentMultiPanelModel != null)
                    //        {
                    //            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                    //        }
                    //    }
                }
            }
        }

        private void _pp_handlePropertyUC_PPHandlePropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_handlePropertyUC.ThisBinding(CreateBindingDictionary());

            IPP_RotoswingPropertyUCPresenter rotoswingPropUCP = _pp_rotoswingPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl rotoswingPropUC = (UserControl)rotoswingPropUCP.GetPPRotoswingPropertyUC();
            _pnlHandleType.Controls.Add(rotoswingPropUC);
            rotoswingPropUC.Dock = DockStyle.Top;
            rotoswingPropUC.BringToFront();

            IPP_RotaryPropertyUCPresenter rotaryPropUCP = _pp_rotaryPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl rotaryPropUC = (UserControl)rotaryPropUCP.GetPPRotaryPropertyUC();
            _pnlHandleType.Controls.Add(rotaryPropUC);
            rotaryPropUC.Dock = DockStyle.Top;
            rotaryPropUC.BringToFront();

            if (_panelModel.Panel_HandleType == Handle_Type._Rotoswing)
            {
                _panelModel.Panel_RotoswingOptionsVisibility = true;
                _panelModel.Panel_RotaryOptionsVisibility = false;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                }

                _panelModel.AdjustPropertyPanelHeight("addRotoswing");

                _panelModel.AdjustHandlePropertyHeight("addRotoswing");
            }
            else if (_panelModel.Panel_HandleType == Handle_Type._Rotary)
            {
                _panelModel.Panel_RotoswingOptionsVisibility = false;
                _panelModel.Panel_RotaryOptionsVisibility = true;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotary");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                }

                _panelModel.AdjustPropertyPanelHeight("addRotary");

                _panelModel.AdjustHandlePropertyHeight("addRotary");
            }

            _initialLoad = false;
        }

        public IPP_HandlePropertyUC GetPPHandlePropertyUC()
        {
            return _pp_handlePropertyUC;
        }

        public IPP_HandlePropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_HandlePropertyUC, PP_HandlePropertyUC>()
                .RegisterType<IPP_HandlePropertyUCPresenter, PP_HandlePropertyUCPresenter>();
            PP_HandlePropertyUCPresenter presenter = unityC.Resolve<PP_HandlePropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_HandleType", new Binding("Text", _panelModel, "Panel_HandleType", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_HandleOptionsVisibility", new Binding("Visible", _panelModel, "Panel_HandleOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_HandleOptionsHeight", new Binding("Height", _panelModel, "Panel_HandleOptionsHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_ArtNo", new Binding("Frame_ArtNo", _panelModel.Panel_ParentFrameModel, "Frame_ArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_SashProfileArtNo", new Binding("Panel_SashProfileArtNo", _panelModel, "Panel_SashProfileArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            
            return binding;
        }
    }
}
