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

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_SashPropertyUC : UserControl, IPP_SashPropertyUC
    {
        public PP_SashPropertyUC()
        {
            InitializeComponent();
        }

        public string  ProfileType_FromMainPresenter { get; set; }

        public event EventHandler PPSashPropertyLoadEventRaised;
        public event EventHandler cmbSashProfileSelectedValueEventRaised;
        public event EventHandler cmbSashProfileReinfSelectedValueEventRaised;

        private void PP_SashPropertyUC_Load(object sender, EventArgs e)
        {
            List<SashProfile_ArticleNo> sash = new List<SashProfile_ArticleNo>();
            foreach (SashProfile_ArticleNo item in SashProfile_ArticleNo.GetAll())
            {
                if (ProfileType_FromMainPresenter.Contains("Alutek"))
                {
                    if (item == SashProfile_ArticleNo._84200 ||
                        item == SashProfile_ArticleNo._84207)
                    {
                        sash.Add(item);
                    }
                }
                else
                {
                    if (item != SashProfile_ArticleNo._84200 &&
                        item != SashProfile_ArticleNo._84207)
                    {
                        sash.Add(item);
                    }
                }
            }
            cmb_SashProfile.DataSource = sash;

            List<SashReinf_ArticleNo> sashReinf = new List<SashReinf_ArticleNo>();
            foreach (SashReinf_ArticleNo item in SashReinf_ArticleNo.GetAll())
            {
                if (ProfileType_FromMainPresenter.Contains("Alutek"))
                {
                    if (item == SashReinf_ArticleNo._None)
                    {
                        sashReinf.Add(item);
                    }
                }
                else
                { 
                        sashReinf.Add(item);   
                }
            }
            
            cmb_SashReinf.DataSource = sashReinf;
            cmb_SashProfile.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            cmb_SashReinf.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            EventHelpers.RaiseEvent(this, PPSashPropertyLoadEventRaised, e);
        }

        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
       
        private void cmb_SashProfile_SelectedValueChanged(object sender, EventArgs e)
        {
            SashProfile_ArticleNo sel_sash = (SashProfile_ArticleNo)((ComboBox)sender).SelectedValue;
            if (sel_sash == SashProfile_ArticleNo._7581 ||
                sel_sash == SashProfile_ArticleNo._374 ||
                sel_sash == SashProfile_ArticleNo._2067 ||
                sel_sash == SashProfile_ArticleNo._84207)
            {
                lbl_InOutOrient.Text = "Outward";
                lbl_InOutOrient.ForeColor = Color.Black;
            }
            else if (sel_sash == SashProfile_ArticleNo._395 ||
                     sel_sash == SashProfile_ArticleNo._373 ||
                     sel_sash == SashProfile_ArticleNo._84200)
            {
                lbl_InOutOrient.Text = "Inward";
                lbl_InOutOrient.ForeColor = Color.CadetBlue;
            }

            EventHelpers.RaiseEvent(sender, cmbSashProfileSelectedValueEventRaised, e);
        }

        private void cmb_SashReinf_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbSashProfileReinfSelectedValueEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_SashProfile.DataBindings.Add(ModelBinding["Panel_SashProfileArtNo"]);
            cmb_SashReinf.DataBindings.Add(ModelBinding["Panel_SashReinfArtNo"]);
            this.DataBindings.Add(ModelBinding["Panel_SashPropertyVisibility"]);
        }

        private void cmb_SashProfile_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmb_SashReinf_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmb_SashProfile_DrawItem(object sender, DrawItemEventArgs e)
        {
            //// Draw the background 
            //e.DrawBackground();

            //// Get the item text    
            //string text = ((ComboBox)sender).Items[e.Index].ToString();
            //SashProfile_ArticleNo sashArtNo = (SashProfile_ArticleNo)((ComboBox)sender).Items[e.Index];

            //if (sashArtNo == SashProfile_ArticleNo._7581 ||
            //    sashArtNo == SashProfile_ArticleNo._395 ||
            //    sashArtNo == SashProfile_ArticleNo._374 ||
            //    sashArtNo == SashProfile_ArticleNo._373)
            //{
            //    if ((Frame_ArtNo == FrameProfile_ArticleNo._7502) )
            //    {
            //        e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
            //    }
            //    else
            //    {
            //        e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
            //    }
            //}
        }
    }
}
