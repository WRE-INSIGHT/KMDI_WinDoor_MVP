using System.Windows.Forms;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using System.Collections.Generic;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;

namespace ServiceLayer.Services.MultiPanelServices
{
    public interface IMultiPanelServices
    {
        void ValidateModel(IMultiPanelModel multiPanelModel);
        IMultiPanelModel AddMultiPanelModel(int mwidth,
                                            int mheight,
                                            int mpanelDisplayWidth,
                                            int mpanelDisplayWidthDecimal,
                                            int mpanelDisplayHeight,
                                            int mpanelDisplayHeightDecimal,
                                            Control mpanelParent,
                                            UserControl mpanelFrameGroup,
                                            IFrameModel mpanelFrameModelParent,
                                            bool mvisible,
                                            FlowDirection mflow,
                                            float mpanelZoom,
                                            int mid = 0,
                                            DockStyle mdock = DockStyle.Fill,
                                            int mpanelStackNo = 0,
                                            int mpanelIndexInsideMPanel = 0,
                                            IMultiPanelModel mpanelParentModel = null,
                                            float mpanelImageRendererZoom = 1,
                                            string mname = "",
                                            int mpanelDivisions = 1,
                                            List<IPanelModel> mpanelLstPanel = null,
                                            List<IDividerModel> mpanelLstDivider = null,
                                            List<IMultiPanelModel> mpanelLstMultiPanel = null,
                                            List<Control> mpanelLstObjects = null,
                                            List<Control> mpanelLstImagers = null);
    }
}