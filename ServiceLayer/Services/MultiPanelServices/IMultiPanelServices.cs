using System.Windows.Forms;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using System.Collections.Generic;
using ModelLayer.Model.Quotation.Divider;

namespace ServiceLayer.Services.MultiPanelServices
{
    public interface IMultiPanelServices
    {
        void ValidateModel(IMultiPanelModel multiPanelModel);
        IMultiPanelModel AddMultiPanelModel(int mwidth,
                                            int mheight,
                                            Control mpanelParent,
                                            UserControl mpanelFrameGroup,
                                            bool mvisible,
                                            FlowDirection mflow,
                                            int mid = 0,
                                            DockStyle mdock = DockStyle.Fill,
                                            string mname = "",
                                            int mpanelDivisions = 1,
                                            List<IPanelModel> mpanelLstPanel = null,
                                            List<IDividerModel> mpanelLstDivider = null,
                                            List<IMultiPanelModel> mpanelLstMultiPanel = null);
    }
}