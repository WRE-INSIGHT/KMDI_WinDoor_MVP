using System.Data;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface ICreateNewGlassSpacerPresenter
    {
        void ShowCreateNewGlassSpacerView();
        ICreateNewGlassSpacerPresenter GetNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter, DataTable spacerDT);
        DataTable PopulateDgvGlassSpacer();
        DataRow CreateNewRowGlassSpacerDT();

    }
}
