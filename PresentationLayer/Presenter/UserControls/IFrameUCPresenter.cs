using System;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls;
using Unity;
using ModelLayer.Model.Quotation.Panel;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IFrameUCPresenter
    {
        void OnFrameLoadEventRaised(object sender, EventArgs e);
        void OnInnerFramePaintEventRaised(object sender, PaintEventArgs e);
        void OnOuterFramePaintEventRaised(object sender, PaintEventArgs e);
        void DeleteFrame();
        IFrameUC GetFrameUC();
        IFrameUCPresenter GetNewInstance(IUnityContainer unityC, IFrameModel frameModel, IMainPresenter mainPresenter);

        IPanelModel AddPanelModel(int panelWd,
                                         int panelHt,
                                         Control panelParent,
                                         UserControl panelFrameGroup,
                                         UserControl panelFramePropertiesGroup,
                                         string panelType,
                                         bool panelVisibility,
                                         int panelID = 0,
                                         string panelName = "",
                                         DockStyle panelDock = DockStyle.Fill,
                                         bool panelOrient = false);
    }
}