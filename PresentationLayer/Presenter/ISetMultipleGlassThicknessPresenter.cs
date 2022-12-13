using System.Collections.Generic;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using Unity;
using ModelLayer.Model.Quotation.Frame;
using System.Data;

namespace PresentationLayer.Presenter
{
    public interface ISetMultipleGlassThicknessPresenter
    {

        ISetMultipleGlassThicknessPresenter GetNewInstance(IUnityContainer unityC,
                                                            IWindoorModel windoorModel,
                                                            IMainPresenter mainpresenter                                                            
                                                            );
        ISetMultipleGlassThicknessView Get_MltpleGlssThcknView();
        DataTable showGlassSummary();
        void GetCurrentGlassthickness();
    }
}