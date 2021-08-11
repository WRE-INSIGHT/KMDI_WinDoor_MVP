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
using PresentationLayer.Presenter.UserControls.DividerPropertiesUCPresenter_Modules;
using PresentationLayer.Views.UserControls.DividerProperties_Modules;
using System.Drawing;

namespace PresentationLayer.Presenter.UserControls
{
    public class DividerPropertiesUCPresenter : IDividerPropertiesUCPresenter, IPresenterCommon
    {
        IDividerPropertiesUC _divProperties;

        private IMainPresenter _mainPresenter;
        private IDividerModel _divModel;
        private IUnityContainer _unityC;

        private IDP_CladdingPropertyUCPresenter _dp_claddingPropertyUCP;

        private Panel _divPropertiesBodyPNL;

        public DividerPropertiesUCPresenter(IDividerPropertiesUC divProperties,
                                            IDP_CladdingPropertyUCPresenter dp_claddingPropertyUCP)
        {
            _divProperties = divProperties;
            _dp_claddingPropertyUCP = dp_claddingPropertyUCP;
            _divPropertiesBodyPNL = _divProperties.GetDividerPropertiesBodyPNL();
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _divProperties.PanelPropertiesLoadEventRaised += _divProperties_PanelPropertiesLoadEventRaised;
            _divProperties.CmbdivArtNoSelectedValueChangedEventRaised += _divProperties_CmbdivArtNoSelectedValueChangedEventRaised;
            _divProperties.btnAddCladdingClickedEventRaised += _divProperties_btnAddCladdingClickedEventRaised;
            _divProperties.btnSaveCladdingClickedEventRaised += _divProperties_btnSaveCladdingClickedEventRaised;
        }

        private void _divProperties_btnSaveCladdingClickedEventRaised(object sender, EventArgs e)
        {
            Dictionary<int, int> cladding_sizes_list = new Dictionary<int, int>();
            int cladding_ID = 0;

            foreach (Control cladding in _divPropertiesBodyPNL.Controls)
            {
                if (cladding.Name.Contains("DP_CladdingPropertyUC"))
                {
                    ((IDP_CladdingPropertyUC)cladding).Cladding_ID = cladding_ID;
                    cladding_sizes_list.Add(cladding_ID,((IDP_CladdingPropertyUC)cladding).Cladding_Size);
                    cladding_ID++;
                }
            }

            if (cladding_sizes_list.Count > 0)
            {
                _divModel.Div_CladdingSizeList = cladding_sizes_list;
                MessageBox.Show("Saved");
                _divProperties.SetBtnSaveBackColor(Color.ForestGreen);
            }
            else
            {
                MessageBox.Show("Invalid save");
            }
        }

        private void _divProperties_btnAddCladdingClickedEventRaised(object sender, EventArgs e)
        {
            IDP_CladdingPropertyUCPresenter claddingUCP = _dp_claddingPropertyUCP.GetNewInstance(_unityC, _divModel, this);
            UserControl claddingUC = (UserControl)claddingUCP.GetCladdingPropertyUC();
            claddingUC.Dock = DockStyle.Top;
            _divPropertiesBodyPNL.Controls.Add(claddingUC);
            _divModel.AdjustPropertyPanelHeight("addCladding");
            _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addCladding");
            _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addCladding");
            claddingUC.BringToFront();

            _divProperties.SetBtnSaveBackColor(Color.White);
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
            divPropUCP._unityC = unityC;
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

        public void SetSaveBtnColor(Color color)
        {
            _divProperties.SetBtnSaveBackColor(color);
        }
    }
}
