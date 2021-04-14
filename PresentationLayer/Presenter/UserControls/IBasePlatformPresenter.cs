using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IBasePlatformPresenter
    {
        IBasePlatformUC getBasePlatformViewUC();
        void AddFrame(IFrameUC frame);
        void InvalidateBasePlatform();
        void PerformLayoutBasePlatform();
        void Invalidate_flpMain();
        IBasePlatformPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel);
        List<int> lst_wd_toPaint(int flpMain_width, List<int> lst_ctrlWds);
        List<int> lst_ht_toPaint(int flpMain_height, List<int> lst_ctrlHts);
        void ViewDeleteControl(UserControl control);
        void Invalidate_flpMainControls();
    }
}