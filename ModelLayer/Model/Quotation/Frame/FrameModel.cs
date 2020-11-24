using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model.Quotation.Frame
{
    public class FrameModel : IFrameModel
    {
        public enum Frame_Padding
        {
            Window = 26,
            Door = 33,
            Concrete
        }

        //private int _frameID;
        [Required(ErrorMessage = "Frame_ID is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value for Frame ID bigger than or equal {1}")]
        public int Frame_ID { get; set; }

        //private string _frameName;
        public string Frame_Name { get; set; }

        //private int _frameWidth;
        [Required(ErrorMessage = "Frame_Width is Required")]
        [Range(400, int.MaxValue, ErrorMessage = "Please enter a value for Frame Width bigger than or equal {1}")]
        public int Frame_Width { get; set; }

        //private int _frameHeight;
        [Required(ErrorMessage = "Frame_Height is Required")]
        [Range(400, int.MaxValue, ErrorMessage = "Please enter a value for Frame Height bigger than or equal {1}")]
        public int Frame_Height { get; set; }

        //private Frame_Padding _frameType;
        public Frame_Padding Frame_Type { get; set; }

        public FrameModel(int frameID,
                          string frameName,
                          int frameWd,
                          int frameHt,
                          Frame_Padding frameType)
        {
            Frame_ID = frameID;
            Frame_Name = frameName;
            Frame_Width = frameWd;
            Frame_Height = frameHt;
            Frame_Type = frameType;
        }
    }
}
