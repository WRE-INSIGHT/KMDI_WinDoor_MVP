using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ISetMultipleGlassThicknessView
    {
        string Glass_Type { get; set; }
        List<string> Panel_ID { get; set; }

        event EventHandler cmbSelectGlassTypeEventRaised;
        event DataGridViewRowPostPaintEventHandler dgvSetMultipleGlassRowPostPaineEventRaised;
        event EventHandler mouseClickEventRaised;
        event EventHandler setMultipleGlassThicknessLoadEventRaised;

        void CloseThisDialog();
        DataGridView Get_DgvGlassList();
        void ShowMultipleThckView();



    }
}