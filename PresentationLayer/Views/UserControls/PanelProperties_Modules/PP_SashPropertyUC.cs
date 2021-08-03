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

        public event EventHandler PPSashPropertyLoadEventRaised;
        public event EventHandler cmbSashProfileSelectedValueEventRaised;
        public event EventHandler cmbSashProfileReinfSelectedValueEventRaised;

        private void PP_SashPropertyUC_Load(object sender, EventArgs e)
        {
            List<SashProfile_ArticleNo> sash = new List<SashProfile_ArticleNo>();
            foreach (SashProfile_ArticleNo item in SashProfile_ArticleNo.GetAll())
            {
                sash.Add(item);
            }
            cmb_SashProfile.DataSource = sash;

            List<SashReinf_ArticleNo> sashReinf = new List<SashReinf_ArticleNo>();
            foreach (SashReinf_ArticleNo item in SashReinf_ArticleNo.GetAll())
            {
                sashReinf.Add(item);
            }
            cmb_SashReinf.DataSource = sashReinf;

            EventHelpers.RaiseEvent(this, PPSashPropertyLoadEventRaised, e);
        }

        private void cmb_SashProfile_SelectedValueChanged(object sender, EventArgs e)
        {
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
    }
}