﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;
using static EnumerationTypeLayer.EnumerationTypes;
using EnumerationTypeLayer;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_ExtensionPropertyUC : UserControl, IPP_ExtensionPropertyUC
    {
        private string _panelType;
        public string Panel_Type
        {
            get
            {
                return _panelType;
            }

            set
            {
                _panelType = value;
                if (_panelType.Contains("Awning"))
                {
                    pnl_TopExtOption.Visible = false;
                    pnl_BotExtOption.Visible = false;
                    pnl_LeftExtOption.Visible = true;
                    pnl_RightExtOption.Visible = true;
                }
                else if (_panelType.Contains("Casement"))
                {
                    pnl_TopExtOption.Visible = true;
                    pnl_BotExtOption.Visible = true;
                    pnl_LeftExtOption.Visible = false;
                    pnl_RightExtOption.Visible = false;
                }
            }
        }


        private FrameProfile_ArticleNo _frameArtNO;
        public FrameProfile_ArticleNo Frame_ArtNo
        {
            get
            {
                return _frameArtNO;
            }

            set
            {
                _frameArtNO = value;
                cmb_TopExt.Refresh();
                cmb_TopExt2.Refresh();
                cmb_BotExt.Refresh();
                cmb_BotExt2.Refresh();
                cmb_LeftExt.Refresh();
                cmb_LeftExt2.Refresh();
                cmb_RightExt.Refresh();
                cmb_RightExt2.Refresh();
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
                cmb_TopExt.Refresh();
                cmb_TopExt2.Refresh();
                cmb_BotExt.Refresh();
                cmb_BotExt2.Refresh();
                cmb_LeftExt.Refresh();
                cmb_LeftExt2.Refresh();
                cmb_RightExt.Refresh();
                cmb_RightExt2.Refresh();
            }
        }

        private bool _initialLoad = true;

        public PP_ExtensionPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPExtensionUCLoadEventRaised;
        public event EventHandler chkToAddExtension2CheckedChangedEventRaised;
        public event EventHandler cmbExtensionsSelectedValueChangedEventRaised;

        private void PP_ExtensionUC_Load(object sender, EventArgs e)
        {
            num_TopExtQty.Maximum = decimal.MaxValue;
            num_TopExtQty2.Maximum = decimal.MaxValue;
            num_TopExtQty3.Maximum = decimal.MaxValue;
            num_BotExtQty.Maximum = decimal.MaxValue;
            num_BotExtQty2.Maximum = decimal.MaxValue;
            num_LeftExtQty.Maximum = decimal.MaxValue;
            num_LeftExtQty2.Maximum = decimal.MaxValue;
            num_RightExtQty.Maximum = decimal.MaxValue;
            num_RightExtQty2.Maximum = decimal.MaxValue;

            List<Extension_ArticleNo> extArtNo = new List<Extension_ArticleNo>();
            foreach (Extension_ArticleNo item in Extension_ArticleNo.GetAll())
            {
                extArtNo.Add(item);
            }
            cmb_TopExt.DataSource = extArtNo;

            List<Extension_ArticleNo> extArtNo1 = new List<Extension_ArticleNo>();
            foreach (Extension_ArticleNo item in Extension_ArticleNo.GetAll())
            {
                extArtNo1.Add(item);
            }
            cmb_TopExt2.DataSource = extArtNo1;

            List<Extension_ArticleNo> extArtNo8 = new List<Extension_ArticleNo>();
            foreach (Extension_ArticleNo item in Extension_ArticleNo.GetAll())
            {
                extArtNo8.Add(item);
            }
            cmb_TopExt3.DataSource = extArtNo8;

            List<Extension_ArticleNo> extArtNo2 = new List<Extension_ArticleNo>();
            foreach (Extension_ArticleNo item in Extension_ArticleNo.GetAll())
            {
                extArtNo2.Add(item);
            }
            cmb_BotExt.DataSource = extArtNo2;

            List<Extension_ArticleNo> extArtNo3 = new List<Extension_ArticleNo>();
            foreach (Extension_ArticleNo item in Extension_ArticleNo.GetAll())
            {
                extArtNo3.Add(item);
            }
            cmb_BotExt2.DataSource = extArtNo3;

            List<Extension_ArticleNo> extArtNo4 = new List<Extension_ArticleNo>();
            foreach (Extension_ArticleNo item in Extension_ArticleNo.GetAll())
            {
                extArtNo4.Add(item);
            }
            cmb_RightExt.DataSource = extArtNo4;

            List<Extension_ArticleNo> extArtNo5 = new List<Extension_ArticleNo>();
            foreach (Extension_ArticleNo item in Extension_ArticleNo.GetAll())
            {
                extArtNo5.Add(item);
            }
            cmb_RightExt2.DataSource = extArtNo5;

            List<Extension_ArticleNo> extArtNo6 = new List<Extension_ArticleNo>();
            foreach (Extension_ArticleNo item in Extension_ArticleNo.GetAll())
            {
                extArtNo6.Add(item);
            }
            cmb_LeftExt.DataSource = extArtNo6;

            List<Extension_ArticleNo> extArtNo7 = new List<Extension_ArticleNo>();
            foreach (Extension_ArticleNo item in Extension_ArticleNo.GetAll())
            {
                extArtNo7.Add(item);
            }
            cmb_LeftExt2.DataSource = extArtNo7;

            EventHelpers.RaiseEvent(this, PPExtensionUCLoadEventRaised, e);

            _initialLoad = false;
        }

        private void chk_ToAdd_TopExt2_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkToAddExtension2CheckedChangedEventRaised, e);
        }

        private void chk_ToAdd_TopExt2_MouseHover(object sender, EventArgs e)
        {
            chk_ToAdd_TopExt2.BackgroundImage = base.BackgroundImage;
            if (chk_ToAdd_TopExt2.Checked == true)
            {
                chk_ToAdd_TopExt2.Text = "-";
            }
            else if (chk_ToAdd_TopExt2.Checked == false)
            {
                chk_ToAdd_TopExt2.Text = "+";
            }
        }

        private void chk_ToAdd_TopExt2_MouseLeave(object sender, EventArgs e)
        {
            chk_ToAdd_TopExt2.BackgroundImage = Properties.Resources.ExtensionTop;
            chk_ToAdd_TopExt2.Text = "";
        }

        private void chk_ToAdd_TopExt3_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkToAddExtension2CheckedChangedEventRaised, e);
        }

        private void chk_ToAdd_TopExt3_MouseHover(object sender, EventArgs e)
        {
            chk_ToAdd_TopExt3.BackgroundImage = base.BackgroundImage;
            if (chk_ToAdd_TopExt3.Checked == true)
            {
                chk_ToAdd_TopExt3.Text = "-";
            }
            else if (chk_ToAdd_TopExt3.Checked == false)
            {
                chk_ToAdd_TopExt3.Text = "+";
            }
        }

        private void chk_ToAdd_TopExt3_MouseLeave(object sender, EventArgs e)
        {
            chk_ToAdd_TopExt3.BackgroundImage = Properties.Resources.ExtensionTop;
            chk_ToAdd_TopExt3.Text = "";
        }

        private void chk_ToAdd_BotExt2_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkToAddExtension2CheckedChangedEventRaised, e);
        }

        private void chk_ToAdd_BotExt2_MouseHover(object sender, EventArgs e)
        {
            chk_ToAdd_BotExt2.BackgroundImage = base.BackgroundImage;
            if (chk_ToAdd_BotExt2.Checked == true)
            {
                chk_ToAdd_BotExt2.Text = "-";
            }
            else if (chk_ToAdd_BotExt2.Checked == false)
            {
                chk_ToAdd_BotExt2.Text = "+";
            }
        }

        private void chk_ToAdd_BotExt2_MouseLeave(object sender, EventArgs e)
        {
            chk_ToAdd_BotExt2.BackgroundImage = Properties.Resources.ExtensionBot;
            chk_ToAdd_BotExt2.Text = "";
        }

        private void chk_ToAdd_LeftExt2_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkToAddExtension2CheckedChangedEventRaised, e);
        }

        private void chk_ToAdd_LeftExt2_MouseHover(object sender, EventArgs e)
        {
            chk_ToAdd_LeftExt2.BackgroundImage = base.BackgroundImage;
            if (chk_ToAdd_LeftExt2.Checked == true)
            {
                chk_ToAdd_LeftExt2.Text = "-";
            }
            else if (chk_ToAdd_LeftExt2.Checked == false)
            {
                chk_ToAdd_LeftExt2.Text = "+";
            }
        }

        private void chk_ToAdd_LeftExt2_MouseLeave(object sender, EventArgs e)
        {
            chk_ToAdd_LeftExt2.BackgroundImage = Properties.Resources.ExtensionLeft;
            chk_ToAdd_LeftExt2.Text = "";
        }

        private void chk_ToAdd_RightExt2_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkToAddExtension2CheckedChangedEventRaised, e);
        }

        private void chk_ToAdd_RightExt2_MouseHover(object sender, EventArgs e)
        {
            chk_ToAdd_RightExt2.BackgroundImage = base.BackgroundImage;
            if (chk_ToAdd_RightExt2.Checked == true)
            {
                chk_ToAdd_RightExt2.Text = "-";
            }
            else if (chk_ToAdd_RightExt2.Checked == false)
            {
                chk_ToAdd_RightExt2.Text = "+";
            }
        }

        private void chk_ToAdd_RightExt2_MouseLeave(object sender, EventArgs e)
        {
            chk_ToAdd_RightExt2.BackgroundImage = Properties.Resources.ExtensionRight;
            chk_ToAdd_RightExt2.Text = "";
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            num_TopExtQty.DataBindings.Add(ModelBinding["Panel_ExtTopQty"]);
            num_BotExtQty.DataBindings.Add(ModelBinding["Panel_ExtBotQty"]);
            num_LeftExtQty.DataBindings.Add(ModelBinding["Panel_ExtLeftQty"]);
            num_RightExtQty.DataBindings.Add(ModelBinding["Panel_ExtRightQty"]);
            num_TopExtQty2.DataBindings.Add(ModelBinding["Panel_ExtTop2Qty"]);
            num_TopExtQty3.DataBindings.Add(ModelBinding["Panel_ExtTop3Qty"]);
            num_BotExtQty2.DataBindings.Add(ModelBinding["Panel_ExtBot2Qty"]);
            num_LeftExtQty2.DataBindings.Add(ModelBinding["Panel_ExtLeft2Qty"]);
            num_RightExtQty2.DataBindings.Add(ModelBinding["Panel_ExtRight2Qty"]);
            cmb_TopExt.DataBindings.Add(ModelBinding["Panel_ExtensionTopArtNo"]);
            cmb_TopExt2.DataBindings.Add(ModelBinding["Panel_ExtensionTop2ArtNo"]);
            cmb_TopExt3.DataBindings.Add(ModelBinding["Panel_ExtensionTop3ArtNo"]);
            cmb_BotExt.DataBindings.Add(ModelBinding["Panel_ExtensionBotArtNo"]);
            cmb_BotExt2.DataBindings.Add(ModelBinding["Panel_ExtensionBot2ArtNo"]);
            cmb_LeftExt.DataBindings.Add(ModelBinding["Panel_ExtensionLeftArtNo"]);
            cmb_LeftExt2.DataBindings.Add(ModelBinding["Panel_ExtensionLeft2ArtNo"]);
            cmb_RightExt.DataBindings.Add(ModelBinding["Panel_ExtensionRightArtNo"]);
            cmb_RightExt2.DataBindings.Add(ModelBinding["Panel_ExtensionRight2ArtNo"]);
            chk_ToAdd_TopExt2.DataBindings.Add(ModelBinding["Panel_ExtTopChk"]);
            chk_ToAdd_TopExt3.DataBindings.Add(ModelBinding["Panel_ExtTop2Chk"]);
            chk_ToAdd_BotExt2.DataBindings.Add(ModelBinding["Panel_ExtBotChk"]);
            chk_ToAdd_LeftExt2.DataBindings.Add(ModelBinding["Panel_ExtLeftChk"]);
            chk_ToAdd_RightExt2.DataBindings.Add(ModelBinding["Panel_ExtRightChk"]);
            pnl_TopExt2Option.DataBindings.Add(ModelBinding["Panel_ExtTopChk_visible"]);
            pnl_TopExt3Option.DataBindings.Add(ModelBinding["Panel_ExtTop2Chk_visible"]);
            pnl_BotExt2Option.DataBindings.Add(ModelBinding["Panel_ExtBotChk_visible"]);
            pnl_LeftExt2Option.DataBindings.Add(ModelBinding["Panel_ExtLeftChk_visible"]);
            pnl_RightExt2Option.DataBindings.Add(ModelBinding["Panel_ExtRightChk_visible"]);
            this.DataBindings.Add(ModelBinding["Panel_ExtensionPropertyHeight"]);
            this.DataBindings.Add(ModelBinding["Panel_Type"]);
            this.DataBindings.Add(ModelBinding["Panel_ExtensionOptionsVisibility"]);
            this.DataBindings.Add(ModelBinding["Frame_ArtNo"]);
            this.DataBindings.Add(ModelBinding["Panel_SashProfileArtNo"]);
        }

        private void cmbExtension_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                Extension_ArticleNo ext = (Extension_ArticleNo)((ComboBox)sender).SelectedValue;

                if (ext == Extension_ArticleNo._639957)
                {
                    if (!(Frame_ArtNo == FrameProfile_ArticleNo._7502 && Panel_SashProfileArtNo == SashProfile_ArticleNo._7581) &&
                        !(Frame_ArtNo == FrameProfile_ArticleNo._7507 && Panel_SashProfileArtNo == SashProfile_ArticleNo._7581))
                    {
                        MessageBox.Show("You've selected an incompatible item, be advised", "Extension Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (ext == Extension_ArticleNo._641798 || ext == Extension_ArticleNo._567639 || ext == Extension_ArticleNo._630956)
                {
                    if (!(Frame_ArtNo == FrameProfile_ArticleNo._7507 && 
                          (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                           Panel_SashProfileArtNo == SashProfile_ArticleNo._373)))
                    {
                        MessageBox.Show("You've selected an incompatible item, be advised", "Extension Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (ext == Extension_ArticleNo._612978)
                {
                    if (!(Frame_ArtNo == FrameProfile_ArticleNo._7502 && Panel_SashProfileArtNo == SashProfile_ArticleNo._7581) &&
                        !(Frame_ArtNo == FrameProfile_ArticleNo._7507 && Panel_SashProfileArtNo == SashProfile_ArticleNo._7581) &&
                        !(Frame_ArtNo == FrameProfile_ArticleNo._7507 && Panel_SashProfileArtNo == SashProfile_ArticleNo._374) &&
                        !(Frame_ArtNo == FrameProfile_ArticleNo._7507 && Panel_SashProfileArtNo == SashProfile_ArticleNo._395))
                    {
                        MessageBox.Show("You've selected an incompatible item, be advised", "Extension Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            EventHelpers.RaiseEvent(sender, cmbExtensionsSelectedValueChangedEventRaised, e);
        }

        private void cmb_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            // Get the item text    
            string text = ((ComboBox)sender).Items[e.Index].ToString();
            Extension_ArticleNo ext = (Extension_ArticleNo)((ComboBox)sender).Items[e.Index];

            if (ext == Extension_ArticleNo._639957)
            {
                if ((Frame_ArtNo == FrameProfile_ArticleNo._7502 && Panel_SashProfileArtNo == SashProfile_ArticleNo._7581) ||
                    (Frame_ArtNo == FrameProfile_ArticleNo._7507 && Panel_SashProfileArtNo == SashProfile_ArticleNo._7581))
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
            }
            else if (ext == Extension_ArticleNo._641798 || ext == Extension_ArticleNo._567639 || ext == Extension_ArticleNo._630956)
            {
                if (Frame_ArtNo == FrameProfile_ArticleNo._7507 && 
                   (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                    Panel_SashProfileArtNo == SashProfile_ArticleNo._373))
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
            }
            else if (ext == Extension_ArticleNo._612978)
            {
                if ((Frame_ArtNo == FrameProfile_ArticleNo._7502 && Panel_SashProfileArtNo == SashProfile_ArticleNo._7581) ||
                    (Frame_ArtNo == FrameProfile_ArticleNo._7507 && Panel_SashProfileArtNo == SashProfile_ArticleNo._7581) ||
                    (Frame_ArtNo == FrameProfile_ArticleNo._7507 && Panel_SashProfileArtNo == SashProfile_ArticleNo._374) ||
                    (Frame_ArtNo == FrameProfile_ArticleNo._7507 && Panel_SashProfileArtNo == SashProfile_ArticleNo._395))
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
            }
            else
            {
                e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
            }
        }
        //cmb_TopExt & num_TopExtQty
        private void cmb_TopExt_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_TopExt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void num_TopExtQty_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        //
        //cmb_TopExt2 & num_TopExtQty2
        private void cmb_TopExt2_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_TopExt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void num_TopExtQty2_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        //
        // cmb_TopExt3 & num_TopExtQty3
        private void cmb_TopExt3_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_TopExt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void num_TopExtQty3_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        //
        // cmb_RightExt & num_RightExtQty
        private void cmb_RightExt_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_RightExt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void num_RightExtQty_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        //
        // cmb_RightExt2 & num_RightExtQty2
        private void cmb_RightExt2_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_RightExt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void num_RightExtQty2_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        //
        // cmb_BotExt & num_BotExtQty
        private void cmb_BotExt_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_BotExt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void num_BotExtQty_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        //
        // cmb_BotExt2 & num_BotExtQty2
        private void cmb_BotExt2_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_BotExt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void num_BotExtQty2_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        //
        // cmb_LeftExt & num_LeftExtQty
        private void cmb_LeftExt_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_LeftExt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void num_LeftExtQty_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        //
        // cmb_LeftExt2 & num_LeftExtQty2
        private void cmb_LeftExt2_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_LeftExt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void num_LeftExtQty2_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        //
        public Panel GetTopExt2OptionPNL()
        {
            return pnl_TopExt2Option;
        }

        public Panel GetTopExt3OptionPNL()
        {
            return pnl_TopExt3Option;
        }

        public Panel GetBotExt2OptionPNL()
        {
            return pnl_BotExt2Option;
        }

        public Panel GetLeftExt2OptionPNL()
        {
            return pnl_LeftExt2Option;
        }

        public Panel GetRightExt2OptionPNL()
        {
            return pnl_RightExt2Option;
        }

       
    }
}