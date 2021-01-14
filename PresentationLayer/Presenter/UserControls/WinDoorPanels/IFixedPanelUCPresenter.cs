using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public interface IFixedPanelUCPresenter
    {
        IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IFrameModel frameModel, IMainPresenter mainPresenter);
        IFixedPanelUC GetFixedPanelUC();
        void SetInitialLoadFalse();
    }
}