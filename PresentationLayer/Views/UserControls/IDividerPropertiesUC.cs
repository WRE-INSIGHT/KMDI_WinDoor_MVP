using System;
using ModelLayer.Model.Quotation.Divider;
using CommonComponents;
using System.Windows.Forms;
using System.Drawing;

namespace PresentationLayer.Views.UserControls
{
    public interface IDividerPropertiesUC : IViewCommon
    {
        int Div_ID { get; set; }
        DividerModel.DividerType Divider_Type { get;  set; }

        event EventHandler PanelPropertiesLoadEventRaised;
        event EventHandler CmbdivArtNoSelectedValueChangedEventRaised;
        event EventHandler btnAddCladdingClickedEventRaised;
        event EventHandler btnSaveCladdingClickedEventRaised;
        event EventHandler chkDMCheckedChangedEventRaised;

        Panel GetDividerPropertiesBodyPNL();
        void SetBtnSaveBackColor(Color color);
    }
}