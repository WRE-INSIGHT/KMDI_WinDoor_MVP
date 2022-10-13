using PresentationLayer.Views;
using System.Data;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IScreenPresenter
    {
        IScreenView GetScreenView();
        IScreenPresenter CreateNewInstance(IUnityContainer unityC,
                                           IMainPresenter mainPresenter);
        //  DataTable screenDT);

        DataTable PopulateDgvScreen();
        DataRow CreateNewRow_ScreenDT();

    }
}