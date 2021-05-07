using System.Windows.Forms;
using ModelLayer.Model.Quotation.Divider;
using static ModelLayer.Model.Quotation.QuotationModel;

namespace ServiceLayer.Services.DividerServices
{
    public interface IDividerServices
    {
        IDividerModel AddDividerModel(int divWD, int divHT, 
                                      Control divParent, 
                                      DividerModel.DividerType divType, 
                                      bool divVisibility,
                                      float divZoom,
                                      Divider_ArticleNo divArtNo,
                                      int divDisplayWidth,
                                      int divDisplayHeight,
                                      int divID = 0,
                                      float divImageRendererZoom = 1,
                                      string divFrameType = "",
                                      string divName = "");        
    }
}