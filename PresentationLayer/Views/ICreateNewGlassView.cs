using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ICreateNewGlassView
    {
        void CloseThis();
        void ShowThis();

        event EventHandler NewGlassViewLoadEventRaised;
        event EventHandler GlassThicknessTextChange;
        event EventHandler BtnAddGlassClick;

        bool pnlGlassVisible2 { set; }
        bool pnlGlassVisible3 { set; }
        bool pnlTotalGlassVisible { set; }
        string lblBetweenTheGlass { set; }
        string lblGlassHeader { set; }
        string lblDescriptionView { get; set; }
        string cmbGlassType_1 { get; set; }
        string cmbGlassType_2 { get; set; }
        string cmbGlassType_3 { get; set; }
        string cmbColor_1 { get; set; }
        string cmbColor_2 { get; set; }
        string cmbColor_3 { get; set; }
        string cmbBetweenTheGlass_1 { get; set; }
        string cmbBetweenTheGlass_2 { get; set; }
        int GlassViewHeight { set; }
        int cmbSelectedindex { set; }

        //int tboxGlassThickness_1 { get; set; }
        //int tboxGlassThickness_2 { get; set; }
        //int tboxGlassThickness_3 { get; set; }
        //string tboxBetweenTheGlass_1 { get; set; }
        //string tboxBetweenTheGlass_2 { get; set; }
        //int tboxTotalGlassThickness1 { get; set; }

        NumericUpDown GetNudGlassThickness1();
        NumericUpDown GetNudGlassThickness2();
        NumericUpDown GetNudGlassThickness3();
        NumericUpDown GetNudBetweenTheGlass1();
        NumericUpDown GetNudBetweenTheGlass2();

        TextBox GetTboxTotalGlassThickness1();




    }
}