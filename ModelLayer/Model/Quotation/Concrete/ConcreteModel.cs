using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model.Quotation.Concrete
{
    public class ConcreteModel : IConcreteModel
    {
        public int Concrete_Id { get; set; }
        public string Concrete_Name { get; set; }
        public int Concrete_Width { get; set; }
        public int Concrete_Height { get; set; }
        public int Concrete_WidthToBind { get; set; }
        public int Concrete_HeightToBind { get; set; }
        public int Concrete_ImagerWidthToBind { get; set; }
        public int Concrete_ImagerHeightToBind { get; set; }
        public float Concrete_ImagerZoom { get; set; }
        public float Concrete_Zoom { get; set; }

        #region Method

        public void Set_DimensionsToBind_using_FrameZoom()
        {
            decimal wd_flt_convert_dec = Convert.ToDecimal(Concrete_Width * Concrete_Zoom);
            decimal concrete_wd_dec = decimal.Round(wd_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
            Concrete_WidthToBind = Convert.ToInt32(concrete_wd_dec);

            decimal ht_flt_convert_dec = Convert.ToDecimal(Concrete_Height * Concrete_Zoom);
            decimal concrete_ht_dec = decimal.Round(ht_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
            Concrete_HeightToBind = Convert.ToInt32(concrete_ht_dec);
        }

        public void Set_ImagerDimensions_using_ImagerZoom()
        {
            Concrete_ImagerWidthToBind = Convert.ToInt32(Concrete_Width * Concrete_ImagerZoom);
            Concrete_ImagerHeightToBind = Convert.ToInt32(Concrete_Height * Concrete_ImagerZoom);
        }

        #endregion
    }
}
