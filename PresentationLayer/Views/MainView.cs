﻿using CommonComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace PresentationLayer.Views
{
    public partial class MainView : Form, IMainView
    {
        #region GetSet 

        public string mainview_title
        {
            get
            {
                return this.Text;
            }

            set
            {
                this.Text = value;
                if (this.Text.Contains(">>"))
                {
                    listOfMaterialsToolStripMenuItem.Enabled = true;
                    changeItemColorToolStripMenuItem.Enabled = true;
                    saveAsToolStripMenuItem.Enabled = true;
                    CostingItemsToolStripMenuItem.Enabled = true;
                    billOfMaterialToolStripMenuItem.Enabled = true;
                    screenToolStripMenuItem.Enabled = true;
                    glassBalancingToolStripMenuItem.Enabled = true;
                    customArrowHeadToolStripMenuItem.Enabled = true;
                    slidingTopViewToolStripMenuItem.Enabled = true;
                    changeItemDimensionToolStripMenuItem.Enabled = true;
                    SortItemtoolStripButton1.Enabled = true;
                    PriceHistorytoolStripButton.Enabled = true;
                    DateAssignedtoolStripButton.Enabled = true;
                    partialAdjustmentToolstrip.Enabled = true;
                }
                else
                {
                    listOfMaterialsToolStripMenuItem.Enabled = false;
                    changeItemColorToolStripMenuItem.Enabled = false;
                    saveAsToolStripMenuItem.Enabled = false;
                    CostingItemsToolStripMenuItem.Enabled = false;
                    billOfMaterialToolStripMenuItem.Enabled = false;
                    screenToolStripMenuItem.Enabled = false;
                    glassBalancingToolStripMenuItem.Enabled = false;
                    customArrowHeadToolStripMenuItem.Enabled = false;
                    slidingTopViewToolStripMenuItem.Enabled = false;
                    changeItemDimensionToolStripMenuItem.Enabled = false;
                    SortItemtoolStripButton1.Enabled = false;
                    PriceHistorytoolStripButton.Enabled = false;
                    DateAssignedtoolStripButton.Enabled = false;
                    partialAdjustmentToolstrip.Enabled = false;
                }
            }
        }

        public bool CreateNewWindoorBtnEnabled
        {
            get
            {
                return tsBtnNwin.Enabled = tsBtnNdoor.Enabled = tsBtnNConcrete.Enabled;
            }
            set
            {
                tsBtnNwin.Enabled = value;
                tsBtnNdoor.Enabled = value;
                tsBtnNConcrete.Enabled = value;
                newfactorBtn.Enabled = value;
                SetGlassToolStripMenuItem.Enabled = value;
                ScreentoolStripButton.Enabled = value;
                duplicateItemToolStripButton1.Enabled = value;
                refreshToolStripButton.Enabled = value;
                ViewImagerToolStripButton1.Enabled = value;
                deleteItemToolStripButton1.Enabled = value;
                glassUpgradeToolStrip.Enabled = value;
                partialAdjustmentToolstrip.Enabled = value;
            }
        }

        public bool ItemToolStripEnabled
        {
            get
            {
                return ItemToolStripMenuItem.Enabled;
            }
            set
            {
                ItemToolStripMenuItem.Enabled = value;
            }
        }

        public bool PriceHistorytoolStripButtonVisible
        {
            get
            {
                return PriceHistorytoolStripButton.Visible;
            }

            set
            {
                PriceHistorytoolStripButton.Visible = value;
            }
        }


        public bool DateAssignedtoolStripButtonVisible
        {
            get
            {
                return DateAssignedtoolStripButton.Visible;
            }

            set
            {
                DateAssignedtoolStripButton.Visible = value;
            }
        }

        private float _zoom;
        public float Zoom
        {
            get
            {
                return _zoom;
            }
            set
            {
                _zoom = value;
                lblZoom.Text = Convert.ToInt32(value * 100).ToString() + "%";
            }
        }

        public ToolStripMenuItem Glass_Single
        {
            get
            {
                return singleToolStripMenuItem;
            }
        }

        public ToolStripMenuItem Glass_DoubleInsulated
        {
            get
            {
                return DoubleInsulatedToolStripMenuItem;
            }
        }

        public ToolStripMenuItem Glass_DoubleLaminated
        {
            get
            {
                return DoubleLaminatedToolStripMenuItem;
            }
        }

        public ToolStripMenuItem Glass_TripleInsulated
        {
            get
            {
                return TripleInsulatedToolStripMenuItem;
            }
        }

        public ToolStripMenuItem Glass_TripleLaminated
        {
            get
            {
                return TripleLaminatedToolStripMenuItem;
            }
        }

        public ToolStripMenuItem Glass_Type
        {
            get
            {
                return glassTypeToolStripMenuItem;
            }
        }

        public ToolStripMenuItem Spacer
        {
            get
            {
                return spacerToolStripMenuItem;
            }
        }

        public ToolStripMenuItem Color
        {
            get
            {
                return colorToolStripMenuItem;
            }
        }


        public bool CustomArrowHeadToggle
        {
            get
            {
                return customArrowHeadToolStripMenuItem.Checked;
            }

            set
            {
                customArrowHeadToolStripMenuItem.Checked = value;
            }
        }
        private int _propertiesScroll;
        public int PropertiesScroll
        {
            get
            {
                return _propertiesScroll;
            }

            set
            {
                try
                {
                    _propertiesScroll = value;
                    pnlPropertiesBody.VerticalScroll.Value = value;
                    pnlPropertiesBody.ScrollControlIntoView(pnlPropertiesBody);

                }
                catch (Exception)
                {

                }

            }
        }
        private int _itemScroll;
        public int ItemScroll
        {
            get
            {
                return _itemScroll;
            }
            set
            {
                _itemScroll = value;
                pnlItems.VerticalScroll.Value = value;
                pnlItems.ScrollControlIntoView(pnlItems);
            }
        }
        public bool SpecificToolStripEnable
        {
            get
            {
                return SpecificToolStripEnable;
            }
            set
            {
                openToolStripButton.Enabled = value;
                saveToolStripButton.Enabled = value;
                ScreentoolStripButton.Enabled = value;
                duplicateItemToolStripButton1.Enabled = value;
                refreshToolStripButton.Enabled = value;
                ViewImagerToolStripButton1.Enabled = value;
                deleteItemToolStripButton1.Enabled = value;
                glassUpgradeToolStrip.Enabled = value;
                partialAdjustmentToolstrip.Enabled = value;
                PriceHistorytoolStripButton.Enabled = value;
                DateAssignedtoolStripButton.Enabled = value;
            }
        }

        #endregion
        public event EventHandler MainViewLoadEventRaised;
        public event FormClosingEventHandler MainViewClosingEventRaised;
        public event EventHandler OpenToolStripButtonClickEventRaised;
        public event EventHandler NewFrameButtonClickEventRaised;
        public event EventHandler NewConcreteButtonClickEventRaised;
        public event EventHandler NewQuotationMenuItemClickEventRaised;
        public event EventHandler PanelMainSizeChangedEventRaised;
        public event EventHandler CreateNewItemClickEventRaised;
        public event EventHandler LabelSizeClickEventRaised;
        public event EventHandler ButtonPlusZoomClickEventRaised;
        public event EventHandler ButtonMinusZoomClickEventRaised;
        public event EventHandler DeleteToolStripButtonClickEventRaised;
        public event EventHandler ListOfMaterialsToolStripMenuItemClickEventRaised;
        public event EventHandler CreateNewGlassClickEventRaised;
        public event EventHandler ChangeItemColorClickEventRaised;
        public event EventHandler glassTypeColorSpacerToolStripMenuItemClickEventRaised;
        public event EventHandler glassBalancingToolStripMenuItemClickEventRaised;
        public event EventHandler customArrowHeadToolStripMenuItemClickEventRaised;
        public event EventHandler assignProjectsToolStripMenuItemClickEventRaised;
        public event EventHandler selectProjectToolStripMenuItemClickEventRaised;
        public event EventHandler refreshToolStripButtonClickEventRaised;
        public event EventHandler CostingItemsToolStripMenuItemClickRaiseEvent;
        public event EventHandler saveAsToolStripMenuItemClickEventRaised;
        public event EventHandler saveToolStripButtonClickEventRaised;
        public event EventHandler slidingTopViewToolStripMenuItemClickRaiseEvent;
        public event EventHandler ViewImagerToolStripButtonClickEventRaised;
        public event DragEventHandler ItemsDragEventRaiseEvent;
        public event EventHandler SortItemButtonClickEventRaised;
        public event EventHandler existingItemToolStripMenuItemClickEventRaised;
        public event EventHandler SetGlassToolStripMenuItemClickRaiseEvent;
        public event EventHandler addProjectsToolStripMenuItemClickEventRaised;
        public event EventHandler screenToolStripMenuItemClickEventRaised;
        public event EventHandler factorToolStripMenuItemClickEventRaised;
        public event EventHandler billOfMaterialToolStripMenuItemClickEventRaised;
        public event EventHandler DuplicateToolStripButtonClickEventRaised;
        public event EventHandler ChangeSyncDirectoryToolStripMenuItemClickEventRaised;
        public event EventHandler NudCurrentPriceValueChangedEventRaised;
        public event EventHandler setNewFactorEventRaised;
        public event MouseEventHandler PanelMainMouseWheelRaiseEvent;
        public event EventHandler MainViewClosedEventRaised;
        public event EventHandler PriceHistorytoolStripButtonClickEventRaised;
        public event EventHandler DateAssignedtoolStripButtonClickEventRaised;
        public event EventHandler glassUpgradeToolStripButtonClickEventRaised;
        public event EventHandler partialAdjusmentToolstripClickClickEventRaised;
        public MainView()
        {
            InitializeComponent();
            pnlItems.MouseWheel += PnlItems_MouseWheel;
            pnlMain.MouseWheel += PnlMain_MouseWheel;
            pnlPropertiesBody.MouseWheel += PnlProperties_MouseWheel;
        }

        private void PnlMain_MouseWheel(object sender, MouseEventArgs e)
        {
            if (CrtlPress)
            {
                EventHelpers.RaiseMouseEvent(sender, PanelMainMouseWheelRaiseEvent, e);
            }
        }

        private void PnlProperties_MouseWheel(object sender, MouseEventArgs e)
        {
            PropertiesScroll = pnlPropertiesBody.VerticalScroll.Value;
        }

        private void PnlItems_MouseWheel(object sender, MouseEventArgs e)
        {
            ItemScroll = pnlItems.VerticalScroll.Value;
        }

        public void ShowMainView()
        {
            this.Show();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            pnlProperties.Size = new Size(185, 629);
            EventHelpers.RaiseEvent(this, MainViewLoadEventRaised, e);

        }

        public void ThisBinding(Dictionary<string, Binding> binding)
        {
            lblSize.DataBindings.Add(binding["WD_Dimension"]);
            this.DataBindings.Add(binding["WD_zoom"]);
            this.DataBindings.Add(binding["WD_customArrowToggle"]);
            //this.DataBindings.Add(binding["WD_PropertiesScroll"]);
        }

        public void RemoveBinding()
        {
            this.DataBindings.Clear();
        }
        public void RemoveBinding(Control ctrl)
        {
            ctrl.DataBindings.Clear();
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventHelpers.RaiseEvent(this, MainViewClosedEventRaised, e);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, OpenToolStripButtonClickEventRaised, e);
        }

        private void QuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, NewQuotationMenuItemClickEventRaised, e);
        }

        public Panel GetPanelMain()
        {
            return pnlMain;
        }

        private void pnlMain_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, PanelMainSizeChangedEventRaised, e);
        }
        public Panel GetPanelItems()
        {
            return pnlItems;
        }
        private void CreateNewItem_Clicked(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CreateNewItemClickEventRaised, e);
        }

        private void CreateNewFrame_Clicked(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, NewFrameButtonClickEventRaised, e); 
        }

        public Panel GetPanelPropertiesBody()
        {
            return pnlPropertiesBody;
        }

        public Label GetLblSize()
        {
            return lblSize;
        }

        public Panel GetPanelBot()
        {
            return pnlBot;
        }

        private void lblSize_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, LabelSizeClickEventRaised, e);
        }

        public Panel GetPanelControlSub()
        {
            return pnlControlSub;
        }

        public Form GetThis()
        {
            return this;
        }

        public ToolStripLabel GetLblSelectedDivider()
        {
            return tsLbl_Status;
        }

        private void btnMinusZoom_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ButtonMinusZoomClickEventRaised, e);
        }

        private void btnPlusZoom_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ButtonPlusZoomClickEventRaised, e);
        }

        private void deleteItemToolStripButton1_Click(object sender, EventArgs e)
        {
            //pnlPropertiesBody.VerticalScroll.Minimum = 100;
            EventHelpers.RaiseEvent(sender, DeleteToolStripButtonClickEventRaised, e);
        }

        private void listOfMaterialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ListOfMaterialsToolStripMenuItemClickEventRaised, e);
        }

        private void CreateNewGlass_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CreateNewGlassClickEventRaised, e);
        }

        private void changeItemColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ChangeItemColorClickEventRaised, e);
        }

        private void glassTypeColorSpacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, glassTypeColorSpacerToolStripMenuItemClickEventRaised, e);
        }

        private void glassBalancingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, glassBalancingToolStripMenuItemClickEventRaised, e);
        }

        public ToolStrip GetTSMain()
        {
            return tsMain;
        }
        public OpenFileDialog GetOpenFileDialog()
        {
            return openFileDialog1;
        }

        public ToolStripProgressBar GetTsProgressLoading()
        {
            return tsprogress_Loading;
        }
        public MenuStrip GetMNSMainMenu()
        {
            return mnsMainMenu;
        }

        public NumericUpDown GetCurrentPrice()
        {
            return Nud_CurrentPrice;
        }

        private void pnlPropertiesBody_Scroll(object sender, ScrollEventArgs e)
        {
            PropertiesScroll = pnlPropertiesBody.VerticalScroll.Value;
        }

        public void FocusOnMainForm()
        {
            this.Focus();
        }

        public void SetActiveControl(Control control)
        {
            this.ActiveControl = control;
        }

        private void customArrowHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, customArrowHeadToolStripMenuItemClickEventRaised, e);
        }

        private void assignProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, assignProjectsToolStripMenuItemClickEventRaised, e);
        }

        private void selectProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, selectProjectToolStripMenuItemClickEventRaised, e);
        }

        public void Set_AssignProject_Visibility(bool visibility)
        {
            assignProjectsToolStripMenuItem.Visible = visibility;
            projectToolStripMenuItem.Visible = visibility;
            //listOfMaterialsToolStripMenuItem.Visible = visibility;
            customArrowHeadToolStripMenuItem.Visible = visibility;
        }

        private void tsBtnNConcrete_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, NewConcreteButtonClickEventRaised, e);
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, refreshToolStripButtonClickEventRaised, e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Properties.Settings.Default.WndrDir;
            EventHelpers.RaiseEvent(sender, saveAsToolStripMenuItemClickEventRaised, e);
        }

        public SaveFileDialog GetSaveFileDialog()
        {
            return saveFileDialog1;
        }

        public ToolStripLabel GetToolStripLabelSync()
        {
            return tsp_Sync;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, saveToolStripButtonClickEventRaised, e);
        }


        private void slidingTopViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, slidingTopViewToolStripMenuItemClickRaiseEvent, e);
        }

        private void ViewImagerToolStripButton1_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ViewImagerToolStripButtonClickEventRaised, e);
        }

        private void pnlItems_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void pnlItems_DragDrop(object sender, DragEventArgs e)
        {
            EventHelpers.RaiseDragEvent(sender, ItemsDragEventRaiseEvent, e);
        }

        private void SortItemtoolStripButton1_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SortItemButtonClickEventRaised, e);
        }

        public ToolStripLabel GetToolStripLabelLoading()
        {
            return tsLbl_Loading;
        }

        public SplitContainer GetSCMain()
        {
            return splitContainer1;
        }

        public Panel GetPanelRight()
        {
            return pnlRight;
        }

        public ToolStripButton GetToolStripButtonSave()
        {
            return saveToolStripButton;
        }
        private void addExistingItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, existingItemToolStripMenuItemClickEventRaised, e);
        }

        private void itemListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CostingItemsToolStripMenuItemClickRaiseEvent, e);
        }

        private void SetGlassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SetGlassToolStripMenuItemClickRaiseEvent, e);
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, addProjectsToolStripMenuItemClickEventRaised, e);

        }

        private void ScreentoolStripButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, screenToolStripMenuItemClickEventRaised, e);
        }
        private void screenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, screenToolStripMenuItemClickEventRaised, e);
        }

        private void factorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, factorToolStripMenuItemClickEventRaised, e);
        }

        private void billOfMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, billOfMaterialToolStripMenuItemClickEventRaised, e);
        }
        private void duplicateItemToolStripButton1_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, DuplicateToolStripButtonClickEventRaised, e);
        }

        private void changeSyncDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ChangeSyncDirectoryToolStripMenuItemClickEventRaised, e);
        }

        private void Nud_CurrentPrice_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, NudCurrentPriceValueChangedEventRaised, e);
        }

        private void newfactorBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, setNewFactorEventRaised, e);
        }

        private void pnlItems_Scroll(object sender, ScrollEventArgs e)
        {
            ItemScroll = pnlItems.VerticalScroll.Value;
        }
        bool CrtlPress = false;
        private void MainView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                CrtlPress = true;
            }
            if (tsBtnNwin.Enabled == true)
            {

                if (e.Control == true && e.KeyCode == Keys.L || e.Control == true && e.KeyCode == Keys.P)
                {
                    itemListToolStripMenuItem_Click(sender, e);
                }
                else if (e.Control == true && e.KeyCode == Keys.S)
                {
                    saveToolStripButton_Click(sender, e);
                }
                else if (e.Alt == true && e.KeyCode == Keys.S)
                {
                    ScreentoolStripButton_Click(sender, e);
                }
                else if (e.Alt == true && e.KeyCode == Keys.C)
                {
                    CreateNewItem_Clicked(C70ToolStripMenuItem, e);
                }
                else if (e.Alt == true && e.KeyCode == Keys.P)
                {
                    CreateNewItem_Clicked(PremiLineToolStripMenuItem, e);
                }
                else if (e.Alt == true && e.KeyCode == Keys.G)
                {
                    CreateNewItem_Clicked(G58ToolStripMenuItem, e);
                }
                else if (e.Control == true && e.KeyCode == Keys.B)
                {
                    billOfMaterialToolStripMenuItem_Click(sender, e);
                }
                else if (e.Control == true && e.KeyCode == Keys.M)
                {
                    listOfMaterialsToolStripMenuItem_Click(sender, e);
                }
            }
            if (e.Control == true && e.KeyCode == Keys.O)
            {
                openToolStripButton_Click(sender, e);
            }
        }


        private void MainView_KeyUp(object sender, KeyEventArgs e)
        {
            CrtlPress = false;
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHelpers.RaiseFormClosingEvent(sender, MainViewClosingEventRaised, e);
        }

        private void PriceHistorytoolStripButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, PriceHistorytoolStripButtonClickEventRaised, e);
        }

        private void DateAssignedtoolStripButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, DateAssignedtoolStripButtonClickEventRaised, e);
        }

        private void glassUpgradeToolStrip_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, glassUpgradeToolStripButtonClickEventRaised, e);
        }

        private void partialAdjusmentToolstrip_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, partialAdjusmentToolstripClickClickEventRaised, e);
        }
    }
}