using ModelLayer.Model.Quotation.Frame;
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
                                List<IPanelModel> lst_panel);
        void ValidateModel(IFrameModel frameModel);
    }
}