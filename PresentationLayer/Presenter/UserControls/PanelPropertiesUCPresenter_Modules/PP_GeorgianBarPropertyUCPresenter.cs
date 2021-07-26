using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_GeorgianBarPropertyUCPresenter : IPP_GeorgianBarPropertyUCPresenter
    {
        IPP_GeorgianBarPropertyUC _pp_georgianBarPropertyUC;

        public PP_GeorgianBarPropertyUCPresenter(IPP_GeorgianBarPropertyUC pp_georgianBarPropertyUC)
        {
            _pp_georgianBarPropertyUC = pp_georgianBarPropertyUC;
            SubcribeToEventSetUp();
        }

        private void SubcribeToEventSetUp()
        {
            _pp_georgianBarPropertyUC.PPGeorgianBarPropertyUCLoadEventRaised += OnPPGeorgianBarPropertyUCLoadEventRaised;
            _pp_georgianBarPropertyUC.nudVerticalQuantityValueChanged += OnNudVerticalQuantityValueChangedEventRaised;
            _pp_georgianBarPropertyUC.nudHorizontalQuantityValueChanged += OnNudHorizontalQuantityValueChangedEventRaised;
        }
        private void OnNudVerticalQuantityValueChangedEventRaised(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnNudHorizontalQuantityValueChangedEventRaised(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnPPGeorgianBarPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
