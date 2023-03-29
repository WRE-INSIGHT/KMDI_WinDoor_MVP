using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public class SP_6052MilledProfilePropertyUCPresenter : ISP_6052MilledProfilePropertyUCPresenter
    {
        ISP_6052MilledProfilePropertyUC _sp_6052MilledProfilePropertyUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;
        private IScreenPresenter _screenPresenter;

        public SP_6052MilledProfilePropertyUCPresenter(ISP_6052MilledProfilePropertyUC sp_6052MilledProfilePropertyUC)
        {
            _sp_6052MilledProfilePropertyUC = sp_6052MilledProfilePropertyUC;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _sp_6052MilledProfilePropertyUC.SP6052MilledProfilePropertyUCLoadEventRaised += _sp_6052MilledProfilePropertyUC_SP6052MilledProfilePropertyUCLoadEventRaised;
            _sp_6052MilledProfilePropertyUC.nud_6052MilledProfile_ValueChangedEventRaised += _sp_6052MilledProfilePropertyUC_nud_6052MilledProfile_ValueChangedEventRaised;
            _sp_6052MilledProfilePropertyUC.nud_6052MilledProfileQty_ValueChangedEventRaised += _sp_6052MilledProfilePropertyUC_nud_6052MilledProfileQty_ValueChangedEventRaised;
        }
    
        private void _sp_6052MilledProfilePropertyUC_nud_6052MilledProfile_ValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (_sp_6052MilledProfilePropertyUC.GetNumericUpDown6052MilledProfile().Text == "" || _sp_6052MilledProfilePropertyUC.GetNumericUpDown6052MilledProfile().Text == " ")
                {
                    _screenModel.Screen_6052MilledProfile = 0;
                    _screenPresenter.GetCurrentAmount();
                }
                else
                {
                    _screenModel.Screen_6052MilledProfile = (int)((NumericUpDown)sender).Value;
                    _screenPresenter.GetCurrentAmount();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in " + this + " " + ex.Message);
                _screenModel.Screen_6052MilledProfile = 0;
            }
            
            
        }
        private void _sp_6052MilledProfilePropertyUC_nud_6052MilledProfileQty_ValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (_sp_6052MilledProfilePropertyUC.GetNumericUpDown6052MilledQty().Text == "" || _sp_6052MilledProfilePropertyUC.GetNumericUpDown6052MilledQty().Text == " ")
                {
                    _screenModel.Screen_6052MilledProfileQty = 0;
                    _screenPresenter.GetCurrentAmount();
                }
                else
                {
                    _screenModel.Screen_6052MilledProfileQty = (int)((NumericUpDown)sender).Value;
                    _screenPresenter.GetCurrentAmount();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in " + this + " " + ex.Message);
                _screenModel.Screen_6052MilledProfileQty = 0;
            }


        }

        private void _sp_6052MilledProfilePropertyUC_SP6052MilledProfilePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _sp_6052MilledProfilePropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public ISP_6052MilledProfilePropertyUC Get6052MilledProfilePropertyUC()
        {
            return _sp_6052MilledProfilePropertyUC;
        }

        public ISP_6052MilledProfilePropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                        IMainPresenter mainPresenter,
                                                                        IScreenModel screenModel,
                                                                        IScreenPresenter screenPresenter)
        {
            unityC
                    .RegisterType<ISP_6052MilledProfilePropertyUC, SP_6052MilledProfilePropertyUC>()
                    .RegisterType<ISP_6052MilledProfilePropertyUCPresenter, SP_6052MilledProfilePropertyUCPresenter>();
            SP_6052MilledProfilePropertyUCPresenter milledProfile6052 = unityC.Resolve<SP_6052MilledProfilePropertyUCPresenter>();
            milledProfile6052._unityC = unityC;
            milledProfile6052._mainPresenter = mainPresenter;
            milledProfile6052._screenModel = screenModel;
            milledProfile6052._screenPresenter = screenPresenter;


            return milledProfile6052;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Screen_6052MilledProfileVisibility", new Binding("Visible", _screenModel, "Screen_6052MilledProfileVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_6052MilledProfile", new Binding("Value", _screenModel, "Screen_6052MilledProfile", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_6052MilledProfileQty", new Binding("Value", _screenModel, "Screen_6052MilledProfileQty", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
