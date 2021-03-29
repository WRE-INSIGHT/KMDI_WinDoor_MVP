using System.Windows.Forms;
using ModelLayer.Model.Quotation.Panel;

namespace ServiceLayer.Services.PanelServices
{
    public interface IPanelServices
    {
        void ValidateModel(IPanelModel panelModel);
        IPanelModel AddPanelModel(int panelWd,
                                  int panelHt,
                                  Control panelParent,
                                  UserControl panelFrameGroup,
                                  UserControl panelFramePropertiesGroup,
                                  UserControl panelMultiPanelGroup,
                                  string panelType,
                                  bool panelVisibility,
                                  int panelID = 0,
                                  float panelImageRendererZoom = 1,
                                  int panelIndexInsideMPanel = 0,
                                  DockStyle panelDock = DockStyle.Fill,
                                  string panelName = "",
                                  bool panelOrient = false);
    }
}