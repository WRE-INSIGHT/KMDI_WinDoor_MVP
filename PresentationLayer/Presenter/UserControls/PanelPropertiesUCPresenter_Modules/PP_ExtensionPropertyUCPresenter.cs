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
    public class PP_ExtensionPropertyUCPresenter : IPP_ExtensionPropertyUCPresenter, IPresenterCommon
    {
        IPP_ExtensionPropertyUC _pp_extensionUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        Panel _pnlTopExt2Option;
        Panel _pnlBotExt2Option;
        Panel _pnlLeftExt2Option;
        Panel _pnlRightExt2Option;

        bool _initialLoad = true;

        public PP_ExtensionPropertyUCPresenter(IPP_ExtensionPropertyUC pp_extensionUC)
        {
            _pp_extensionUC = pp_extensionUC;
            _pnlTopExt2Option = _pp_extensionUC.GetTopExt2OptionPNL();
            _pnlBotExt2Option = _pp_extensionUC.GetBotExt2OptionPNL();
            _pnlLeftExt2Option = _pp_extensionUC.GetLeftExt2OptionPNL();
            _pnlRightExt2Option = _pp_extensionUC.GetRightExt2OptionPNL();
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_extensionUC.PPExtensionUCLoadEventRaised += _pp_extensionUC_PPExtensionUCLoadEventRaised;
            _pp_extensionUC.chkToAddExtension2CheckedChangedEventRaised += _pp_extensionUC_chkToAddExtension2CheckedChangedEventRaised;
            _pp_extensionUC.cmbExtensionsSelectedValueChangedEventRaised += _pp_extensionUC_cmbExtensionsSelectedValueChangedEventRaised;
        }

        private void _pp_extensionUC_cmbExtensionsSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (_initialLoad == false)
            {
                Extension_ArticleNo extArtNo = (Extension_ArticleNo)cmb.SelectedValue;
                if (cmb.Name == "cmb_TopExt")
                {
                    _panelModel.Panel_ExtensionTopArtNo = extArtNo;
                }
                else if (cmb.Name == "cmb_TopExt2")
                {
                    _panelModel.Panel_ExtensionTop2ArtNo = extArtNo;
                }
                else if (cmb.Name == "cmb_BotExt")
                {
                    _panelModel.Panel_ExtensionBotArtNo = extArtNo;
                }
                else if (cmb.Name == "cmb_BotExt2")
                {
                    _panelModel.Panel_ExtensionBot2ArtNo = extArtNo;
                }
                else if (cmb.Name == "cmb_LeftExt")
                {
                    _panelModel.Panel_ExtensionLeftArtNo = extArtNo;
                }
                else if (cmb.Name == "cmb_LeftExt2")
                {
                    _panelModel.Panel_ExtensionLeft2ArtNo = extArtNo;
                }
                else if (cmb.Name == "cmb_RightExt")
                {
                    _panelModel.Panel_ExtensionRightArtNo = extArtNo;
                }
                else if (cmb.Name == "cmb_RightExt2")
                {
                    _panelModel.Panel_ExtensionRight2ArtNo = extArtNo;
                }
            }
        }

        private void _pp_extensionUC_chkToAddExtension2CheckedChangedEventRaised(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            if (chk.Name == "chk_ToAdd_TopExt2")
            {
                _panelModel.Panel_ExtTopChk = chk.Checked;
            }
            else if (chk.Name == "chk_ToAdd_BotExt2")
            {
                _panelModel.Panel_ExtBotChk = chk.Checked;
            }
            else if (chk.Name == "chk_ToAdd_LeftExt2")
            {
                _panelModel.Panel_ExtLeftChk = chk.Checked;
            }
            else if (chk.Name == "chk_ToAdd_RightExt2")
            {
                _panelModel.Panel_ExtRightChk = chk.Checked;
            }

            if (chk.Checked == true)
            {
                chk.Text = "-";
                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtensionField");
                _panelModel.AdjustPropertyPanelHeight("addExtensionField");
                _panelModel.AdjustHandlePropertyHeight("addExtensionField");
                _panelModel.AdjustRotoswingPropertyHeight("addExtensionField");
                _panelModel.AdjustExtensionPropertyHeight("addExtensionField");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addExtensionField");
                }
            }
            else if (chk.Checked == false)
            {
                chk.Text = "+";
                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtensionField");
                _panelModel.AdjustPropertyPanelHeight("minusExtensionField");
                _panelModel.AdjustHandlePropertyHeight("minusExtensionField");
                _panelModel.AdjustRotoswingPropertyHeight("minusExtensionField");
                _panelModel.AdjustExtensionPropertyHeight("minusExtensionField");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusExtensionField");
                }
            }

        }

        private void _pp_extensionUC_PPExtensionUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_extensionUC.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_ExtTopQty", new Binding("Value", _panelModel, "Panel_ExtTopQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtBotQty", new Binding("Value", _panelModel, "Panel_ExtBotQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtLeftQty", new Binding("Value", _panelModel, "Panel_ExtLeftQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtRightQty", new Binding("Value", _panelModel, "Panel_ExtRightQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtTop2Qty", new Binding("Value", _panelModel, "Panel_ExtTop2Qty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtBot2Qty", new Binding("Value", _panelModel, "Panel_ExtBot2Qty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtLeft2Qty", new Binding("Value", _panelModel, "Panel_ExtLeft2Qty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtRight2Qty", new Binding("Value", _panelModel, "Panel_ExtRight2Qty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtensionTopArtNo", new Binding("Text", _panelModel, "Panel_ExtensionTopArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtensionTop2ArtNo", new Binding("Text", _panelModel, "Panel_ExtensionTop2ArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtensionBotArtNo", new Binding("Text", _panelModel, "Panel_ExtensionBotArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtensionBot2ArtNo", new Binding("Text", _panelModel, "Panel_ExtensionBot2ArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtensionLeftArtNo", new Binding("Text", _panelModel, "Panel_ExtensionLeftArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtensionLeft2ArtNo", new Binding("Text", _panelModel, "Panel_ExtensionLeft2ArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtensionRightArtNo", new Binding("Text", _panelModel, "Panel_ExtensionRightArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtensionRight2ArtNo", new Binding("Text", _panelModel, "Panel_ExtensionRight2ArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtTopChk", new Binding("Checked", _panelModel, "Panel_ExtTopChk", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtTopChk_visible", new Binding("Visible", _panelModel, "Panel_ExtTopChk", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtBotChk", new Binding("Checked", _panelModel, "Panel_ExtBotChk", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtBotChk_visible", new Binding("Visible", _panelModel, "Panel_ExtBotChk", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtLeftChk", new Binding("Checked", _panelModel, "Panel_ExtLeftChk", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtLeftChk_visible", new Binding("Visible", _panelModel, "Panel_ExtLeftChk", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtRightChk", new Binding("Checked", _panelModel, "Panel_ExtRightChk", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ExtRightChk_visible", new Binding("Visible", _panelModel, "Panel_ExtRightChk", true, DataSourceUpdateMode.OnPropertyChanged));

            binding.Add("Panel_ExtensionPropertyHeight", new Binding("Height", _panelModel, "Panel_ExtensionPropertyHeight", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

        public IPP_ExtensionPropertyUC GetPPExtensionUC()
        {
            return _pp_extensionUC;
        }

        public IPP_ExtensionPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_ExtensionPropertyUC, PP_ExtensionPropertyUC>()
                .RegisterType<IPP_ExtensionPropertyUCPresenter, PP_ExtensionPropertyUCPresenter>();
            PP_ExtensionPropertyUCPresenter presenter = unityC.Resolve<PP_ExtensionPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

    }
}
