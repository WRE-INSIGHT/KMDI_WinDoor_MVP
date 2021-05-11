using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ModelLayer.Model.Quotation.Divider.DividerModel;
using static ModelLayer.Model.Quotation.QuotationModel;
using CommonComponents;

namespace PresentationLayer.Views.UserControls
{
    public partial class DividerPropertiesUC : UserControl, IDividerPropertiesUC
    {
        public DividerPropertiesUC()
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

        private DividerType _dividerType;
        public DividerType Divider_Type
        {
            get
            {
                return _dividerType;
            }
            set
            {
                _dividerType = value;
                lbl_divArtNo.Text = value.ToString() + " Art No";
                lbl_divReinf.Text = value.ToString() + " Reinf";
                if (value == DividerType.Mullion)
                {
                    lbl_Width.Visible = false;
                    num_divWidth.Visible = false;
                    this.BackColor = Color.PowderBlue;
                }
                else if (value == DividerType.Transom)
                {
                    lbl_Height.Visible = false;
                    num_divHeight.Visible = false;
                    this.BackColor = Color.RosyBrown;
                }
            }
        }
        public event EventHandler PanelPropertiesLoadEventRaised;

        private void DividerPropertiesUC_Load(object sender, EventArgs e)
        {
            num_divWidth.Maximum = decimal.MaxValue;
            num_divHeight.Maximum = decimal.MaxValue;
            cmb_divArtNo.DataSource = Enum.GetValues(typeof(Divider_ArticleNo));
            cmb_divReinf.DataSource = Enum.GetValues(typeof(DividerReinf_ArticleNo));
            EventHelpers.RaiseEvent(this, PanelPropertiesLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Div_ID"]);
            num_divWidth.DataBindings.Add(ModelBinding["Div_DisplayWidth"]);
            num_divHeight.DataBindings.Add(ModelBinding["Div_DisplayHeight"]);
            lbl_divname.DataBindings.Add(ModelBinding["Div_Name"]);
            this.DataBindings.Add(ModelBinding["Div_Visible"]);
            cmb_divArtNo.DataBindings.Add(ModelBinding["Div_ArtNo"]);
            cmb_divReinf.DataBindings.Add(ModelBinding["Div_ReinfArtNo"]);
            this.DataBindings.Add(ModelBinding["Divider_Type"]);
        }
    }
}
