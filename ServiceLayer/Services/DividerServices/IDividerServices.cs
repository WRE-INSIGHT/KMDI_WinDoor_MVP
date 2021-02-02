using System.Windows.Forms;
using ModelLayer.Model.Quotation.Divider;

namespace ServiceLayer.Services.DividerServices
{
    public interface IDividerServices
    {
        IDividerModel AddDividerModel(int divWD, int divHT, 
                                      Control divParent, 
                                      UserControl divFrameGroup, 
                                      DividerModel.DividerType divType, 
                                      bool divVisibility, 
                                      int divID = 0, 
                                      string divFrameType = "",
                                      string divName = "");        
    }
}