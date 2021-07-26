using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views.UserControls;
using ModelLayer.Model.Quotation.Panel;
using System.Windows.Forms;
using Unity;
using CommonComponents;
using static EnumerationTypeLayer.EnumerationTypes;
using PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;

namespace PresentationLayer.Presenter.UserControls
{
    public class PanelPropertiesUCPresenter : IPanelPropertiesUCPresenter, IPresenterCommon
    {
        IPanelPropertiesUC _panelPropertiesUC;

        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;
        private IPP_MotorizedPropertyUCPresenter _pp_motorizedPropertyUCPresenter;
        private IPP_SashPropertyUCPresenter _pp_sashPropertyUCPresenter;
        private IPP_GlassPropertyUCPresenter _pp_glassPropertyUCPresenter;
        private IPP_HandlePropertyUCPresenter _pp_handlePropertUCPresenter;
        private IUnityContainer _unityC;

        private FlowLayoutPanel _flpPanelSpecs;

        public PanelPropertiesUCPresenter(IPanelPropertiesUC panelPropertiesUC,
                                          IPP_MotorizedPropertyUCPresenter pp_motorizedPropertyUCPresenter,
                                          IPP_SashPropertyUCPresenter pp_sashPropertyUCPresenter,
                                          IPP_GlassPropertyUCPresenter pp_glassPropertyUCPresenter,
                                          IPP_HandlePropertyUCPresenter pp_handlePropertUCPresenter)
        {
            _panelPropertiesUC = panelPropertiesUC;
            _pp_motorizedPropertyUCPresenter = pp_motorizedPropertyUCPresenter;
            _pp_sashPropertyUCPresenter = pp_sashPropertyUCPresenter;
            _pp_glassPropertyUCPresenter = pp_glassPropertyUCPresenter;
            _pp_handlePropertUCPresenter = pp_handlePropertUCPresenter;
            _flpPanelSpecs = _panelPropertiesUC.GetPanelSpecsFLP();

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _panelPropertiesUC.PanelPropertiesLoadEventRaised += new EventHandler(OnPanelPropertiesLoadEventRaised);
            _panelPropertiesUC.ChkOrientationCheckChangedEventRaised += _panelPropertiesUC_ChkOrientationCheckChangedEventRaised;
        }

        bool chkOrient_state, adjust_bool;
        private void _panelPropertiesUC_ChkOrientationCheckChangedEventRaised(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            _panelModel.Panel_Orient = chk.Checked;

            if (chkOrient_state != chk.Checked)
            {
                adjust_bool = true;
                chkOrient_state = chk.Checked;

                if (adjust_bool == true)
                {

                    if (_panelModel.Panel_ParentFrameModel != null)
                    {
                        if (chk.Text == "None" && chk.Checked == false)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusSash");
                            _panelModel.AdjustPropertyPanelHeight("minusSash");
                        }
                        else if (chk.Text == "dSash" && chk.Checked == true)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addSash");
                            _panelModel.AdjustPropertyPanelHeight("addSash");
                        }
                        adjust_bool = false;
                    }

                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        if (chk.Text == "None" && chk.Checked == false)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusSash");
                        }
                        else if (chk.Text == "dSash" && chk.Checked == true)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addSash");
                        }
                        adjust_bool = false;
                    }
                }
                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            }
        }

        private void OnPanelPropertiesLoadEventRaised(object sender, EventArgs e)
        {
            _panelPropertiesUC.ThisBinding(CreateBindingDictionary());
            if (_panelModel.Panel_SashPropertyVisibility == true)
            {
                IPP_MotorizedPropertyUCPresenter motorizedPropUCP = _pp_motorizedPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
                _flpPanelSpecs.Controls.Add((UserControl)motorizedPropUCP.GetPPMotorizedPropertyUC());

                IPP_HandlePropertyUCPresenter handlePropUCP = _pp_handlePropertUCPresenter.GetNewInstance(_unityC, _panelModel);
                _flpPanelSpecs.Controls.Add((UserControl)handlePropUCP.GetPPHandlePropertyUC());
            }
            IPP_SashPropertyUCPresenter sashPropUCP = _pp_sashPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            _flpPanelSpecs.Controls.Add((UserControl)sashPropUCP.GetPPSashPropertyUC());

            IPP_GlassPropertyUCPresenter glassPropUCP = _pp_glassPropertyUCPresenter.GetNewInstance(_unityC, _panelModel, _mainPresenter);
            _flpPanelSpecs.Controls.Add((UserControl)glassPropUCP.GetPPGlassPropertyUC());

            chkOrient_state = _panelModel.Panel_Orient;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Width", new Binding("Value", _panelModel, "Panel_DisplayWidth", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Height", new Binding("Value", _panelModel, "Panel_DisplayHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Name", new Binding("Text", _panelModel, "Panel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Type", new Binding("Text", _panelModel, "Panel_Type", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_ChkText", new Binding("Text", _panelModel, "Panel_ChkText", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Orient", new Binding("Checked", _panelModel, "Panel_Orient", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelGlass_ID", new Binding("PanelGlass_ID", _panelModel, "PanelGlass_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_PropertyHeight", new Binding("Height", _panelModel, "Panel_PropertyHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            
            return panelBinding;
        }

        public IPanelPropertiesUC GetPanelPropertiesUC()
        {
            return _panelPropertiesUC;
        }


        public IPanelPropertiesUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IPanelPropertiesUC, Panel_PropertiesUC>()
                .RegisterType<IPanelPropertiesUCPresenter, PanelPropertiesUCPresenter>();
            PanelPropertiesUCPresenter panelPropUCP = unityC.Resolve<PanelPropertiesUCPresenter>();
            panelPropUCP._unityC = unityC;
            panelPropUCP._panelModel = panelModel;
            panelPropUCP._mainPresenter = mainPresenter;

            return panelPropUCP;
        }

    }
}
