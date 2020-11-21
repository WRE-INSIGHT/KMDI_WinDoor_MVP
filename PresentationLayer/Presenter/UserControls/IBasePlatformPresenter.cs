using PresentationLayer.Views.UserControls;
using System.Windows.Forms;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IBasePlatformPresenter
    {
        IBasePlatformUC getBasePlatformViewUC();
        void SetBasePlatformSize(int wd, int ht);
        void AddFrame(IFrameUC frame);
        void InvalidateBasePlatform();
        void PerformLayoutBasePlatform();
    }
}