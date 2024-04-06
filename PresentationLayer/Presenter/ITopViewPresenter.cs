using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using Unity;
using CommonComponents;

namespace PresentationLayer.Presenter
{
    public interface ITopViewPresenter : IPresenterCommon
    {
        int TotalPoints { get; set; }
        void Get_TopViewPanelViewer();
        ITopView GetTopViewDesign();
        ITopViewPresenter GetNewInstance(IMainPresenter mainPresenter,
                                            IUnityContainer unityC,
                                            IPanelModel panelModel,
                                            IFrameModel frameModel,
                                            IWindoorModel windoorModel,
                                            IQuotationModel quotationModel);
    }
}
