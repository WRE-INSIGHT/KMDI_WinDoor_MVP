using CommonComponents;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Variables;
using PresentationLayer.Presenter.UserControls.DividerPropertiesUCPresenter_Modules;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.DividerProperties_Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls
{
    public class DividerPropertiesUCPresenter : IDividerPropertiesUCPresenter, IPresenterCommon
    {
        IDividerPropertiesUC _divProperties;
        private IMainPresenter _mainPresenter;
        private IDividerModel _divModel;
        private IUnityContainer _unityC;

        private IDP_CladdingPropertyUCPresenter _dp_claddingPropertyUCP;
        private IDP_LeverEspagnolettePropertyUCPresenter _dp_leverEspagPropertyUCP;
        private IDP_CladdingBracketPropertyUCPresenter _dp_claddingBracketPropertyUCP;

        private Panel _divPropertiesBodyPNL;
        private Button _btnSelectDMPanel;
        private List<IDP_CladdingPropertyUCPresenter> _lst_claddUCP = new List<IDP_CladdingPropertyUCPresenter>();

        bool _initialLoad = true;
        int cladding_count = 0;

        ConstantVariables const_var = new ConstantVariables();

        public int Cladding_Count
        {
            get
            {
                return cladding_count;
            }
            set
            {
                cladding_count = value;
                if (cladding_count == 0)
                {
                    _divModel.Div_claddingBracketVisibility = false;
                    _divModel.AdjustPropertyPanelHeight("minusCladdingBracket");
                    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusCladdingBracket");
                    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusCladdingBracket");

                }
                else if (cladding_count > 0)
                {
                    if (_divModel.Div_claddingBracketVisibility == false)
                    {
                        _divModel.Div_claddingBracketVisibility = true;
                        _divModel.AdjustPropertyPanelHeight("addCladdingBracket");
                        _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addCladdingBracket");
                        _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addCladdingBracket");
                    }
                }

            }
        }

        public DividerPropertiesUCPresenter(IDividerPropertiesUC divProperties,
                                            IDP_CladdingPropertyUCPresenter dp_claddingPropertyUCP,
                                            IDP_LeverEspagnolettePropertyUCPresenter dp_leverEspagPropertyUCP,
                                            IDP_CladdingBracketPropertyUCPresenter dp_claddingBracketPropertyUCP)
        {
            _divProperties = divProperties;
            _dp_claddingPropertyUCP = dp_claddingPropertyUCP;
            _dp_leverEspagPropertyUCP = dp_leverEspagPropertyUCP;
            _dp_claddingBracketPropertyUCP = dp_claddingBracketPropertyUCP;
            _divPropertiesBodyPNL = _divProperties.GetDividerPropertiesBodyPNL();
            _btnSelectDMPanel = _divProperties.GetBtnSelectDMPanel();
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
            _divProperties.btnSelectDMPanelClickedEventRaised += _divProperties_btnSelectDMPanelClickedEventRaised;
            _divProperties.SashProfileChangedEventRaised += _divProperties_SashProfileChangedEventRaised;
            _divProperties.cmbCladdingArtNoSelectedValueChangeEventRiased += _divProperties_cmbCladdingArtNoSelectedValueChangeEventRiased;
        }


        SashProfile_ArticleNo curr_sashProfileArtNo;
        private void _divProperties_SashProfileChangedEventRaised(object sender, EventArgs e)
        {
            SashProfile_ArticleNo sel_sashProfileArtNo = (SashProfile_ArticleNo)sender;
            if (!_initialLoad && curr_sashProfileArtNo != sel_sashProfileArtNo)
            {
                if (sel_sashProfileArtNo == SashProfile_ArticleNo._395 ||
                    sel_sashProfileArtNo == SashProfile_ArticleNo._374 ||
                    sel_sashProfileArtNo == SashProfile_ArticleNo._373)
                {
                    if (curr_sashProfileArtNo != SashProfile_ArticleNo._395 &&
                        curr_sashProfileArtNo != SashProfile_ArticleNo._374 &&
                        curr_sashProfileArtNo != SashProfile_ArticleNo._373)
                    {
                        _divModel.Div_LeverEspagArtNo = LeverEspagnolette_ArticleNo._631153;

                        _divModel.Div_LeverEspagVisibility = true;
                        _divModel.AdjustPropertyPanelHeight("addLeverEspag");
                        _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addLeverEspag");
                        _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addLeverEspag");
                    }
                }
                else if (sel_sashProfileArtNo != SashProfile_ArticleNo._395 &&
                         sel_sashProfileArtNo != SashProfile_ArticleNo._374 &&
                         sel_sashProfileArtNo != SashProfile_ArticleNo._373)
                {
                    if (curr_sashProfileArtNo == SashProfile_ArticleNo._395 ||
                        curr_sashProfileArtNo == SashProfile_ArticleNo._374 ||
                        curr_sashProfileArtNo == SashProfile_ArticleNo._373)
                    {
                        _divModel.Div_LeverEspagVisibility = false;
                        _divModel.AdjustPropertyPanelHeight("minusLeverEspag");
                        _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusLeverEspag");
                        _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusLeverEspag");
                    }
                }
                curr_sashProfileArtNo = sel_sashProfileArtNo;
            }
        }

        private void _divProperties_btnSelectDMPanelClickedEventRaised(object sender, EventArgs e)
        {
            int propertiesScroll = _mainPresenter.PropertiesScroll;

            List<Control> lst_obj = _divModel.Div_MPanelParent.MPanelLst_Objects;
            Control div = lst_obj.Find(obj => obj.Name == _divModel.Div_Name);
            IPanelModel prev_pnl = null, nxt_pnl = null;
            int ndx = lst_obj.IndexOf(div);
            string prev_pnl_str = lst_obj[ndx - 1].Name;

            prev_pnl = _divModel.Div_MPanelParent.MPanelLst_Panel.Find(prev => prev.Panel_Name == prev_pnl_str);
            prev_pnl.Panel_BackColor = SystemColors.Highlight;

            string nxt_pnl_str = "";
            if (lst_obj.Count() > ndx + 1)
            {
                nxt_pnl_str = _divModel.Div_MPanelParent.MPanelLst_Objects[ndx + 1].Name;
                nxt_pnl = _divModel.Div_MPanelParent.MPanelLst_Panel.Find(prev => prev.Panel_Name == nxt_pnl_str);
                nxt_pnl.Panel_BackColor = SystemColors.Highlight;
            }

            if (prev_pnl.Panel_Name.Contains("Fixed") == false || nxt_pnl.Panel_Name.Contains("Fixed") == false)
            {
                _mainPresenter.SetLblStatus("DMPreSelection", true, (Control)sender, _divModel, prev_pnl, nxt_pnl, this);
            }
            else
            {
                MessageBox.Show("Not applicable on fixed panels", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            _mainPresenter.PropertiesScroll = propertiesScroll;

        }

        private void _divProperties_cmbDMArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                int propertiesScroll = _mainPresenter.PropertiesScroll;
                _divModel.Div_DMArtNo = (DummyMullion_ArticleNo)((ComboBox)sender).SelectedValue;

                _mainPresenter.PropertiesScroll = propertiesScroll;
            }
        }

        private void _divProperties_chkDMCheckedChangedEventRaised(object sender, EventArgs e)
        {
            int propertiesScroll = _mainPresenter.PropertiesScroll;
            CheckBox chk = (CheckBox)sender;
            if (!_initialLoad)
            {
                int orig_locY = ((UserControl)_divProperties).Location.Y;

                _divModel.Div_ChkDM = chk.Checked;
                _divModel.Div_ArtVisibility = !chk.Checked;

                Control div_obj = _divModel.Div_MPanelParent.MPanelLst_Objects.Find(obj => obj.Name == _divModel.Div_Name);
                int div_ndx = _divModel.Div_MPanelParent.MPanelLst_Objects.IndexOf(div_obj);
                Control prev_pnl = _divModel.Div_MPanelParent.MPanelLst_Objects[div_ndx - 1],
                        nxt_pnl = null;
                IPanelModel prev_pnlModel = null, nxt_pnlModel = null;

                if (prev_pnl.Name.Contains("MultiPanel") == false)
                {
                    prev_pnlModel = _divModel.Div_MPanelParent.MPanelLst_Panel.Find(panel => panel.Panel_Name == prev_pnl.Name);
                }

                if (div_ndx + 1 < _divModel.Div_MPanelParent.MPanelLst_Objects.Count())
                {
                    nxt_pnl = _divModel.Div_MPanelParent.MPanelLst_Objects[div_ndx + 1];

                    if (nxt_pnl.Name.Contains("MultiPanel") == false)
                    {
                        nxt_pnlModel = _divModel.Div_MPanelParent.MPanelLst_Panel.Find(panel => panel.Panel_Name == nxt_pnl.Name);
                    }
                }

                if (chk.Checked == true)
                {
                    _divProperties.GetDMArtNoPNL().SendToBack();
                    _divModel.Div_ArtNo = Divider_ArticleNo._None;
                    _divModel.Div_ReinfArtNo = DividerReinf_ArticleNo._None;
                    _divModel.AdjustPropertyPanelHeight("addDM");
                    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addDM");
                    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addDM");

                    _divModel.AdjustPropertyPanelHeight("minusDivArt");
                    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusDivArt");
                    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusDivArt");

                    _divModel.AdjustPropertyPanelHeight("minusPanelAddCladding");
                    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusPanelAddCladding");
                    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusPanelAddCladding");

                    if (_divModel.Div_DMPanel != null && _divModel.Div_LeverEspagVisibility == false)
                    {
                        _divModel.Div_LeverEspagVisibility = true;
                        _divModel.AdjustPropertyPanelHeight("addLeverEspag");
                        _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addLeverEspag");
                        _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addLeverEspag");

                    }

                    if (cladding_count > 0)
                    {
                        _divModel.AdjustPropertyPanelHeight("minusCladdingBracket");
                        _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusCladdingBracket");
                        _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusCladdingBracket");

                    }

                    for (int i = 0; i < cladding_count; i++)
                    {
                        _divModel.AdjustPropertyPanelHeight("minusCladding");
                        _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusCladding");
                        _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusCladding");
                    }

                    if (prev_pnlModel != null)
                    {
                        if (prev_pnlModel.Panel_CornerDriveOptionsVisibility == false && prev_pnlModel.Panel_Type != "Fixed Panel")
                        {
                            prev_pnlModel.Panel_CornerDriveOptionsVisibility = true;
                            prev_pnlModel.AdjustPropertyPanelHeight("addCornerDrive");
                            _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                            _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                            propertiesScroll += const_var.panel_property_cornerDriveOptionsheight_default;

                        }
                    }

                    if (nxt_pnlModel != null)
                    {
                        if (nxt_pnlModel.Panel_CornerDriveOptionsVisibility == false && prev_pnlModel.Panel_Type != "Fixed Panel")
                        {
                            nxt_pnlModel.Panel_CornerDriveOptionsVisibility = true;
                            nxt_pnlModel.AdjustPropertyPanelHeight("addCornerDrive");
                            _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                            _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Panel", "addCornerDrive");

                            //added_scrollView += const_var.panel_property_cornerDriveOptionsheight_default;
                        }
                    }
                }
                else if (chk.Checked == false)
                {
                    _divModel.AdjustPropertyPanelHeight("addDivArt");
                    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addDivArt");
                    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addDivArt");

                    _divModel.AdjustPropertyPanelHeight("minusDM");
                    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusDM");
                    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusDM");

                    _divModel.AdjustPropertyPanelHeight("addPanelAddCladding");
                    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addPanelAddCladding");
                    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addPanelAddCladding");

                    if (_divModel.Div_DMPanel != null && _divModel.Div_LeverEspagVisibility == true)
                    {
                        _divModel.Div_LeverEspagVisibility = false;
                        _divModel.AdjustPropertyPanelHeight("minusLeverEspag");
                        _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusLeverEspag");
                        _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusLeverEspag");
                    }

                    if (cladding_count > 0)
                    {
                        _divModel.AdjustPropertyPanelHeight("addCladdingBracket");
                        _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addCladdingBracket");
                        _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addCladdingBracket");
                    }

                    for (int i = 0; i < cladding_count; i++)
                    {
                        _divModel.AdjustPropertyPanelHeight("addCladding");
                        _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addCladding");
                        _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addCladding");
                    }

                    _divModel.Div_DMPanel = null;
                    _btnSelectDMPanel.Text = "Select";
                    _btnSelectDMPanel.BackColor = SystemColors.Control;

                    if (prev_pnlModel != null)
                    {
                        if (prev_pnlModel.Panel_CornerDriveOptionsVisibility == true && prev_pnlModel.Panel_Type != "Fixed Panel")
                        {
                            prev_pnlModel.Panel_CornerDriveOptionsVisibility = false;
                            prev_pnlModel.AdjustPropertyPanelHeight("minusCornerDrive");
                            _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                            _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                            propertiesScroll -= const_var.panel_property_cornerDriveOptionsheight_default;
                        }
                    }

                    if (nxt_pnlModel != null)
                    {
                        if (nxt_pnlModel.Panel_CornerDriveOptionsVisibility == true && prev_pnlModel.Panel_Type != "Fixed Panel")
                        {
                            nxt_pnlModel.Panel_CornerDriveOptionsVisibility = false;
                            nxt_pnlModel.AdjustPropertyPanelHeight("minusCornerDrive");
                            _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                            _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                        }
                    }
                }

                int new_locY = ((UserControl)_divProperties).Location.Y;

                _mainPresenter.Set_pnlPropertiesBody_ScrollView(orig_locY + (new_locY - orig_locY));
                _mainPresenter.GetCurrentPrice();
            }
            _mainPresenter.PropertiesScroll = propertiesScroll;

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
                    cladding_sizes_list.Add(cladding_ID, ((IDP_CladdingPropertyUC)cladding).Cladding_Size);
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
                MessageBox.Show("Cladding length must be added before saving");
            }
            _mainPresenter.GetCurrentPrice();
        }

        private void _divProperties_btnAddCladdingClickedEventRaised(object sender, EventArgs e)
        {
            int propertiesScroll = _mainPresenter.PropertiesScroll;
            _divModel.Div_CladdingProfileArtNoVisibility = true;
            _divModel.Div_CladdingProfileArtNo = CladdingProfile_ArticleNo._WK50;
            if (cladding_count < 1)
            {
                _divModel.AdjustPropertyPanelHeight("addCladdingArtNo");
                _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addCladdingArtNo");
                _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addCladdingArtNo");
            }

            IDP_CladdingPropertyUCPresenter claddingUCP = _dp_claddingPropertyUCP.GetNewInstance(_unityC, _divModel, _mainPresenter, this);
            _lst_claddUCP.Add(claddingUCP);
            UserControl claddingUC = (UserControl)claddingUCP.GetCladdingPropertyUC();
            claddingUC.Dock = DockStyle.Top;
            _divPropertiesBodyPNL.Controls.Add(claddingUC);

            _divModel.AdjustPropertyPanelHeight("addCladding");
            _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addCladding");
            _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addCladding");
            claddingUC.BringToFront();

            _divModel.Div_CladdingCount++;
            Cladding_Count++;

            _dp_claddingBracketPropertyUCP.BringToFrontUC();

            int locY = ((UserControl)_divProperties).Location.Y;

            _mainPresenter.Set_pnlPropertiesBody_ScrollView(locY + const_var.div_property_claddingOptionsHeight);

            _divProperties.SetBtnSaveBackColor(Color.White);
            _mainPresenter.PropertiesScroll = propertiesScroll;

        }

        private void _divProperties_CmbdivArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                int propertiesScroll = _mainPresenter.PropertiesScroll;
                _divModel.Div_ArtNo = (Divider_ArticleNo)((ComboBox)sender).SelectedValue;
                _mainPresenter.PropertiesScroll = propertiesScroll;
                _mainPresenter.GetCurrentPrice();
            }
        }

        private void _divProperties_cmbCladdingArtNoSelectedValueChangeEventRiased(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                int propertiesScroll = _mainPresenter.PropertiesScroll;
                _divModel.Div_CladdingProfileArtNo = (CladdingProfile_ArticleNo)((ComboBox)sender).SelectedValue;
                _mainPresenter.PropertiesScroll = propertiesScroll;

            }
        }

        private void _divProperties_PanelPropertiesLoadEventRaised(object sender, EventArgs e)
        {


            if (_divModel.Div_DMPanel != null && _divModel.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
            {
                _divModel.AdjustPropertyPanelHeight("addLeverEspag");

                _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addLeverEspag");
                _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addLeverEspag");
            }

            if (_divModel.Div_ChkDM == true)
            {
                _divModel.Div_ArtVisibility = false;

                _divModel.Div_ArtNo = Divider_ArticleNo._None;
                _divModel.Div_ReinfArtNo = DividerReinf_ArticleNo._None;
            }
            IDP_CladdingBracketPropertyUCPresenter bracketUCP = _dp_claddingBracketPropertyUCP.GetNewInstance(_unityC, _divModel);
            _dp_claddingBracketPropertyUCP = bracketUCP;
            UserControl bracketProp = (UserControl)bracketUCP.GetCladdingBracketPropertyUC();
            _divPropertiesBodyPNL.Controls.Add(bracketProp);
            bracketProp.Dock = DockStyle.Top;
            bracketProp.BringToFront();
            if (_divModel.Div_CladdingSizeList != null)
            {
                    if (_divModel.Div_CladdingSizeList.Count > 0)
                    {

                        foreach (var cladding in _divModel.Div_CladdingSizeList)
                        {

                            _divModel.Div_CladdingProfileArtNoVisibility = true;
                            _divModel.Div_CladdingProfileArtNo = CladdingProfile_ArticleNo._WK50;
                            if (cladding_count < 1)
                            {
                                _divModel.AdjustPropertyPanelHeight("addCladdingArtNo");
                                _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addCladdingArtNo");
                                _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addCladdingArtNo");
                                _divModel.Div_claddingBracketVisibility = false;
                            }

                            IDP_CladdingPropertyUCPresenter claddingUCP = _dp_claddingPropertyUCP.GetNewInstance(_unityC, _divModel, _mainPresenter, this);
                            IDP_CladdingPropertyUC claddingPropUC = claddingUCP.GetCladdingPropertyUC();
                            _lst_claddUCP.Add(claddingUCP);

                            claddingPropUC.Cladding_Size = (int)cladding.Value;
                            claddingPropUC.Cladding_ID = cladding.Key;
                            claddingPropUC.Divider_Type = _divModel.Div_Type.ToString();
                            UserControl claddingUC = (UserControl)claddingPropUC;
                            claddingUC.Dock = DockStyle.Top;
                            _divPropertiesBodyPNL.Controls.Add(claddingUC);

                            _divModel.AdjustPropertyPanelHeight("addCladding");
                            _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addCladding");
                            _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addCladding");
                            claddingUC.BringToFront();

                            _divModel.Div_CladdingCount++;
                            Cladding_Count++;

                            _dp_claddingBracketPropertyUCP.BringToFrontUC();

                            int locY = ((UserControl)_divProperties).Location.Y;

                            //_mainPresenter.Set_pnlPropertiesBody_ScrollView(locY + const_var.div_property_claddingOptionsHeight);

                            _divProperties.SetBtnSaveBackColor(Color.White);
                        }
                    }
                
            }
            _divProperties.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
            //IDP_LeverEspagnolettePropertyUCPresenter leverUCP = _dp_leverEspagPropertyUCP.GetNewInstance(_unityC, _divModel);
            //_dp_leverEspagPropertyUCP = leverUCP;
            //UserControl leverProp = (UserControl)leverUCP.GetDPLeverEspagPropertyUC();
            //_divPropertiesBodyPNL.Controls.Add(leverProp);
            //leverProp.Dock = DockStyle.Top;
            //leverProp.SendToBack();

            //if (_divModel.Div_DMPanel != null && _divModel.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
            //{
            //    _divModel.AdjustPropertyPanelHeight("addLeverEspag");
            //    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addLeverEspag");
            //    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addLeverEspag");
            //}

            //if (_divModel.Div_ChkDM == true)
            //{
            //    _divModel.Div_ArtVisibility = false;

            //    _divModel.Div_ArtNo = Divider_ArticleNo._None;
            //    _divModel.Div_ReinfArtNo = DividerReinf_ArticleNo._None;
            //}

            //IDP_CladdingBracketPropertyUCPresenter bracketUCP = _dp_claddingBracketPropertyUCP.GetNewInstance(_unityC, _divModel);
            //_dp_claddingBracketPropertyUCP = bracketUCP;
            //UserControl bracketProp = (UserControl)bracketUCP.GetCladdingBracketPropertyUC();
            //_divPropertiesBodyPNL.Controls.Add(bracketProp);
            //bracketProp.Dock = DockStyle.Top;
            //bracketProp.BringToFront();

            //_divProperties.ThisBinding(CreateBindingDictionary());
            //_initialLoad = false;
            Refresh_LblTotalCladdingLength();
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
            divBinding.Add("Div_CladdingProfileArtNo", new Binding("Text", _divModel, "Div_CladdingProfileArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_CladdingProfileArtNoVisibility", new Binding("Visible", _divModel, "Div_CladdingProfileArtNoVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_SelectedPanel", new Binding("Text", _divModel, "Div_SelectedPanel", true, DataSourceUpdateMode.OnPropertyChanged));
            return divBinding;
        }

        public void SetSaveBtnColor(Color color)
        {
            _divProperties.SetBtnSaveBackColor(color);
        }

        //public IDP_LeverEspagnolettePropertyUCPresenter GetLeverEspagUCP()
        //{

        //    return _dp_leverEspagPropertyUCP;
        //}

        public void Refresh_LblTotalCladdingLength()
        {
            int totalCladdLength = 0;
            foreach (IDP_CladdingPropertyUCPresenter clad in _lst_claddUCP)
            {
                totalCladdLength += clad.GetCladdingPropertyUC().Cladding_Size;
            }
            _divProperties.SetLblTotalCladdingLength_Text(totalCladdLength.ToString());
        }

        public void Remove_CladdingUCP(IDP_CladdingPropertyUCPresenter claddUCP)
        {
            _lst_claddUCP.Remove(claddUCP);
        }

        public IDP_LeverEspagnolettePropertyUCPresenter GetLeverEspagUCP(IUnityContainer unityC, IDividerModel divModel)
        {
            _dp_leverEspagPropertyUCP = _dp_leverEspagPropertyUCP.GetNewInstance(unityC, divModel);
            UserControl leverProp = (UserControl)_dp_leverEspagPropertyUCP.GetDPLeverEspagPropertyUC();
            _divPropertiesBodyPNL.Controls.Add(leverProp);
            leverProp.Dock = DockStyle.Top;
            leverProp.SendToBack();
            return _dp_leverEspagPropertyUCP;
        }
    }
}
