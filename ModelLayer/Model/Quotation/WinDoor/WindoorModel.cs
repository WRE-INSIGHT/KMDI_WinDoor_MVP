using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model.Quotation.WinDoor
{
    public class WindoorModel : IWindoorModel
    {
        [Required(ErrorMessage = "ID is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int WD_id { get; set; }

        [Required(ErrorMessage = "Window Name is Required")]
        [StringLength(15, MinimumLength = 6)]
        public string WD_name { get; set; }

        [Required(ErrorMessage = "Window Width is Required")]
        [Range(400, int.MaxValue, ErrorMessage = "Please enter a value bigger than or equal to {1}")]
        public int WD_width { get; set; }

        [Required(ErrorMessage = "Window Height is Required")]
        [Range(400, int.MaxValue, ErrorMessage = "Please enter a value bigger than or equal to {1}")]
        public int WD_height { get; set; }

        public bool WD_visibility { get; set; } //visibility of Window/Door
        public bool WD_orientation { get; set; }

        [Required(ErrorMessage = "Zoom value is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than or equal to {1}")]
        public int WD_zoom { get; set; } //multiply by 0.01 to decimal
                                         
        public string WD_description { get; set; }

        [Required(ErrorMessage = "Window Price is Required")]
        public int WD_price { get; set; } //multiply by 0.01 to get cents (decimal)

        [Required(ErrorMessage = "Window Quantity is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than or equal to {1}")]
        public int WD_quantity { get; set; } //dapat hindi zero
        public decimal WD_discount { get; set; }

        [Required(ErrorMessage = "Window Profile is Required")]
        public string WD_profile { get; set; }
    }
}
