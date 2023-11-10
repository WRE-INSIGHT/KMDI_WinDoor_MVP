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

        public Panel GetHeaderPanel()
        {
            return pnl_Header;
        }

        public Timer BGChangedTimer()
        {
            return tmr_BGChange;
        }

        public void GetUCdispose()
        {
             Dispose();
        }
        
        public event EventHandler partialAdjustmentUC_LoadEventRaised;
        public event EventHandler paPnlAfter_ResizeEventRaised;
        public event EventHandler btn_HideAndShow_ClickEventRaised;
        public event EventHandler btn_UsePartialAdjustment_ClickEventRaised;
        public event EventHandler pnl_Header_MouseLeaveEventRaised;
        public event EventHandler tmr_BGChange_TickEventRaised;
        public event EventHandler pnl_Header_MouseEnterEventRaised;
        public event EventHandler btn_HideAndShow_MouseEnterEventRaised;
        public event EventHandler btn_HideAndShow_MouseLeaveEventRaised;
        public event EventHandler btn_UsePartialAdjustment_MouseEnterEventRaised;
        public event EventHandler btn_UsePartialAdjustment_MouseLeaveEventRaised;
        public event MouseEventHandler pnl_Header_LeftMouseDownEventRaised;
        public event EventHandler pnl_Header_RightMouseDownClickEventRaised;
        public event EventHandler RightMouseDownLeaveExceptionEventRaised;


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


        private void pnl_Header_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, pnl_Header_MouseLeaveEventRaised, e);
        }

        private void tmr_BGChange_Tick(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, tmr_BGChange_TickEventRaised, e);
        }

        private void pnl_Header_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, pnl_Header_MouseEnterEventRaised, e);
        }

        private void btn_HideAndShow_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btn_HideAndShow_MouseEnterEventRaised, e);
        }

        private void btn_HideAndShow_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btn_HideAndShow_MouseLeaveEventRaised, e);
        }

        private void btn_UsePartialAdjustment_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btn_UsePartialAdjustment_MouseEnterEventRaised, e);
        }

        private void btn_UsePartialAdjustment_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btn_UsePartialAdjustment_MouseLeaveEventRaised, e);
        }
        
        private void pnl_Header_MouseDown(object sender, MouseEventArgs e)
        {
            

            if (ModifierKeys.HasFlag(Keys.Control) && e.Button == MouseButtons.Left)
            {
                EventHelpers.RaiseMouseEvent(sender, pnl_Header_LeftMouseDownEventRaised, e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                EventHelpers.RaiseEvent(sender, RightMouseDownLeaveExceptionEventRaised, e);
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Delete", pnl_Header_RightMouseDownClickEventRaised));
                m.Show(pnl_Header,new Point (e.X,e.Y));
            }
        }
    }
}
