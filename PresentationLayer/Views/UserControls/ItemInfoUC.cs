﻿using System;
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
        private bool _wdSelected;
        public bool WD_Selected
        {
            get
            {
                return _wdSelected;
            }

            set
            {
                _wdSelected = value;
                if (_wdSelected)
                {
                    lbl_item.ForeColor = Color.Blue;
                }
                else
                {
                    lbl_item.ForeColor = Color.Black;
                }
            }
        }

        public ItemInfoUC()
        {
            InitializeComponent();
        }

        //public DockStyle dok
        //{
        //    set
        //    {
        //        this.Dock = value;
        //    }
        //}

        //public string ItemDesc
        //{
        //    set
        //    {
        //        lbl_desc.Text = value;
        //    }
        //}

        //public string ItemDimension
        //{
        //    set
        //    {
        //        lbl_dimension.Text = value;
        //    }
        //}

        //public Image ItemImage
        //{
        //    set
        //    {
        //        pbox_itemImage.Image = value;
        //    }
        //}

        //public string ItemName
        //{
        //    set
        //    {
        //        lbl_item.Text = value;
        //    }
        //}

        //public bool ItemVisibility
        //{
        //    set
        //    {
        //        this.Visible = value;
        //    }
        //}

        public event EventHandler ItemInfoUCLoadEventRaised;
        public event MouseEventHandler lblItemMouseDoubleClickEventRaised;

        public void BringToFrontThis()
        {
            this.BringToFront();
        }

        private void ItemInfoUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
            EventHelpers.RaiseEvent(this, ItemInfoUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> windoorModelBinding)
        {
            lbl_item.DataBindings.Add(windoorModelBinding["WD_name"]);
            lbl_dimension.DataBindings.Add(windoorModelBinding["WD_Dimension"]);
            lbl_desc.DataBindings.Add(windoorModelBinding["WD_description"]);
            this.DataBindings.Add(windoorModelBinding["WD_visibility"]);
            pbox_itemImage.DataBindings.Add(windoorModelBinding["WD_image"]);
            this.DataBindings.Add(windoorModelBinding["WD_Selected"]);
        }

        private void lbl_item_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                EventHelpers.RaiseMouseEvent(sender, lblItemMouseDoubleClickEventRaised, e);
            }
        }
    }
}
