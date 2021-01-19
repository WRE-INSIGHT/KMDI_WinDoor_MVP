using System.Windows.Forms;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using System.Collections.Generic;

namespace ServiceLayer.Services.MultiPanelServices
{
    public interface IMultiPanelServices
    {
        IMultiPanelModel CreateMultiPanel(int mid, string mname, int mwidth, int mheight, DockStyle mdock, bool mvisible, FlowDirection mflow,
                                          Control mpanelParent,
                                          UserControl mpanelFrameGroup,
                                          int mpanelDivisions,
                                          List<IPanelModel> mpanelLstPanel = null);
        void ValidateModel(IMultiPanelModel multiPanelModel);
        IMultiPanelModel AddMultiPanelModel(int mwidth,
                                            int mheight,
                                            Control mpanelParent,
                                            UserControl mpanelFrameGroup,
                                            bool mvisible,
                                            FlowDirection mflow,
                                            int mid = 0,
                                            string mname = "",
                                            DockStyle mdock = DockStyle.Fill,
                                            int mpanelDivisions = 1,
                                            List<IPanelModel> mpanelLstPanel = null);
    }
}