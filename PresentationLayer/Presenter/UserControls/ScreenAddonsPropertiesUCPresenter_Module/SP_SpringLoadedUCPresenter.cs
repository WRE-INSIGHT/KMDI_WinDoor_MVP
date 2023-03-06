using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public class SP_SpringLoadedUCPresenter : ISP_SpringLoadedUCPresenter
    {
        ISP_SpringLoadedUC _springLoadedUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;
        private IScreenPresenter _screenPresenter;
        

        public SP_SpringLoadedUCPresenter(ISP_SpringLoadedUC springLoadedUC)
        {
            _springLoadedUC = springLoadedUC;      
            _springLoadedUC.springLoadedCheckboxEventRaised += new EventHandler(OnspringLoadedCheckboxEventRaised);
            _springLoadedUC.spSpringLoadedUCLoadEventRaised += new EventHandler(OnspSpringLoadedUCLoadEventRaised);
        }

        private void OnspSpringLoadedUCLoadEventRaised(object sender, EventArgs e)
        {
            _springLoadedUC.ThisBinding(CreateBindingDictionary());
        }
      
        public ISP_SpringLoadedUC GetspringloadedUC()
        {
            return _springLoadedUC;
        }

        private void OnspringLoadedCheckboxEventRaised(object sender, EventArgs e)
        {
            if (_springLoadedUC.SpringLoadedCheckBox().Checked)
            {
                _screenModel.SpringLoad_Checked = true;
            }
            else
            {
                _screenModel.SpringLoad_Checked = false;
            }
            _screenPresenter.GetCurrentAmount();  
        }

        private Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("SpringLoad_Visibility", new Binding("Visible", _screenModel, "SpringLoad_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("SpringLoad_Checked", new Binding("Checked", _screenModel, "SpringLoad_Checked", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

        public ISP_SpringLoadedUCPresenter GetNewInstance(IUnityContainer unityC,IMainPresenter mainPresenter,IScreenModel screenModel,IScreenPresenter screenPresenter)
        {
            unityC
                .RegisterType<ISP_SpringLoadedUC, SP_SpringLoadedUC>()
                .RegisterType<ISP_SpringLoadedUCPresenter, SP_SpringLoadedUCPresenter>();

            SP_SpringLoadedUCPresenter springloadedpresenter = unityC.Resolve<SP_SpringLoadedUCPresenter>();
            springloadedpresenter._unityC = unityC;
            springloadedpresenter._mainPresenter = mainPresenter;
            springloadedpresenter._screenModel = screenModel;
            springloadedpresenter._screenPresenter = screenPresenter;

            return springloadedpresenter;
        }
    }
}
