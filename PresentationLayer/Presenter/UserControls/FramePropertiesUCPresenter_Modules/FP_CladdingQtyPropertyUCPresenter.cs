using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public class FP_CladdingQtyPropertyUCPresenter : IFP_CladdingQtyPropertyUCPresenter
    {
        IFP_CladdingQtyPropertyUC _claddingQtyPropertyUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainpresenter;
        private IFrameModel _frameModel;

        public FP_CladdingQtyPropertyUCPresenter(IFP_CladdingQtyPropertyUC claddingQtyPropertyUC)
        {
            _claddingQtyPropertyUC = claddingQtyPropertyUC;

            SubcribeToEventSetUp();
        }

        private void SubcribeToEventSetUp()
        {
            _claddingQtyPropertyUC.CladdingQtyPropertyUCLoadEventRaised += _claddingQtyPropertyUC_CladdingQtyPropertyUCLoadEventRaised;
            _claddingQtyPropertyUC.nudCladdingQtyValueChangedEventRaised += _claddingQtyPropertyUC_nudCladdingQtyValueChangedEventRaised;
        }

        private void _claddingQtyPropertyUC_nudCladdingQtyValueChangedEventRaised(object sender, EventArgs e)
        {
            if (!_mainpresenter.ItemLoad)
            {
                _frameModel.Frame_CladdingQty = Convert.ToInt32(((NumericUpDown)sender).Value);
            }
        }

        private void _claddingQtyPropertyUC_CladdingQtyPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _claddingQtyPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IFP_CladdingQtyPropertyUC GetCladdingQtyPropertyUC()
        {
            return _claddingQtyPropertyUC;
        }

        public IFP_CladdingQtyPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                 IMainPresenter mainpresenter,
                                                                 IFrameModel frameModel)
        {
            unityC
                  .RegisterType<IFP_CladdingQtyPropertyUC, FP_CladdingQtyPropertyUC>()
                  .RegisterType<IFP_CladdingQtyPropertyUCPresenter, FP_CladdingQtyPropertyUCPresenter>();
            FP_CladdingQtyPropertyUCPresenter cladding = unityC.Resolve<FP_CladdingQtyPropertyUCPresenter>();

            cladding._unityC = unityC;
            cladding._mainpresenter = mainpresenter;
            cladding._frameModel = frameModel;

            return cladding;
        }





        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Frame_CladdingQty", new Binding("Value", _frameModel, "Frame_CladdingQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_CladdingVisibility", new Binding("Visible", _frameModel, "Frame_CladdingVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
