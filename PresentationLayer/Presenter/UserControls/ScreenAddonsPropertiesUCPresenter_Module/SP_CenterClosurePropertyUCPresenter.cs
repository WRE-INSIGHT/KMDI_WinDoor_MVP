using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public class SP_CenterClosurePropertyUCPresenter : ISP_CenterClosurePropertyUCPresenter
    {
        ISP_CenterClosurePropertyUC _sp_centerClosurePropertyUC;


        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;
        private IScreenPresenter _screenPresenter;
        
        public SP_CenterClosurePropertyUCPresenter(ISP_CenterClosurePropertyUC sp_centerClosurePropertyUC)
        {
            _sp_centerClosurePropertyUC = sp_centerClosurePropertyUC;

            SubcribeToEventSetpUp();
        }

        private void SubcribeToEventSetpUp()
        {
            _sp_centerClosurePropertyUC.SPCenterClosurePropertyUCLoadEventRaised += _sp_centerClosurePropertyUC_SPCenterClosurePropertyUCLoadEventRaised;
            _sp_centerClosurePropertyUC.chkBoxCenterClosureCheckedChangedEventRaised += _sp_centerClosurePropertyUC_chkBoxCenterClosureCheckedChangedEventRaised;

            _sp_centerClosurePropertyUC.nud_LatchKitQty_ValueChangedEventRaised += _sp_centerClosurePropertyUC_nud_LatchKitQty_ValueChangedEventRaised;
            _sp_centerClosurePropertyUC.nud_IntermediatePartQty_ValueChangedEventRaised += _sp_centerClosurePropertyUC_nud_IntermediatePartQty_ValueChangedEventRaised;

        }

        private void _sp_centerClosurePropertyUC_nud_LatchKitQty_ValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (_sp_centerClosurePropertyUC.GetNumericUpDownLatchKit().Text == "" || _sp_centerClosurePropertyUC.GetNumericUpDownLatchKit().Text == " ")
                {
                    _screenModel.Screen_LatchKitQty = 0;
                    _screenPresenter.GetCurrentAmount();
                }
                else
                {
                    _screenModel.Screen_LatchKitQty = (int)((NumericUpDown)sender).Value;
                    _screenPresenter.GetCurrentAmount();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CenterClosure LatchKitQty " + ex.Message);
                _screenModel.Screen_LatchKitQty = 0;
            }

        }
        private void _sp_centerClosurePropertyUC_nud_IntermediatePartQty_ValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (_sp_centerClosurePropertyUC.GetNumericUpDownIntermediatePart().Text == "" || _sp_centerClosurePropertyUC.GetNumericUpDownIntermediatePart().Text == " ")
                {
                    _screenModel.Screen_IntermediatePartQty = 0;
                    _screenPresenter.GetCurrentAmount();
                }
                else
                {
                    _screenModel.Screen_IntermediatePartQty = (int)((NumericUpDown)sender).Value;
                    _screenPresenter.GetCurrentAmount();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CenterClosure IntermediatePart " + ex.Message);
                _screenModel.Screen_IntermediatePartQty = 0;
            }
        }

        private void _sp_centerClosurePropertyUC_chkBoxCenterClosureCheckedChangedEventRaised(object sender, EventArgs e)
        {
            if (_screenModel.Screen_CenterClosureVisibilityOption == true)
            {
                _sp_centerClosurePropertyUC.GetPanelBody().Visible = false;
            }
            else
            {
                _sp_centerClosurePropertyUC.GetPanelBody().Visible = true;
            }
        }

        private void _sp_centerClosurePropertyUC_SPCenterClosurePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_CenterClosureVisibilityOption = false;
            _sp_centerClosurePropertyUC.GetPanelBody().Visible = false;
            _sp_centerClosurePropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public ISP_CenterClosurePropertyUC GetISP_CenterClosurePropertyUC()
        {
            return _sp_centerClosurePropertyUC;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Screen_CenterClosureVisibility", new Binding("Visible", _screenModel, "Screen_CenterClosureVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_CenterClosureVisibilityOption", new Binding("Checked", _screenModel, "Screen_CenterClosureVisibilityOption", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_LatchKitQty", new Binding("Value", _screenModel, "Screen_LatchKitQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_IntermediatePartQty", new Binding("Value", _screenModel, "Screen_IntermediatePartQty", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

        public ISP_CenterClosurePropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                      IMainPresenter mainPresenter,
                                                                      IScreenModel screenModel,
                                                                      IScreenPresenter screenPresenter)
        {
            unityC
                .RegisterType<ISP_CenterClosurePropertyUC, SP_CenterClosurePropertyUC>()
                .RegisterType<ISP_CenterClosurePropertyUCPresenter, SP_CenterClosurePropertyUCPresenter>();
            SP_CenterClosurePropertyUCPresenter centerClosure = unityC.Resolve<SP_CenterClosurePropertyUCPresenter>();
            centerClosure._unityC = unityC;
            centerClosure._mainPresenter = mainPresenter;
            centerClosure._screenModel = screenModel;
            centerClosure._screenPresenter = screenPresenter;

            return centerClosure;
        }


    }
}
