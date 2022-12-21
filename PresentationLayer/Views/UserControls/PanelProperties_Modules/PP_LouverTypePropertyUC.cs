using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_LouverTypePropertyUC : UserControl
    {
        public PP_LouverTypePropertyUC()
        {
            InitializeComponent();
        }

        private void PP_LouverTypePropertyUC_Load(object sender, EventArgs e)
        {
            List<LouverType_Option> LouverType = new List<LouverType_Option>();
            foreach (LouverType_Option item in LouverType_Option.GetAll())
            {
                LouverType.Add(item);
            }
            cmb_LouverType.DataSource = LouverType;
        }
    }
}
