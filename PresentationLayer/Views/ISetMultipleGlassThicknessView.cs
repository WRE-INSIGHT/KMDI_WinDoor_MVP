using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ISetMultipleGlassThicknessView
    {
        event EventHandler cmbSelectGlassTypeEventRaised;
        event EventHandler mouseClickEventRaised;
        event EventHandler setMultipleGlassThicknessLoadEventRaised;

        DataGridView Get_DgvGlassList();
         void ShowMultipleThckView();
    }
}