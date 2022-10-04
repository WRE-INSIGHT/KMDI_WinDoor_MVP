using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class ScreenView : Form, IScreenView
    {
        public ScreenView()
        {
            InitializeComponent();
        }

        public int screen_width
        {
            get
            {
                return (int)nud_Width.Value;
            }
            set
            {
                nud_Width.Value = value;
            }
        }

        public int screen_height
        {
            get
            {
                return (int)nud_Height.Value;
            }
            set
            {
                nud_Height.Value = value;
            }
        }

        public decimal screen_factor
        {
            get
            {
                return nud_Factor.Value;
            }
            set
            {
                nud_Factor.Value = value;
            }
        }
        public event EventHandler cmbScreenTypeSelectedValueChangedEventRaised;
        public event EventHandler ScreenViewLoadEventRaised;
        public event EventHandler nudWidthValueChangedEventRaised;
        public event EventHandler nudHeightValueChangedEventRaised;
        public event EventHandler nudFactorValueChangedEventRaised;

        private void cmb_ScreenType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbScreenTypeSelectedValueChangedEventRaised, e);
        }

        private void ScreenView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ScreenViewLoadEventRaised, e);
        }

        private void nud_Width_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudWidthValueChangedEventRaised, e);
        }

        private void nud_Height_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudHeightValueChangedEventRaised, e);
        }

        private void nud_Factor_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudFactorValueChangedEventRaised, e);
        }
    }
}
