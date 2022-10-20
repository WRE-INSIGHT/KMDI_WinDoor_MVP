using ModelLayer.Variables;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation.Screen
{
    public class ScreenModel : IScreenModel, INotifyPropertyChanged
    {


        private ConstantVariables constants = new ConstantVariables();

        public int Screen_id { get; set; }

        private bool _screen_Types_Window;
        public bool Screen_Types_Window
        {
            get
            {
                return _screen_Types_Window;
            }
            set
            {
                _screen_Types_Window = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_Types_Door;
        public bool Screen_Types_Door
        {
            get
            {
                return _screen_Types_Door;
            }
            set
            {
                _screen_Types_Door = value;
                NotifyPropertyChanged();
            }
        }


        private int _screen_Width;
        public int Screen_Width
        {
            get
            {
                return _screen_Width;
            }
            set
            {
                _screen_Width = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_Height;
        public int Screen_Height
        {
            get
            {
                return _screen_Height;
            }
            set
            {
                _screen_Height = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_Factor;
        public decimal Screen_Factor
        {
            get
            {
                return _screen_Factor;
            }
            set
            {
                _screen_Factor = value;
                NotifyPropertyChanged();
            }
        }


        private ScreenType _screen_Type;
        public ScreenType Screen_Types
        {
            get
            {
                return _screen_Type;
            }
            set
            {
                _screen_Type = value;
                NotifyPropertyChanged();
            }
        }


        private Base_Color _screen_BaseColor;
        public Base_Color Screen_BaseColor
        {
            get
            {
                return _screen_BaseColor;
            }
            set
            {
                _screen_BaseColor = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_Set;
        public int Screen_Set
        {
            get
            {
                return _screen_Set;
            }
            set
            {
                _screen_Set = value;
                NotifyPropertyChanged();
            }
        }


        private string _screen_WindoorID; //location
        public string Screen_WindoorID //location
        {
            get
            {
                return _screen_WindoorID;
            }
            set
            {
                _screen_WindoorID = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_UnitPrice;
        public decimal Screen_UnitPrice
        {
            get
            {
                return _screen_UnitPrice;
            }
            set
            {
                _screen_UnitPrice = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_Quantity;
        public int Screen_Quantity
        {
            get
            {
                return _screen_Quantity;
            }
            set
            {
                _screen_Quantity = value;
                NotifyPropertyChanged();
            }
        }


        private decimal _screen_TotalAmount;
        public decimal Screen_TotalAmount
        {
            get
            {
                return _screen_TotalAmount;
            }
            set
            {
                _screen_TotalAmount = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_NetPrice;
        public decimal Screen_NetPrice
        {
            get
            {
                return _screen_NetPrice;
            }
            set
            {
                _screen_NetPrice = value;
                NotifyPropertyChanged();
            }
        }


        private decimal _screen_Discount;
        public decimal Screen_Discount
        {
            get
            {
                return _screen_Discount;
            }
            set
            {
                _screen_Discount = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_DiscountedPrice;
        public decimal Screen_DiscountedPrice
        {
            get
            {
                return _screen_DiscountedPrice;
            }
            set
            {
                _screen_DiscountedPrice = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_DiscountedPriceWithoutVat;
        public decimal Screen_DiscountedPriceWithoutVat
        {
            get
            {
                return _screen_DiscountedPriceWithoutVat;
            }
            set
            {
                _screen_DiscountedPriceWithoutVat = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_LaborAndMobilization;
        public decimal Screen_LaborAndMobilization
        {
            get
            {
                return _screen_LaborAndMobilization;
            }
            set
            {
                _screen_LaborAndMobilization = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_TotalNetPriceWithoutVat;
        public decimal Screen_TotalNetPriceWithoutVat
        {
            get
            {
                return _screen_TotalNetPriceWithoutVat;
            }
            set
            {
                _screen_TotalNetPriceWithoutVat = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_PVCVisibility;
        public bool Screen_PVCVisibility
        {
            get
            {
                return _screen_PVCVisibility;
            }
            set
            {
                _screen_PVCVisibility = value;
                NotifyPropertyChanged();
            }
        }


        private int _screen_0505Width;
        public int Screen_0505Width
        {
            get
            {
                return _screen_0505Width;
            }
            set
            {
                _screen_0505Width = value;
                NotifyPropertyChanged();
            }
        }


        private int _screen_1067Height;
        public int Screen_1067Height
        {
            get
            {
                return _screen_1067Height;
            }
            set
            {
                _screen_1067Height = value;
                NotifyPropertyChanged();
            }
        }


        private int _screen_0505Qty;
        public int Screen_0505Qty
        {
            get
            {
                return _screen_0505Qty;
            }
            set
            {
                _screen_0505Qty = value;
                NotifyPropertyChanged();
            }
        }


        private int _screen_1067Qty;
        public int Screen_1067Qty
        {
            get
            {
                return _screen_1067Qty;
            }
            set
            {
                _screen_1067Qty = value;
                NotifyPropertyChanged();
            }
        }


        private bool _screen_CenterClosureVisibility;
        public bool Screen_CenterClosureVisibility
        {
            get
            {
                return _screen_CenterClosureVisibility;
            }
            set
            {
                _screen_CenterClosureVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_CenterClosureVisibilityOption;
        public bool Screen_CenterClosureVisibilityOption
        {
            get
            {
                return _screen_CenterClosureVisibilityOption;
            }
            set
            {
                _screen_CenterClosureVisibilityOption = value;
                NotifyPropertyChanged();
            }
        }


        private int _screen_LatchKitQty;
        public int Screen_LatchKitQty
        {
            get
            {
                return _screen_LatchKitQty;
            }
            set
            {
                _screen_LatchKitQty = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_IntermediatePartQty;
        public int Screen_IntermediatePartQty
        {
            get
            {
                return _screen_IntermediatePartQty;
            }
            set
            {
                _screen_IntermediatePartQty = value;
                NotifyPropertyChanged();
            }
        }







        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ScreenModel(int screen_id,
                           int screen_width,
                           int screen_height,
                           decimal screen_factor,
                           ScreenType screen_types,
                           string screen_windoorID,
                           decimal screen_unitPrice,
                           int screen_quantity,
                           decimal screen_totalAmount)
        {
            Screen_id = screen_id;
            Screen_Width = screen_width;
            Screen_Height = screen_height;
            Screen_Factor = screen_factor;
            Screen_Types = screen_types;
            Screen_WindoorID = screen_windoorID;
            Screen_UnitPrice = screen_unitPrice;
            Screen_Quantity = screen_quantity;
            Screen_TotalAmount = screen_totalAmount;
        }
    }
}
