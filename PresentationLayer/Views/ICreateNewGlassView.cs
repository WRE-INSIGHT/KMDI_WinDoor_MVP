using System;

namespace PresentationLayer.Views
{
    public interface ICreateNewGlassView
    {
        void CloseThis();
        void ShowThis();

        event EventHandler NewGlassViewLoadEventRaised;
        event EventHandler GlassThicknessTextChange;


        bool pnlGlassVisible2 { set; }
        bool pnlGlassVisible3 { set; }
        bool pnlTotalGlassVisible { set; }
        string lblBetweenTheGlass { set; }
        string lblGlassHeader { set; }
        string lblDescriptionView { set; }
        int GlassViewHeight { set; }
        int cmbSelectedindex { set; }
        int tboxGlassThickness_1 { get; set; }





    }
}