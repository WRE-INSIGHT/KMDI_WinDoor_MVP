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
        void AddConcrete(IConcreteUC concreteUC);
        void InvalidateBasePlatform();
        void PerformLayoutBasePlatform();
        void Invalidate_flpMain();
        IBasePlatformPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel, IMainPresenter mainPresenter);
        List<int> lst_wd_toPaint(int flpMain_width, List<int> lst_ctrlWds);
        List<int> lst_ht_toPaint(int flpMain_height, List<int> lst_ctrlHts);
        Dictionary<int, decimal> WidthList_ToPaint(int flpMain_width, decimal[,] arr_wd_locX);
        Dictionary<int, decimal> HeightList_ToPaint(int flpMain_height, decimal[,] arr_ht_locY);
        void ViewDeleteControl(UserControl control);
        void Invalidate_flpMainControls();
        void RemoveBindingView();
    }
}