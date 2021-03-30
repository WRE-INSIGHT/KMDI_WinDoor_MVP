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
    public partial class TransomImagerUC : UserControl, ITransomImagerUC
    {
        public TransomImagerUC()
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
        public event PaintEventHandler transomUCPaintEventRaised;
        public event EventHandler transomUCVisibleChangedEventRaised;

        private void TransomImagerUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, transomUCPaintEventRaised, e);
        }

        private void TransomImagerUC_VisibleChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, transomUCVisibleChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Div_ID"]);
            this.DataBindings.Add(ModelBinding["DivImageRenderer_Width"]);
            this.DataBindings.Add(ModelBinding["DivImageRenderer_Height"]);
            this.DataBindings.Add(ModelBinding["Div_Visible"]);
        }
    }
}
