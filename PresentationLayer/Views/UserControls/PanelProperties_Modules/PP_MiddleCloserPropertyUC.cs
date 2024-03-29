﻿using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_MiddleCloserPropertyUC : UserControl, IPP_MiddleCloserPropertyUC
    {
        public PP_MiddleCloserPropertyUC()
        {
            InitializeComponent();
        }
        public event EventHandler CmbMiddleCLoserSelectedValueChangedEventRaised;
        public event EventHandler MiddleCloserPropertyUCLoadEventRaised;
        public event EventHandler MCPairQtyValueChangedEventRaised;
        private void cmb_MiddleCLoser_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbMiddleCLoserSelectedValueChangedEventRaised, e);
        }

        private void PP_MiddleCloserPropertyUC_Load(object sender, EventArgs e)
        {
            num_MCPairQty.Maximum = decimal.MaxValue;

            List<MiddleCloser_ArticleNo> MClist = new List<MiddleCloser_ArticleNo>();
            foreach (MiddleCloser_ArticleNo item in MiddleCloser_ArticleNo.GetAll())
            {
                MClist.Add(item);
            }
            cmb_MiddleCLoser.DataSource = MClist;

            EventHelpers.RaiseEvent(sender, MiddleCloserPropertyUCLoadEventRaised, e);
        }

        private void num_MCPairQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, MCPairQtyValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_MiddleCloserVisibility"]);
            cmb_MiddleCLoser.DataBindings.Add(ModelBinding["Panel_MiddleCloserArtNo"]);
            num_MCPairQty.DataBindings.Add(ModelBinding["Panel_MiddleCloserPairQty"]);
        }
        private void cmb_MiddleCLoser_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;

        }

        private void cmb_MiddleCLoser_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void num_MCPairQty_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
    }
}
