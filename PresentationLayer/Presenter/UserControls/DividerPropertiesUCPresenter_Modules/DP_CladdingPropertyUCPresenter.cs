using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.Views.UserControls.DividerProperties_Modules;
using System;
using System.Drawing;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.DividerPropertiesUCPresenter_Modules
{
    public class DP_CladdingPropertyUCPresenter : IDP_CladdingPropertyUCPresenter
    {
        IDP_CladdingPropertyUC _dp_claddingPropertyUC;

        private IUnityContainer _unityC;
        private IDividerModel _dividerModel;
        private IMainPresenter _mainPresenter;
        private IDividerPropertiesUCPresenter _divPropUCP;

        public DP_CladdingPropertyUCPresenter(IDP_CladdingPropertyUC dp_claddingPropertyUC)
        {
            _dp_claddingPropertyUC = dp_claddingPropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _dp_claddingPropertyUC.DPCladdingPropertyUCLoadEventRaised += _dp_claddingPropertyUC_DPCladdingPropertyUCLoadEventRaised;
            _dp_claddingPropertyUC.numCladdingSizeValueChangedEventRaised += _dp_claddingPropertyUC_numCladdingSizeValueChangedEventRaised;
            _dp_claddingPropertyUC.btnDeleteCladdingClickedEventRaised += _dp_claddingPropertyUC_btnDeleteCladdingClickedEventRaised;
        }

        private void _dp_claddingPropertyUC_btnDeleteCladdingClickedEventRaised(object sender, EventArgs e)
        {
            int propertiesScroll = _mainPresenter.PropertiesScroll;
            _dividerModel.Div_CladdingCount--;

            _dividerModel.AdjustPropertyPanelHeight("minusCladding");
            _dividerModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusCladding");
            _dividerModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusCladding");

            if (_dividerModel.Div_CladdingCount == 0)
            {
                _dividerModel.Div_CladdingProfileArtNoVisibility = false;
                _dividerModel.AdjustPropertyPanelHeight("minusCladdingArtNo");
                _dividerModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusCladdingArtNo");
                _dividerModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusCladdingArtNo");

                _dividerModel.Div_CladdingSizeList.Clear();
 
            }


            _divPropUCP.Cladding_Count--;
            _divPropUCP.SetSaveBtnColor(Color.White);
            _divPropUCP.Remove_CladdingUCP(this);
            _divPropUCP.Refresh_LblTotalCladdingLength();

            Control pnl_parent = ((UserControl)_dp_claddingPropertyUC).Parent;
            pnl_parent.Controls.Remove((UserControl)_dp_claddingPropertyUC);
            _mainPresenter.PropertiesScroll = propertiesScroll;
            _mainPresenter.GetCurrentPrice();
        }

        private void _dp_claddingPropertyUC_numCladdingSizeValueChangedEventRaised(object sender, EventArgs e)
        {
            _divPropUCP.SetSaveBtnColor(Color.White);
            int claddLength = Convert.ToInt16(((NumericUpDown)sender).Value);
            _divPropUCP.Refresh_LblTotalCladdingLength();
        }

        private void _dp_claddingPropertyUC_DPCladdingPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _dp_claddingPropertyUC.Divider_Type = _dividerModel.Div_Type.ToString();
        }

        public IDP_CladdingPropertyUC GetCladdingPropertyUC()
        {
            return _dp_claddingPropertyUC;
        }

        public IDP_CladdingPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                              IDividerModel divModel,
                                                              IMainPresenter mainPresenter,
                                                              IDividerPropertiesUCPresenter divPropUCP)
        {
            unityC
                .RegisterType<IDP_CladdingPropertyUC, DP_CladdingPropertyUC>()
                .RegisterType<IDP_CladdingPropertyUCPresenter, DP_CladdingPropertyUCPresenter>();
            DP_CladdingPropertyUCPresenter presenter = unityC.Resolve<DP_CladdingPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._dividerModel = divModel;
            presenter._divPropUCP = divPropUCP;
            presenter._mainPresenter = mainPresenter;
            return presenter;
        }
    }
}
