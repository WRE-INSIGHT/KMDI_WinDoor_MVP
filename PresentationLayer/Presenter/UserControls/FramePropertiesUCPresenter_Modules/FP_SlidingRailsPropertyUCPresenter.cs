using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public class FP_SlidingRailsPropertyUCPresenter : IFP_SlidingRailsPropertyUCPresenter
    {
        IFP_SlidingRailsPropertyUC _slidingRailsPropertyUC;

        private IUnityContainer _unityC;
        private IFrameModel _frameModel;
        private IMainPresenter _mainPresenter;

        public FP_SlidingRailsPropertyUCPresenter(IFP_SlidingRailsPropertyUC slidingRailsPropertyUC)
        {
            _slidingRailsPropertyUC = slidingRailsPropertyUC;

            SubscribeToEventSetUp();
        }

        private void SubscribeToEventSetUp()
        {
            _slidingRailsPropertyUC.FPSlidingRailsPropertyUCLoadEventRaised += _slidingRailsPropertyUC_FPSlidingRailsPropertyUCLoadEventRaised;
            _slidingRailsPropertyUC.nudRailsQtyValueChangedEventRaised += _slidingRailsPropertyUC_nudRailsQtyValueChangedEventRaised;
        }

        private void _slidingRailsPropertyUC_nudRailsQtyValueChangedEventRaised(object sender, EventArgs e)
        {
            int railQty=(int)((NumericUpDown)sender).Value;
            if (railQty <= 5 && railQty >= 2)
            {
                _frameModel.Frame_SlidingRailsQty = railQty;
                _mainPresenter.GetCurrentPrice();
            }
            else
            {
                if (railQty > 5)
                {
                    ((NumericUpDown)sender).Value = 5;
                }
                else if (railQty < 2)
                {
                    ((NumericUpDown)sender).Value = 2;
                }
                MessageBox.Show("Rail must be 2 - 5 only");   
            }
          
        }

        private void _slidingRailsPropertyUC_FPSlidingRailsPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            if (_frameModel.Frame_SlidingRailsQty == 0)
            {
                _frameModel.Frame_SlidingRailsQty = 2;
            }
            else
            {
                _frameModel.Frame_SlidingRailsQty = _frameModel.Frame_SlidingRailsQty;
            }
            _slidingRailsPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IFP_SlidingRailsPropertyUC GetSlidingRailsPropertyUC()
        {
            return _slidingRailsPropertyUC;
        }

        public IFP_SlidingRailsPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                     IFrameModel frameModel,
                                                                     IMainPresenter mainPresenter)
        {
            unityC
                    .RegisterType<IFP_SlidingRailsPropertyUC, FP_SlidingRailsPropertyUC>()
                    .RegisterType<IFP_SlidingRailsPropertyUCPresenter, FP_SlidingRailsPropertyUCPresenter>();
            FP_SlidingRailsPropertyUCPresenter rails = unityC.Resolve<FP_SlidingRailsPropertyUCPresenter>();
            rails._unityC = unityC;
            rails._frameModel = frameModel;
            rails._mainPresenter = mainPresenter;

            return rails;
        }
        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Frame_SlidingRailsQty", new Binding("Value", _frameModel, "Frame_SlidingRailsQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_SlidingRailsQtyVisibility", new Binding("Visible", _frameModel, "Frame_SlidingRailsQtyVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
