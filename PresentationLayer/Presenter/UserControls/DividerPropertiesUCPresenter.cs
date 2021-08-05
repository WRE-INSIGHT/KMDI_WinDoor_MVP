using CommonComponents;
using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using ModelLayer.Model.Quotation.MultiPanel;

namespace PresentationLayer.Presenter.UserControls
{
    public class DividerPropertiesUCPresenter : IDividerPropertiesUCPresenter, IPresenterCommon
    {
        IDividerPropertiesUC _divProperties;

        private IMainPresenter _mainPresenter;
        private IDividerModel _divModel;

        public DividerPropertiesUCPresenter(IDividerPropertiesUC divProperties)
        {
            _divProperties = divProperties;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _divProperties.PanelPropertiesLoadEventRaised += _divProperties_PanelPropertiesLoadEventRaised;
            _divProperties.CmbdivArtNoSelectedValueChangedEventRaised += _divProperties_CmbdivArtNoSelectedValueChangedEventRaised;
        }

        private void _divProperties_CmbdivArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _divModel.Div_ArtNo = (Divider_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _divProperties_PanelPropertiesLoadEventRaised(object sender, EventArgs e)
        {
            _divProperties.ThisBinding(CreateBindingDictionary());
        }
        
        public IDividerPropertiesUC GetDivProperties()
        {
            return _divProperties;
        }

        public IDividerPropertiesUCPresenter GetNewInstance(IUnityContainer unityC, IDividerModel divModel, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IDividerPropertiesUC, DividerPropertiesUC>()
                .RegisterType<IDividerPropertiesUCPresenter, DividerPropertiesUCPresenter>();
            DividerPropertiesUCPresenter divPropUCP = unityC.Resolve<DividerPropertiesUCPresenter>();
            divPropUCP._divModel = divModel;
            divPropUCP._mainPresenter = mainPresenter;

            return divPropUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> divBinding = new Dictionary<string, Binding>();
            divBinding.Add("Div_ID", new Binding("Div_ID", _divModel, "Div_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_DisplayWidth", new Binding("Value", _divModel, "Div_DisplayWidth", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_DisplayHeight", new Binding("Value", _divModel, "Div_DisplayHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Name", new Binding("Text", _divModel, "Div_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Divider_Type", new Binding("Divider_Type", _divModel, "Div_Type", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Visible", new Binding("Visible", _divModel, "Div_Visible", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_ArtNo", new Binding("Text", _divModel, "Div_ArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_ReinfArtNo", new Binding("Text", _divModel, "Div_ReinfArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_PropHeight", new Binding("Height", _divModel, "Div_PropHeight", true, DataSourceUpdateMode.OnPropertyChanged));

            return divBinding;
        }
    }
}
