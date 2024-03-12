using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface ITopViewPresenter
    {
        ITopView GetTopViewDesign();
        ITopViewPresenter GetNewInstance(IMainPresenter mainPresenter,
                                            IUnityContainer unityC,
                                            IPanelModel panelModel,
                                            IFrameModel frameModel,
                                            IWindoorModel windoorModel);
    }
}
