using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter
{
    public class GlassThicknessListPresenter : IGlassThicknessListPresenter
    {
        IGlassThicknessListView _glassThicknessListView;

        private IPanelModel _panelModel;
        private DataTable _glassThicknessDT;

        CommonFunctions commonfunc = new CommonFunctions();

        public GlassThicknessListPresenter(IGlassThicknessListView glassThicknessListView)
        {
            _glassThicknessListView = glassThicknessListView;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _glassThicknessListView.GlassThicknessListViewLoadEventRaised += _glassThicknessListView_GlassThicknessListViewLoadEventRaised;
            _glassThicknessListView.DgvGlassThicknessListRowpostpaintEventRaised += _glassThicknessListView_DgvGlassThicknessListRowpostpaintEventRaised;
            _glassThicknessListView.DgvGlassThicknessListCellDoubleClickEventRaised += _glassThicknessListView_DgvGlassThicknessListCellDoubleClickEventRaised;
        }

        private void _glassThicknessListView_DgvGlassThicknessListCellDoubleClickEventRaised(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells["Description"];
                if (cell.Value.ToString() != "Insulated" && cell.Value.ToString() != "Laminated")
                {
                    _panelModel.Panel_GlassThickness = Convert.ToSingle(dgv.Rows[e.RowIndex].Cells["TotalThickness"].Value);
                    _panelModel.Panel_GlassThicknessDesc = dgv.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                    _glassThicknessListView.CloseThisDialog();
                }
                else
                {
                    MessageBox.Show("Invalid selection", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void _glassThicknessListView_DgvGlassThicknessListRowpostpaintEventRaised(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            commonfunc.rowpostpaint(sender, e);
        }

        private void _glassThicknessListView_GlassThicknessListViewLoadEventRaised(object sender, EventArgs e)
        {
            _glassThicknessListView.Get_DgvGlassThicknessList().DataSource = ConstructFiltered_glassThicknessDT();
            _glassThicknessListView.Get_DgvGlassThicknessList().Columns["TotalThickness"].Visible = false;
            _glassThicknessListView.Get_DgvGlassThicknessList().Columns["Description"].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        }

        public void ShowGlassThicknessListView()
        {
            _glassThicknessListView.ShowThisDialog();
        }

        private DataTable ConstructFiltered_glassThicknessDT()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TotalThickness", Type.GetType("System.Decimal"));
            dt.Columns.Add("Description", Type.GetType("System.String"));

            if (_panelModel.Panel_GlassType == GlassType._Single)
            {
                foreach (DataRow row in _glassThicknessDT.Rows)
                {
                    if ((bool)row["Single"] == true)
                    {
                        dt.Rows.Add(row["TotalThickness"], row["Description"]);
                    }
                }
            }
            else if (_panelModel.Panel_GlassType != GlassType._Single)
            {
                DataRow insulated_row = dt.NewRow();
                insulated_row["TotalThickness"] = 0.0f;
                insulated_row["Description"] = "Insulated";

                DataRow laminated_row = dt.NewRow();
                laminated_row["TotalThickness"] = 0.0f;
                laminated_row["Description"] = "Laminated";

                dt.Rows.Add(insulated_row);
                dt.Rows.Add(laminated_row);
                foreach (DataRow row in _glassThicknessDT.Rows)
                {
                    int ndx = 0;
                    string col_name = "";
                    DataRow newrow = dt.NewRow();
                    newrow["TotalThickness"] = row["TotalThickness"];
                    newrow["Description"] = row["Description"];
                    if (_panelModel.Panel_GlassType == GlassType._Double)
                    {
                        col_name = "Double";
                    }
                    else if (_panelModel.Panel_GlassType == GlassType._Triple)
                    {
                        col_name = "Triple";
                    }

                    if ((bool)row[col_name] == true)
                    {
                        if ((bool)row["Insulated"] == true)
                        {
                            ndx = dt.Rows.IndexOf(insulated_row) + 1;
                        }
                        else if ((bool)row["Laminated"] == true)
                        {
                            ndx = dt.Rows.IndexOf(laminated_row) + 1;
                        }
                        dt.Rows.InsertAt(newrow, ndx);
                    }
                }
            }

            return dt;
        }

        public IGlassThicknessListPresenter GetNewInstance(IUnityContainer unityC,
                                                           DataTable glassThicknessDT,
                                                           IPanelModel panelModel)
        {
            unityC
                .RegisterType<IGlassThicknessListView, GlassThicknessListView>()
                .RegisterType<IGlassThicknessListPresenter, GlassThicknessListPresenter>();
            GlassThicknessListPresenter presenter = unityC.Resolve<GlassThicknessListPresenter>();
            presenter._glassThicknessDT = glassThicknessDT;
            presenter._panelModel = panelModel;

            return presenter;
        }
    }
}
