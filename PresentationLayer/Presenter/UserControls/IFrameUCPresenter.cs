﻿using System;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IFrameUCPresenter
    {
        void OnFrameLoadEventRaised(object sender, EventArgs e);
        void OnInnerFramePaintEventRaised(object sender, PaintEventArgs e);
        void OnOuterFramePaintEventRaised(object sender, PaintEventArgs e);
        void SetValues(IFrameModel frameModel);
        IFrameUC GetFrameUC();
        IFrameUCPresenter GetNewInstance(IFrameModel frameModel);
    }
}