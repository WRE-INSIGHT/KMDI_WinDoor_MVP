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

        bool _initialLoad = true;

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
            _divProperties.chkDMCheckedChangedEventRaised += _divProperties_chkDMCheckedChangedEventRaised;
            _divProperties.cmbDMArtNoSelectedValueChangedEventRaised += _divProperties_cmbDMArtNoSelectedValueChangedEventRaised;
        }

        private void _divProperties_cmbDMArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _divModel.Div_DMArtNo = (DummyMullion_ArticleNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _divProperties_chkDMCheckedChangedEventRaised(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (!_initialLoad)
            {
                _divModel.Div_ChkDM = chk.Checked;
                _divModel.Div_ArtVisibility = !chk.Checked;

                if (chk.Checked == true)
                {
                    _divModel.AdjustPropertyPanelHeight("addDM");
                    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addDM");
                    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addDM");

                    _divModel.AdjustPropertyPanelHeight("minusDivArt");
                    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusDivArt");
                    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusDivArt");
                }
                else if (chk.Checked == false)
                {
                    _divModel.AdjustPropertyPanelHeight("addDivArt");
                    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addDivArt");
                    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addDivArt");

                    _divModel.AdjustPropertyPanelHeight("minusDM");
                    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusDM");
                    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusDM");
                }
            }
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
            if (!_initialLoad)
            {
                _divModel.Div_ArtNo = (Divider_ArticleNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _divProperties_PanelPropertiesLoadEventRaised(object sender, EventArgs e)
        {
            _divProperties.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
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
            divBinding.Add("Div_ChkDM", new Binding("Checked", _divModel, "Div_ChkDM", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_ChkDMVisibility", new Binding("Visible", _divModel, "Div_ChkDMVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_ChkDM2", new Binding("Visible", _divModel, "Div_ChkDM", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_ArtVisibility", new Binding("Visible", _divModel, "Div_ArtVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_DMArtNo", new Binding("Text", _divModel, "Div_DMArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return divBinding;
        }

        public void SetSaveBtnColor(Color color)
        {
            _divProperties.SetBtnSaveBackColor(color);
        }
    }
}
