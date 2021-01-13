using System.Windows.Forms;
using ModelLayer.Model.Quotation.Panel;

namespace ServiceLayer.Services.PanelServices
{
    public interface IPanelServices
    {
        IPanelModel CreatePanelModel(int panelID, string panelName, int panelWd, int panelHt, DockStyle panelDock, string panelType, bool panelOrient, Control panelParent, UserControl panelFrameGroup, bool panelVisibility, UserControl panelFramePropertiesGroup);
        void ValidateModel(IPanelModel panelModel);
        IPanelModel AddPanelModel(int panelWd,
                                  int panelHt,
                                  Control panelParent,
                                  UserControl panelFrameGroup,
                                  UserControl panelFramePropertiesGroup,
                                  string panelType,
                                  bool panelVisibility,
                                  int panelID = 0,
                                  DockStyle panelDock = DockStyle.Fill,
                                  string panelName = "",
                                  bool panelOrient = false);
    }
}