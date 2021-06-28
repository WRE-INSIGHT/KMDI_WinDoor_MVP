using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IGlassThicknessListView
    {
        event EventHandler GlassThicknessListViewLoadEventRaised;

        DataGridView Get_DgvGlassThicknessList();
        void ShowThisDialog();
    }
}