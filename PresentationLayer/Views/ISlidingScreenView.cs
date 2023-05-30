using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ISlidingScreenView
    {
        TextBox CostingFactor { get; set; }
        TextBox Design { get; set; }
        NumericUpDown FixedTransomHeight { get; set; }
        NumericUpDown FixedTransomNumberofPanels { get; set; }
        NumericUpDown MovingTransomNumberofPanels { get; set; }
        NumericUpDown NumberofFixedPanels { get; set; }
        NumericUpDown NumberofRails { get; set; }
        NumericUpDown NumberofSlidingPanels { get; set; }
        NumericUpDown SlidingHeight { get; set; }
        NumericUpDown SlidingWidth { get; set; }

        event EventHandler btn_addScreen_ClickEventRaised;
        event EventHandler cmbbox_bottomframe_SelectedValueChangedEventRaised;
        event EventHandler cmbbox_dummyhandle_SelectedValueChangedEventRaised;
        event EventHandler cmbbox_fixedTwithTransom_SelectedValueChangedEventRaised;
        event EventHandler cmbbox_frame_SelectedValueChangedEventRaised;
        event EventHandler cmbbox_handle_SelectedValueChangedEventRaised;
        event EventHandler cmbbox_locking_SelectedValueChangedEventRaised;
        event EventHandler cmbbox_movingTDirection_SelectedValueChangedEventRaised;
        event EventHandler cmbbox_movingTinsideSash_SelectedValueChangedEventRaised;
        event EventHandler cmbbox_mullionStrengthener_SelectedValueChangedEventRaised;
        event EventHandler cmbbox_profile_SelectedValueChangedEventRaised;
        event EventHandler cmbbox_sash_SelectedValueChangedEventRaised;
        event EventHandler num_fixedpanels_ValueChangedEventRaised;
        event EventHandler num_fixedTNoofPanel_ValueChangedEventRaised;
        event EventHandler num_fixedTTransomheight_ValueChangedEventRaised;
        event EventHandler num_height_ValueChangedEventRaised;
        event EventHandler num_movingTNoofPanel_ValueChangedEventRaised;
        event EventHandler num_rails_ValueChangedEventRaised;
        event EventHandler num_slidingpanels_ValueChangedEventRaised;
        event EventHandler num_width_ValueChangedEventRaised;
        event EventHandler txtbox_userdefineDesign_TextChangedEventRaised;
        event EventHandler SlidingScreenView_LoadEventRaised;

        ComboBox BottomFrame();
        void CloseSlidingView();
        ComboBox DummyHandle();
        Label FixedTransomHeightLabel();
        Label FixedTrasomNumberofPanelsLabel();
        ComboBox FixedWithTransom();
        ComboBox Frame();
        ComboBox Locking();
        ComboBox MovingTransomDirection();
        Label MovingTransomDirectionLabel();
        ComboBox MovingTransomInsideSash();
        Label MovingTransomNumberofPanelsLabel();
        ComboBox MullionStrengthener();
        ComboBox Profile();
        ComboBox Sash();
        void ShowSlidingView();
        ComboBox SlidingHandle();
    }
}