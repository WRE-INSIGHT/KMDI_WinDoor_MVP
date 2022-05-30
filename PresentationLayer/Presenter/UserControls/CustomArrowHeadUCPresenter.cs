using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using System;
using System.Drawing;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class CustomArrowHeadUCPresenter : ICustomArrowHeadUCPresenter
    {
        ICustomArrowHeadUC _customArrowHeadUC;

        private ICustomArrowHeadPresenter _customArrowHeadPresenter;
        private IWindoorModel _windoorModel;
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
            _customArrowHeadPresenter.ComputeTotalArrowLenght();
        }

        private void _customArrowHeadUC_BtnDeleteArrowHeadClickEventRaised(object sender, EventArgs e)
        {
            Control CustomArrowHeadUCParent = ((UserControl)_customArrowHeadUC).Parent;
            CustomArrowHeadUCParent.Controls.Remove((UserControl)_customArrowHeadUC);

            if (CustomArrowHeadUCParent.Name == "pnl_ArrowHeight")
            {
                _customArrowHeadPresenter.ArrowHT_Count--;
                _windoorModel.Lbl_ArrowHtCount--;
                _customArrowHeadPresenter.Remove_ArrowHeadUCP(this);
                _windoorModel.Dictionary_ht_redArrowLines.Remove(_customArrowHeadUC.ArrowId);
                _customArrowHeadPresenter.remove_Lst_arrowHt(_customArrowHeadUC);
                _customArrowHeadPresenter.GetICustomArrowHeadView().SetBtnSaveBackColor(SystemColors.Control);
            }

            if (CustomArrowHeadUCParent.Name == "pnl_ArrowWidth")
            {
                _customArrowHeadPresenter.ArrowWD_Count--;
                _windoorModel.Lbl_ArrowWdCount--;
                _customArrowHeadPresenter.Remove_ArrowHeadUCP(this);
                _windoorModel.Dictionary_wd_redArrowLines.Remove(_customArrowHeadUC.ArrowId);
                _customArrowHeadPresenter.remove_Lst_arrowWd(_customArrowHeadUC);
                _customArrowHeadPresenter.GetICustomArrowHeadView().SetBtnSaveBackColor(SystemColors.Control);
            }
            _customArrowHeadPresenter.ComputeTotalArrowLenght();
        }

        public ICustomArrowHeadUC GetCustomArrowUC()
        {
            return _customArrowHeadUC;
        }

        public ICustomArrowHeadUCPresenter GetNewInstance(IUnityContainer unityC,
                                                          ICustomArrowHeadPresenter customArrowHeadPresenter,
                                                          IWindoorModel windoorModel)
        {
            unityC
                 .RegisterType<ICustomArrowHeadUC, CustomArrowHeadUC>()
                 .RegisterType<ICustomArrowHeadUCPresenter, CustomArrowHeadUCPresenter>();
            CustomArrowHeadUCPresenter presenter = unityC.Resolve<CustomArrowHeadUCPresenter>();
            presenter._unityC = unityC;
            presenter._customArrowHeadPresenter = customArrowHeadPresenter;
            presenter._windoorModel = windoorModel;
            return presenter;
        }
    }
}
