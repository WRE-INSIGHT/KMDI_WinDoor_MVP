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

namespace PresentationLayer.Views.UserControls.DividerProperties_Modules
{
    public partial class DP_LeverEspagnolettePropertyUC : UserControl, IDP_LeverEspagnolettePropertyUC
    {
        private SashProfile_ArticleNo _sashProfileArtNo;
        public SashProfile_ArticleNo Panel_SashProfileArtNo
        {
            get
            {
                return _sashProfileArtNo;
            }

            set
            {
                _sashProfileArtNo = value;
                if (_sashProfileArtNo != SashProfile_ArticleNo._395)
                {
                    this.Visible = false;
                }
                else if (_sashProfileArtNo == SashProfile_ArticleNo._395)
                {
                    this.Visible = true;
                }
                SashProfileChanged(Panel_SashProfileArtNo, new EventArgs());
            }
        }

        public DP_LeverEspagnolettePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler DPLeverEspagnolettePropertyUCLoadEventRaised;
        public event EventHandler cmbLeverEspagSelectedValueChangedEventRaised;
        public event EventHandler DPLeverEspagnolettePropertyUCVisibleChangedEventRaised;
        public event EventHandler SashProfileChangedEventRaised;

        private void DP_LeverEspagnolettePropertyUC_Load(object sender, EventArgs e)
        {
            List<LeverEspagnolette_ArticleNo> LeverEspArtNo = new List<LeverEspagnolette_ArticleNo>();
            foreach (LeverEspagnolette_ArticleNo item in LeverEspagnolette_ArticleNo.GetAll())
            {
                LeverEspArtNo.Add(item);
            }
            cmb_LeverEspag.DataSource = LeverEspArtNo;

            if (Panel_SashProfileArtNo == null)
            {
                this.Visible = false;
            }
            
            EventHelpers.RaiseEvent(this, DPLeverEspagnolettePropertyUCLoadEventRaised, e);
        }

        private void cmb_LeverEspag_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbLeverEspagSelectedValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_LeverEspag.DataBindings.Add(ModelBinding["Div_LeverEspagArtNo"]);
        }

        public void SashPropBinding(Dictionary<string, Binding> sashBinding)
        {
            this.DataBindings.Add(sashBinding["Panel_SashProfileArtNo"]);
        }

        private void DP_LeverEspagnolettePropertyUC_VisibleChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, DPLeverEspagnolettePropertyUCVisibleChangedEventRaised, e);
        }

        private void SashProfileChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SashProfileChangedEventRaised, e);
        }
    }
}
