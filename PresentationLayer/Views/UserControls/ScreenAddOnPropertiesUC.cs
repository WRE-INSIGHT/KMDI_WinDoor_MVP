using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class ScreenAddOnPropertiesUC : UserControl, IScreenAddOnPropertiesUC
    {
        public ScreenAddOnPropertiesUC()
        {
            InitializeComponent();
        }
        public event EventHandler ScreenAddOnPropertiesUCLoadEventRaised;
        public event EventHandler btnAddMatsClickEventRaised;

        public Panel GetPanelAddOns()
        {
            return pnl_addOns;
        }

        private void ScreenAddOnPropertiesUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ScreenAddOnPropertiesUCLoadEventRaised, e);
        }

        private void btn_addMats_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnAddMatsClickEventRaised, e);
        }
    }
}
