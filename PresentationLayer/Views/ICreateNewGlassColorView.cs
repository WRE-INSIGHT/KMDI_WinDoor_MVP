using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ICreateNewGlassColorView
    {
        string tboxGlassColorView { get; set; }

        void ShowThis();
        void CloseThis();
        DataGridView GetDgvGlassColorList();

        event EventHandler OnCreateNewGlassColorViewLoadEventRaised;
        event EventHandler OnBtnAddGlassColorClickEventRaised;
        event DataGridViewRowPostPaintEventHandler DgvGlassColorListRowpostpaintEventRaised;
    }
}
