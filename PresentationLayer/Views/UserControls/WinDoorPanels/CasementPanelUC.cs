using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public partial class CasementPanelUC : UserControl, ICasementPanelUC
    {
        public CasementPanelUC()
        {
            InitializeComponent();
        }

        public event PaintEventHandler casementPanelUCPaintEventRaised;
        public event EventHandler casementPanelUCSizeChangedEventRaised;

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_Dock"]);
            this.DataBindings.Add(ModelBinding["Panel_Width"]);
            this.DataBindings.Add(ModelBinding["Panel_Height"]);
            this.DataBindings.Add(ModelBinding["Panel_Visibility"]);
        }

        private void CasementPanelUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, casementPanelUCPaintEventRaised, e);
        }

        private void CasementPanelUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, casementPanelUCSizeChangedEventRaised, e);
        }
    }
}
