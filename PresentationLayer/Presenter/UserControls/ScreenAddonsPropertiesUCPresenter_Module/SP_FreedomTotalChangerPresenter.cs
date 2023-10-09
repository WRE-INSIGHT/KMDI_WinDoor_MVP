using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public class SP_FreedomTotalChangerPresenter : ISP_FreedomTotalChangerPresenter
    {
        ISP_FreedomTotalChangerUC _sp_freedomTotalChangerUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;
        private IScreenPresenter _screenPresenter;

        public SP_FreedomTotalChangerPresenter(ISP_FreedomTotalChangerUC sp_freedomTotalChangerUC)
        {
            _sp_freedomTotalChangerUC = sp_freedomTotalChangerUC;

            _sp_freedomTotalChangerUC.chkboxtotalChangerCheckedChangedEventRaised += _sp_freedomTotalChangerUC_chkboxtotalChangerCheckedChangedEventRaised;
            _sp_freedomTotalChangerUC.SPFreedomTotalChangerUCLoadEventRaised += _sp_freedomTotalChangerUC_SPFreedomTotalChangerUCLoadEventRaised;
        }

        private void _sp_freedomTotalChangerUC_SPFreedomTotalChangerUCLoadEventRaised(object sender, EventArgs e)
        {
            _sp_freedomTotalChangerUC.ThisBinding(CreateBindingDictionary());
        }

        private void _sp_freedomTotalChangerUC_chkboxtotalChangerCheckedChangedEventRaised(object sender, EventArgs e)
        {
            if (_sp_freedomTotalChangerUC.GetFreedomTotalChangerChkBx().Checked)
            {
                _screenModel.Screen_FreedomTotalChangerIsChecked = true;
            }
            else
            {
                _screenModel.Screen_FreedomTotalChangerIsChecked = false;
            }
            _screenPresenter.GetCurrentAmount();
        }

        public ISP_FreedomTotalChangerUC GetISP_FreedomTotalChangerUC()
        {
            return _sp_freedomTotalChangerUC;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Screen_FreedomTotalChangerVisibility", new Binding("Visible", _screenModel, "Screen_FreedomTotalChangerVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_FreedomTotalChangerIsChecked", new Binding("Checked", _screenModel, "Screen_FreedomTotalChangerIsChecked", true, DataSourceUpdateMode.OnPropertyChanged));


            return binding;
        }

        public ISP_FreedomTotalChangerPresenter CreateNewIntance(IUnityContainer unityC,
                                                                 IMainPresenter mainPresenter,
                                                                 IScreenModel screenModel,
                                                                 IScreenPresenter screenPresenter)
        {

            unityC
                    .RegisterType<ISP_FreedomTotalChangerUC, SP_FreedomTotalChangerUC>()
                    .RegisterType<ISP_FreedomTotalChangerPresenter, SP_FreedomTotalChangerPresenter>();
            SP_FreedomTotalChangerPresenter freedomTotalChanger = unityC.Resolve<SP_FreedomTotalChangerPresenter>();
            freedomTotalChanger._unityC = unityC;
            freedomTotalChanger._mainPresenter = mainPresenter;
            freedomTotalChanger._screenModel = screenModel;
            freedomTotalChanger._screenPresenter = screenPresenter;

            return freedomTotalChanger;

        }
       
    }
}
