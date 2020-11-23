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
                                       FrameModel.Frame_Padding frame_type)
        {
            FrameModel fr = new FrameModel();
            fr.Frame_ID = frame_id;
            fr.Frame_Name = frame_name;
            fr.Frame_Width = frame_width;
            fr.Frame_Height = frame_height;
            fr.Frame_Type = frame_type;

            ValidateModel(fr);

            return fr;
        }

        public void ValidateModel(IFrameModel frameModel)
        {
            _modelCheck.ValidateModelDataAnnotations(frameModel);
        }
    }
}
