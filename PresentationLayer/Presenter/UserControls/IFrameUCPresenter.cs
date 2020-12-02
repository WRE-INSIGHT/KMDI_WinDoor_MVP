using System;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IFrameUCPresenter
    {
        void OnFrameLoadEventRaised(object sender, EventArgs e);
        void OnInnerFramePaintEventRaised(object sender, PaintEventArgs e);
        void OnOuterFramePaintEventRaised(object sender, PaintEventArgs e);
        void DeleteFrame();
        IFrameUC GetFrameUC();
        IFrameUCPresenter GetFrameUCPresenter();
        IFrameUCPresenter GetNewInstance(IUnityContainer unityC, IFrameModel frameModel, IMainPresenter mainPresenter);
    }
}