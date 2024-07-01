using CommonComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Divider.DividerModel;

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
                SashProfileChanged(_panelSashProfileArtNo, new EventArgs());
            }
        }

        public string ProfileType_FromMainPresenter { get; set; }

        public event EventHandler PanelPropertiesLoadEventRaised;
        public event EventHandler CmbdivArtNoSelectedValueChangedEventRaised;
        public event EventHandler cmbCladdingArtNoSelectedValueChangeEventRiased;
        public event EventHandler btnAddCladdingClickedEventRaised;
        public event EventHandler btnSaveCladdingClickedEventRaised;
        public event EventHandler chkDMCheckedChangedEventRaised;
        public event EventHandler cmbDMArtNoSelectedValueChangedEventRaised;
        public event EventHandler btnSelectDMPanelClickedEventRaised;
        public event EventHandler SashProfileChangedEventRaised;

        private bool _initialLoad = true;

        private void DividerPropertiesUC_Load(object sender, EventArgs e)
        {
            num_divWidth.Maximum = decimal.MaxValue;
            num_divHeight.Maximum = decimal.MaxValue;

            List<Divider_ArticleNo> dArtNo = new List<Divider_ArticleNo>();
            foreach (Divider_ArticleNo item in Divider_ArticleNo.GetAll())
            {
                if (ProfileType_FromMainPresenter != null)
                {
                    if (ProfileType_FromMainPresenter.Contains("Alutek"))
                    {
                        if (item == Divider_ArticleNo._84300 ||
                            item == Divider_ArticleNo._84301)
                        {
                            dArtNo.Add(item);
                        }
                    }
                    else
                    {
                        if (item != Divider_ArticleNo._84300 &&
                            item != Divider_ArticleNo._84301)
                        {
                            dArtNo.Add(item);
                        }
                    }
                }
                 
            }
            cmb_divArtNo.DataSource = dArtNo;

            List<DividerReinf_ArticleNo> dReinfArtNo = new List<DividerReinf_ArticleNo>();
            foreach (DividerReinf_ArticleNo item in DividerReinf_ArticleNo.GetAll())
            {
                if (ProfileType_FromMainPresenter != null)
                {
                    if (ProfileType_FromMainPresenter.Contains("Alutek"))
                    {
                        if (item == DividerReinf_ArticleNo._None)
                        {
                            dReinfArtNo.Add(item);
                        }
                    }
                    else
                    {
                        dReinfArtNo.Add(item);
                    }
                }
               
            }
            cmb_divReinf.DataSource = dReinfArtNo;

            List<DummyMullion_ArticleNo> dMArtNo = new List<DummyMullion_ArticleNo>();
            foreach (DummyMullion_ArticleNo item in DummyMullion_ArticleNo.GetAll())
            {
                if (ProfileType_FromMainPresenter != null)
                {
                    if (ProfileType_FromMainPresenter.Contains("Alutek"))
                    {
                        if (item == DummyMullion_ArticleNo._84401)
                        {
                            dMArtNo.Add(item);
                        }
                    }
                    else
                    {
                        if (item != DummyMullion_ArticleNo._84401)
                        {
                            dMArtNo.Add(item);
                        }
                    }
                }
                
              
            }
            cmb_DMArtNo.DataSource = dMArtNo;

            List<CladdingProfile_ArticleNo> claddingProfileArtNo = new List<CladdingProfile_ArticleNo>();
            foreach (CladdingProfile_ArticleNo item in CladdingProfile_ArticleNo.GetAll())
            {
                claddingProfileArtNo.Add(item);
            }
            cmb_CladdingArtNo.DataSource = claddingProfileArtNo;

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
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (this.Parent == null)
            {
                RemoveDataBinding();
            }

        }
        private void RemoveDataBinding()
        {
            this.DataBindings.Clear();
            num_divWidth.DataBindings.Clear();
            num_divHeight.DataBindings.Clear();
            lbl_divname.DataBindings.Clear();
            cmb_divArtNo.DataBindings.Clear();
            cmb_divReinf.DataBindings.Clear();
            chk_DM.DataBindings.Clear();
            chk_DM.DataBindings.Clear();
            pnl_DMArtNo.DataBindings.Clear();
            pnl_divArtNo.DataBindings.Clear();
            cmb_DMArtNo.DataBindings.Clear();
            cmb_CladdingArtNo.DataBindings.Clear();
            pnl_divCladdingArtNo.DataBindings.Clear();


            num_divWidth.Dispose();
            num_divHeight.Dispose();
            lbl_divname.Dispose();
            cmb_divArtNo.Dispose();
            cmb_divReinf.Dispose();
            chk_DM.Dispose();
            pnl_DMArtNo.Dispose();
            pnl_divArtNo.Dispose();
            cmb_DMArtNo.Dispose();
            cmb_CladdingArtNo.Dispose();
            pnl_divCladdingArtNo.Dispose();
            lbl_divArtNo.Dispose();
            lbl_divReinf.Dispose();
            lbl_divSpecs.Dispose();
            lbl_Height.Dispose();
            lbl_totalCladdingLength.Dispose();
            lbl_Width.Dispose();
            btn_Save.Dispose();
            btn_SelectDMPanel.Dispose();
            btn_AddCladding.Dispose();
            label1.Dispose();
            label2.Dispose();
            label3.Dispose();
            label4.Dispose();
            pnl_AddCladding.Dispose();
            pnl_divCladdingArtNo.Dispose();
            pnl_divHt.Dispose();
            pnl_dividerBody.Dispose();
            pnl_divName.Dispose();
            pnl_divWd.Dispose();
            this.Dispose();


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
            cmb_CladdingArtNo.DataBindings.Add(ModelBinding["Div_CladdingProfileArtNo"]);
            pnl_divCladdingArtNo.DataBindings.Add(ModelBinding["Div_CladdingProfileArtNoVisibility"]);
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
                          Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                          Panel_SashProfileArtNo == SashProfile_ArticleNo._395))
                    {
                        MessageBox.Show("You've selected an incompatible item, be advised", Divider_Type.ToString() + " Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (dm == DummyMullion_ArticleNo._84401)
                {
                    if (!(Panel_SashProfileArtNo == SashProfile_ArticleNo._84207 ||
                          Panel_SashProfileArtNo == SashProfile_ArticleNo._84200))
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
                    Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                    Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
            }
            else if (dm == DummyMullion_ArticleNo._84401)
            {
                if (Panel_SashProfileArtNo == SashProfile_ArticleNo._84207 || Panel_SashProfileArtNo == SashProfile_ArticleNo._84200)
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
            }
        }

        public Panel GetDMArtNoPNL()
        {
            return pnl_DMArtNo;
        }

        public void SetLblTotalCladdingLength_Text(string total)
        {
            lbl_totalCladdingLength.Text = total;
            SetLblTotalCladdingLength_BackColor();
        }

        private void SetLblTotalCladdingLength_BackColor()
        {
            int cladTotal = Convert.ToInt32(lbl_totalCladdingLength.Text);
            if (_dividerType == DividerType.Mullion)
            {
                if (cladTotal == num_divHeight.Value)
                {
                    lbl_totalCladdingLength.BackColor = Color.Green;
                }
                else
                {
                    lbl_totalCladdingLength.BackColor = Color.IndianRed;
                }
            }
            else if (_dividerType == DividerType.Transom)
            {
                if (cladTotal == num_divWidth.Value)
                {
                    lbl_totalCladdingLength.BackColor = Color.Green;
                }
                else
                {
                    lbl_totalCladdingLength.BackColor = Color.IndianRed;
                }
            }
        }

        private void SashProfileChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SashProfileChangedEventRaised, e);
        }

        private void cmb_CladdingArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbCladdingArtNoSelectedValueChangeEventRiased, e);
        }
        private void cmb_divArtNo_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cmb_divArtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cmb_divReinf_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cmb_divReinf_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cmb_CladdingArtNo_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cmb_CladdingArtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}