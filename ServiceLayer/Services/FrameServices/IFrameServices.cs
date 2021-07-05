using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using System.Collections.Generic;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.QuotationModel;

namespace ServiceLayer.Services.FrameServices
{
    public interface IFrameServices
    {
        IFrameModel AddFrameModel(int frame_width,
                                  int frame_height,
                                  FrameModel.Frame_Padding frame_type,
                                  float frameImager_Zoom,
                                  float frameZoom,
                                  FrameProfile_ArticleNo frameArtNo,
                                  IWindoorModel frameWindoorModel,
                                  int frame_id = 0,
                                  string frame_name = "",
                                  bool frame_visible = true,
                                  List<IPanelModel> lst_Panel = null,
                                  List<IMultiPanelModel> lst_MPanel = null,
                                  List<IDividerModel> lst_Divider = null);
        void ValidateModel(IFrameModel frameModel);
    }
}