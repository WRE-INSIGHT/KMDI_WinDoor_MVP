using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls
{
    public partial class PartialAdjustmentUC : UserControl, IPartialAdjustmentUC
    {
        public PartialAdjustmentUC()
        {
            InitializeComponent();
        }

        public UserControl GetAdjustmentUCForm()
        {
            return this;
        }

        public PictureBox GetOldItemDesignImage()
        {
            return _paOldDesPictureBox;
        }

        public PictureBox GetCurrentItemDesignImage()
        {
            return _paCurrectDesPictureBox;
        }

        public RichTextBox GetOldItemDescription()
        {
            return _paOldDescRTextBox;
        }

        public RichTextBox GetCurrentItemDescription()
        {
            return _paCurrentDescRTextBox;
        }

        public Panel GetCurrentItemMainPanel()
        {
            return _paPnlAfter;
        }
        public Label GetPAItemNo()
        {
            return lbl_ItemNo;
        }
        public Label GetOldItemPrice()
        {
            return lbl_PrevPrice;
        }
        public Label GetCurrentItemPrice()
        {
            return lbl_CurrPrice;
        }

        
        public event EventHandler partialAdjustmentUC_LoadEventRaised;
        public event EventHandler paPnlAfter_ResizeEventRaised;
        public event EventHandler btn_HideAndShow_ClickEventRaised;
        public event EventHandler btn_UsePartialAdjustment_ClickEventRaised;


        private void PartialAdjustmentUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, partialAdjustmentUC_LoadEventRaised, e);
        }

        private void _paPnlAfter_Resize(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, paPnlAfter_ResizeEventRaised, e);
        }

        private void btn_HideAndShow_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btn_HideAndShow_ClickEventRaised, e);
        }

        private void btn_UsePartialAdjustment_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btn_UsePartialAdjustment_ClickEventRaised, e);
        }
    }
}
