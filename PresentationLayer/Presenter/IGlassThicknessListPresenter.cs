using ModelLayer.Model.Quotation.Panel;
using System.Data;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IGlassThicknessListPresenter
    {
        IGlassThicknessListPresenter GetNewInstance(IUnityContainer unityC,
                                                    DataTable glassThicknessDT,
                                                    IPanelModel panelModel,
                                                    IMainPresenter mainPresenter);
        void ShowGlassThicknessListView();
    }
}