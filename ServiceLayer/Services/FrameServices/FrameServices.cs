using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.Panel;
using ServiceLayer.CommonServices;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Divider;
using static ModelLayer.Model.Quotation.QuotationModel;

namespace ServiceLayer.Services.FrameServices
{
    public class FrameServices : IFrameServices
    {
        private IModelDataAnnotationCheck _modelCheck;

        public FrameServices(IModelDataAnnotationCheck modelCheck)
        {
            _modelCheck = modelCheck;
        }

        public IFrameModel CreateFrame(int frame_id, 
                                       string frame_name, 
                                       int frame_width, 
                                       int frame_height, 
                                       FrameModel.Frame_Padding frame_type,
                                       bool frame_visible,
                                       List<IPanelModel> lst_panel,
                                       List<IMultiPanelModel> lst_mpanel,
                                       float frameImager_Zoom,
                                       List<IDividerModel> lst_divider,
                                       float frameZoom,
                                       FrameProfile_ArticleNo frameArtNo)
        {
            IFrameModel fr = new FrameModel(frame_id,
                                           frame_name,
                                           frame_width,
                                           frame_height,
                                           frame_type,
                                           frame_visible,
                                           lst_panel,
                                           lst_mpanel,
                                           frameImager_Zoom,
                                           lst_divider,
                                           frameZoom,
                                           frameArtNo);
            ValidateModel(fr);

            return fr;
        }

        public void ValidateModel(IFrameModel frameModel)
        {
            _modelCheck.ValidateModelDataAnnotations(frameModel);
        }

        public IFrameModel AddFrameModel(int frame_width,
                                         int frame_height,
                                         FrameModel.Frame_Padding frame_type,
                                         float frameImager_Zoom,
                                         float frameZoom,
                                         FrameProfile_ArticleNo frameArtNo,
                                         int frame_id = 0,
                                         string frame_name = "",
                                         bool frame_visible = true,
                                         List<IPanelModel> lst_Panel = null,
                                         List<IMultiPanelModel> lst_MPanel = null,
                                         List<IDividerModel> lst_Divider = null)
        {
            if (frame_name == "")
            {
                frame_name = "Frame " + frame_id;
            }
            if (lst_Panel == null)
            {
                lst_Panel = new List<IPanelModel>();
            }
            if (lst_MPanel == null)
            {
                lst_MPanel = new List<IMultiPanelModel>();
            }
            if (lst_Divider == null)
            {
                lst_Divider = new List<IDividerModel>();
            }

            IFrameModel _frameModel = CreateFrame(frame_id,
                                                     frame_name,
                                                     frame_width,
                                                     frame_height,
                                                     frame_type,
                                                     frame_visible,
                                                     lst_Panel,
                                                     lst_MPanel,
                                                     frameImager_Zoom,
                                                     lst_Divider,
                                                     frameZoom,
                                                     frameArtNo);

            return _frameModel;
        }

    }
}
