using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using System.Collections.Generic;

namespace ServiceLayer.Services.FrameServices
{
    public interface IFrameServices
    {
        IFrameModel CreateFrame(int frame_id, 
                                string frame_name, 
                                int frame_width, 
                                int frame_height, 
                                FrameModel.Frame_Padding frame_type,
                                bool frame_visible,
                                List<IPanelModel> lst_panel,
                                List<IMultiPanelModel> lst_mpanel,
                                float frameImager_Zoom,
                                List<IDividerModel> lst_divider,
                                float frameZoom);
        IFrameModel AddFrameModel(int frame_width,
                                  int frame_height,
                                  FrameModel.Frame_Padding frame_type,
                                  float frameImager_Zoom,
                                  float frameZoom,
                                  int frame_id = 0,
                                  string frame_name = "",
                                  bool frame_visible = true,
                                  List<IPanelModel> lst_Panel = null,
                                  List<IMultiPanelModel> lst_MPanel = null,
                                  List<IDividerModel> lst_Divider = null);
        void ValidateModel(IFrameModel frameModel);
    }
}