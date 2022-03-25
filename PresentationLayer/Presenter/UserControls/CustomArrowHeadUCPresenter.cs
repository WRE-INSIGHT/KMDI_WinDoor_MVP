using PresentationLayer.Views.UserControls;
using System;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class CustomArrowHeadUCPresenter : ICustomArrowHeadUCPresenter
    {
        ICustomArrowHeadUC _customArrowHeadUC;

        private ICustomArrowHeadPresenter _customArrowHeadPresenter;
        private IUnityContainer _unityC;
        public CustomArrowHeadUCPresenter(ICustomArrowHeadUC customArrowHeadUC)
        {
            _customArrowHeadUC = customArrowHeadUC;
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _customArrowHeadUC.NudArrowSizeValueChangeEventRaised += _customArrowHeadUC_NudArrowSizeValueChangeEventRaised;
            _customArrowHeadUC.BtnDeleteArrowHeadClickEventRaised += _customArrowHeadUC_BtnDeleteArrowHeadClickEventRaised;
        }


        private void _customArrowHeadUC_NudArrowSizeValueChangeEventRaised(object sender, EventArgs e)
        {
            int ArrowSizeLength = Convert.ToInt16(((NumericUpDown)sender).Value);
        }

        private void _customArrowHeadUC_BtnDeleteArrowHeadClickEventRaised(object sender, EventArgs e)
        {
            _customArrowHeadPresenter.ArrowWD_Count--;
            _customArrowHeadPresenter.Remove_ArrowHeadUCP(this);

            Control CustomArrowHeadUCParent = ((UserControl)_customArrowHeadUC).Parent;
            CustomArrowHeadUCParent.Controls.Remove((UserControl)_customArrowHeadUC);
        }

        public ICustomArrowHeadUC GetCustomArrowUC()
        {
            return _customArrowHeadUC;
        }

        public ICustomArrowHeadUCPresenter GetNewInstance(IUnityContainer unityC, ICustomArrowHeadPresenter customArrowHeadPresenter)
        {
            unityC
                 .RegisterType<ICustomArrowHeadUC, CustomArrowHeadUC>()
                 .RegisterType<ICustomArrowHeadUCPresenter, CustomArrowHeadUCPresenter>();
            CustomArrowHeadUCPresenter presenter = unityC.Resolve<CustomArrowHeadUCPresenter>();
            presenter._unityC = unityC;
            presenter._customArrowHeadPresenter = customArrowHeadPresenter;
            return presenter;
        }
    }
}
