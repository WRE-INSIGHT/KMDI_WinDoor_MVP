using CommonComponents;
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
    public partial class AssignProjectsView : Form, IAssignProjectsView
    {
        public AssignProjectsView()
        {
            InitializeComponent();
        }
        public string SearchProjStr
        {
            get
            {
                return txt_SearchProj.Text.Trim();
            }
        }

        public DataGridView DGV_Projects
        {
            get
            {
                return dgv_Projects;
            }
        }

        public void ShowThis()
        {
            this.ShowDialog();
        }

        public event EventHandler AssignProjectsViewLoadEventRaised;

        CommonMethods.CommonFunctions common_func = new CommonMethods.CommonFunctions();

        private void AssignProjectsView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, AssignProjectsViewLoadEventRaised, e);
        }

        private void dgv_Projects_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            common_func.rowpostpaint(sender, e);
        }
    }
}