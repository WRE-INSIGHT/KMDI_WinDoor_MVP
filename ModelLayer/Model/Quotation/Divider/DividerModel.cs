using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelLayer.Model.Quotation.Divider
{
    public class DividerModel : IDividerModel, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public enum DividerType
        {
            Mullion = 0,
            Transom = 1
        }

        private int _divID;
        public int Div_ID
        {
            get
            {
                return _divID;
            }
            set
            {
                _divID = value;
                NotifyPropertyChanged();
            }
        }

        private string _divName;
        public string Div_Name
        {
            get
            {
                return _divName;
            }
            set
            {
                _divName = value;
                NotifyPropertyChanged();
            }
        }

        private DividerType _divType;
        public DividerType Div_Type
        {
            get
            {
                return _divType;
            }
            set
            {
                _divType = value;
            }
        }

        private int _divWd;
        public int Div_Width
        {
            get
            {
                return _divWd;
            }
            set
            {
                _divWd = value;
                NotifyPropertyChanged();
            }
        }

        private int _divHt;
        public int Div_Height
        {
            get
            {
                return _divHt;
            }
            set
            {
                _divHt = value;
                NotifyPropertyChanged();
            }
        }

        private bool _divVisibility;
        public bool Div_Visible
        {
            get
            {
                return _divVisibility;
            }
            set
            {
                _divVisibility = value;
            }
        }

        private Control _divParent;
        public Control Div_Parent
        {
            get
            {
                return _divParent;
            }
            set
            {
                _divParent = value;
            }
        }
        private UserControl _divFrameGroup;
        public UserControl Div_FrameGroup
        {
            get
            {
                return _divFrameGroup;
            }
            set
            {
                _divFrameGroup = value;
            }
        }

        public DividerModel(int divID,
                            string divName,
                            int divWD,
                            int divHT,
                            bool divVisibility,
                            DividerType divType,
                            Control divParent,
                            UserControl divFrameGroup)
        {
            Div_ID = divID;
            Div_Name = divName;
            Div_Width = divWD;
            Div_Height = divHT;
            Div_Visible = divVisibility;
            Div_Type = divType;
            Div_Parent = divParent;
            Div_FrameGroup = divFrameGroup;
        }
    }
}
