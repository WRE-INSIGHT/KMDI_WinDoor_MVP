using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;
using PresentationLayer.Views.UserControls.WinDoorPanels;
namespace PresentationLayer.Views
{
    public partial class MainView : Form, IMainView
    {
        #region GetSet

        public string Nickname
        {
            set
            {
                lblWelcome.Text = "Welcome, " + value;
            }
        }

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
                }
                else
                {
                    listOfMaterialsToolStripMenuItem.Enabled = false;
                    changeItemColorToolStripMenuItem.Enabled = false;
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

        #endregion

        public event EventHandler MainViewLoadEventRaised;
        public event EventHandler MainViewClosingEventRaised;
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
        public event EventHandler assignProjectsToolStripMenuItemClickEventRaised;
        public event EventHandler selectProjectToolStripMenuItemClickEventRaised;

        public MainView()
        {
            InitializeComponent();
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
            EventHelpers.RaiseEvent(this, MainViewClosingEventRaised, e);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Properties.Settings.Default.WndrDir;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                EventHelpers.RaiseEvent(this, OpenToolStripButtonClickEventRaised, e);
            }
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
            //if (pnlMain.VerticalScroll.Visible == true || pnlMain.HorizontalScroll.Visible == true)
            //{
            //    btnMinusZoom.Enabled = true;
            //}
            //else if(pnlMain.VerticalScroll.Visible == false || pnlMain.HorizontalScroll.Visible == false)
            //{
            //    btnMinusZoom.Enabled = false;
            //}
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

        public MenuStrip GetMNSMainMenu()
        {
            return mnsMainMenu;
        }

        private void pnlPropertiesBody_Scroll(object sender, ScrollEventArgs e)
        {
            //Console.WriteLine("Scroll_val: " + pnlPropertiesBody.VerticalScroll.Value);
        }

        public void FocusOnMainForm()
        {
            this.Focus();
        }

        public void SetActiveControl(Control control)
        {
            this.ActiveControl = control;
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
        }

        private void tsBtnNConcrete_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, NewConcreteButtonClickEventRaised, e);
        }

        private void invertOrientationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}