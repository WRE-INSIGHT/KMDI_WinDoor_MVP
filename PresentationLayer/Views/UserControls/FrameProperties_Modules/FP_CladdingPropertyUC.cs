﻿using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public partial class FP_CladdingQtyPropertyUC : UserControl, IFP_CladdingQtyPropertyUC
    {
        public FP_CladdingQtyPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler CladdingQtyPropertyUCLoadEventRaised;

        private void FP_CladdingQtyPropertyUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CladdingQtyPropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            nud_CladdingQty.DataBindings.Add(ModelBinding["Frame_CladdingQty"]);
            this.DataBindings.Add(ModelBinding["Frame_CladdingVisibility"]);
        }

    }
}
