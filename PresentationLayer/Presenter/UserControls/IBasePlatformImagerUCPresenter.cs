using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IBasePlatformImagerUCPresenter
    {
        IBasePlatformImagerUC GetBasePlatformImagerUC();
        IBasePlatformImagerUCPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel, IMainPresenter mainPresenter);
        void InvalidateBasePlatform();
        void AddFrame(IFrameImagerUC frameImagerUC);
        void Invalidate_flpMain();
        void BringToFront_baseImager();
        void SendToBack_baseImager();
        void DeleteControl(UserControl frameImagerUC);
        void SetWdFlpImage();

        List<Point> OuterFrame_DrawPoints(List<Size> frameImager_sizes, int basePlatformImage_Width);
    }
}