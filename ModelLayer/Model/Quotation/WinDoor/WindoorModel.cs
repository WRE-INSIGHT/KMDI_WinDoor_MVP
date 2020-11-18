﻿using System;
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
        public int WD_id { get; set; } //maglagay minimum value para sa ID, dapat hindi zero

        [Required(ErrorMessage = "Window Name is Required")]
        [StringLength(15, MinimumLength = 6)]
        public string WD_name { get; set; }

        [Required(ErrorMessage = "Window Width is Required")]
        public int WD_width { get; set; } //dapat hindi zero

        [Required(ErrorMessage = "Window Height is Required")]
        public int WD_height { get; set; } //dapat hindi zero

        public bool WD_visibility { get; set; } //visibility of Window/Door
        public bool WD_orientation { get; set; }

        [Required(ErrorMessage = "Zoom value is Required")]
        public int WD_zoom { get; set; } //multiply by 0.01 to decimal
                                         //dapat hindi zero
        public string WD_description { get; set; }

        [Required(ErrorMessage = "Window Price is Required")]
        public int WD_price { get; set; } //multiply by 0.01 to get cents (decimal)

        [Required(ErrorMessage = "Window Quantity is Required")]
        public int WD_quantity { get; set; } //dapat hindi zero
        public decimal WD_discount { get; set; }
    }
}
