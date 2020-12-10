using System.Windows.Forms;
using ModelLayer.Model.Quotation.Panel;

namespace ServiceLayer.Services.PanelServices
{
    public interface IPanelServices
    {
        IPanelModel CreatePanelModel(int panelID, string panelName, int panelWd, int panelHt, DockStyle panelDock, string panelType, bool panelOrient, Control panelParent, UserControl panelFrameGroup);
        void ValidateModel(IPanelModel panelModel);
    }
}