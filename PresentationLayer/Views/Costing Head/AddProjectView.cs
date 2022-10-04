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

namespace PresentationLayer.Views.Costing_Head
{
    public partial class AddProjectView : Form, IAddProjectView
    {
        public AddProjectView()
        {
            InitializeComponent();
        }
        #region parameters
        public ComboBox cmbArea()
        {
            return cmb_AreaStr;
        }
        public ComboBox cmbCity()
        {
            return cmb_CityStr;
        }
        public ComboBox cmbProvince()
        {
            return cmb_ProvinceStr;
        }
        #endregion
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            txt_FirstnameStr.DataBindings.Add(ModelBinding["Firstname"]);
            txt_LastnameStr.DataBindings.Add(ModelBinding["Lastname"]);
            txt_CompanynameStr.DataBindings.Add(ModelBinding["CompanyName"]);
            txt_ContactnoStr.DataBindings.Add(ModelBinding["ContactNo"]);
            cmb_FilelableasStr.DataBindings.Add(ModelBinding["FileLableAs"]);
            txt_UnitStr.DataBindings.Add(ModelBinding["UnitNo"]);
            txt_EstablishmentStr.DataBindings.Add(ModelBinding["Establishment"]);
            txt_HousenoStr.DataBindings.Add(ModelBinding["HouseNo"]);
            txt_StreetStr.DataBindings.Add(ModelBinding["Street"]);
            txt_VillageStr.DataBindings.Add(ModelBinding["Village"]);
            txt_BarangayStr.DataBindings.Add(ModelBinding["Barangay"]);
            cmb_CityStr.DataBindings.Add(ModelBinding["City"]);
            cmb_ProvinceStr.DataBindings.Add(ModelBinding["Province"]);
            cmb_AreaStr.DataBindings.Add(ModelBinding["Area"]);
        }
        public event EventHandler AddProjectViewLoadEventRaised;
        public event EventHandler cmbProvinceSelectedItemChange;
        public event EventHandler btnSaveClickEventRaised;
        private void AddProjectView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, AddProjectViewLoadEventRaised, e);
        }
        private void cmb_ProvinceStr_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbProvinceSelectedItemChange, e);
        }
        public void ShowThisView()
        {
            this.Show();
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnSaveClickEventRaised, e);
        }

        public void CloseThisView()
        {
            this.Close();
            this.Dispose();
        }
    }
}