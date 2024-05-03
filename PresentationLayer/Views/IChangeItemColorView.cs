using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IChangeItemColorView : IViewCommon
    {
        string FromMainpresenter_profileType { get; set; }

        event EventHandler BtnOkClickEventRaised;
        event EventHandler ChangeItemColorViewLoadEventRaised;
        event EventHandler CmbBaseColorSelectedValueChangedEventRaised;
        event EventHandler CmbInsideColorSelectedValueChangedEventRaised;
        event EventHandler CmbOutsideColorSelectedValueChangedEventRaised;
        event EventHandler nudWoodecAdditionalValueChangedEventRaised;
        event EventHandler CmbColorAppliedToSelectedValueChangedEventRaised;

        void ShowThisDialog();
        void CloseView();
        Panel GetPanelInOutColor();
        Panel GetPanelWoodec();
        NumericUpDown GetNudWoodec();
        ComboBox GetColorAppliedTo();


    }
}