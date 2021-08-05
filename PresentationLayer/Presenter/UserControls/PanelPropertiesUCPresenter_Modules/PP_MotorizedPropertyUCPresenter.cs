using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_MotorizedPropertyUCPresenter : IPP_MotorizedPropertyUCPresenter, IPresenterCommon
    {
        IPP_MotorizedPropertyUC _pp_motorizedPropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;

        public PP_MotorizedPropertyUCPresenter(IPP_MotorizedPropertyUC pp_motorizedPropertyUC)
        {
            _pp_motorizedPropertyUC = pp_motorizedPropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_motorizedPropertyUC.PPMotorizedPropertyUCLoadEventRaised += _pp_motorizedPropertyUC_PPMotorizedPropertyUCLoadEventRaised;
            _pp_motorizedPropertyUC.chkMotorizedCheckedChangedEventRaised += _pp_motorizedPropertyUC_chkMotorizedCheckedChangedEventRaised;
            _pp_motorizedPropertyUC.cmbMotorizedMechSelectedValueChangedEventRaised += _pp_motorizedPropertyUC_cmbMotorizedMechSelectedValueChangedEventRaised;
        }

        private void _pp_motorizedPropertyUC_cmbMotorizedMechSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _panelModel.Panel_MotorizedMechArtNo = (MotorizedMech_ArticleNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _pp_motorizedPropertyUC_chkMotorizedCheckedChangedEventRaised(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            _panelModel.Panel_MotorizedOptionVisibility = chk.Checked;
            _panelModel.Panel_HandleOptionsVisibility = !chk.Checked;

            int fieldExtension_count = 0;

            fieldExtension_count = (_panelModel.Panel_ExtTopChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
            fieldExtension_count = (_panelModel.Panel_ExtBotChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
            fieldExtension_count = (_panelModel.Panel_ExtLeftChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
            fieldExtension_count = (_panelModel.Panel_ExtRightChk == true) ? fieldExtension_count += 1 : fieldExtension_count;

            if (chk.Checked == true)
            {
                chk.Text = "Yes";
                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addCmbMotorized");
                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusHandle");

                _panelModel.AdjustPropertyPanelHeight("addCmbMotorized");
                _panelModel.AdjustPropertyPanelHeight("minusHandle");

                if (_panelModel.Panel_HandleType == Handle_Type._Rotoswing)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                    _panelModel.AdjustPropertyPanelHeight("minusRotoswing");
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._Rotary)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                    _panelModel.AdjustPropertyPanelHeight("minusRotary");
                }

                _panelModel.AdjustMotorizedPropertyHeight("whole");

                if (_panelModel.Panel_ExtensionOptionsVisibility == true)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtension");
                    _panelModel.AdjustPropertyPanelHeight("minusExtension");

                    for (int i = 0; i < fieldExtension_count; i++)
                    {
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtensionField");
                        _panelModel.AdjustPropertyPanelHeight("minusExtensionField");
                    }

                    if (_panelModel.Panel_CornerDriveOptionsVisibility == true)
                    {
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                        _panelModel.AdjustPropertyPanelHeight("minusCornerDrive");
                    }
                }
            }
            else if (chk.Checked == false)
            {
                chk.Text = "No";
                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusCmbMotorized");
                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addHandle");

                _panelModel.AdjustPropertyPanelHeight("minusCmbMotorized");
                _panelModel.AdjustPropertyPanelHeight("addHandle");

                if (_panelModel.Panel_HandleType == Handle_Type._Rotoswing)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                    _panelModel.AdjustPropertyPanelHeight("addRotoswing");
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._Rotary)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                    _panelModel.AdjustPropertyPanelHeight("addRotary");
                }

                _panelModel.AdjustMotorizedPropertyHeight("chkMotorizedOnly");

                if (_panelModel.Panel_ExtensionOptionsVisibility == true)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                    _panelModel.AdjustPropertyPanelHeight("addExtension");

                    for (int i = 0; i < fieldExtension_count; i++)
                    {
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtensionField");
                        _panelModel.AdjustPropertyPanelHeight("addExtensionField");
                    }

                    if (_panelModel.Panel_CornerDriveOptionsVisibility == true)
                    {
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                        _panelModel.AdjustPropertyPanelHeight("addCornerDrive");
                    }
                }
            }
        }

        private void _pp_motorizedPropertyUC_PPMotorizedPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_motorizedPropertyUC.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
        }

        public IPP_MotorizedPropertyUC GetPPMotorizedPropertyUC()
        {
            return _pp_motorizedPropertyUC;
        }

        public IPP_MotorizedPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_MotorizedPropertyUC, PP_MotorizedPropertyUC>()
                .RegisterType<IPP_MotorizedPropertyUCPresenter, PP_MotorizedPropertyUCPresenter>();
            PP_MotorizedPropertyUCPresenter presenter = unityC.Resolve<PP_MotorizedPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_MotorizedOptionVisibility", new Binding("Checked", _panelModel, "Panel_MotorizedOptionVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MotorizedOptionVisibility2", new Binding("Visible", _panelModel, "Panel_MotorizedOptionVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MotorizedMechArtNo", new Binding("Text", _panelModel, "Panel_MotorizedMechArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MotorizedPropertyHeight", new Binding("Height", _panelModel, "Panel_MotorizedPropertyHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MotorizedMechSetQty", new Binding("Value", _panelModel, "Panel_MotorizedMechSetQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_2DHingeQty", new Binding("Value", _panelModel, "Panel_2DHingeQty", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
