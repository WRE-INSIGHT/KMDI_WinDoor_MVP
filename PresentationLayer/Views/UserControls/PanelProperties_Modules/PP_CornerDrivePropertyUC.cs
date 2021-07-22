using System;
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
    public partial class PP_CornerDrivePropertyUC : UserControl, IPP_CornerDrivePropertyUC
    {
        public PP_CornerDrivePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPCornerDriveCLoadEventRaised;
        public event EventHandler cmbCornerDriveSelectedValueChangedEventRaised;

        private void PP_CornerDrivePropertyUC_Load(object sender, EventArgs e)
        {
            List<CornerDrive_ArticleNo> cdriveArtNo = new List<CornerDrive_ArticleNo>();
            foreach (CornerDrive_ArticleNo item in CornerDrive_ArticleNo.GetAll())
            {
                cdriveArtNo.Add(item);
            }
            cmb_CornerDrive.DataSource = cdriveArtNo;

            EventHelpers.RaiseEvent(this, PPCornerDriveCLoadEventRaised, e);
        }

        private void cmb_CornerDrive_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbCornerDriveSelectedValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_CornerDrive.DataBindings.Add(ModelBinding["Panel_CornerDriveArtNo"]);
        }
    }
}
