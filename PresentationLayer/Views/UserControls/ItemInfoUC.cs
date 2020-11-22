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
    public partial class ItemInfoUC : UserControl, IItemInfoUC
    {
        public ItemInfoUC()
        {
            InitializeComponent();
        }

        public DockStyle dok
        {
            set
            {
                this.Dock = value;
            }
        }

        public string ItemDesc
        {
            set
            {
                lbl_desc.Text = value;
            }
        }

        public string ItemDimension
        {
            set
            {
                lbl_dimension.Text = value;
            }
        }

        public Image ItemImage
        {
            set
            {
                pbox_itemImage.Image = value;
            }
        }

        public string ItemName
        {
            set
            {
                lbl_item.Text = value;
            }
        }

        public bool ItemVisibility
        {
            set
            {
                this.Visible = value;
            }
        }

        public event EventHandler ItemInfoUCLoadEventRaised;

        public void BringToFrontThis()
        {
            this.BringToFront();
        }

        private void ItemInfoUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, ItemInfoUCLoadEventRaised, e);
        }
    }
}
