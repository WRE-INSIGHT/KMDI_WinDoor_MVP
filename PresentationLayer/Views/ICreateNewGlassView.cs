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
        bool SpacerVisible { set; }
        string lblBetweenTheGlass { set; }
        string lblGlassHeader { set; }
        string lblDescriptionView { get; set; }
        int GlassViewHeight { set; }

        NumericUpDown GlassThickness1 { get; set; }
        NumericUpDown GlassThickness2 { get; set; }
        NumericUpDown GlassThickness3 { get; set; }
        NumericUpDown BetweenTheGlass1 { get; set; }
        NumericUpDown BetweenTheGlass2 { get; set; }
        NumericUpDown TotalThickness { get; set; }

        ComboBox GlassType1();
        ComboBox GlassType2();
        ComboBox GlassType3();
        ComboBox Color1();
        ComboBox Color2();
        ComboBox Color3();
        ComboBox Spacer1();
        ComboBox Spacer2();




    }
}