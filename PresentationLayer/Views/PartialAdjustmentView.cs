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
    public partial class PartialAdjustmentView : Form, IPartialAdjustmentView
    {
        public PartialAdjustmentView()
        {
            InitializeComponent();
        }

        public Panel GetPanelHeader()
        {
            return _pnlHeader;
        }
        public Panel GetPanelBody()
        {
            return _pnlBody;
        }

        public Label GetPrevItemLbl()
        {
            return lbl_prevItem;
        }
        public Label GetCurrItemLbl()
        {
            return lbl_currItem;
        }
        public void ShowPartialAdjusmentView()
        {
            this.ShowDialog();
        }

        public void ClosePartialAdjustmentView()
        {
            this.Close();
        }

        public Form GetThis()
        {
            return this;
        }
        public event EventHandler _printToolStripBtnClickEventRaised;  
        public event EventHandler _partialAdjustmentViewLoadEventRaised;

        private void _printToolStripBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, _printToolStripBtnClickEventRaised, e);
        }

        private void PartialAdjustmentView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, _partialAdjustmentViewLoadEventRaised, e);
        }
    }
}
