using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_LouverGallerySetPropertyUC : UserControl, IPP_LouverGallerySetPropertyUC
    {
        public PP_LouverGallerySetPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler LouverGallerySetPropertyUCLoadEventRaised;
        public event EventHandler btnAddLouverClickEventRaised;
        public event EventHandler cmbBladeHeightSelectedValueChangedEventRaised;
        public event EventHandler cmbHandleTypeSelectedValueChangedEventRaised;
        public event EventHandler cmbHandleLocationSelectedValueChangedEventRaised;
        public event EventHandler cmbGalleryColorSelectedValueChangedEventRaised;
        public event EventHandler chkMotorizedCheckedChangedEventRaised;

        public ComboBox GetHandleLoc()
        {
            return cmb_HandleLocation;
        }

        public ComboBox GetHandleType()
        {
            return cmb_HandleType;
        }

        private void PP_LouverGallerySetPropertyUC_Load(object sender, EventArgs e)
        {
            List<BladeHeight_Option> BladeHeight = new List<BladeHeight_Option>();
            foreach (BladeHeight_Option item in BladeHeight_Option.GetAll())
            {
                BladeHeight.Add(item);
            }
            cmb_BladeHeight.DataSource = BladeHeight;

            List<LouverHandleType_Option> GalleryHandle = new List<LouverHandleType_Option>();
            foreach (LouverHandleType_Option item in LouverHandleType_Option.GetAll())
            {
                GalleryHandle.Add(item);
            }
            cmb_HandleType.DataSource = GalleryHandle;

            List<LouverHandleLoc_Option> GalleryHandleLoc = new List<LouverHandleLoc_Option>();
            foreach (LouverHandleLoc_Option item in LouverHandleLoc_Option.GetAll())
            {
                GalleryHandleLoc.Add(item);
            }
            cmb_HandleLocation.DataSource = GalleryHandleLoc;

            List<LouverColor_Option> GalleryColor = new List<LouverColor_Option>();
            foreach (LouverColor_Option item in LouverColor_Option.GetAll())
            {
                GalleryColor.Add(item);
            }
            cmb_GalleryColor.DataSource = GalleryColor;


            EventHelpers.RaiseEvent(sender, LouverGallerySetPropertyUCLoadEventRaised, e);
        }

        private void btn_addLouver_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnAddLouverClickEventRaised, e);
        }
        private void cmb_BladeHeight_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbBladeHeightSelectedValueChangedEventRaised, e);
        }

        private void cmb_HandleType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbHandleTypeSelectedValueChangedEventRaised, e);
        }

        private void cmb_HandleLocation_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbHandleLocationSelectedValueChangedEventRaised, e);
        }

        private void cmb_GalleryColor_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbGalleryColorSelectedValueChangedEventRaised, e);
        }

        public Panel GetPanelBody()
        {
            return pnl_body;
        }
        private void chk_Motorized_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkMotorizedCheckedChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_LouverGallerySetVisibility"]);
            //cmb_BladeHeight.DataBindings.Add(ModelBinding["Panel_LouverBladeHeight"]);
            nud_NoOfBladePerSet.DataBindings.Add(ModelBinding["Panel_LouverNumberBladesPerSet"]);
            //cmb_HandleType.DataBindings.Add(ModelBinding["Panel_LouverHandleType"]);
            //cmb_HandleLocation.DataBindings.Add(ModelBinding["Panel_LouverHandleLocation"]);
            //cmb_GalleryColor.DataBindings.Add(ModelBinding["Panel_LouverGalleryColor"]);
        }


    }
}
