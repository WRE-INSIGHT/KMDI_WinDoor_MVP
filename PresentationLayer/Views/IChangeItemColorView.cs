using CommonComponents;
using System;

namespace PresentationLayer.Views
{
    public interface IChangeItemColorView : IViewCommon
    {
        event EventHandler BtnOkClickEventRaised;
        event EventHandler ChangeItemColorViewLoadEventRaised;
        event EventHandler CmbBaseColorSelectedValueChangedEventRaised;
        event EventHandler CmbInsideColorSelectedValueChangedEventRaised;
        event EventHandler CmbOutsideColorSelectedValueChangedEventRaised;

        void ShowThisDialog();
        void CloseView();
    }
}