using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ModelLayer.Model.Quotation.Divider
{
    public interface IDividerModel
    {
        int Div_Height { get; set; }
        int DivImageRenderer_Height { get; set; }
        int Div_ID { get; set; }
        string Div_Name { get; set; }
        Control Div_Parent { get; set; }
        DividerModel.DividerType Div_Type { get; set; }
        bool Div_Visible { get; set; }
        int Div_Width { get; set; }
        int DivImageRenderer_Width { get; set; }
        string Div_FrameType { get; set; }
        float DivImageRenderer_Zoom { get; set; }
        float Div_Zoom { get; set; }
        int Div_WidthToBind { get; set; }
        int Div_HeightToBind { get; set; }
    }
}