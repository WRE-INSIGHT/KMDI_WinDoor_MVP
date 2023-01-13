using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
   public  class SP_MagnumScreenTypeUCPresenter : ISP_MagnumScreenTypeUCPresenter
    {
        ISP_MagnumScreenTypeUC _magnumScreenTypeView;

        private IMainPresenter _mainPresenter;
        private IUnityContainer _unityC;
        private IScreenModel _screenModel;

        public ISP_MagnumScreenTypeUC GetMagnumScreenTypeView()
        {
            return _magnumScreenTypeView;
        }

        public SP_MagnumScreenTypeUCPresenter(ISP_MagnumScreenTypeUC magnumScreenTypeView)
        {
            _magnumScreenTypeView = magnumScreenTypeView;
            _magnumScreenTypeView.magnumScreenTypeEventRaised += new EventHandler(OnmagnumScreenTypeEventRaised);
            _magnumScreenTypeView.magnumScreenTypeUCloadEventRaised += new EventHandler(OnmagnumScreenTypeUCloadEventRaised);
            _magnumScreenTypeView.reinforcedCheckBoxEventRaised += new EventHandler(OnreinforcedCheckBoxEventRaised);
        }
 
        private void OnmagnumScreenTypeUCloadEventRaised(object sender, EventArgs e)
        {
            _magnumScreenTypeView.ThisBinding(CreateBindingDictionary());
        }
    
        private void OnreinforcedCheckBoxEventRaised(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void OnmagnumScreenTypeEventRaised(object sender, EventArgs e)
        {
            _screenModel.Magnum_ScreenType = (Magnum_ScreenType)((ComboBox)sender).SelectedValue;
        }

        private Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
           
            binding.Add("SP_MagnumScreenType_Visibility", new Binding("Visible", _screenModel, "SP_MagnumScreenType_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Magnum_ScreenType", new Binding("Text", _screenModel, "Magnum_ScreenType", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Reinforced", new Binding("Checked", _screenModel, "Reinforced", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

        public ISP_MagnumScreenTypeUCPresenter CreateNewInstance(IUnityContainer unityC, 
                                                                IMainPresenter mainPresenter, 
                                                                IScreenModel screenModel)
        {
            unityC
                .RegisterType<ISP_MagnumScreenTypeUCPresenter, SP_MagnumScreenTypeUCPresenter>()
                .RegisterType<ISP_MagnumScreenTypeUC, SP_MagnumScreenTypeUC>();
            SP_MagnumScreenTypeUCPresenter magnumscreen = unityC.Resolve<SP_MagnumScreenTypeUCPresenter>();
            magnumscreen._unityC = unityC;
            magnumscreen._mainPresenter = mainPresenter;
            magnumscreen._screenModel = screenModel;

            return magnumscreen;
        }

    }
}
