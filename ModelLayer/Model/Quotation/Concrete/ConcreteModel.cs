using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelLayer.Model.Quotation.Concrete
{
    public class ConcreteModel : IConcreteModel, INotifyPropertyChanged
    {
        [Required(ErrorMessage = "Concrete_Width is Required")]
        [Range(400, int.MaxValue, ErrorMessage = "Please enter a value for Concrete Width bigger than or equal {1}")]
        private int _concreteWd;
        public int Concrete_Width
        {
            get
            {
                return _concreteWd;
            }
            set
            {
                _concreteWd = value;
                NotifyPropertyChanged();
            }
        }

        [Required(ErrorMessage = "Concrete_Height is Required")]
        [Range(400, int.MaxValue, ErrorMessage = "Please enter a value for Concrete Height bigger than or equal {1}")]
        private int _concreteHt;
        public int Concrete_Height
        {
            get
            {
                return _concreteHt;
            }
            set
            {
                _concreteHt = value;
                NotifyPropertyChanged();
            }
        }

        public int Concrete_Id { get; set; }
        public string Concrete_Name { get; set; }


       
        private int _concreteWdToBind;
        public int Concrete_WidthToBind
        {
            get
            {
                return _concreteWdToBind;
            }
            set
            {
                _concreteWdToBind = value;
                NotifyPropertyChanged();
            }
        }

        private int _concreteHtToBind;
        public int Concrete_HeightToBind
        {
            get
            {
                return _concreteHtToBind;
            }
            set
            {
                _concreteHtToBind = value;
                NotifyPropertyChanged();
            }
        }
        private UserControl _concreteUC;
        public UserControl Concrete_UC
        {
            get
            {
                return _concreteUC;
            }

            set
            {
                _concreteUC = value;
                NotifyPropertyChanged();
            }
        }
        private UserControl _concretePropertiesUC;
        public UserControl Concrete_PropertiesUC
        {
            get
            {
                return _concretePropertiesUC;
            }
            set
            {
                _concretePropertiesUC = value;
                NotifyPropertyChanged();
            }
        }

        public int Concrete_ImagerWidthToBind { get; set; }
        public int Concrete_ImagerHeightToBind { get; set; }
        public float Concrete_ImagerZoom { get; set; }
        public float Concrete_Zoom { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Method

        public void Set_DimensionsToBind_using_ConcreteZoom()
        {
            decimal wd_flt_convert_dec = Convert.ToDecimal(Concrete_Width * Concrete_Zoom);
            decimal concrete_wd_dec = decimal.Round(wd_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
            //Concrete_WidthToBind = Convert.ToInt32(concrete_wd_dec);
            Concrete_WidthToBind = Convert.ToInt32(wd_flt_convert_dec);
            decimal ht_flt_convert_dec = Convert.ToDecimal(Concrete_Height * Concrete_Zoom);
            decimal concrete_ht_dec = decimal.Round(ht_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
            //Concrete_HeightToBind = Convert.ToInt32(concrete_ht_dec);
            Concrete_HeightToBind = Convert.ToInt32(ht_flt_convert_dec);
        }

        public void Set_ImagerDimensions_using_ImagerZoom()
        {
            Concrete_ImagerWidthToBind = Convert.ToInt32(Concrete_Width * Concrete_ImagerZoom);
            Concrete_ImagerHeightToBind = Convert.ToInt32(Concrete_Height * Concrete_ImagerZoom);
        }

        #endregion
    }
}
