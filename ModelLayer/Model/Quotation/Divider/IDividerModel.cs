using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ModelLayer.Model.Quotation.Divider
{
    public interface IDividerModel
    {
        UserControl Div_FrameGroup { get; set; }
        int Div_Height { get; set; }
        int Div_ID { get; set; }
        string Div_Name { get; set; }
        Control Div_Parent { get; set; }
        DividerModel.DividerType Div_Type { get; set; }
        bool Div_Visible { get; set; }
        int Div_Width { get; set; }
        string Div_FrameType { get; set; }
    }
}