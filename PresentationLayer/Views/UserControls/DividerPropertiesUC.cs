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
using static EnumerationTypeLayer.EnumerationTypes;

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
                    pnl_divWd.Visible = false;
                    this.BackColor = Color.RosyBrown;
                }
                else if (value == DividerType.Transom)
                {
                    lbl_Height.Visible = false;
                    pnl_divHt.Visible = false;
                    this.BackColor = Color.PowderBlue;
                }
            }
        }
        public event EventHandler PanelPropertiesLoadEventRaised;
        public event EventHandler CmbdivArtNoSelectedValueChangedEventRaised;

        private void DividerPropertiesUC_Load(object sender, EventArgs e)
        {
            num_divWidth.Maximum = decimal.MaxValue;
            num_divHeight.Maximum = decimal.MaxValue;

            List<Divider_ArticleNo> dArtNo = new List<Divider_ArticleNo>();
            foreach (Divider_ArticleNo item in Divider_ArticleNo.GetAll())
            {
                dArtNo.Add(item);
            }
            cmb_divArtNo.DataSource = dArtNo;

            List<DividerReinf_ArticleNo> dReinfArtNo = new List<DividerReinf_ArticleNo>();
            foreach (DividerReinf_ArticleNo item in DividerReinf_ArticleNo.GetAll())
            {
                dReinfArtNo.Add(item);
            }
            cmb_divReinf.DataSource = dReinfArtNo;

            EventHelpers.RaiseEvent(this, PanelPropertiesLoadEventRaised, e);
        }

        private void cmb_divArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbdivArtNoSelectedValueChangedEventRaised, e);
        }

        public Panel GetDividerPropertiesBodyPNL()
        {
            return pnl_dividerBody;
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
            this.DataBindings.Add(ModelBinding["Div_PropHeight"]);
        }
    }
}
