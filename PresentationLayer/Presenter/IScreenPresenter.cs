using CommonComponents;
using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module;
using PresentationLayer.Views;
using System.Data;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IScreenPresenter : IPresenterCommon
    {
        IScreenView GetScreenView();
        IScreenPresenter CreateNewInstance(IUnityContainer unityC,
                                           IMainPresenter mainPresenter,
                                           IScreenModel screenModel);
       



        DataTable PopulateDgvScreen();
        DataRow CreateNewRow_ScreenDT();
        void GetCurrentAmount();
    }
}