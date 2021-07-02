using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ICreateNewGlassTypeView
    {

        string tboxGlassTypeView { get; set; }
        void CloseThis();
        void ShowThis();

        DataGridView GetDgvGlassTypeList();

        event EventHandler OnCreateNewGlassTypeViewLoadEventRaised;
        event EventHandler OnBtnAddGlassTypeClickEventRaised;
    }
}
