using System.Data;
using EnumerationTypeLayer;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface ICreateNewGlassPresenter
    {
        DataRow CreateNewGlass_Datarow();
        ICreateNewGlassPresenter GetNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter, EnumerationTypes.CreateNewGlass_ShowPurpose purpose, DataTable glassThicknessDT);
        void ShowCreateNewGlassView();
    }
}