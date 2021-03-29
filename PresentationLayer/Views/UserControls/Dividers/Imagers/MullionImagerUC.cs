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

namespace PresentationLayer.Views.UserControls.Dividers.Imagers
{
    public partial class MullionImagerUC : UserControl, IMullionImagerUC
    {
        public MullionImagerUC()
        {
            InitializeComponent();
        }

        private int _divID;
        public int Div_ID
        {
            get
            {
                return _divID;
            }
            set
            {
                _divID = value;
            }
        }

        public event PaintEventHandler mullionUCPaintEventRaised;
        public event EventHandler mullionVisibleChangedEventRaised;

        private void MullionImagerUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, mullionUCPaintEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Div_ID"]);
            this.DataBindings.Add(ModelBinding["Div_Width"]);
            this.DataBindings.Add(ModelBinding["Div_Height"]);
            this.DataBindings.Add(ModelBinding["Div_Visible"]);
        }

        private void MullionImagerUC_VisibleChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, mullionVisibleChangedEventRaised, e);
        }
    }
}
