using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public class SP_PVCbox1067WithReinPropertyUCPresenter : ISP_PVCbox1067WithReinPropertyUCPresenter
    {
        ISP_PVCbox1067WithReinPropertyUC _PVCbox1067WithReinPropertyUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;
        private IScreenPresenter _screenPresenter;
        private NumericUpDown _nud1067PVCBox;
        private NumericUpDown _nud1067PVCBoxQty;
        
        public SP_PVCbox1067WithReinPropertyUCPresenter(ISP_PVCbox1067WithReinPropertyUC PVCbox1067WithReinPropertyUC)
        {
            _PVCbox1067WithReinPropertyUC = PVCbox1067WithReinPropertyUC;
            _nud1067PVCBox = _PVCbox1067WithReinPropertyUC.GetNumericUpDown1067PVCBox();
            _nud1067PVCBoxQty = _PVCbox1067WithReinPropertyUC.GetNumericUpDown1067PVCBoxQty();
            subcribeToEventSetup();
        }

        private void subcribeToEventSetup()
        {
            _PVCbox1067WithReinPropertyUC.SPPVCbox1067WithReinPropertyUCLoadEventRaised += _PVCbox1067WithReinPropertyUC_SPPVCbox1067WithReinPropertyUCLoadEventRaised;
            _PVCbox1067WithReinPropertyUC.nud_1067PVCbox_ValueChangedEventRaised += _PVCbox1067WithReinPropertyUC_nud_1067PVCbox_ValueChangedEventRaised;
            _PVCbox1067WithReinPropertyUC.nud1067PVCboxQtyValueChangedEventRaised += _PVCbox1067WithReinPropertyUC_nud1067PVCboxQtyValueChangedEventRaised;
        }

        private void _PVCbox1067WithReinPropertyUC_nud_1067PVCbox_ValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if(_nud1067PVCBox.Text == "" || _nud1067PVCBox.Text == " ")
                {
                    _screenModel.Screen_1067PVCbox = 0;
                    _screenPresenter.GetCurrentAmount();
                }
                else
                {
                    _screenModel.Screen_1067PVCbox = (int)((NumericUpDown)sender).Value;
                    _screenPresenter.GetCurrentAmount();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in " + this + " " + ex.Message );
                _nud1067PVCBox.Value = 0;
            }
            
        }
        private void _PVCbox1067WithReinPropertyUC_nud1067PVCboxQtyValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (_nud1067PVCBoxQty.Text == "" || _nud1067PVCBoxQty.Text == " ")
                {
                    _screenModel.Screen_1067PVCboxQty = 0;
                    _screenPresenter.GetCurrentAmount();
                }
                else
                {
                    _screenModel.Screen_1067PVCboxQty = (int)((NumericUpDown)sender).Value;
                    _screenPresenter.GetCurrentAmount();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in " + this + " " + ex.Message);
                _nud1067PVCBoxQty.Value = 0;
            }
        }

        private void _PVCbox1067WithReinPropertyUC_SPPVCbox1067WithReinPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _PVCbox1067WithReinPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public ISP_PVCbox1067WithReinPropertyUC GetPVCbox1067WithReinPropertyUC()
        {
            return _PVCbox1067WithReinPropertyUC;
        }

        public ISP_PVCbox1067WithReinPropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                                        IMainPresenter mainPresenter,
                                                                                        IScreenModel screenModel,
                                                                                        IScreenPresenter screenPresenter)
        {
            unityC
                .RegisterType<ISP_PVCbox1067WithReinPropertyUC, SP_PVCbox1067WithReinPropertyUC>()
                .RegisterType<ISP_PVCbox1067WithReinPropertyUCPresenter, SP_PVCbox1067WithReinPropertyUCPresenter>();
            SP_PVCbox1067WithReinPropertyUCPresenter pvc1067 = unityC.Resolve<SP_PVCbox1067WithReinPropertyUCPresenter>();
            pvc1067._unityC = unityC;
            pvc1067._mainPresenter = mainPresenter;
            pvc1067._screenModel = screenModel;
            pvc1067._screenPresenter = screenPresenter;



            return pvc1067;
        }


        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Screen_1067PVCboxVisibility", new Binding("Visible", _screenModel, "Screen_1067PVCboxVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_1067PVCbox", new Binding("Value", _screenModel, "Screen_1067PVCbox", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_1067PVCboxQty", new Binding("Value", _screenModel, "Screen_1067PVCboxQty", true, DataSourceUpdateMode.OnPropertyChanged));


            return binding;
        }
    }
}
