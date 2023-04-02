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
   public class SP_PriceIncreaseByPercentageUCPresenter : ISP_PriceIncreaseByPercentageUCPresenter
    {
        ISP_PriceIncreaseByPercentageUC _sp_PriceIncreaseByPercentageUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;
        private IScreenPresenter _screenPresenter;

        public ISP_PriceIncreaseByPercentageUC GetISP_PriceIncreaseByPercentageUC()
        {
            return _sp_PriceIncreaseByPercentageUC;
        }

        public SP_PriceIncreaseByPercentageUCPresenter(ISP_PriceIncreaseByPercentageUC sp_PriceIncreaseByPercentageUC)
        {
            _sp_PriceIncreaseByPercentageUC = sp_PriceIncreaseByPercentageUC;
            SubscribeToEventSetUp();
        }

        private void SubscribeToEventSetUp()
        {
            _sp_PriceIncreaseByPercentageUC.chkboxAdditionalPercentageCheckedChangedEventRaised += _sp_PriceIncreaseByPercentageUC_chkboxAdditionalPercentageCheckedChangedEventRaised;
            _sp_PriceIncreaseByPercentageUC.nudPercentageValueChangedEventRaised += _sp_PriceIncreaseByPercentageUC_nudPercentageValueChangedEventRaised;
            _sp_PriceIncreaseByPercentageUC.SPPriceIncreaseByPercentageUCLoadEventRaised += _sp_PriceIncreaseByPercentageUC_SPPriceIncreaseByPercentageUCLoadEventRaised;
        }

        private void _sp_PriceIncreaseByPercentageUC_SPPriceIncreaseByPercentageUCLoadEventRaised(object sender, EventArgs e)
        {

            _screenModel.Screen_PriceIncreaseVisibilityOption = false;
            _screenModel.Screen_PriceIncreasePercentage = 5;
            _sp_PriceIncreaseByPercentageUC.GetPanelBody().Visible = false;
            _sp_PriceIncreaseByPercentageUC.GetPriceIncraeseUserControl().Size = new System.Drawing.Size(227, 27);
            _sp_PriceIncreaseByPercentageUC.ThisBinding(CreateBindingDictionary());
        }

        private void _sp_PriceIncreaseByPercentageUC_nudPercentageValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if(_sp_PriceIncreaseByPercentageUC.GetNudPriceIncrease().Text == "" || _sp_PriceIncreaseByPercentageUC.GetNudPriceIncrease().Text == " ")
                {
                    _screenModel.Screen_PriceIncreasePercentage = 0;
                    _screenPresenter.GetCurrentAmount();
                }
                else
                {
                    _screenModel.Screen_PriceIncreasePercentage = (int)((NumericUpDown)sender).Value;                
                    _screenPresenter.GetCurrentAmount();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in PriceIncreaseByPercentage " + ex.Message);
                _screenModel.Screen_PriceIncreasePercentage = 0;

            }
        }

        private void _sp_PriceIncreaseByPercentageUC_chkboxAdditionalPercentageCheckedChangedEventRaised(object sender, EventArgs e)
        {
            if (_sp_PriceIncreaseByPercentageUC.GetChkBoxPriceIncrease().Checked)
            {
                _screenModel.Screen_PriceIncreaseVisibilityOption = true;
                _sp_PriceIncreaseByPercentageUC.GetPanelBody().Visible = true;
                _sp_PriceIncreaseByPercentageUC.GetPriceIncraeseUserControl().Size = new System.Drawing.Size(227, 54);
            }
            else
            {
                _screenModel.Screen_PriceIncreaseVisibilityOption = false;
                _sp_PriceIncreaseByPercentageUC.GetPanelBody().Visible = false;
                _sp_PriceIncreaseByPercentageUC.GetPriceIncraeseUserControl().Size = new System.Drawing.Size(227, 27);
            }
            _screenPresenter.GetCurrentAmount();
        }
        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Screen_PriceIncreaseVisibility", new Binding("Visible", _screenModel, "Screen_PriceIncreaseVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_PriceIncreaseVisibilityOption", new Binding("Checked", _screenModel, "Screen_PriceIncreaseVisibilityOption", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_PriceIncreasePercentage", new Binding("Value", _screenModel, "Screen_PriceIncreasePercentage", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

        public ISP_PriceIncreaseByPercentageUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                           IMainPresenter mainPresenter,
                                                                           IScreenModel screenModel,
                                                                           IScreenPresenter screenPresenter)
        {
            unityC
                .RegisterType<ISP_PriceIncreaseByPercentageUC, SP_PriceIncreaseByPercentageUC>()
                .RegisterType<ISP_PriceIncreaseByPercentageUCPresenter, SP_PriceIncreaseByPercentageUCPresenter>();
            SP_PriceIncreaseByPercentageUCPresenter priceincrease = unityC.Resolve<SP_PriceIncreaseByPercentageUCPresenter>();
            priceincrease._unityC = unityC;
            priceincrease._mainPresenter = mainPresenter;
            priceincrease._screenModel = screenModel;
            priceincrease._screenPresenter = screenPresenter;

            return priceincrease;
        }


    }
}
