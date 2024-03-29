﻿using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views
{
    public partial class ChangeItemColorView : Form, IChangeItemColorView
    {
        public ChangeItemColorView()
        {
            InitializeComponent();
        }

        public event EventHandler ChangeItemColorViewLoadEventRaised;
        public event EventHandler BtnOkClickEventRaised;
        public event EventHandler CmbBaseColorSelectedValueChangedEventRaised;
        public event EventHandler CmbInsideColorSelectedValueChangedEventRaised;
        public event EventHandler CmbOutsideColorSelectedValueChangedEventRaised;

        private void ChangeItemColorView_Load(object sender, EventArgs e)
        {
            List<Base_Color> base_col = new List<Base_Color>();
            List<Foil_Color> inside_col = new List<Foil_Color>();
            List<Foil_Color> outside_col = new List<Foil_Color>();

            foreach (Base_Color item in Base_Color.GetAll())
            {
                base_col.Add(item);
            }
            cmb_baseColor.DataSource = base_col;

            foreach (Foil_Color item in Foil_Color.GetAll())
            {
                inside_col.Add(item);
            }
            cmb_InsideColor.DataSource = inside_col;

            foreach (Foil_Color item in Foil_Color.GetAll())
            {
                outside_col.Add(item);
            }
            cmb_outsideColor.DataSource = outside_col;

            EventHelpers.RaiseEvent(this, ChangeItemColorViewLoadEventRaised, e);
        }

        public void ShowThisDialog()
        {
            this.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, BtnOkClickEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_baseColor.DataBindings.Add(ModelBinding["WD_BaseColor"]);
            cmb_InsideColor.DataBindings.Add(ModelBinding["WD_InsideColor"]);
            cmb_outsideColor.DataBindings.Add(ModelBinding["WD_OutsideColor"]);
        }

        private void cmb_baseColor_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbBaseColorSelectedValueChangedEventRaised, e);
        }

        private void cmb_InsideColor_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbInsideColorSelectedValueChangedEventRaised, e);
        }

        private void cmb_outsideColor_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbOutsideColorSelectedValueChangedEventRaised, e);
        }

        public void CloseView()
        {
            this.Close();
        }
    }
}
