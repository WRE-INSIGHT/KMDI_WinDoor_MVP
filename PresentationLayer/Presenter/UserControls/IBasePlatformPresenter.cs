using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        IBasePlatformPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel, IMainPresenter mainPresenter);
        List<int> lst_wd_toPaint(int flpMain_width, List<int> lst_ctrlWds);
        List<int> lst_ht_toPaint(int flpMain_height, List<int> lst_ctrlHts);
        List<int> WidthList_ToPaint(int flpMain_width, int[,] arr_wd_locX);
        List<int> HeightList_ToPaint(int flpMain_height, int[,] arr_ht_locY);
        void ViewDeleteControl(UserControl control);
        void Invalidate_flpMainControls();
    }
}