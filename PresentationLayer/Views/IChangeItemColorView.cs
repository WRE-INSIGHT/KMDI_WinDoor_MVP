using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IChangeItemColorView : IViewCommon
    {
        event EventHandler BtnOkClickEventRaised;
        event EventHandler ChangeItemColorViewLoadEventRaised;
        event EventHandler CmbBaseColorSelectedValueChangedEventRaised;
        event EventHandler CmbInsideColorSelectedValueChangedEventRaised;
        event EventHandler CmbOutsideColorSelectedValueChangedEventRaised;
        event EventHandler nudWoodecAdditionalValueChangedEventRaised;
        event EventHandler CmbColorAppliedToSelectedValueChangedEventRaised;

        void ShowThisDialog();
        void CloseView();
        Panel GetPanelWoodec();
        NumericUpDown GetNudWoodec();
        ComboBox GetColorAppliedTo();


    }
}