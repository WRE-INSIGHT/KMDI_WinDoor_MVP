using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.CommonMethods;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter
{
    public class GlassThicknessListPresenter : IGlassThicknessListPresenter
    {
        IGlassThicknessListView _glassThicknessListView;

        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;
        private ISetMultipleGlassThicknessPresenter _setMultipleGlassThicknessPresenter;
        private IWindoorModel _windoorModel;
        private GlassType _glassType;
        private DataTable _glassThicknessDT;
        private List<string> _panelIdList;
        private bool _setMultipleThicknessUpdate;
        private IUnityContainer unityC;
        CommonFunctions commonfunc = new CommonFunctions();


        public GlassType Panel_GlassType
        {
            get
            {
                return _glassType;
            }
            set
            {
                _glassType = value;
            }
        }

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

                    #region multiplethicknessupdate

                    if (_setMultipleThicknessUpdate == true)
                    {
                        _panelIdList = _setMultipleGlassThicknessPresenter.Get_MltpleGlssThcknView().Panel_ID;

                        foreach (IFrameModel fr in _windoorModel.lst_frame)
                        {
                            if (fr.Lst_MultiPanel.Count >= 1 && fr.Lst_Panel.Count == 0)
                            {

                                #region multipanel
                                foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                                {

                                    foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                                    {
                                        for (int i = 0; i < _panelIdList.Count; i++)
                                        {
                                            var str_PanelId = _panelIdList[i].Substring(6);
                                            var int_PanelId = Convert.ToInt32(str_PanelId);

                                            if (pnl.PanelGlass_ID == int_PanelId)
                                            {
                                                string prev_thickness = pnl.Panel_GlassThicknessDesc;

                                                pnl.Panel_GlassType = _glassType;
                                                pnl.Panel_GlassThickness = Convert.ToSingle(dgv.Rows[e.RowIndex].Cells["TotalThickness"].Value);
                                                pnl.Panel_GlassThicknessDesc = dgv.Rows[e.RowIndex].Cells["Description"].Value.ToString();



                                                if (pnl.Panel_GlassThicknessDesc.Contains("Georgian Bar"))
                                                {
                                                    if (prev_thickness == null || !prev_thickness.Contains("Georgian Bar"))
                                                    {
                                                        pnl.Panel_GeorgianBarOptionVisibility = true;
                                                        pnl.AdjustPropertyPanelHeight("addGeorgianBar");
                                                        pnl.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addGeorgianBar");
                                                        if (pnl.Panel_ParentMultiPanelModel != null)
                                                        {
                                                            pnl.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addGeorgianBar");
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (prev_thickness != null && prev_thickness.Contains("Georgian Bar"))
                                                    {

                                                        pnl.Panel_GeorgianBarOptionVisibility = false;
                                                        pnl.AdjustPropertyPanelHeight("minusGeorgianBar");
                                                        pnl.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusGeorgianBar");
                                                        if (pnl.Panel_ParentMultiPanelModel != null)
                                                        {
                                                            pnl.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusGeorgianBar");
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                            else if (fr.Lst_Panel.Count == 1 && fr.Lst_MultiPanel.Count == 0)
                            {
                                #region singlePanel 
                                foreach (IPanelModel SinglePanel in fr.Lst_Panel)
                                {
                                    for (int i = 0; i < _panelIdList.Count; i++)
                                    {
                                        var str_PanelId = _panelIdList[i].Substring(6);
                                        var int_PanelId = Convert.ToInt32(str_PanelId);

                                        if (SinglePanel.PanelGlass_ID == int_PanelId)
                                        {
                                            string prev_thickness = SinglePanel.Panel_GlassThicknessDesc;

                                            SinglePanel.Panel_GlassType = _glassType;
                                            SinglePanel.Panel_GlassThickness = Convert.ToSingle(dgv.Rows[e.RowIndex].Cells["TotalThickness"].Value);
                                            SinglePanel.Panel_GlassThicknessDesc = dgv.Rows[e.RowIndex].Cells["Description"].Value.ToString();

                                            if (SinglePanel.Panel_GlassThicknessDesc.Contains("Georgian Bar"))
                                            {
                                                if (prev_thickness == null || !prev_thickness.Contains("Georgian Bar"))
                                                {
                                                    SinglePanel.Panel_GeorgianBarOptionVisibility = true;
                                                    SinglePanel.AdjustPropertyPanelHeight("addGeorgianBar");
                                                    SinglePanel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addGeorgianBar");
                                                    if (SinglePanel.Panel_ParentMultiPanelModel != null)
                                                    {
                                                        SinglePanel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addGeorgianBar");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (prev_thickness != null && prev_thickness.Contains("Georgian Bar"))
                                                {

                                                    SinglePanel.Panel_GeorgianBarOptionVisibility = false;
                                                    SinglePanel.AdjustPropertyPanelHeight("minusGeorgianBar");
                                                    SinglePanel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusGeorgianBar");
                                                    if (SinglePanel.Panel_ParentMultiPanelModel != null)
                                                    {
                                                        SinglePanel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusGeorgianBar");
                                                    }
                                                }
                                            }

                                        }
                                    }
                                }
                                #endregion
                            }
                        }

                        _panelIdList.Clear();
                        _glassThicknessListView.CloseThisDialog();
                        _setMultipleGlassThicknessPresenter.GetCurrentGlassthickness();
                        _mainPresenter.GetCurrentPrice();
                        _mainPresenter.itemDescription();
                    }
                    else
                    {
                        string prev_thickness = _panelModel.Panel_GlassThicknessDesc;

                        _panelModel.Panel_GlassThickness = Convert.ToSingle(dgv.Rows[e.RowIndex].Cells["TotalThickness"].Value);
                        _panelModel.Panel_GlassThicknessDesc = dgv.Rows[e.RowIndex].Cells["Description"].Value.ToString();

                        if (_panelModel.Panel_GlassThicknessDesc.Contains("Georgian Bar"))
                        {
                            if (prev_thickness == null || !prev_thickness.Contains("Georgian Bar"))
                            {
                                _panelModel.Panel_GeorgianBarOptionVisibility = true;
                                _panelModel.AdjustPropertyPanelHeight("addGeorgianBar");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addGeorgianBar");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addGeorgianBar");
                                }
                            }
                        }
                        else
                        {
                            if (prev_thickness != null && prev_thickness.Contains("Georgian Bar"))
                            {
                                _panelModel.Panel_GeorgianBarOptionVisibility = false;
                                _panelModel.AdjustPropertyPanelHeight("minusGeorgianBar");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusGeorgianBar");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusGeorgianBar");
                                }
                            }
                        }
                        _glassThicknessListView.CloseThisDialog();
                        _mainPresenter.GetCurrentPrice();
                        _mainPresenter.itemDescription();
                    }
                    #endregion

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
            if (Panel_GlassType != null)
            {
                _glassThicknessListView.Get_DgvGlassThicknessList().DataSource = ConstructFiltered_glassThicknessDT_MultiSelect();
                _setMultipleThicknessUpdate = true;


            }
            else
            {
                _glassThicknessListView.Get_DgvGlassThicknessList().DataSource = ConstructFiltered_glassThicknessDT();
            }

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

        private DataTable ConstructFiltered_glassThicknessDT_MultiSelect()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TotalThickness", Type.GetType("System.Decimal"));
            dt.Columns.Add("Description", Type.GetType("System.String"));

            if (Panel_GlassType == GlassType._Single)
            {
                foreach (DataRow row in _glassThicknessDT.Rows)
                {
                    if ((bool)row["Single"] == true)
                    {
                        dt.Rows.Add(row["TotalThickness"], row["Description"]);
                    }
                }
            }
            else if (Panel_GlassType != GlassType._Single)
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
                    if (Panel_GlassType == GlassType._Double)
                    {
                        col_name = "Double";
                    }
                    else if (Panel_GlassType == GlassType._Triple)
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
                                                           IPanelModel panelModel,
                                                           IMainPresenter mainPresenter
                                                            )
        {
            unityC
                .RegisterType<IGlassThicknessListView, GlassThicknessListView>()
                .RegisterType<IGlassThicknessListPresenter, GlassThicknessListPresenter>();
            GlassThicknessListPresenter presenter = unityC.Resolve<GlassThicknessListPresenter>();
            presenter._glassThicknessDT = glassThicknessDT;
            presenter._panelModel = panelModel;
            presenter._mainPresenter = mainPresenter;



            return presenter;
        }

        public IGlassThicknessListPresenter GetNewInstance_MultipleGlassThickness(IUnityContainer unityC, DataTable glassThicknessDT, IPanelModel panelModel, IMainPresenter mainPresenter, ISetMultipleGlassThicknessPresenter setMultipleThicknessPresenter, IWindoorModel windoorModel)
        {

            unityC
                .RegisterType<IGlassThicknessListView, GlassThicknessListView>()
                .RegisterType<IGlassThicknessListPresenter, GlassThicknessListPresenter>();
            GlassThicknessListPresenter presenter_MultipleThickness = unityC.Resolve<GlassThicknessListPresenter>();
            presenter_MultipleThickness._glassThicknessDT = glassThicknessDT;
            presenter_MultipleThickness._panelModel = panelModel;
            presenter_MultipleThickness._mainPresenter = mainPresenter;
            presenter_MultipleThickness._setMultipleGlassThicknessPresenter = setMultipleThicknessPresenter;
            presenter_MultipleThickness._windoorModel = windoorModel;

            return presenter_MultipleThickness;
        }
    }
}


