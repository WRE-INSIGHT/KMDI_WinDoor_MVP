using ModelLayer.Model.Quotation.Panel;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ModelLayer.Model.Quotation.Frame
{
    public interface IFrameModel
    {
        int Frame_Height { get; set; }
        int Frame_ID { get; set; }
        string Frame_Name { get; set; }
        FrameModel.Frame_Padding Frame_Type { get; set; }
        int Frame_Width { get; set; }
        bool Frame_Visible { get; set; }
        //int Frame_Padding_int { get; set; }
        Padding Frame_Padding_int { get; set; }
        List<IPanelModel> lst_Panel { get; set; }
    }
}