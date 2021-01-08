using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IFrameImagerUCPresenter
    {
        IFrameImagerUC GetFrameImagerUC();
        IFrameImagerUCPresenter GetNewInstance(IUnityContainer unityC, IFrameModel frameModel);
    }
}