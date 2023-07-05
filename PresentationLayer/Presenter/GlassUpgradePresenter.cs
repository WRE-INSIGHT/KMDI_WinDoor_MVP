using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class GlassUpgradePresenter
    {
        private IGlassUpgradeView _glassUpgradeView;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IWindoorModel _windoorModel;

        private DataGridView _dgv_GlassUpgrade;
        private DataTable _glassUpgradeDT = new DataTable();
        private NumericUpDown _glassUpgradeDiscount;
                
        public GlassUpgradePresenter(IGlassUpgradeView glassUpgradeView)
        {
            _glassUpgradeView = glassUpgradeView;

            _dgv_GlassUpgrade = _glassUpgradeView.GlassUpgradeDGView();
            _glassUpgradeDiscount = _glassUpgradeView.DiscountNum;
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _glassUpgradeView.GlassUpgradeView_LoadEventRaised += new EventHandler(OnGlassUpgradeViewLoadEventRaised);
        }

        private DataColumn CreateColumn(string columnName, string caption, string type)
        {
            DataColumn col = new DataColumn();
            col.DataType = Type.GetType(type);
            col.ColumnName = columnName;
            col.Caption = caption;

            return col;
        }

        private DataTable PopulateDgvGlassUpgrade()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Item No.", Type.GetType("System.string"));
            dt.Columns.Add("Window/Door I.D.", Type.GetType("System.string"));
            dt.Columns.Add("Quantity", Type.GetType("System.string"));
            dt.Columns.Add("Width", Type.GetType("System.string"));
            dt.Columns.Add("Height", Type.GetType("System.string"));
            dt.Columns.Add("Original Glass Used", Type.GetType("System.string"));
            dt.Columns.Add("GlassPrice", Type.GetType("System.string"));
            dt.Columns.Add("Upgrade To", Type.GetType("System.string"));
            dt.Columns.Add("GlassPrice", Type.GetType("System.string"));
            dt.Columns.Add("Upgrade Value", Type.GetType("System.string"));
            dt.Columns.Add("Amount Per Unit", Type.GetType("System.string"));
            dt.Columns.Add("Total Net Prices", Type.GetType("System.string"));

            foreach(DataRow glassupgradeDTRow in _glassUpgradeDT.Rows)
            {
                dt.Rows.Add(glassupgradeDTRow["Item No"],
                            glassupgradeDTRow["Window/Door I.D."],
                            glassupgradeDTRow["Quantity"],
                            glassupgradeDTRow["Width"],
                            glassupgradeDTRow["Height"],
                            glassupgradeDTRow["Original Glass Used"],
                            glassupgradeDTRow["GlassPrice"],
                            glassupgradeDTRow["Upgrade To"],
                            glassupgradeDTRow["GlassPrice"],
                            glassupgradeDTRow["Upgrade Value"],
                            glassupgradeDTRow["Amount Per Unit"],
                            glassupgradeDTRow["Total Net Prices"]);
            }

            return dt;
        }

        private void OnGlassUpgradeViewLoadEventRaised(object sender, EventArgs e)
        {
            _glassUpgradeDT.Columns.Add(CreateColumn("Item No.", "Item No", "System.string"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Window/Door I.D.", "Window/Door I.D.", "System.string"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Quantiy", "Quantity", "System.string"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Width", "Width", "System.string"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Height", "Height", "System.string"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Original Glass Used", "Original Glass Used", "System.string"));
            _glassUpgradeDT.Columns.Add(CreateColumn("GlassPrice", "GlassPrice", "System.string"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Uprade To","Upgrade To","System.string"));
            _glassUpgradeDT.Columns.Add(CreateColumn("GlassPrice","GlassPrice", "System.string"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Upgrade Value", "Upgrade Value", "System.string"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Amount Per Unit", "Amount Per Unit", "System.string"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Total Net Prices", "Total Net Prices", "System.string"));

            _glassUpgradeView.GlassUpgradeDGView().DataSource = PopulateDgvGlassUpgrade();

             

        }





    }
}
