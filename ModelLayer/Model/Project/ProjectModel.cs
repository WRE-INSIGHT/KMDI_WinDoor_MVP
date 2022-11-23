using ModelLayer.Model.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model.AddProject
{
    public class ProjectModel : IProjectModel
    {
      
        private string _barangay;
       
        public string Barangay
        {
            get
            {
                return _barangay;
            }

            set
            {
                _barangay = value;
            }
        }
       
        private string _city;
        [Required(ErrorMessage = "City is Required")]
        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                _city = value;
            }
        }
       
        private string _area;
        [Required(ErrorMessage = "Area is Required")]
        public string Area
        {
            get
            {
                return _area;
            }

            set
            {
                _area = value;
            }
        }
      
        private string _province;
        [Required(ErrorMessage = "Province is Required")]
        public string Province
        {
            get
            {
                return _province;
            }

            set
            {
                _province = value;
            }
        }
        
        private string _establishment;
       
        public string Establishment
        {
            get
            {
                return _establishment;
            }

            set
            {
                _establishment = value;
            }
        }
      
        private string _houseNo;
       
        public string HouseNo
        {
            get
            {
                return _houseNo;
            }

            set
            {
                _houseNo = value;
            }
        }
       
        private string _street;
       
        public string Street
        {
            get
            {
                return _street;
            }

            set
            {
                _street = value;
            }
        }
        private string _unitNo;
        public string UnitNo
        {
            get
            {
                return _unitNo;
            }

            set
            {
                _unitNo = value;
            }
        }
        private string _village;

        public string Village
        {
            get
            {
                return _village;
            }

            set
            {
                _village = value;
            }
        }
        private string _firstname;
        public string Firstname
        {
            get
            {
                return _firstname;
            }

            set
            {
                _firstname = value;
            }
        }
        private string _lastname;
        public string Lastname
        {
            get
            {
                return _lastname;
            }

            set
            {
                _lastname = value;
            }
        }
        private string _companyName;
        public string CompanyName
        {
            get
            {
                return _companyName;
            }

            set
            {
                _companyName = value;
            }
        }
        private string _contactNo;
        [Required(ErrorMessage = "Contact No is Required")]
        public string ContactNo
        {
            get
            {
                return _contactNo;
            }

            set
            {
                _contactNo = value;
            }
        }
        private string _fileLableAs;
        [Required(ErrorMessage = "File/Lable As is Required")]
        public string FileLableAs
        {
            get
            {
                return _fileLableAs;
            }

            set
            {
                _fileLableAs = value;
            }
        }

        public string CompleteAddress
        {
            get
            {
                string Complete_Address = string.Empty;
                if (!string.IsNullOrWhiteSpace(UnitNo))
                {
                    Complete_Address += UnitNo + " ";
                }

                if (!string.IsNullOrWhiteSpace(Establishment))
                {
                    Complete_Address += Establishment + ", ";
                }
                if (!string.IsNullOrWhiteSpace(HouseNo))
                {
                    Complete_Address += HouseNo + " ";
                }
                if (!string.IsNullOrWhiteSpace(Street))
                {
                    Complete_Address += Street + " ";
                }
                if (!string.IsNullOrWhiteSpace(Village))
                {
                    Complete_Address += Village + " ";
                }
                if (!string.IsNullOrWhiteSpace(Barangay))
                {
                    Complete_Address += Barangay + ", ";
                }
                if (!string.IsNullOrWhiteSpace(City))
                {
                    Complete_Address += City + ", ";
                }
                if (!string.IsNullOrWhiteSpace(Province))
                {
                    Complete_Address += Province + " ";
                }
                if (!string.IsNullOrWhiteSpace(Area))
                {
                    Complete_Address += Area;
                }
                return Complete_Address;
            }

           
        }
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }
    }
}
