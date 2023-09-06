using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public interface IFP_CladdingQtyPropertyUCPresenter : IPresenterCommon
    {
        IFP_CladdingQtyPropertyUC GetCladdingQtyPropertyUC();
        IFP_CladdingQtyPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                          IMainPresenter mainpresenter,
                                                          IFrameModel frameModel);
    }
}