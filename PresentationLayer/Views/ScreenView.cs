using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views
{
    public partial class ScreenView : Form, IScreenView
    {
        public ScreenView()
        {
            InitializeComponent();
        }

        public NumericUpDown screen_width
        {
            get
            {
                return nud_Width;
            }
            set
            {
                nud_Width.Value = Convert.ToDecimal(value);
            }
        }

        public NumericUpDown screen_height
        {
            get
            {
                return nud_Height;
            }
            set
            {
                nud_Height.Value = Convert.ToDecimal(value);
            }
        }

        public NumericUpDown screen_factor
        {
            get
            {
                return nud_Factor;
            }
            set
            {
                nud_Factor.Value = Convert.ToDecimal(value);
            }
        }



        public event EventHandler cmbScreenTypeSelectedValueChangedEventRaised;
        public event EventHandler ScreenViewLoadEventRaised;
        public event EventHandler nudWidthValueChangedEventRaised;
        public event EventHandler nudHeightValueChangedEventRaised;
        public event EventHandler nudFactorValueChangedEventRaised;
        public event EventHandler cmbbaseColorSelectedValueChangedEventRaised;


        public void ShowScreemView()
        {
            this.Show();
        }

        public ComboBox GetCmbBaseColor()
        {
            return cmb_baseColor;
        }

        public ComboBox GetCmbScreenType()
        {
            return cmb_ScreenType;
        }

        public NumericUpDown GetNudSet()
        {
            return nud_Sets;
        } 

        public NumericUpDown GetNudQuantity()
        {
            return nud_Quantity;
        }

        public NumericUpDown GetNudTotalPrice()
        {
            return nud_TotalPrice;
        }

        public DataGridView GetDatagrid()
        {
            return dgv_Screen;
        }
        private void cmb_ScreenType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbScreenTypeSelectedValueChangedEventRaised, e);
        }

        private void ScreenView_Load(object sender, EventArgs e)
        {
            List<ScreenType> screen = new List<ScreenType>();
            foreach (ScreenType item in ScreenType.GetAll())
            {
                screen.Add(item);
            }
            cmb_ScreenType.DataSource = screen;

            List<Base_Color> baseColor = new List<Base_Color>();
            foreach (Base_Color item in Base_Color.GetAll())
            {
                baseColor.Add(item);
            }
            cmb_baseColor.DataSource = baseColor;

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

        private void cmb_baseColor_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbbaseColorSelectedValueChangedEventRaised, e);

        }
    }
}
