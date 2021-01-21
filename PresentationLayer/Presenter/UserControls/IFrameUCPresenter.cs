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
        void DeleteFrame();
        IFrameUC GetFrameUC();
        IFrameUCPresenter GetNewInstance(IUnityContainer unityC,
                                         IFrameModel frameModel,
                                         IMainPresenter mainPresenter,
                                         IBasePlatformPresenter basePlatformUCP);
        void ViewDeleteControl(UserControl control);

        //IPanelModel AddPanelModel(int panelWd,
        //                                 int panelHt,
        //                                 Control panelParent,
        //                                 UserControl panelFrameGroup,
        //                                 UserControl panelFramePropertiesGroup,
        //                                 string panelType,
        //                                 bool panelVisibility,
        //                                 int panelID = 0,
        //                                 string panelName = "",
        //                                 DockStyle panelDock = DockStyle.Fill,
        //                                 bool panelOrient = false);
    }
}