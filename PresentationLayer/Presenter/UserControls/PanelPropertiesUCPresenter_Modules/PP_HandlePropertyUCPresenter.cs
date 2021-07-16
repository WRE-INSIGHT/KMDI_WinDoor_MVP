using CommonComponents;
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

        FlowLayoutPanel _flpHandleType;
        bool _initialLoad = true;

        public PP_HandlePropertyUCPresenter(IPP_HandlePropertyUC pp_handlePropertyUC,
                                            IPP_RotoswingPropertyUCPresenter pp_rotoswingPropertyUCPresenter,
                                            IPP_RotaryPropertyUCPresenter pp_rotaryPropertyUCPresenter)
        {
            _pp_handlePropertyUC = pp_handlePropertyUC;
            _pp_rotoswingPropertyUCPresenter = pp_rotoswingPropertyUCPresenter;
            _pp_rotaryPropertyUCPresenter = pp_rotaryPropertyUCPresenter;
            _flpHandleType = _pp_handlePropertyUC.GetHandleTypeFLP();
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

                    if (_panelModel.Panel_HandleType == Handle_Type._Rotoswing)
                    {
                        _panelModel.Panel_RotoswingOptionsVisibility = true;
                        _panelModel.Panel_RotaryOptionsVisibility = false;

                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                        _panelModel.AdjustPropertyPanelHeight("minusRotary");
                        _panelModel.AdjustHandlePropertyHeight("minusRotary");

                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                        _panelModel.AdjustPropertyPanelHeight("addRotoswing");
                        _panelModel.AdjustHandlePropertyHeight("addRotoswing");
                    }
                    else if (_panelModel.Panel_HandleType == Handle_Type._Rotary)
                    {
                        _panelModel.Panel_RotoswingOptionsVisibility = false;
                        _panelModel.Panel_RotaryOptionsVisibility = true;

                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                        _panelModel.AdjustPropertyPanelHeight("minusRotoswing");
                        _panelModel.AdjustHandlePropertyHeight("minusRotoswing");

                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                        _panelModel.AdjustPropertyPanelHeight("addRotary");
                        _panelModel.AdjustHandlePropertyHeight("addRotary");
                    }
                }
            }
        }

        private void _pp_handlePropertyUC_PPHandlePropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_handlePropertyUC.ThisBinding(CreateBindingDictionary());

            IPP_RotoswingPropertyUCPresenter rotoswingPropUCP = _pp_rotoswingPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            _flpHandleType.Controls.Add((UserControl)rotoswingPropUCP.GetPPRotoswingPropertyUC());

            IPP_RotaryPropertyUCPresenter rotaryPropUCP = _pp_rotaryPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            _flpHandleType.Controls.Add((UserControl)rotaryPropUCP.GetPPRotaryPropertyUC());

            if (_panelModel.Panel_HandleType == Handle_Type._Rotoswing)
            {
                _panelModel.Panel_RotoswingOptionsVisibility = true;
                _panelModel.Panel_RotaryOptionsVisibility = false;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");

                _panelModel.AdjustPropertyPanelHeight("addRotoswing");

                _panelModel.AdjustHandlePropertyHeight("addRotoswing");
            }
            else if (_panelModel.Panel_HandleType == Handle_Type._Rotary)
            {
                _panelModel.Panel_RotoswingOptionsVisibility = false;
                _panelModel.Panel_RotaryOptionsVisibility = true;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotary");

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
            
            return binding;
        }
    }
}
