using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public class SP_6040MilledProfileWithReinforcementPropertyUCPresenter : ISP_6040MilledProfileWithReinforcementPropertyUCPresenter
    {
        ISP_6040MilledProfileWithReinforcementPropertyUC _6040MilledProfile;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;
        private IScreenPresenter _screenPresenter;
        private NumericUpDown _nud6040ProfileWithRein;
        private NumericUpDown _nud6040ProfileWithReinQty;

        public SP_6040MilledProfileWithReinforcementPropertyUCPresenter(ISP_6040MilledProfileWithReinforcementPropertyUC MilledProfile6040)
        {
            _6040MilledProfile = MilledProfile6040;
            _nud6040ProfileWithRein = _6040MilledProfile.GetNumericUpDown6040ProfilewRein();
            _nud6040ProfileWithReinQty = _6040MilledProfile.GetNumericUpDown6040ProfilewReinQty();
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _6040MilledProfile.SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised += _6040MilledProfile_SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised;
            _6040MilledProfile.nud_6040MilledProfile_ValueChangedEventRaised += _6040MilledProfile_nud_6040MilledProfile_ValueChangedEventRaised;
            _6040MilledProfile.nud6040MilledProfileQtyValueChangedEventRaised += _6040MilledProfile_nud6040MilledProfileQtyValueChangedEventRaised;
        }

        private void _6040MilledProfile_nud_6040MilledProfile_ValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if(_nud6040ProfileWithRein.Text == "" || _nud6040ProfileWithRein.Text == " ")
                {
                    _screenModel.Screen_6040MilledProfile = 0;
                    _screenPresenter.GetCurrentAmount();
                }
                else
                {
                    _screenModel.Screen_6040MilledProfile = (int)((NumericUpDown)sender).Value;
                    _screenPresenter.GetCurrentAmount();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in " + this + " " + ex.Message);
                _nud6040ProfileWithRein.Value = 0;
            }
            
                      
        }
        private void _6040MilledProfile_nud6040MilledProfileQtyValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (_nud6040ProfileWithReinQty.Text == "" || _nud6040ProfileWithReinQty.Text == " ")
                {
                    _screenModel.Screen_6040MilledProfileQty = 0;
                    _screenPresenter.GetCurrentAmount();
                }
                else
                {
                    _screenModel.Screen_6040MilledProfileQty = (int)((NumericUpDown)sender).Value;
                    _screenPresenter.GetCurrentAmount();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in " + this + " " + ex.Message);
                _nud6040ProfileWithReinQty.Value = 0;
            }
        }

        private void _6040MilledProfile_SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _6040MilledProfile.ThisBinding(CreateBindingDictionary());
        }

        public ISP_6040MilledProfileWithReinforcementPropertyUC Get6040MilledProfile()
        {
            return _6040MilledProfile;
        }

        public ISP_6040MilledProfileWithReinforcementPropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                                            IMainPresenter mainPresenter,
                                                                                            IScreenModel screenModel,
                                                                                            IScreenPresenter screenPresenter)
        {
            unityC
                .RegisterType<ISP_6040MilledProfileWithReinforcementPropertyUC, SP_6040MilledProfileWithReinforcementPropertyUC>()
                .RegisterType<ISP_6040MilledProfileWithReinforcementPropertyUCPresenter, SP_6040MilledProfileWithReinforcementPropertyUCPresenter>();
            SP_6040MilledProfileWithReinforcementPropertyUCPresenter MilledProfile6040 = unityC.Resolve<SP_6040MilledProfileWithReinforcementPropertyUCPresenter>();
            MilledProfile6040._unityC = unityC;
            MilledProfile6040._mainPresenter = mainPresenter;
            MilledProfile6040._screenModel = screenModel;
            MilledProfile6040._screenPresenter = screenPresenter;



            return MilledProfile6040;
        }


        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Screen_6040MilledProfileVisibility", new Binding("Visible", _screenModel, "Screen_6040MilledProfileVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_6040MilledProfile", new Binding("Value", _screenModel, "Screen_6040MilledProfile", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_6040MilledProfileQty", new Binding("Value", _screenModel, "Screen_6040MilledProfileQty", true, DataSourceUpdateMode.OnPropertyChanged));


            return binding;
        }
    }
}
