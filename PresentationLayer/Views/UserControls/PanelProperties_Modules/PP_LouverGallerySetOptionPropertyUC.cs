using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_LouverGallerySetOptionPropertyUC : UserControl, IPP_LouverGallerySetOptionPropertyUC
    {
        public PP_LouverGallerySetOptionPropertyUC()
        {
            InitializeComponent();
        }
        public event EventHandler LouverGallerySetOptionPropertyUCLoadEventRaised;
        public event EventHandler btnDeleteGallerySetClickEventRaised;

        public TextBox GetCmbLouverGalleryArtNo()
        {
            return tbox_GallerySetArtNo;
        }

        public string lblGallerySetArtNo
        {
            get
            {
                return lbl_GallerySetArtNo.Text;
            }
            set
            {
                lbl_GallerySetArtNo.Text = value;
            }
        }

        private void PP_LouverGallerySetOptionPropertyUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, LouverGallerySetOptionPropertyUCLoadEventRaised, e);
        }

        private void btn_DeleteGallerySet_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnDeleteGallerySetClickEventRaised, e);
        }
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_LouverGallerySetOptionVisibility"]);
            // tbox_GallerySetArtNo.DataBindings.Add(ModelBinding["Panel_LouverGallerySetOptionArtNo"]);
        }


    }
}
