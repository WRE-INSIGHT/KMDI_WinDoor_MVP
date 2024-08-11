﻿using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views
{
    public partial class PricingView : Form, IPricingView
    {
        public PricingView()
        {
            InitializeComponent();
        }

        public string ProfileType_FromMainPresenter { get; set; }


        public event EventHandler PricingViewLoadEventRaised;
        public event DataGridViewRowPostPaintEventHandler dgvPriceListRowPostPaintEventRaised;
        public event EventHandler cmbFilterSelectedValueChangedEventRaised;

        public DataGridView GetDgvPrice()
        {
            return dgv_priceList;
        }

        public void ShowPricingList()
        {
            this.Show();
        }

        private void PricingView_Load(object sender, EventArgs e)
        {
            List<BillOfMaterialsFilter> filter = new List<BillOfMaterialsFilter>();
            foreach (BillOfMaterialsFilter item in BillOfMaterialsFilter.GetAll())
            {
                if (ProfileType_FromMainPresenter.Contains("Alutek"))
                {
                    if (item == BillOfMaterialsFilter._PriceBreakDown ||
                        item == BillOfMaterialsFilter._MaterialCost ||
                        item == BillOfMaterialsFilter._InstallationCost)
                    {
                        filter.Add(item);
                    }
                }
                else
                {
                    if (item != BillOfMaterialsFilter._InstallationCost)
                    {
                        filter.Add(item);
                    }
                }

            }
            cmb_Filter.DataSource = filter;

            EventHelpers.RaiseEvent(sender, PricingViewLoadEventRaised, e);
        }

        private void dgv_priceList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            EventHelpers.RaiseDatagridviewRowpostpaintEvent(sender, dgvPriceListRowPostPaintEventRaised, e);
        }

        private void cmb_Filter_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbFilterSelectedValueChangedEventRaised, e);
        }
    }
}
