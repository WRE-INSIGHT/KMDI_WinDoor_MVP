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
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views
{
    public partial class SetMultipleGlassThicknessView : Form, ISetMultipleGlassThicknessView
    {

        
        public event EventHandler cmbSelectGlassTypeEventRaised;
        public event EventHandler setMultipleGlassThicknessLoadEventRaised;
        public event EventHandler mouseClickEventRaised;
        public event DataGridViewRowPostPaintEventHandler dgvSetMultipleGlassRowPostPaineEventRaised;
        private string _glasstype;

        List<string> Panel_id = new List<string>();

        public List<string> Panel_ID
        {
            get { return Panel_id; }
            set { Panel_id = value; }
        }

        public string Glass_Type
        {
            get { return _glasstype; }
            set { _glasstype = value; }
        }

        public void CloseThisDialog()
        {
            this.Close();
        }
      
        public void ShowMultipleThckView()
        {
            this.Show();
        }

        public SetMultipleGlassThicknessView()
        {
            InitializeComponent();
        }

        public DataGridView Get_DgvGlassList()
        {
            return setGlssThckNssDGV;
        }

        private void SetMultipleGlassThicknessView_Load(object sender, EventArgs e)
        {

            List<GlassType> gType = new List<GlassType>();
            foreach (GlassType item in GlassType.GetAll())
            {
                gType.Add(item);
            }
            cmb_GlassType.DataSource = gType;
            EventHelpers.RaiseEvent(sender, setMultipleGlassThicknessLoadEventRaised, e);
        }

       
    
        private void setGlssThckNssDGV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        { 
            EventHelpers.RaiseDatagridviewRowpostpaintEvent(sender, dgvSetMultipleGlassRowPostPaineEventRaised, e);
        }
    
        private void setGlssThckNssDGV_MouseDown(object sender, MouseEventArgs e)
        {
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Update", mouseClickEventRaised));
                    m.Show(setGlssThckNssDGV, new Point(e.X, e.Y));
                    _glasstype = cmb_GlassType.SelectedItem.ToString();                                                    
                }
        }

      



    }
}
