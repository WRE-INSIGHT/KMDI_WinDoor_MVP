using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PresentationLayer.Presenter
{
    public class GlassThicknessListPresenter : IGlassThicknessListPresenter
    {
        IGlassThicknessListView _glassThicknessListView;

        private IPanelModel _panelModel;
        private IPanelPropertiesUCPresenter _panelPropertiesUCP;
        private DataTable _glassThicknessDT;

        public GlassThicknessListPresenter(IGlassThicknessListView glassThicknessListView)
        {
            _glassThicknessListView = glassThicknessListView;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _glassThicknessListView.GlassThicknessListViewLoadEventRaised += _glassThicknessListView_GlassThicknessListViewLoadEventRaised;
        }

        private void _glassThicknessListView_GlassThicknessListViewLoadEventRaised(object sender, EventArgs e)
        {
            _glassThicknessListView.Get_DgvGlassThicknessList().DataSource = ConstructFiltered_glassThicknessDT();
        }

        public void ShowGlassThicknessListView()
        {
            _glassThicknessListView.ShowThisDialog();
        }

        private DataTable ConstructFiltered_glassThicknessDT()
        {
            DataTable dt = _glassThicknessDT;

            return dt;
        }

        public IGlassThicknessListPresenter GetNewInstance(IUnityContainer unityC,
                                                           IPanelPropertiesUCPresenter panelPropertiesUCP,
                                                           DataTable glassThicknessDT,
                                                           IPanelModel panelModel)
        {
            unityC
                .RegisterType<IGlassThicknessListView, GlassThicknessListView>()
                .RegisterType<IGlassThicknessListPresenter, GlassThicknessListPresenter>();
            GlassThicknessListPresenter presenter = unityC.Resolve<GlassThicknessListPresenter>();
            presenter._panelPropertiesUCP = panelPropertiesUCP;
            presenter._glassThicknessDT = glassThicknessDT;
            presenter._panelModel = panelModel;

            return presenter;
        }
    }
}
