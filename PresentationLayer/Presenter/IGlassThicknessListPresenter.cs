using System.Data;
using PresentationLayer.Presenter.UserControls;
using Unity;
using ModelLayer.Model.Quotation.Panel;

namespace PresentationLayer.Presenter
{
    public interface IGlassThicknessListPresenter
    {
        IGlassThicknessListPresenter GetNewInstance(IUnityContainer unityC, 
                                                    DataTable glassThicknessDT,
                                                    IPanelModel panelModel);
        void ShowGlassThicknessListView();
    }
}