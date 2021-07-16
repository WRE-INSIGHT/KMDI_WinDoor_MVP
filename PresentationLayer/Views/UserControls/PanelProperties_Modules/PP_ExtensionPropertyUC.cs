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
    public partial class PP_ExtensionPropertyUC : UserControl, IPP_ExtensionPropertyUC
    {
        public PP_ExtensionPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPExtensionUCLoadEventRaised;

        private void PP_ExtensionUC_Load(object sender, EventArgs e)
        {
            num_TopExtQty.Maximum = decimal.MaxValue;
            num_TopExtQty2.Maximum = decimal.MaxValue;

            List<Extension_ArticleNo> extArtNo = new List<Extension_ArticleNo>();
            foreach (Extension_ArticleNo item in Extension_ArticleNo.GetAll())
            {
                extArtNo.Add(item);
            }
            cmb_TopExt.DataSource = extArtNo;
            cmb_TopExt2.DataSource = extArtNo;

            EventHelpers.RaiseEvent(this, PPExtensionUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            num_TopExtQty.DataBindings.Add(ModelBinding["Panel_ExtTopQty"]);
        }

        private void chk_ToAdd_TopExt2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked == true)
            {
                chk.Text = "-";
            }
            else if (chk.Checked == true)
            {
                chk.Text = "+";
            }

            pnl_TopExt2Option.Visible = chk.Checked;
        }
    }
}
