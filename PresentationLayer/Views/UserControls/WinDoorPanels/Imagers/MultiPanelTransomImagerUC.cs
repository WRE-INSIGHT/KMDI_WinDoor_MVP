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

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public partial class MultiPanelTransomImagerUC : UserControl, IMultiPanelTransomImagerUC, IMultiPanelImagerUC
    {
        public MultiPanelTransomImagerUC()
        {
            InitializeComponent();
        }

        private int _mpanelID;
        public int MPanel_ID
        {
            get
            {
                return _mpanelID;
            }
            set
            {
                _mpanelID = value;
            }
        }

        private string _mpanelPlacement;
        public string MPanel_Placement
        {
            get
            {
                return _mpanelPlacement;
            }

            set
            {
                _mpanelPlacement = value;
            }
        }

        public event PaintEventHandler flpMulltiPaintEventRaised;
        public event EventHandler flpMultiVisibleChangedEventRaised;

        private void flp_MultiTransomImager_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, flpMulltiPaintEventRaised, e);
        }

        private void MultiPanelTransomImagerUC_VisibleChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, flpMultiVisibleChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["MPanel_ID"]);
            this.DataBindings.Add(ModelBinding["MPanel_Placement"]);
            this.DataBindings.Add(ModelBinding["MPanel_Dock"]);
            this.DataBindings.Add(ModelBinding["MPanelImageRenderer_Width"]);
            this.DataBindings.Add(ModelBinding["MPanelImageRenderer_Height"]);
            this.DataBindings.Add(ModelBinding["MPanel_Margin"]);
            this.DataBindings.Add(ModelBinding["MPanel_Visibility"]);
        }

        public void AddImagerControl(UserControl userctrlObj)
        {
            flp_MultiTransomImager.Controls.Add(userctrlObj);
        }

        public void DeleteImagerControl(UserControl userctrlObj)
        {
            flp_MultiTransomImager.Controls.Remove(userctrlObj);
        }
    }
}
