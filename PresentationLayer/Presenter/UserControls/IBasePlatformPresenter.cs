using PresentationLayer.Views.UserControls;
using System.Collections.Generic;
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
        void Invalidate_flpMain();
        void DeleteFrameUC(IFrameUC frameUC);
        List<int> lst_wd_toPaint(int flpMain_width, List<int> lst_ctrlWds);
        List<int> lst_ht_toPaint(int flpMain_height, List<int> lst_ctrlHts);
    }
}