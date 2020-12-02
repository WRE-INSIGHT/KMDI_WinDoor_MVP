using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Frame;
using ServiceLayer.CommonServices;

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
                                       bool frame_visible)
        {
            IFrameModel fr = new FrameModel(frame_id,
                                           frame_name,
                                           frame_width,
                                           frame_height,
                                           frame_type,
                                           frame_visible);
            ValidateModel(fr);

            return fr;
        }

        public void ValidateModel(IFrameModel frameModel)
        {
            _modelCheck.ValidateModelDataAnnotations(frameModel);
        }
    }
}
