using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class SlidingScreenView : Form, ISlidingScreenView
    {
        public SlidingScreenView()
        {
            InitializeComponent();
        }

        #region Prop

        public void ShowSlidingView()
        {
            this.Show();
        }
        public void CloseSlidingView()
        {
            this.Close();
        }

        public TextBox CostingFactor
        {
            get
            {
                return txtbox_costingfactor;
            }
            set
            {
                txtbox_costingfactor = value;
            }
        }
        public ComboBox Profile()
        {
            return cmbbox_profile; 
        }
        public ComboBox Frame()
        {
            return cmbbox_frame;
        }
        public ComboBox Sash()
        {
            return cmbbox_sash;
        }
        public NumericUpDown NumberofRails
        {
            get
            {
                return num_rails;
            }
            set
            {
                num_rails.Value = Convert.ToInt32(value);
            }
        }
        public NumericUpDown NumberofSlidingPanels
        {
            get
            {
                return num_slidingpanels;
            }
            set
            {
                num_slidingpanels.Value = Convert.ToInt32(value);
            }
        }
        public NumericUpDown NumberofFixedPanels
        {
            get
            {
                return num_fixedpanels;
            }
            set
            {
                num_fixedpanels.Value = Convert.ToInt32(value);
            }
        }
        public ComboBox BottomFrame()
        {
            return cmbbox_bottomframe;
        }
        public ComboBox SlidingHandle()
        {
            return cmbbox_handle;
        }
        public ComboBox Locking()
        {
            return cmbbox_locking;
        }
        public ComboBox DummyHandle()
        {
            return cmbbox_dummyhandle;
        }
        public ComboBox FixedWithTransom()
        {
            return cmbbox_fixedTwithTransom;
        }
        public NumericUpDown FixedTransomHeight
        {
            get
            {
                return num_fixedTTransomheight;
            }
            set
            {
                num_fixedTTransomheight.Value = Convert.ToDecimal(value);
            }
        }
        public NumericUpDown FixedTransomNumberofPanels
        {
            get
            {
                return num_fixedTNoofPanel;
            }
            set
            {
                num_fixedTNoofPanel.Value = Convert.ToInt32(value);
            }
        }
        public ComboBox MullionStrengthener()
        {
            return cmbbox_mullionStrengthener;
        }
        public ComboBox MovingTransomInsideSash()
        {
            return cmbbox_movingTinsideSash;
        }
        public ComboBox MovingTransomDirection()
        {
            return cmbbox_movingTDirection;
        }
        public NumericUpDown MovingTransomNumberofPanels
        {
            get
            {
                return num_movingTNoofPanel;
            }
            set
            {
                num_movingTNoofPanel.Value = Convert.ToInt32(value);
            }
        }

        public TextBox Design
        {
            get
            {
                return txtbox_userdefineDesign;
            }
            set
            {
                txtbox_userdefineDesign = value;
            }
        }
        public NumericUpDown SlidingWidth
        {
            get
            {
                return num_width;
            }
            set
            {
                num_width.Value = Convert.ToDecimal(value);
            }
        }
        public NumericUpDown SlidingHeight
        {
            get
            {
                return num_height;
            }
            set
            {
                num_height.Value = Convert.ToDecimal(value);
            }
        }

        public Label FixedTransomHeightLabel()
        {
            return lbl_fixedTTransomheight;
        }
        public Label FixedTrasomNumberofPanelsLabel()
        {
            return lbl_fixedTNoofPanel;
        }
        public Label MovingTransomDirectionLabel()
        {
            return lbl_movingTTransomheight;
        }
        public Label MovingTransomNumberofPanelsLabel()
        {
            return lbl_movingTNoofPanel;
        }

        #endregion

        #region EventHandler

        public event EventHandler cmbbox_profile_SelectedValueChangedEventRaised;
        public event EventHandler cmbbox_frame_SelectedValueChangedEventRaised;
        public event EventHandler cmbbox_sash_SelectedValueChangedEventRaised;
        public event EventHandler num_rails_ValueChangedEventRaised;
        public event EventHandler num_slidingpanels_ValueChangedEventRaised;
        public event EventHandler num_fixedpanels_ValueChangedEventRaised;
        public event EventHandler cmbbox_bottomframe_SelectedValueChangedEventRaised;
        public event EventHandler cmbbox_handle_SelectedValueChangedEventRaised;
        public event EventHandler cmbbox_locking_SelectedValueChangedEventRaised;
        public event EventHandler cmbbox_dummyhandle_SelectedValueChangedEventRaised;

        public event EventHandler cmbbox_fixedTwithTransom_SelectedValueChangedEventRaised;
        public event EventHandler num_fixedTTransomheight_ValueChangedEventRaised;
        public event EventHandler num_fixedTNoofPanel_ValueChangedEventRaised;
        public event EventHandler cmbbox_mullionStrengthener_SelectedValueChangedEventRaised;
        public event EventHandler cmbbox_movingTinsideSash_SelectedValueChangedEventRaised;
        public event EventHandler cmbbox_movingTDirection_SelectedValueChangedEventRaised;
        public event EventHandler num_movingTNoofPanel_ValueChangedEventRaised;

        public event EventHandler txtbox_userdefineDesign_TextChangedEventRaised;
        public event EventHandler num_width_ValueChangedEventRaised;
        public event EventHandler num_height_ValueChangedEventRaised;

        public event EventHandler btn_addScreen_ClickEventRaised;

        public event EventHandler SlidingScreenView_LoadEventRaised;



        #endregion

        #region Events

        private void SlidingScreenView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SlidingScreenView_LoadEventRaised, e);
        }

        private void cmbbox_profile_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbbox_profile_SelectedValueChangedEventRaised, e);
        }

        private void cmbbox_frame_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbbox_frame_SelectedValueChangedEventRaised, e);
        }

        private void cmbbox_sash_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbbox_sash_SelectedValueChangedEventRaised, e);
        }

        private void num_rails_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, num_rails_ValueChangedEventRaised, e);
        }

        private void num_slidingpanels_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, num_slidingpanels_ValueChangedEventRaised, e);
        }

        private void num_fixedpanels_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, num_fixedpanels_ValueChangedEventRaised, e);
        }

        private void cmbbox_bottomframe_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbbox_bottomframe_SelectedValueChangedEventRaised, e);
        }

        private void cmbbox_handle_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbbox_handle_SelectedValueChangedEventRaised, e);
        }

        private void cmbbox_locking_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbbox_locking_SelectedValueChangedEventRaised, e);
        }

        private void cmbbox_dummyhandle_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbbox_dummyhandle_SelectedValueChangedEventRaised, e);
        }

        private void cmbbox_fixedTwithTransom_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbbox_fixedTwithTransom_SelectedValueChangedEventRaised, e);
        }

        private void num_fixedTTransomheight_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, num_fixedTTransomheight_ValueChangedEventRaised, e);
        }

        private void num_fixedTNoofPanel_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, num_fixedTNoofPanel_ValueChangedEventRaised, e);
        }

        private void cmbbox_mullionStrengthener_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbbox_mullionStrengthener_SelectedValueChangedEventRaised, e);
        }

        private void cmbbox_movingTinsideSash_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbbox_movingTinsideSash_SelectedValueChangedEventRaised, e);
        }

        private void cmbbox_movingTDirection_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbbox_movingTDirection_SelectedValueChangedEventRaised, e);
        }

        private void num_movingTNoofPanel_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, num_movingTNoofPanel_ValueChangedEventRaised, e);
        }
        

        private void txtbox_userdefineDesign_TextChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, txtbox_userdefineDesign_TextChangedEventRaised, e);
        }

        private void num_width_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, num_width_ValueChangedEventRaised, e);
        }

        private void num_height_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, num_height_ValueChangedEventRaised, e);
        }

        private void btn_addScreen_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btn_addScreen_ClickEventRaised, e);
        }
        #endregion


    }
}
