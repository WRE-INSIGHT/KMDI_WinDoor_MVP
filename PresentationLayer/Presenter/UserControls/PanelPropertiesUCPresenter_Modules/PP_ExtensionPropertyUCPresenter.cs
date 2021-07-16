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
        }

        private void _pp_extensionUC_chkToAddExtension2CheckedChangedEventRaised(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked == true)
            {
                chk.Text = "-";
                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtensionField");
                _panelModel.AdjustPropertyPanelHeight("addExtensionField");
                _panelModel.AdjustHandlePropertyHeight("addExtensionField");
                _panelModel.AdjustRotoswingPropertyHeight("addExtensionField");
                _panelModel.AdjustExtensionPropertyHeight("addExtensionField");
            }
            else if (chk.Checked == false)
            {
                chk.Text = "+";
                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtensionField");
                _panelModel.AdjustPropertyPanelHeight("minusExtensionField");
                _panelModel.AdjustHandlePropertyHeight("minusExtensionField");
                _panelModel.AdjustRotoswingPropertyHeight("minusExtensionField");
                _panelModel.AdjustExtensionPropertyHeight("minusExtensionField");
            }

            if (chk.Name == "chk_ToAdd_TopExt2")
            {
                _pnlTopExt2Option.Visible = chk.Checked;
            }
            else if (chk.Name == "chk_ToAdd_BotExt2")
            {
                _pnlBotExt2Option.Visible = chk.Checked;
            }
            else if (chk.Name == "chk_ToAdd_LeftExt2")
            {
                _pnlLeftExt2Option.Visible = chk.Checked;
            }
            else if (chk.Name == "chk_ToAdd_RightExt2")
            {
                _pnlRightExt2Option.Visible = chk.Checked;
            }
        }

        private void _pp_extensionUC_PPExtensionUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_extensionUC.ThisBinding(CreateBindingDictionary());
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_ExtTopQty", new Binding("Value", _panelModel, "Panel_ExtTopQty", true, DataSourceUpdateMode.OnPropertyChanged));
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
