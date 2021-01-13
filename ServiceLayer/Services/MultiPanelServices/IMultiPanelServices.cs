﻿using System.Windows.Forms;
using ModelLayer.Model.Quotation.MultiPanel;

namespace ServiceLayer.Services.MultiPanelServices
{
    public interface IMultiPanelServices
    {
        IMultiPanelModel CreateMultiPanel(int mid, string mname, int mwidth, int mheight, DockStyle mdock, bool mvisible, FlowDirection mflow,
                                          Control mpanelParent,
                                          UserControl mpanelFrameGroup,
                                          int mpanelDivisions);
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
                                            int mpanelDivisions = 1);
    }
}