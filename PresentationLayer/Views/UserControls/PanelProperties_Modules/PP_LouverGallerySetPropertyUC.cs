using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_LouverGallerySetPropertyUC : UserControl
    {
        public PP_LouverGallerySetPropertyUC()
        {
            InitializeComponent();
        }

        private void PP_LouverGallerySetPropertyUC_Load(object sender, EventArgs e)
        {
            List<BladeHeight_Option> BladeHeight = new List<BladeHeight_Option>();
            foreach (BladeHeight_Option item in BladeHeight_Option.GetAll())
            {
                BladeHeight.Add(item);
            }
            cmb_BladeHeight.DataSource = BladeHeight;

            List<GalleryHandle_Option> GalleryHandle = new List<GalleryHandle_Option>();
            foreach (GalleryHandle_Option item in GalleryHandle_Option.GetAll())
            {
                GalleryHandle.Add(item);
            }
            cmb_HandleType.DataSource = GalleryHandle;

            List<GalleryHandleLoc_Option> GalleryHandleLoc = new List<GalleryHandleLoc_Option>();
            foreach (GalleryHandleLoc_Option item in GalleryHandleLoc_Option.GetAll())
            {
                GalleryHandleLoc.Add(item);
            }
            cmb_HandleLocation.DataSource = GalleryHandleLoc;
        }
    }
}
