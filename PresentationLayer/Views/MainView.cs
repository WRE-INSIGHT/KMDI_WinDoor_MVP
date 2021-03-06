﻿using System;
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
            }
        }

        public bool CreateNewWindoorBtnEnabled
        {
            get
            {
                return tsBtnNwin.Enabled = tsBtnNdoor.Enabled;
            }
            set
            {
                tsBtnNwin.Enabled = value;
                tsBtnNdoor.Enabled = value;
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

        public event EventHandler MainViewLoadEventRaised;
        public event EventHandler MainViewClosingEventRaised;
        public event EventHandler OpenToolStripButtonClickEventRaised;
        public event EventHandler NewFrameButtonClickEventRaised;
        public event EventHandler NewQuotationMenuItemClickEventRaised;
        public event EventHandler PanelMainSizeChangedEventRaised;
        public event EventHandler CreateNewItemClickEventRaised;
        public event EventHandler LabelSizeClickEventRaised;
        public event EventHandler ButtonPlusZoomClickEventRaised;
        public event EventHandler ButtonMinusZoomClickEventRaised;
        public event EventHandler DeleteToolStripButtonClickEventRaised;

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
            return tsLbl_SelectedDivider;
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
    }
}
