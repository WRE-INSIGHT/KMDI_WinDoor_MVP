﻿using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class QuoteItemListView : Form, IQuoteItemListView
    {

        public CheckBox GetChkboxSelectAll()
        {
            return chkbox_selectall;
        }

        private bool _getItemListUC_CheckState;
        public bool GetItemListUC_CheckBoxState
        {
            get
            {
                return _getItemListUC_CheckState;
            }
            set
            {
                _getItemListUC_CheckState = value;
            }
        }

        public QuoteItemListView()
        {
            InitializeComponent();
        }
        public event EventHandler TSbtnPrintClickEventRaised;
        public event EventHandler TSbtnGlassSummaryClickEventRaised;
        public event EventHandler QuoteItemListViewLoadEventRaised;
        public event EventHandler TsbtnContractSummaryClickEventRaised;
        public event FormClosedEventHandler QuoteItemListViewFormClosedEventRaised;
        public event EventHandler chkboxSelectallCheckedChangeEventRaised;
        
        private void TSbtnPrint_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, TSbtnPrintClickEventRaised, e);
        }
        public void showQuoteItemList()
        {
            this.Show();
        }

        public void closeQuoteItemList()
        {
            this.Close();
        }
        private void QuoteItemListView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, QuoteItemListViewLoadEventRaised, e);
        }
        public Panel GetPnlPrintBody()
        {
            return pnlPrintBody;
        }
        private void TSbtnGlassSummary_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, TSbtnGlassSummaryClickEventRaised, e);
        }

        private void QuoteItemListView_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventHelpers.RaiseFormClosedEvent(sender, QuoteItemListViewFormClosedEventRaised, e);

        }

        private void TSbtnContractSummary_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, TsbtnContractSummaryClickEventRaised, e);
        }

        private void chkbox_selectall_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkboxSelectallCheckedChangeEventRaised, e);
        }
    }
}
