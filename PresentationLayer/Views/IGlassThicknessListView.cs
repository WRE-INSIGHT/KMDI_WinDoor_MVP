using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IGlassThicknessListView
    {
        event EventHandler GlassThicknessListViewLoadEventRaised;
        event DataGridViewRowPostPaintEventHandler DgvGlassThicknessListRowpostpaintEventRaised;
        event DataGridViewCellEventHandler DgvGlassThicknessListCellDoubleClickEventRaised;
        event EventHandler txtboxsearchTextChangedEventRaised;
        string SearchVal { get; set; }
        DataGridView Get_DgvGlassThicknessList();
        void ShowThisDialog();
        void CloseThisDialog();
    }
}