using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.CommonMethods;
using PresentationLayer.Views;
using ServiceLayer.Services.PanelServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter
{
    public class SetMultipleGlassThicknessPresenter : ISetMultipleGlassThicknessPresenter
    {
        ISetMultipleGlassThicknessView _setMultipleGlassThicknessView;

        bool _initialLoad = true;

        CommonFunctions commonfunc = new CommonFunctions();
        private DataGridView _dgvGlassSummary;

        private List<string> _panelIdList;
        private IWindoorModel _windoorModel;
        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IGlassThicknessListPresenter _glassThicknessPresenter;
        private IGlassThicknessListPresenter glassThicknessPresenter = null;

        public ISetMultipleGlassThicknessView Get_MltpleGlssThcknView()
        {
            return _setMultipleGlassThicknessView;
        }

        public SetMultipleGlassThicknessPresenter(IUnityContainer unityC, ISetMultipleGlassThicknessView setMultipleGlassThicknessView, IGlassThicknessListPresenter glassThicknessPresenter)
        {
            _unityC = unityC;
            _setMultipleGlassThicknessView = setMultipleGlassThicknessView;
            _glassThicknessPresenter = glassThicknessPresenter;
            _dgvGlassSummary = _setMultipleGlassThicknessView.Get_DgvGlassList();
            _panelIdList = _setMultipleGlassThicknessView.Panel_ID;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {

            _setMultipleGlassThicknessView.setMultipleGlassThicknessLoadEventRaised += new EventHandler(OnsetMultipleGlassThicknessLoadEventRaised);
            _setMultipleGlassThicknessView.mouseClickEventRaised += new EventHandler(OnmouseClickEventRaised);
            _setMultipleGlassThicknessView.dgvSetMultipleGlassRowPostPaineEventRaised += new DataGridViewRowPostPaintEventHandler(OndgvSetMultipleGlassRowPostPaineEventRaised);

        }

        public void GetCurrentGlassthickness()
        {
            _dgvGlassSummary.DataSource = showGlassSummary();
        }


        private void OndgvSetMultipleGlassRowPostPaineEventRaised(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            commonfunc.rowpostpaint(sender, e);
        }

        private void OnmouseClickEventRaised(object sender, EventArgs e)
        {

            foreach (DataGridViewRow r in _dgvGlassSummary.SelectedRows)
            {                
                _panelIdList.Add(r.Cells[0].Value.ToString());
            }

            if(_panelIdList.Count == 0)
            {
                MessageBox.Show("No Panel Selected", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (_panelIdList.Count > 1)
            {
                foreach (IFrameModel fr in _windoorModel.lst_frame)
                {
                    if (fr.Lst_MultiPanel.Count() >= 1 && fr.Lst_Panel.Count() == 0)
                    {

                        foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                        {
                            foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                            {
                                glassThicknessPresenter = _glassThicknessPresenter.GetNewInstance_MultipleGlassThickness(_unityC, _mainPresenter.GlassThicknessDT, pnl, _mainPresenter, this, _windoorModel);
                                foreach (GlassType gt in GlassType.GetAll())
                                {
                                    if (gt.ToString() == _setMultipleGlassThicknessView.Glass_Type)
                                    {
                                        var str = glassThicknessPresenter.Panel_GlassType = gt;
                                    }
                                }
                            }
                        }

                    }else if (fr.Lst_Panel.Count() == 1 && fr.Lst_MultiPanel.Count() == 0)
                    {
                        IPanelModel Singlepnl = fr.Lst_Panel[0];

                        glassThicknessPresenter = _glassThicknessPresenter.GetNewInstance_MultipleGlassThickness(_unityC, _mainPresenter.GlassThicknessDT, Singlepnl, _mainPresenter, this, _windoorModel);
                        foreach (GlassType gt in GlassType.GetAll())
                        {
                            if (gt.ToString() == _setMultipleGlassThicknessView.Glass_Type)
                            {
                                var str = glassThicknessPresenter.Panel_GlassType = gt;
                            }
                        }

                    }

                }
                glassThicknessPresenter.ShowGlassThicknessListView();

            }else
            {
                MessageBox.Show("Select Multiple Panels", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            _panelIdList.Clear();
          
        }

        private void OnsetMultipleGlassThicknessLoadEventRaised(object sender, EventArgs e)
        {
            _dgvGlassSummary.DataSource = showGlassSummary();
            _initialLoad = false;
        }

        public DataTable showGlassSummary()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Panel Name", typeof(string));
            dt.Columns.Add("Panel Type", typeof(string));
            dt.Columns.Add("Glass Description", typeof(string));
            dt.Columns.Add("Panel Dimension", typeof(string));
            dt.Columns.Add("Glass Type", typeof(string));


            foreach (IFrameModel fr in _windoorModel.lst_frame)
            {
                if (fr.Lst_MultiPanel.Count() >= 1 && fr.Lst_Panel.Count() == 0)
                {
                    foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                    {
                        foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Panel Name"] = "Panel" + " " + pnl.PanelGlass_ID;
                            dr["Panel Type"] = pnl.Panel_Type;
                            dr["Glass Description"] = pnl.Panel_GlassThicknessDesc;
                            dr["Panel Dimension"] = pnl.Panel_GlassWidth + " w x " + pnl.Panel_GlassHeight;
                            dr["Glass Type"] = pnl.Panel_GlassType;
                            dt.Rows.Add(dr);
                        }
                    }

                }
                else if (fr.Lst_Panel.Count() == 1 && fr.Lst_MultiPanel.Count() == 0)
                {
                    IPanelModel Singlepnl = fr.Lst_Panel[0];

                    DataRow dr = dt.NewRow();
                    dr["Panel Name"] = "Panel " + " " + Singlepnl.PanelGlass_ID;
                    dr["Panel Type"] = Singlepnl.Panel_Type;
                    dr["Glass Description"] = Singlepnl.Panel_GlassThicknessDesc;
                    dr["Panel Dimension"] = Singlepnl.Panel_GlassWidth + " w x " + Singlepnl.Panel_GlassHeight;
                    dr["Glass Type"] = Singlepnl.Panel_GlassType;
                    dt.Rows.Add(dr);

                }
            }

            return dt;
        }

        public ISetMultipleGlassThicknessPresenter GetNewInstance(IUnityContainer unityC,
                                                                    IWindoorModel windoorModel,
                                                                    IMainPresenter mainpresenter
                                                                    )
        {
            unityC
                .RegisterType<ISetMultipleGlassThicknessPresenter, SetMultipleGlassThicknessPresenter>()
                .RegisterType<ISetMultipleGlassThicknessView, SetMultipleGlassThicknessView>();
            SetMultipleGlassThicknessPresenter setMultipleGlassThickness = unityC.Resolve<SetMultipleGlassThicknessPresenter>();
            setMultipleGlassThickness._unityC = unityC;
            setMultipleGlassThickness._windoorModel = windoorModel;
            setMultipleGlassThickness._mainPresenter = mainpresenter;


            return setMultipleGlassThickness;

        }



    }
}
