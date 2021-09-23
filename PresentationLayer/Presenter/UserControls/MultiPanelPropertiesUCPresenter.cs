using CommonComponents;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Panel;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls
{
    public class MultiPanelPropertiesUCPresenter : IMultiPanelPropertiesUCPresenter, IPresenterCommon
    {
        IMultiPanelPropertiesUC _multiPanelPropertiesUC;

        private IUnityContainer _unityC;
        private IMultiPanelModel _multiPanelModel;
        
        private IMainPresenter _mainPresenter;

        public MultiPanelPropertiesUCPresenter(IMultiPanelPropertiesUC multiPanelPropertiesUC)
        {
            _multiPanelPropertiesUC = multiPanelPropertiesUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _multiPanelPropertiesUC.MultiPanelPropertiesLoadEventRaised += _multiPanelPropertiesUC_MultiPanelPropertiesLoadEventRaised;
            _multiPanelPropertiesUC.glassbalancingClickedEventRaised += _multiPanelPropertiesUC_glassbalancingClickedEventRaised;
        }

        private void _multiPanelPropertiesUC_glassbalancingClickedEventRaised(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmGB = (ToolStripMenuItem)sender;

            if (_multiPanelModel.MPanelLst_Panel.Count > 0)
            {
                _mainPresenter.Run_GetListOfMaterials_SpecificItem();

                string panel_GlassID = "";
                foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                {
                    panel_GlassID += ", P" + pnl.PanelGlass_ID;
                }
                string gbmode = "";
                SashProfile_ArticleNo ref_sash = _multiPanelModel.MPanelLst_Panel[0].Panel_SashProfileArtNo;
                bool same_sash = false;

                bool allWithSash = _multiPanelModel.MPanelLst_Panel.All(pnl => pnl.Panel_SashPropertyVisibility == true);
                bool allNoSash = _multiPanelModel.MPanelLst_Panel.All(pnl => pnl.Panel_SashPropertyVisibility == false);
                if (allWithSash == true && allNoSash == false)
                {
                    gbmode = "withSash";
                    int ref_sash_count = _multiPanelModel.MPanelLst_Panel.Select(pnl => pnl.Panel_SashProfileArtNo == ref_sash).Count();
                    if (ref_sash_count == _multiPanelModel.MPanelLst_Panel.Count)
                    {
                        same_sash = true;
                    }
                    else
                    {
                        same_sash = false;
                    }
                }
                else if (allWithSash == false && allNoSash == true)
                {
                    gbmode = "noSash";
                }
                else if (allWithSash == false && allNoSash == false)
                {
                    gbmode = "";
                }

                if (gbmode == "")
                {
                    MessageBox.Show("Cannot apply auto glass balancing" + "\n" + "You can apply auto glass balancing if all panel has sash or all panel has no sash",
                                    "Glass balancing not available",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tsmGB.Checked = false;
                }
                else if (gbmode != "")
                {
                    if (same_sash == true)
                    {
                        if (tsmGB.Checked == false)
                        {
                            DialogResult dr = MessageBox.Show("Confirm glass balancing on panel(s) " + panel_GlassID.Remove(0, 2) + "?", "Glass balancing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                if (tsmGB.Checked == false)
                                {
                                    foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                                    {
                                        pnl.Panel_Width = pnl.Panel_OriginalWidth;
                                        pnl.Panel_Height = pnl.Panel_OriginalHeight;
                                    }

                                    _multiPanelModel.SetEqualGlassDimension(gbmode, ref_sash);
                                    tsmGB.Checked = false;
                                }
                                tsmGB.Checked = true;
                            }
                        }
                        else if (tsmGB.Checked == true)
                        {
                            _multiPanelModel.MPanel_DisplayWidth = _multiPanelModel.MPanel_OriginalDisplayWidth;
                            _multiPanelModel.MPanel_DisplayHeight = _multiPanelModel.MPanel_OriginalDisplayHeight;

                            foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                            {
                                pnl.Panel_Width = pnl.Panel_OriginalWidth;
                                pnl.Panel_Height = pnl.Panel_OriginalHeight;

                                pnl.Panel_DisplayWidth = pnl.Panel_OriginalDisplayWidth;
                                pnl.Panel_DisplayHeight = pnl.Panel_OriginalDisplayHeight;
                            }

                            _multiPanelModel.Fit_MyControls_Dimensions();
                            _multiPanelModel.Fit_MyControls_ToBindDimensions();
                            _multiPanelModel.Adjust_ControlDisplaySize();

                            foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel)
                            {
                                mpnl.MPanel_DisplayWidth = mpnl.MPanel_OriginalDisplayWidth;
                                mpnl.MPanel_DisplayHeight = mpnl.MPanel_OriginalDisplayHeight;

                                mpnl.Fit_MyControls_Dimensions();
                                mpnl.Fit_MyControls_ToBindDimensions();
                                mpnl.Adjust_ControlDisplaySize();
                            }

                            tsmGB.Checked = false;
                        }

                        _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                        _mainPresenter.basePlatform_MainPresenter.Invalidate_flpMainControls();
                        _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                        _mainPresenter.basePlatformWillRenderImg_MainPresenter.Invalidate_flpMain();
                    }
                    else
                    {
                        MessageBox.Show("Cannot apply auto glass balancing" + "\n" + "You can apply auto glass balancing if all panel has same sash profile",
                                        "Glass balancing not available",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("No available panel(s)", "Glass balancing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tsmGB.Checked = false;
            }
        }

        private void _multiPanelPropertiesUC_MultiPanelPropertiesLoadEventRaised(object sender, EventArgs e)
        {
            _multiPanelPropertiesUC.ThisBinding(CreateBindingDictionary());
        }

        public IMultiPanelPropertiesUC GetMultiPanelPropertiesUC()
        {
            return _multiPanelPropertiesUC;
        }
        public IMultiPanelPropertiesUCPresenter GetNewInstance(IUnityContainer unityC,
                                                               IMultiPanelModel multiPanelModel,
                                                               IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IMultiPanelPropertiesUC, MultiPanelPropertiesUC>()
                .RegisterType<IMultiPanelPropertiesUCPresenter, MultiPanelPropertiesUCPresenter>();
            MultiPanelPropertiesUCPresenter multiPropUCP = unityC.Resolve<MultiPanelPropertiesUCPresenter>();
            multiPropUCP._unityC = unityC;
            multiPropUCP._mainPresenter = mainPresenter;
            multiPropUCP._multiPanelModel = multiPanelModel;

            return multiPropUCP;
        }
        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> multiPanelBinding = new Dictionary<string, Binding>();
            multiPanelBinding.Add("MPanel_ID", new Binding("MPanelID", _multiPanelModel, "MPanel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Width", new Binding("Value", _multiPanelModel, "MPanel_DisplayWidth", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Height", new Binding("Value", _multiPanelModel, "MPanel_DisplayHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Name", new Binding("Text", _multiPanelModel, "MPanel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Visibility", new Binding("Visible", _multiPanelModel, "MPanel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanelProp_Height", new Binding("Height", _multiPanelModel, "MPanelProp_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_PNumEnable1", new Binding("Enabled", _multiPanelModel, "MPanel_NumEnable", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_PNumEnable2", new Binding("Enabled", _multiPanelModel, "MPanel_NumEnable", true, DataSourceUpdateMode.OnPropertyChanged));

            return multiPanelBinding;
        }

        public Panel GetMultiPanelPropertiesPNL()
        {
            return _multiPanelPropertiesUC.GetMultiPanelPropertiesPNL();
        }
    }
}
