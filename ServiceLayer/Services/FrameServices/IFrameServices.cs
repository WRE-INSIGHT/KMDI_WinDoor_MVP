using ModelLayer.Model.Quotation.Frame;

namespace ServiceLayer.Services.FrameServices
{
    public interface IFrameServices
    {
        IFrameModel CreateFrame(int frame_id, string frame_name, int frame_width, int frame_height, FrameModel.Frame_Padding frame_type);
        void ValidateModel(IFrameModel frameModel);
    }
}