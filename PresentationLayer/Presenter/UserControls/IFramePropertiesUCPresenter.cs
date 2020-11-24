using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IFramePropertiesUCPresenter
    {
        IFramePropertiesUC GetFramePropertiesUC();
        IFramePropertiesUCPresenter GetNewInstance(IFrameModel frameModel);
    }
}