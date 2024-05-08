using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Variables;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_CenterProfilePropertyUCPresenter : IPP_CenterProfilePropertyUCPresenter
    {
        IPP_CenterProfilePropertyUC _centerProfilePropertyUC;

        private IMainPresenter _mainPresenter;
        private IUnityContainer _unityC;
        private IPanelModel _panelModel;
        private IFramePropertiesUCPresenter _framePropertiesUCPresenter;

        bool withCenterProfile = false;

        Panel _pnlCenterProfileSelectedPanel;

        ConstantVariables constants = new ConstantVariables();
         
        public PP_CenterProfilePropertyUCPresenter(IPP_CenterProfilePropertyUC centerProfilePropertyUC)
        {
            _centerProfilePropertyUC = centerProfilePropertyUC;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _centerProfilePropertyUC.CenterProfilePropertyUCLoadEventRaised += _centerProfilePropertyUC_CenterProfilePropertyUCLoadEventRaised;
            _centerProfilePropertyUC.CenterProfileArtNoSelectedValueChangedEventRaised += _centerProfilePropertyUC_CenterProfileArtNoSelectedValueChangedEventRaised;
            _centerProfilePropertyUC.btnSelectCPPanelClickEventRiased += _centerProfilePropertyUC_btnSelectCPPanelClickEventRiased;
           

            _pnlCenterProfileSelectedPanel = _centerProfilePropertyUC.GetCenterProfileSelectedPanel();
        }

        private void _centerProfilePropertyUC_btnSelectCPPanelClickEventRiased(object sender, EventArgs e)
        {
            List<IPanelModel> lst_pnl = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Panel;
            IPanelModel CurrentPanel = lst_pnl.Find(obj => obj.Panel_Name == _panelModel.Panel_Name);
            IPanelModel prev_pnl = null, nxt_pnl = null;
            int ndx = lst_pnl.IndexOf(CurrentPanel);
            string prev_pnl_str = lst_pnl[ndx - 1].Panel_Name;

            CurrentPanel.Panel_BackColor = Color.Red;
            //prev_pnl = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Panel.Find(prev => prev.Panel_Name == prev_pnl_str);
            //prev_pnl.Panel_BackColor = Color.Red;

            //string nxt_pnl_str = "";
            //if (lst_pnl.Count > ndx + 1)
            //{
            //    nxt_pnl_str = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Panel[ndx + 1].Panel_Name;
            //    nxt_pnl = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Panel.Find(prev => prev.Panel_Name == nxt_pnl_str);
            //    nxt_pnl.Panel_BackColor = SystemColors.Highlight;
            //}

            //if (_panelModel.Panel_ParentMultiPanelModel.MPanel_DividerEnabled == false)
            //{
            //    _mainPresenter.SetLblStatus("DMPreSelection", true, (Control)sender, _divModel, prev_pnl, nxt_pnl, this);
            //}
            //else
            //{
            //    MessageBox.Show("Not applicable on fixed panels", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
        }

        private void _centerProfilePropertyUC_CenterProfileArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (_mainPresenter.ItemLoad == false)
            {
                _panelModel.Panel_CenterProfileArtNo = (CenterProfile_ArticleNo)((ComboBox)sender).SelectedValue;
            }

            ComboBox CenterProfileArtNo = (ComboBox)sender;

            if (CenterProfileArtNo.SelectedValue.ToString() == CenterProfile_ArticleNo._None.ToString())
            {
                _pnlCenterProfileSelectedPanel.Visible = false;
                if (withCenterProfile == true)
                {
                    _centerProfilePropertyUC.AddHT_FormBody(-constants.frame_WithCenterClosureSelectedPanel);
                    withCenterProfile = false;
                }
               

            }
            else  
            {
                _pnlCenterProfileSelectedPanel.Visible = true;

                if (withCenterProfile == false)
                {
                    _centerProfilePropertyUC.AddHT_FormBody(constants.frame_WithCenterClosureSelectedPanel);
                    withCenterProfile = true; 
                }

            }

            Console.WriteLine(CenterProfile_ArticleNo._None.ToString());

        }

        private void _centerProfilePropertyUC_CenterProfilePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _centerProfilePropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_CenterProfilePropertyUC GetCenterProfilePropertyUC()
        {
            return _centerProfilePropertyUC;
        }

        public IPP_CenterProfilePropertyUCPresenter CreateNewInstance(IMainPresenter mainPresenter,
                                                                      IUnityContainer unityC,
                                                                      IPanelModel panelModel,
                                                                      IFramePropertiesUCPresenter framePropertiesUCPresenter)
        {
            unityC
                .RegisterType<IPP_CenterProfilePropertyUC, PP_CenterProfilePropertyUC>()
                .RegisterType<IPP_CenterProfilePropertyUCPresenter, PP_CenterProfilePropertyUCPresenter>();
            PP_CenterProfilePropertyUCPresenter CenterProfile = unityC.Resolve<PP_CenterProfilePropertyUCPresenter>();
            CenterProfile._mainPresenter = mainPresenter;
            CenterProfile._unityC = unityC;
            CenterProfile._panelModel = panelModel;
            CenterProfile._framePropertiesUCPresenter = framePropertiesUCPresenter;

            return CenterProfile;
        }
        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_CenterProfileVisibility", new Binding("Visible", _panelModel, "Panel_CenterProfileVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_CenterProfileArtNo", new Binding("Text", _panelModel, "Panel_CenterProfileArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
