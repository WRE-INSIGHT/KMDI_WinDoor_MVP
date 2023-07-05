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

        public ComboBox GlassTypeCmb()
        {
            return cmb_glassType;
        }

        public DataGridView GlassUpgradeDGView()
        {
            return glassUpgradeDGV;
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

        #endregion

        #region EventHandler

        public event EventHandler GlassUpgradeView_LoadEventRaised;

        #endregion

        private void GlassUpgradeView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, GlassUpgradeView_LoadEventRaised, e);
        }
    }
}
