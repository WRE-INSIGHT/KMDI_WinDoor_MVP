using CommonComponents;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;

namespace PresentationLayer.Presenter.UserControls
{
    public class MultiPanelPropertiesUCPresenter : IMultiPanelPropertiesUCPresenter, IPresenterCommon
    {
        IMultiPanelPropertiesUC _multiPanelPropertiesUC;

        private IUnityContainer _unityC;
        private IMultiPanelModel _multiPanelModel;
        
        private IMainPresenter _mainPresenter;

        public MultiPanelPropertiesUCPresenter(IMultiPanelPropertiesUC multiPanelPropertiesUC)
        {
            _multiPanelPropertiesUC = multiPanelPropertiesUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _multiPanelPropertiesUC.NumWidthValueChangedEventRaised += _multiPanelPropertiesUC_NumFWidthValueChangedEventRaised;
            _multiPanelPropertiesUC.NumHeightValueChangedEventRaised += _multiPanelPropertiesUC_NumFHeightValueChangedEventRaised;
            _multiPanelPropertiesUC.MultiPanelPropertiesLoadEventRaised += _multiPanelPropertiesUC_MultiPanelPropertiesLoadEventRaised;
        }
        
        private void _multiPanelPropertiesUC_MultiPanelPropertiesLoadEventRaised(object sender, EventArgs e)
        {
            _multiPanelPropertiesUC.ThisBinding(CreateBindingDictionary());
        }

        private void _multiPanelPropertiesUC_NumFHeightValueChangedEventRaised(object sender, EventArgs e)
        {
            NumericUpDown numH = (NumericUpDown)sender;
            _multiPanelModel.MPanel_Height = Convert.ToInt32(numH.Value);
        }

        private void _multiPanelPropertiesUC_NumFWidthValueChangedEventRaised(object sender, EventArgs e)
        {
            NumericUpDown numW = (NumericUpDown)sender;
            _multiPanelModel.MPanel_Width = Convert.ToInt32(numW.Value);
        }

        public IMultiPanelPropertiesUC GetMultiPanelPropertiesUC()
        {
            return _multiPanelPropertiesUC;
        }
        public IMultiPanelPropertiesUCPresenter GetNewInstance(IUnityContainer unityC,
                                                               IMultiPanelModel multiPanelModel,
                                                               IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IMultiPanelPropertiesUC, MultiPanelPropertiesUC>()
                .RegisterType<IMultiPanelPropertiesUCPresenter, MultiPanelPropertiesUCPresenter>();
            MultiPanelPropertiesUCPresenter multiPropUCP = unityC.Resolve<MultiPanelPropertiesUCPresenter>();
            multiPropUCP._unityC = unityC;
            multiPropUCP._mainPresenter = mainPresenter;
            multiPropUCP._multiPanelModel = multiPanelModel;

            return multiPropUCP;
        }
        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> multiPanelBinding = new Dictionary<string, Binding>();
            multiPanelBinding.Add("MPanel_ID", new Binding("MPanelID", _multiPanelModel, "MPanel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Width", new Binding("Value", _multiPanelModel, "MPanel_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Height", new Binding("Value", _multiPanelModel, "MPanel_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            //multiPanelBinding.Add("MPanel_Width", new Binding("Value", _multiPanelModel, "MPanel_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            //multiPanelBinding.Add("MPanel_Height", new Binding("Value", _multiPanelModel, "MPanel_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Name", new Binding("Text", _multiPanelModel, "MPanel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Visibility", new Binding("Visible", _multiPanelModel, "MPanel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanelProp_Height", new Binding("Height", _multiPanelModel, "MPanelProp_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_PNumEnable1", new Binding("Enabled", _multiPanelModel, "MPanel_NumEnable", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_PNumEnable2", new Binding("Enabled", _multiPanelModel, "MPanel_NumEnable", true, DataSourceUpdateMode.OnPropertyChanged));

            return multiPanelBinding;
        }

        public FlowLayoutPanel GetMultiPanelPropertiesFLP()
        {
            return _multiPanelPropertiesUC.GetMultiPanelPropertiesFLP();
        }

    }
}
