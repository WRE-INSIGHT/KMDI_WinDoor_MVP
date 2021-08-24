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
        private IPP_GeorgianBarPropertyUCPresenter _pp_georgianBarPropertUCPresenter;
        private IPP_ExtensionPropertyUCPresenter _pp_extensionPropertyUCPresenter;
        private IPP_CornerDrivePropertyUCPresenter _pp_cornerDrivePropertyUCPresenter;
        private IPP_HingePropertyUCPresenter _pp_hingePropertyUCPresenter;

        private IUnityContainer _unityC;

        private Panel _pnlPanelSpecs;

        public PanelPropertiesUCPresenter(IPanelPropertiesUC panelPropertiesUC,
                                          IPP_MotorizedPropertyUCPresenter pp_motorizedPropertyUCPresenter,
                                          IPP_SashPropertyUCPresenter pp_sashPropertyUCPresenter,
                                          IPP_GlassPropertyUCPresenter pp_glassPropertyUCPresenter,
                                          IPP_HandlePropertyUCPresenter pp_handlePropertUCPresenter,
                                          IPP_GeorgianBarPropertyUCPresenter pp_georgianBarPropertUCPresenter,
                                          IPP_ExtensionPropertyUCPresenter pp_extensionPropertyUCPresenter,
                                          IPP_CornerDrivePropertyUCPresenter pp_cornerDrivePropertyUCPresenter,
                                          IPP_HingePropertyUCPresenter pp_hingePropertyUCPresenter)
        {
            _panelPropertiesUC = panelPropertiesUC;
            _pp_motorizedPropertyUCPresenter = pp_motorizedPropertyUCPresenter;
            _pp_sashPropertyUCPresenter = pp_sashPropertyUCPresenter;
            _pp_glassPropertyUCPresenter = pp_glassPropertyUCPresenter;
            _pp_handlePropertUCPresenter = pp_handlePropertUCPresenter;
            _pp_georgianBarPropertUCPresenter = pp_georgianBarPropertUCPresenter;
            _pp_extensionPropertyUCPresenter = pp_extensionPropertyUCPresenter;
            _pp_cornerDrivePropertyUCPresenter = pp_cornerDrivePropertyUCPresenter;
            _pp_hingePropertyUCPresenter = pp_hingePropertyUCPresenter;
            _pnlPanelSpecs = _panelPropertiesUC.GetPanelSpecsPNL();

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

            IPP_SashPropertyUCPresenter sashPropUCP = _pp_sashPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl sashProp = (UserControl)sashPropUCP.GetPPSashPropertyUC();
            _pnlPanelSpecs.Controls.Add(sashProp);
            sashProp.Dock = DockStyle.Top;
            sashProp.BringToFront();

            if (_panelModel.Panel_Type.Contains("Casement") || _panelModel.Panel_Type.Contains("Awning"))
            {
                _panelModel.Panel_HingeOptionsVisibility = true;
                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addHinge");
                _panelModel.AdjustPropertyPanelHeight("addHinge");
            }

            IPP_HingePropertyUCPresenter hingePropUCP = _pp_hingePropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl hingeProp = (UserControl)hingePropUCP.GetPP_HingePropertyUC();
            _pnlPanelSpecs.Controls.Add(hingeProp);
            hingeProp.Dock = DockStyle.Top;
            hingeProp.BringToFront();

            if (_panelModel.Panel_SashPropertyVisibility == true)
            {
                IPP_MotorizedPropertyUCPresenter motorizedPropUCP = _pp_motorizedPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
                UserControl motorized = (UserControl)motorizedPropUCP.GetPPMotorizedPropertyUC();
                _pnlPanelSpecs.Controls.Add(motorized);
                motorized.Dock = DockStyle.Top;
                motorized.BringToFront();

                IPP_HandlePropertyUCPresenter handlePropUCP = _pp_handlePropertUCPresenter.GetNewInstance(_unityC, _panelModel);
                UserControl handle = (UserControl)handlePropUCP.GetPPHandlePropertyUC();
                _pnlPanelSpecs.Controls.Add(handle);
                handle.Dock = DockStyle.Top;
                handle.BringToFront();
            }

            IPP_CornerDrivePropertyUCPresenter cdPropUCP = _pp_cornerDrivePropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl cdPropUC = (UserControl)cdPropUCP.GetPPCornerDriveUC();
            _pnlPanelSpecs.Controls.Add(cdPropUC);
            cdPropUC.Dock = DockStyle.Top;
            cdPropUC.BringToFront();

            IPP_ExtensionPropertyUCPresenter extPropUCP = _pp_extensionPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl extPropUC = (UserControl)extPropUCP.GetPPExtensionUC();
            _pnlPanelSpecs.Controls.Add(extPropUC);
            extPropUC.Dock = DockStyle.Top;
            extPropUC.BringToFront();

            if (_panelModel.Panel_Type.Contains("Casement") || _panelModel.Panel_Height >= 2100)
            {
                _panelModel.Panel_ExtensionOptionsVisibility = true;
                _panelModel.Panel_CornerDriveOptionsVisibility = true;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                _panelModel.AdjustPropertyPanelHeight("addCornerDrive");

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                _panelModel.AdjustPropertyPanelHeight("addExtension");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                }
            }

            IPP_GlassPropertyUCPresenter glassPropUCP = _pp_glassPropertyUCPresenter.GetNewInstance(_unityC, _panelModel, _mainPresenter);
            UserControl glassProp = (UserControl)glassPropUCP.GetPPGlassPropertyUC();
            _pnlPanelSpecs.Controls.Add(glassProp);
            glassProp.Dock = DockStyle.Top;
            glassProp.BringToFront();

            IPP_GeorgianBarPropertyUCPresenter gbarPropUCP = _pp_georgianBarPropertUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl gbarProp = (UserControl)gbarPropUCP.GetPPGeorgianBarPropertyUC();
            _pnlPanelSpecs.Controls.Add(gbarProp);
            gbarProp.Dock = DockStyle.Top;
            gbarProp.BringToFront();

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
