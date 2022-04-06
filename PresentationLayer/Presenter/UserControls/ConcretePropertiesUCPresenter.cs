using CommonComponents;
using ModelLayer.Model.Quotation.Concrete;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class ConcretePropertiesUCPresenter : IConcretePropertiesUCPresenter, IPresenterCommon
    {
        IConcretePropertiesUC _concretePropertiesUC;
        IUnityContainer _unityC;

        private IConcreteModel _concreteModel;
        private IMainPresenter _mainPresenter;

        public ConcretePropertiesUCPresenter(IConcretePropertiesUC concretePropertiesUC)
        {
            _concretePropertiesUC = concretePropertiesUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _concretePropertiesUC.ConcretePropertiesUCLoadEventRaised += _concretePropertiesUC_ConcretePropertiesUCLoadEventRaised;
            _concretePropertiesUC.numcWidthValueChangedEventRaised += _concretePropertiesUC_numcWidthValueChangedEventRaised;
            _concretePropertiesUC.numcHeightValueChangedEventRaised += _concretePropertiesUC_numcHeightValueChangedEventRaised;
        }

        private void _concretePropertiesUC_numcHeightValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown numH = (NumericUpDown)sender;
                _concreteModel.Concrete_Height = Convert.ToInt32(numH.Value);

                _concreteModel.Set_DimensionsToBind_using_ConcreteZoom();
                _concreteModel.Set_ImagerDimensions_using_ImagerZoom();

                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                _mainPresenter.basePlatform_MainPresenter.Invalidate_flpMainControls();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void _concretePropertiesUC_numcWidthValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown numW = (NumericUpDown)sender;
                _concreteModel.Concrete_Width = Convert.ToInt32(numW.Value);

                _concreteModel.Set_DimensionsToBind_using_ConcreteZoom();
                _concreteModel.Set_ImagerDimensions_using_ImagerZoom();

                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                _mainPresenter.basePlatform_MainPresenter.Invalidate_flpMainControls();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void _concretePropertiesUC_ConcretePropertiesUCLoadEventRaised(object sender, EventArgs e)
        {
            try
            {
                _concretePropertiesUC.ThisBinding(CreateBindingDictionary());
                _concretePropertiesUC.BringToFrontThis();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }


        public IConcretePropertiesUC GetConcretePropertiesUC()
        {
            return _concretePropertiesUC;
        }

        public IConcretePropertiesUCPresenter GetNewInstance(IConcreteModel concreteModel,
                                                             IUnityContainer unityC,
                                                             IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IConcretePropertiesUC, ConcretePropertiesUC>()
                .RegisterType<IConcretePropertiesUCPresenter, ConcretePropertiesUCPresenter>();
            ConcretePropertiesUCPresenter propertiesUCP = unityC.Resolve<ConcretePropertiesUCPresenter>();
            propertiesUCP._concreteModel = concreteModel;
            propertiesUCP._mainPresenter = mainPresenter;
            propertiesUCP._unityC = unityC;

            return propertiesUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Concrete_ID", new Binding("Concrete_ID", _concreteModel, "Concrete_Id", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Concrete_Name", new Binding("Text", _concreteModel, "Concrete_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Concrete_Width", new Binding("Value", _concreteModel, "Concrete_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Concrete_Height", new Binding("Value", _concreteModel, "Concrete_Height", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
