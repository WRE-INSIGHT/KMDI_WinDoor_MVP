namespace ModelLayer.Model.Quotation.Frame
{
    public interface IFrameModel
    {
        int Frame_Height { get; set; }
        int Frame_ID { get; set; }
        string Frame_Name { get; set; }
        FrameModel.Frame_Padding Frame_Type { get; set; }
        int Frame_Width { get; set; }
    }
}