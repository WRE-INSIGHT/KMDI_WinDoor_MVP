using System;
using ModelLayer.Model.Quotation.Divider;
using CommonComponents;
using System.Windows.Forms;
using System.Drawing;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls
{
    public interface IDividerPropertiesUC : IViewCommon
    {
        int Div_ID { get; set; }
        DividerModel.DividerType Divider_Type { get;  set; }
        SashProfile_ArticleNo Panel_SashProfileArtNo { get; set; }

        event EventHandler PanelPropertiesLoadEventRaised;
        event EventHandler CmbdivArtNoSelectedValueChangedEventRaised;
        event EventHandler btnAddCladdingClickedEventRaised;
        event EventHandler btnSaveCladdingClickedEventRaised;
        event EventHandler chkDMCheckedChangedEventRaised;
        event EventHandler cmbDMArtNoSelectedValueChangedEventRaised;
        event EventHandler btnSelectDMPanelClickedEventRaised;

        Panel GetDividerPropertiesBodyPNL();
        Button GetBtnSelectDMPanel();
        void SetBtnSaveBackColor(Color color);
    }
}