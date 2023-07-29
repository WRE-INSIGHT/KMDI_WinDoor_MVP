using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class GlassUpgradeView : Form, IGlassUpgradeView
    {
        public GlassUpgradeView()
        {
            InitializeComponent(); 
        }

        #region Properties
        public void ShowGlassUpgradeView()
        {
            this.ShowDialog();
        }
        public void CloseGlassUpgradeView()
        {
            this.Close();
        }

        public Form GlassUpgraedViewForm()
        {
            return this;
        }

        public ComboBox GlassTypeCmb()
        {
            return cmb_glassType;
        }

        public CheckedListBox ItemListChkBx()
        {
            return chkbx_ItemList;
        }

        public DataGridView GlassUpgradeDGView()
        {
            return glassUpgradeDGV;
        }
        public Panel ItemDescriptionPnl()
        {
            return pnl_desc;
        }
        public CheckBox SelectAllItems()
        {
            return chkbx_selectall;
        }
        public CheckBox AllodDuplicate()
        {
            return chkbx_Duplicate;
        }
        public ComboBox MultipleGlassUpgrade()
        {
            return cmb_multipleGlassUpgrade;
        }
        public Label AENameAndPosLbl
        {
            get
            {
                return _namepos;
            }
            set
            {
                _namepos = value;
            }
        }

        public Label ClientNameLbl
        {
            get
            {
                return _clientName;
            }
            set
            {
                _clientName = value;
            }
        }
        public Label ClientAddressLbl
        {
            get
            {
                return _clientAdd;
            }
            set
            {
                _clientAdd = value;
            }
        }
        public Label QuoteNumberLbl
        {
            get
            {
                return _quoteNum;
            }
            set
            {
                _quoteNum = value;
            }
        }
        public Label DateLbl
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }
        public Label ItemDescriptionLbl
        {
            get
            {
                return lbl_desc;
            }
            set
            {
                lbl_desc = value;
            }
        }
        public Label WindoorLbl()
        {
            return _lblWindoor;
        }
        public NumericUpDown DiscountNum
        {
            get
            {
                return num_discount;
            }
            set
            {
                num_discount.Value = Convert.ToDecimal(value); 
            }
        }
        public NumericUpDown GlassAmountNum
        {
            get
            {
                return num_glassAmount;
            }
            set
            {
                num_glassAmount.Value = Convert.ToDecimal(value);
            }
        }
        public NumericUpDown WindowsDoorsNum
        {
            get
            {
                return num_wdwsAndDoors;
            }
            set
            {
                num_wdwsAndDoors.Value = Convert.ToDecimal(value);
            }
        }
        public TextBox ItemDescriptionTxt
        {
            get
            {
                return txt_itemDesc;
            }
            set
            {
                txt_itemDesc = value;
            }
        }
        public PictureBox ItemImage
        {
            get
            {
                return pbox_itemImage;
            }
            set
            {
                pbox_itemImage = value;
            }
        }

        #endregion

        #region EventHandler

        public event EventHandler GlassUpgradeView_LoadEventRaised;
        public event EventHandler chkbx_ItemList_SelectedValueChangedEventRaised;
        public event EventHandler GlassUpgradeView_SizeChangedEventRaised;
        public event EventHandler btn_add_ClickEventRaised;
        public event EventHandler deleteToolStripMenuItem_ClickEventRaised;
        public event DataGridViewCellMouseEventHandler glassUpgradeDGV_ColumnHeaderMouseClickEventRaised;
        public event EventHandler glassUpgradeDGV_CellEndEditEventRaised;
        public event EventHandler cmb_glassType_SelectedValueChangedEventRaised;
        public event DataGridViewCellMouseEventHandler glassUpgradeDGV_CellMouseClickEventRaised;
        public event EventHandler chkbx_selectall_CheckedChangedEventRaised;
        public event FormClosingEventHandler GlassUpgradeView_FormClosingEventRaised;
        public event EventHandler _printBtn_ClickEventRaised;
        public event EventHandler upgradeToToolStripMenuItemClickEventRaised;


        #endregion

        private void GlassUpgradeView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, GlassUpgradeView_LoadEventRaised, e);
        }

        private void chkbx_ItemList_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkbx_ItemList_SelectedValueChangedEventRaised, e);           
        }

        private void GlassUpgradeView_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, GlassUpgradeView_SizeChangedEventRaised,e);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btn_add_ClickEventRaised,e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteToolStripMenuItem_ClickEventRaised,e );
        }

        private void glassUpgradeDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EventHelpers.RaiseDatagridviewCellMouseEvent(sender, glassUpgradeDGV_ColumnHeaderMouseClickEventRaised, e);
        }

        private void glassUpgradeDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, glassUpgradeDGV_CellEndEditEventRaised, e);
        }

        private void cmb_glassType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmb_glassType_SelectedValueChangedEventRaised, e);
        }

        private void glassUpgradeDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EventHelpers.RaiseDatagridviewCellMouseEvent(sender, glassUpgradeDGV_CellMouseClickEventRaised, e);
        }

        private void chkbx_selectall_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkbx_selectall_CheckedChangedEventRaised, e);
        }

        private void GlassUpgradeView_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHelpers.RaiseFormClosingEvent(sender, GlassUpgradeView_FormClosingEventRaised, e);
        }

        private void _printBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, _printBtn_ClickEventRaised, e);
        }

        private void upgradeToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, upgradeToToolStripMenuItemClickEventRaised,e);
        }
    }
}
