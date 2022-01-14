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

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public partial class MultiPanelMullionImagerUC : UserControl, IMultiPanelMullionImagerUC, IMultiPanelImagerUC
    {
        public MultiPanelMullionImagerUC()
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
        public event EventHandler flpMulltiVisibleChangedEventRaised;

        private void flp_MultiMullionImager_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, flpMulltiPaintEventRaised, e);
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

        private void MultiPanelMullionImagerUC_VisibleChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, flpMulltiVisibleChangedEventRaised, e);
        }

        public void AddImagerControl(UserControl userctrlObj)
        {
            flp_MultiMullionImager.Controls.Add(userctrlObj);
        }

        public void DeleteImagerControl(UserControl userctrlObj)
        {
            flp_MultiMullionImager.Controls.Remove(userctrlObj);
        }
    }
}
