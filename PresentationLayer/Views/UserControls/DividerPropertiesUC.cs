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
using EnumerationTypeLayer;

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

        private SashProfile_ArticleNo _panelSashProfileArtNo;
        public SashProfile_ArticleNo Panel_SashProfileArtNo
        {
            get
            {
                return _panelSashProfileArtNo;
            }

            set
            {
                _panelSashProfileArtNo = value;
                cmb_DMArtNo.Refresh();
            }
        }

        public event EventHandler PanelPropertiesLoadEventRaised;
        public event EventHandler CmbdivArtNoSelectedValueChangedEventRaised;
        public event EventHandler btnAddCladdingClickedEventRaised;
        public event EventHandler btnSaveCladdingClickedEventRaised;
        public event EventHandler chkDMCheckedChangedEventRaised;
        public event EventHandler cmbDMArtNoSelectedValueChangedEventRaised;
        public event EventHandler btnSelectDMPanelClickedEventRaised;

        private bool _initialLoad = true;

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

            List<DummyMullion_ArticleNo> dMArtNo = new List<DummyMullion_ArticleNo>();
            foreach (DummyMullion_ArticleNo item in DummyMullion_ArticleNo.GetAll())
            {
                dMArtNo.Add(item);
            }
            cmb_DMArtNo.DataSource = dMArtNo;

            EventHelpers.RaiseEvent(this, PanelPropertiesLoadEventRaised, e);

            _initialLoad = false;
        }

        private void cmb_divArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbdivArtNoSelectedValueChangedEventRaised, e);
        }

        public Panel GetDividerPropertiesBodyPNL()
        {
            return pnl_dividerBody;
        }
        private void btn_AddCladding_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnAddCladdingClickedEventRaised, e);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnSaveCladdingClickedEventRaised, e);
        }

        private void chk_DM_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_DM.Checked == true)
            {
                chk_DM.Text = "DM";
            }
            else if (chk_DM.Checked == false)
            {
                Binding sash = this.DataBindings["Panel_SashProfileArtNo"];
                if (sash != null)
                {
                    this.DataBindings.Remove(sash);
                }
                _panelSashProfileArtNo = null;
                cmb_DMArtNo.Refresh();

                chk_DM.Text = "M";
            }
            EventHelpers.RaiseEvent(sender, chkDMCheckedChangedEventRaised, e);
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
            chk_DM.DataBindings.Add(ModelBinding["Div_ChkDM"]);
            chk_DM.DataBindings.Add(ModelBinding["Div_ChkDMVisibility"]);
            pnl_DMArtNo.DataBindings.Add(ModelBinding["Div_ChkDM2"]);
            pnl_divArtNo.DataBindings.Add(ModelBinding["Div_ArtVisibility"]);
            cmb_DMArtNo.DataBindings.Add(ModelBinding["Div_DMArtNo"]);
        }

        public void SetBtnSaveBackColor(Color color)
        {
            btn_Save.BackColor = color;
        }

        private void cmb_DMArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                DummyMullion_ArticleNo dm = (DummyMullion_ArticleNo)((ComboBox)sender).SelectedValue;
                if (dm == DummyMullion_ArticleNo._7533)
                {
                    if (!(Panel_SashProfileArtNo == SashProfile_ArticleNo._7581))
                    {
                        MessageBox.Show("You've selected an incompatible item, be advised", Divider_Type.ToString() + " Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (dm == DummyMullion_ArticleNo._385P)
                {
                    if (!(Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                          Panel_SashProfileArtNo == SashProfile_ArticleNo._395))
                    {
                        MessageBox.Show("You've selected an incompatible item, be advised", Divider_Type.ToString() + " Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            EventHelpers.RaiseEvent(sender, cmbDMArtNoSelectedValueChangedEventRaised, e);
        }

        private void btn_SelectDMPanel_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnSelectDMPanelClickedEventRaised, e);
        }

        public Button GetBtnSelectDMPanel()
        {
            return btn_SelectDMPanel;
        }

        public void Bind_DMPanelModel(Dictionary<string, Binding> ModelBinding)
        {
            Binding sash = this.DataBindings["Panel_SashProfileArtNo"];
            if (sash != null)
            {
                this.DataBindings.Remove(sash);
            }
            this.DataBindings.Add(ModelBinding["Panel_SashProfileArtNo"]);
        }

        private void cmb_DMArtNo_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background 
            e.DrawBackground();

            // Get the item text    
            string text = ((ComboBox)sender).Items[e.Index].ToString();
            DummyMullion_ArticleNo dm = (DummyMullion_ArticleNo)((ComboBox)sender).Items[e.Index];

            if (dm == DummyMullion_ArticleNo._7533)
            {
                if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
            }
            else if (dm == DummyMullion_ArticleNo._385P)
            {
                if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                    Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
            }
        }
    }
}
