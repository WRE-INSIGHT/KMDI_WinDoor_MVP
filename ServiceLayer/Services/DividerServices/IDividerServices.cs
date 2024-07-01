using System.Windows.Forms;
using ModelLayer.Model.Quotation.Divider;
using static ModelLayer.Model.Quotation.QuotationModel;
using ModelLayer.Model.Quotation.MultiPanel;
using static EnumerationTypeLayer.EnumerationTypes;
using System.Collections.Generic;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.User;

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
                                      IMultiPanelModel divMPanelParent,
                                      IFrameModel divFrameParent,
                                      IUserModel divUserModel,
                                      int divID = 0,
                                      float divImageRendererZoom = 1,
                                      string divFrameType = "",
                                      string divName = "",
                                      Dictionary<int, int> divCladdingSizeList = null,
                                      bool divChkDM = false,
                                      bool divArtVisibility = true,
                                      DummyMullion_ArticleNo divDMArtNo = null,
                                      IPanelModel divDMPanel = null,
                                      bool divLeverEspagVisibility = false);        
    }
}