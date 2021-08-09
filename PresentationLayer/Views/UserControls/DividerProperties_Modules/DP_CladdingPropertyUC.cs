using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.DividerProperties_Modules
{
    public partial class DP_CladdingPropertyUC : UserControl, IDP_CladdingPropertyUC
    {
        public DP_CladdingPropertyUC()
        {
            InitializeComponent();
        }

        public int Cladding_Size
        {
            get
            {
                return (int)num_CladdingSize.Value;
            }

            set
            {
                num_CladdingSize.Value = value;
            }
        }

        private int _claddingID;
        public int Cladding_ID
        {
            get
            {
                return _claddingID;
            }
            set
            {
                _claddingID = value;
            }
        }

        private string _htwd;
        private string _divType;
        public string Divider_Type
        {
            get
            {
                return _divType;
            }
            set
            {
                _divType = value;
                if (_divType == "Mullion")
                {
                    _htwd = "Height";
                }
                else if (_divType == "Transom")
                {
                    _htwd = "Width";
                }
                lbl_CladdingSize.Text = _htwd;
            }
        }

        public event EventHandler DPCladdingPropertyUCLoadEventRaised;
        public event EventHandler numCladdingSizeValueChangedEventRaised;
        public event EventHandler btnDeleteCladdingClickedEventRaised;

        private void DP_CladdingPropertyUC_Load(object sender, EventArgs e)
        {
            num_CladdingSize.Maximum = decimal.MaxValue;
            EventHelpers.RaiseEvent(this, DPCladdingPropertyUCLoadEventRaised, e);
        }

        private void num_CladdingSize_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, numCladdingSizeValueChangedEventRaised, e);
        }

        private void btn_DeleteCladding_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnDeleteCladdingClickedEventRaised, e);
        }
    }
}
