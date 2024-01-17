using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IGeorgianBarCustomizeDesignPresenter
    {
        IGeorgianBarCustomizeDesignView GetGeorgianBarCustomizeDesignView();
        IGeorgianBarCustomizeDesignPresenter GetNewInstance(IMainPresenter mainPresenter,
                                                                   IUnityContainer unityC,
                                                                   IPanelModel panelModel,
                                                                   IWindoorModel windoorModel);
    }
}