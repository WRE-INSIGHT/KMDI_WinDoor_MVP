using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ICreateNewGlassSpacerView
    {
        string tboxGlassSpacerView { get; set; }
        void ShowThis();
        void CloseThis();

        DataGridView GetDgvGlassSpacerList();

        event EventHandler OnCreateNewGlassSpacerViewLoadEventRaised;
        event EventHandler OnBtnAddGlassSpacerClickEventRaised;
        event DataGridViewRowPostPaintEventHandler OnDgvGlassSpacerListRowpostpaintEventRaised;

    }
}
