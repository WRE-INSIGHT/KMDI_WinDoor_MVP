using System.Windows.Forms;
using ModelLayer.Model.Quotation.Divider;

namespace ServiceLayer.Services.DividerServices
{
    public interface IDividerServices
    {
        IDividerModel AddDividerModel(int divWD, int divHT, 
                                      Control divParent, 
                                      DividerModel.DividerType divType, 
                                      bool divVisibility, 
                                      int divID = 0, 
                                      float divImageRendererZoom = 1,
                                      string divFrameType = "",
                                      string divName = "");        
    }
}