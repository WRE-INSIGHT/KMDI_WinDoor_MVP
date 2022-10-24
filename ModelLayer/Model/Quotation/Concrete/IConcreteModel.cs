using System.Windows.Forms;

namespace ModelLayer.Model.Quotation.Concrete
{
    public interface IConcreteModel
    {
        int Concrete_Height { get; set; }
        int Concrete_HeightToBind { get; set; }
        int Concrete_Id { get; set; }
        int Concrete_ImagerHeightToBind { get; set; }
        int Concrete_ImagerWidthToBind { get; set; }
        float Concrete_ImagerZoom { get; set; }
        string Concrete_Name { get; set; }
        int Concrete_Width { get; set; }
        int Concrete_WidthToBind { get; set; }
        float Concrete_Zoom { get; set; }
        UserControl Concrete_UC { get; set; }
        void Set_DimensionsToBind_using_ConcreteZoom();
        void Set_ImagerDimensions_using_ImagerZoom();
    }
}