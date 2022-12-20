using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_LouverGalleryPropertyUC : UserControl
    {
        public PP_LouverGalleryPropertyUC()
        {
            InitializeComponent();
        }

        private void PP_LouverBladesCombinationPropertyUC_Load(object sender, EventArgs e)
        {
            List<BladeCombination_Option> BladeCombi = new List<BladeCombination_Option>();
            foreach (BladeCombination_Option item in BladeCombination_Option.GetAll())
            {
                BladeCombi.Add(item);
            }
            cmb_BladeCombination.DataSource = BladeCombi;

            List<BladeType_Option> BladeType = new List<BladeType_Option>();
            foreach (BladeType_Option item in BladeType_Option.GetAll())
            {
                BladeType.Add(item);
            }
            cmb_BladeType.DataSource = BladeType;
        }


    }
}
