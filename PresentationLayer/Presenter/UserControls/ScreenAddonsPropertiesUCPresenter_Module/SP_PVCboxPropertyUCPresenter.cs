using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public class SP_PVCboxPropertyUCPresenter : ISP_PVCboxPropertyUCPresenter
    {
        ISP_PVCboxPropertyUC _sp_pVCboxPropertyUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;
        private IScreenPresenter _screenPresenter;
        private NumericUpDown _nud0505width;
        private NumericUpDown _nud0505Qty;
        private NumericUpDown _nud1067height;
        private NumericUpDown _nud1067Qty;


        public SP_PVCboxPropertyUCPresenter(ISP_PVCboxPropertyUC sp_pVCboxPropertyUC)
        {
            _sp_pVCboxPropertyUC = sp_pVCboxPropertyUC;
            _nud0505width = _sp_pVCboxPropertyUC.GetNumericUpDownScreen0505width();
            _nud0505Qty = _sp_pVCboxPropertyUC.GetNumericUpDownScreen0505Qty();
            _nud1067height = _sp_pVCboxPropertyUC.GetNumericUpDownScreen1067height();
            _nud1067Qty = _sp_pVCboxPropertyUC.GetNumericUpDownScreen1067Qty();
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _sp_pVCboxPropertyUC.SPPVCboxPropertyUCLoadEventRaised += _sp_pVCboxPropertyUC_SPPVCboxPropertyUCLoadEventRaised;
            _sp_pVCboxPropertyUC.nud0505WidthValueChangedEventRaised += _sp_pVCboxPropertyUC_nud0505WidthValueChangedEventRaised;
            _sp_pVCboxPropertyUC.nud1067HeightValueChangedEventRaised += _sp_pVCboxPropertyUC_nud1067HeightValueChangedEventRaised;
            _sp_pVCboxPropertyUC.nud1067QtyValueChangedEventRaised += _sp_pVCboxPropertyUC_nud1067QtyValueChangedEventRaised;
            _sp_pVCboxPropertyUC.nud0505QtyValueChangedEventRaised += _sp_pVCboxPropertyUC_nud0505QtyValueChangedEventRaised;
        }

        private void _sp_pVCboxPropertyUC_nud0505QtyValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if(_nud0505Qty.Text == "" || _nud0505Qty.Text == " ")
                {
                    _screenModel.Screen_0505Qty = 0;
                    _screenPresenter.GetCurrentAmount();
                }
                else
                {
                    _screenModel.Screen_0505Qty = (int)((NumericUpDown)sender).Value;
                    _screenPresenter.GetCurrentAmount();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erron in " + this + " " + ex.Message);
                _nud0505Qty.Value = 0;
            }
        }

        private void _sp_pVCboxPropertyUC_nud1067QtyValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if(_nud1067Qty.Text == "" || _nud1067Qty.Text == " ")
                {
                    _screenModel.Screen_1067Qty = 0;
                    _screenPresenter.GetCurrentAmount();
                }
                else
                {
                    _screenModel.Screen_1067Qty = (int)((NumericUpDown)sender).Value;
                    _screenPresenter.GetCurrentAmount();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in " + this + " "  + ex.Message);
                _nud1067Qty.Value = 0;
            }
        }

        private void _sp_pVCboxPropertyUC_nud1067HeightValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (_nud1067height.Text == "" || _nud1067height.Text == " ")
                {
                    _screenModel.Screen_1067Height = 0;
                    _screenPresenter.GetCurrentAmount();
                }
                else
                {
                    _screenModel.Screen_1067Height = (int)((NumericUpDown)sender).Value;
                    _screenPresenter.GetCurrentAmount();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in " + this + " " + ex.Message);
                _nud1067height.Value = 0;
            }              
        }

        private void _sp_pVCboxPropertyUC_nud0505WidthValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if(_nud0505width.Text == "" || _nud0505width.Text == " ")
                {
                    _screenModel.Screen_0505Width = 0;
                    _screenPresenter.GetCurrentAmount();
                }
                else
                {
                    _screenModel.Screen_0505Width = (int)((NumericUpDown)sender).Value;
                    _screenPresenter.GetCurrentAmount();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error In " + this + " " + ex.Message);
                _nud0505width.Value = 0;
            }
            
        }

        private void _sp_pVCboxPropertyUC_SPPVCboxPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _sp_pVCboxPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public ISP_PVCboxPropertyUC GetPVCboxPropertyUC()
        {
            return _sp_pVCboxPropertyUC;
        }

        public ISP_PVCboxPropertyUCPresenter CreatenewInstance(IUnityContainer unityC,
                                                               IMainPresenter mainPresenter,
                                                               IScreenModel screenModel,
                                                               IScreenPresenter screenPresenter)
        {
            unityC
                    .RegisterType<ISP_PVCboxPropertyUC, SP_PVCboxPropertyUC>()
                    .RegisterType<ISP_PVCboxPropertyUCPresenter, SP_PVCboxPropertyUCPresenter>();
            SP_PVCboxPropertyUCPresenter PVCbox = unityC.Resolve<SP_PVCboxPropertyUCPresenter>();
            PVCbox._unityC = unityC;
            PVCbox._mainPresenter = mainPresenter;
            PVCbox._screenModel = screenModel;
            PVCbox._screenPresenter = screenPresenter;

            return PVCbox;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Screen_PVCVisibility", new Binding("Visible", _screenModel, "Screen_PVCVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_0505Width", new Binding("Value", _screenModel, "Screen_0505Width", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_1067Height", new Binding("Value", _screenModel, "Screen_1067Height", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_0505Qty", new Binding("Value", _screenModel, "Screen_0505Qty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_1067Qty", new Binding("Value", _screenModel, "Screen_1067Qty", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }


    }
}
