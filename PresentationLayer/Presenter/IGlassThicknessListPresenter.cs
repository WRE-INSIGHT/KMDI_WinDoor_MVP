using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using System.Data;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter
{
    public interface IGlassThicknessListPresenter
    {
        IGlassThicknessListPresenter GetNewInstance(IUnityContainer unityC,
                                                    DataTable glassThicknessDT,
                                                    IPanelModel panelModel,
                                                    IMainPresenter mainPresenter
                                                    );
        IGlassThicknessListPresenter GetNewInstance_MultipleGlassThickness(IUnityContainer unityC,
                                                                           DataTable glassThicknessDT,
                                                                           IPanelModel panelModel,
                                                                           IMainPresenter mainPresenter,
                                                                           ISetMultipleGlassThicknessPresenter setMultipleThicknessPresenter,
                                                                           IWindoorModel windoorModel
                                                                            );

        GlassType Panel_GlassType { get; set; }

        void ShowGlassThicknessListView();
    }
}