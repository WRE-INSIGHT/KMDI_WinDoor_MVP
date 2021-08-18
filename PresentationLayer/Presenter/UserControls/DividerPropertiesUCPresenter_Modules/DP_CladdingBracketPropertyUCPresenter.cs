using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.Views.UserControls.DividerProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.DividerPropertiesUCPresenter_Modules
{
    public class DP_CladdingBracketPropertyUCPresenter : IDP_CladdingBracketPropertyUCPresenter
    {
        IDP_CladdingBracketPropertyUC _dp_CladdingBracketPropertyUC;
        private IDividerModel _dividerModel;
        private IUnityContainer _unityC;



        public DP_CladdingBracketPropertyUCPresenter(IDP_CladdingBracketPropertyUC dp_CladdingBracketPropertyUC)
        {
            _dp_CladdingBracketPropertyUC = dp_CladdingBracketPropertyUC;
            SubscribeToEventSetup();
        }


        private void SubscribeToEventSetup()
        {
            _dp_CladdingBracketPropertyUC.CladdingBracketPropertyUCLoadEventRaised += _dp_CladdingBracketPropertyUC_CladdingBracketPropertyUCLoadEventRaised;
            _dp_CladdingBracketPropertyUC.nudBracketForConcreteValueChangedEventRaised += _dp_CladdingBracketPropertyUC_nudBracketForConcreteValueChangedEventRaised;
            _dp_CladdingBracketPropertyUC.nudBracketForUPVCValueChangedEventRaised += _dp_CladdingBracketPropertyUC_nudBracketForUPVCValueChangedEventRaised;
        }

        private void _dp_CladdingBracketPropertyUC_nudBracketForUPVCValueChangedEventRaised(object sender, EventArgs e)
        {
            //TODO
        }

        private void _dp_CladdingBracketPropertyUC_nudBracketForConcreteValueChangedEventRaised(object sender, EventArgs e)
        {
            //TODO
        }

        private void _dp_CladdingBracketPropertyUC_CladdingBracketPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _dp_CladdingBracketPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IDP_CladdingBracketPropertyUC GetCladdingBracketPropertyUC()
        {
            return _dp_CladdingBracketPropertyUC;
        }

        public IDP_CladdingBracketPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IDividerModel dividerModel)
        {
            unityC
                .RegisterType<IDP_CladdingBracketPropertyUC, DP_CladdingBracketPropertyUC>()
                .RegisterType<IDP_CladdingBracketPropertyUCPresenter, DP_CladdingBracketPropertyUCPresenter>();
            DP_CladdingBracketPropertyUCPresenter CladdingBracketPropertyUCPresenter = unityC.Resolve<DP_CladdingBracketPropertyUCPresenter>();
            CladdingBracketPropertyUCPresenter._unityC = unityC;
            CladdingBracketPropertyUCPresenter._dividerModel = dividerModel;

            return CladdingBracketPropertyUCPresenter;
        }
        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Div_claddingBracketVisibility", new Binding("Visible", _dividerModel, "Div_claddingBracketVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Div_CladdingBracketForConcrete", new Binding("Text", _dividerModel, "Div_CladdingBracketForConcrete", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Div_CladdingBracketForUPVC", new Binding("Text", _dividerModel, "Div_CladdingBracketForUPVC", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;

        }

    }
}
