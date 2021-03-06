﻿using CommonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ModelLayer.Model.Quotation.Frame.FrameModel;

namespace PresentationLayer.Views.UserControls
{
    public interface IFramePropertiesUC: IViewCommon
    {
        int FrameID { get; set; }
        event EventHandler FramePropertiesLoadEventRaised;
        event EventHandler NumFHeightValueChangedEventRaised;
        event EventHandler NumFWidthValueChangedEventRaised;
        event EventHandler RdBtnCheckedChangedEventRaised;
        void BringToFrontThis();
        FlowLayoutPanel GetFramePropertiesFLP();
        void SetFrameTypeRadioBtnEnabled(bool frameTypeEnabled);
    }
}
