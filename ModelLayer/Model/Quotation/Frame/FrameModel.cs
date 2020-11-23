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
        [Required(ErrorMessage = "Frame_ID is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value for Frame ID bigger than {1}")]
        public int Frame_ID { get; set; }

        public string Frame_Name { get; set; }

        [Required(ErrorMessage = "Frame_Width is Required")]
        [Range(400, int.MaxValue, ErrorMessage = "Please enter a value for Frame Width bigger than or equal {1}")]
        public int Frame_Width { get; set; }

        [Required(ErrorMessage = "Frame_Height is Required")]
        [Range(400, int.MaxValue, ErrorMessage = "Please enter a value for Frame Height bigger than or equal {1}")]
        public int Frame_Height { get; set; }
        public Frame_Padding Frame_Type { get; set; }
        public enum Frame_Padding
        {
            Window = 26,
            Door = 33
        }
    }
}
