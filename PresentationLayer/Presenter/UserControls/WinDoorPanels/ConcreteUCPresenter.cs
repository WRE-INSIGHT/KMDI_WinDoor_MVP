using CommonComponents;
using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Variables;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class ConcreteUCPresenter : IConcreteUCPresenter, IPresenterCommon
    {
        IConcreteUC _concreteUC;

        private IUnityContainer _unityC;
        private IConcreteModel _concreteModel;
        private IMainPresenter _mainPresenter;
        private IBasePlatformPresenter _basePlatformUCP;
        private ConstantVariables constants = new ConstantVariables();
        Color color = Color.Black;

        public ConcreteUCPresenter(IConcreteUC concreteUC)
        {
            _concreteUC = concreteUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _concreteUC.ConcreteUCLoadEventRaised += _concreteUC_ConcreteUCLoadEventRaised;
            _concreteUC.ConcreteUCPaintEventRaised += _concreteUC_ConcreteUCPaintEventRaised;
            _concreteUC.deleteToolStripMenuItemClickEventRaised += _concreteUC_deleteToolStripMenuItemClickEventRaised;
            _concreteUC.concreteUCMouseClickEventRaised += _concreteUC_concreteUCMouseClickEventRaised;
        }
        private UserControl concreteUC;
        private void _concreteUC_concreteUCMouseClickEventRaised(object sender, MouseEventArgs e)
        {
           


            try
            {
                concreteUC = (UserControl)sender;
                IWindoorModel wdm = _mainPresenter.frameModel_MainPresenter.Frame_WindoorModel;
                int propertyHeight = 0;
                int framePropertyHeight = 0;
                int concretePropertyHeight = 0;
                int mpnlPropertyHeight = 0;
                int pnlPropertyHeight = 0;
                int divPropertyHeight = 0;
                foreach (Control wndrObject in wdm.lst_objects)
                {
                    if (wndrObject.Name.Contains("Frame"))
                    {
                        #region FrameModel
                        foreach (FrameModel frm in wdm.lst_frame)
                        {
                            if (frm.Frame_Name == wndrObject.Name)
                            {
                                if (frm.Frame_Name == wndrObject.Name)
                                {
                                    propertyHeight += frm.Frame_PropertiesUC.Height;
                                    break;
                                }
                                #region  Frame Panel
                                foreach (PanelModel pnl in frm.Lst_Panel)
                                {
                                    pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                }
                                #endregion
                                #region 2nd Level MultiPanel
                                foreach (MultiPanelModel mpnl in frm.Lst_MultiPanel)
                                {
                                    mpnlPropertyHeight += constants.mpnl_propertyHeight_default;
                                    foreach (Control ctrl in mpnl.MPanelLst_Objects)
                                    {
                                        if (ctrl.Name.Contains("PanelUC"))
                                        {
                                            #region 2nd Level MultiPanel Panel
                                            foreach (PanelModel pnl in mpnl.MPanelLst_Panel)
                                            {
                                                if (ctrl.Name == pnl.Panel_Name)
                                                {
                                                    pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                    break;
                                                }
                                            }
                                            #endregion

                                        }
                                        else if (ctrl.Name.Contains("MullionUC") || ctrl.Name.Contains("TransomUC"))
                                        {
                                            #region 2nd Level MultiPanel Divider
                                            foreach (DividerModel div in mpnl.MPanelLst_Divider)
                                            {
                                                if (ctrl.Name == div.Div_Name)
                                                {
                                                    divPropertyHeight += div.Div_PropHeight;
                                                    break;
                                                }
                                            }
                                            #endregion

                                        }
                                        else if (ctrl.Name.Contains("MultiTransom") || ctrl.Name.Contains("MultiMullion"))
                                        {

                                            #region 2nd Level MultiPanel MultiPanel

                                            foreach (MultiPanelModel thirdlvlmpnl in mpnl.MPanelLst_MultiPanel)
                                            {
                                                if (ctrl.Name == thirdlvlmpnl.MPanel_Name)
                                                {
                                                    mpnlPropertyHeight += constants.mpnl_propertyHeight_default;
                                                    foreach (Control thirdlvlctrl in thirdlvlmpnl.MPanelLst_Objects)
                                                    {
                                                        if (thirdlvlctrl.Name.Contains("PanelUC"))
                                                        {
                                                            foreach (PanelModel pnl in thirdlvlmpnl.MPanelLst_Panel)
                                                            {
                                                                if (thirdlvlctrl.Name == pnl.Panel_Name)
                                                                {
                                                                    pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        else if (thirdlvlctrl.Name.Contains("MullionUC") || thirdlvlctrl.Name.Contains("TransomUC"))
                                                        {

                                                            foreach (DividerModel div in thirdlvlmpnl.MPanelLst_Divider)
                                                            {
                                                                if (thirdlvlctrl.Name == div.Div_Name)
                                                                {
                                                                    divPropertyHeight += div.Div_PropHeight;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        foreach (MultiPanelModel fourthlvlmpnl in thirdlvlmpnl.MPanelLst_MultiPanel)
                                                        {
                                                            if (thirdlvlctrl.Name == fourthlvlmpnl.MPanel_Name)
                                                            {
                                                                mpnlPropertyHeight += constants.mpnl_propertyHeight_default;
                                                                foreach (Control fourthlvlctrl in fourthlvlmpnl.MPanelLst_Objects)
                                                                {

                                                                    if (fourthlvlctrl.Name.Contains("PanelUC"))
                                                                    {
                                                                        foreach (PanelModel pnl in fourthlvlmpnl.MPanelLst_Panel)
                                                                        {
                                                                            if (fourthlvlctrl.Name == pnl.Panel_Name)
                                                                            {
                                                                                pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                                                break;
                                                                            }
                                                                        }

                                                                    }
                                                                    else if (fourthlvlctrl.Name.Contains("MullionUC") || fourthlvlctrl.Name.Contains("TransomUC"))
                                                                    {
                                                                        foreach (DividerModel div in fourthlvlmpnl.MPanelLst_Divider)
                                                                        {
                                                                            if (fourthlvlctrl.Name == div.Div_Name)
                                                                            {
                                                                                divPropertyHeight += div.Div_PropHeight;
                                                                                break;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion
                                        }
                                    }
                                }
                                #endregion
                                propertyHeight += frm.Frame_PropertiesUC.Height;
                                framePropertyHeight = 0;
                                mpnlPropertyHeight = 0;
                                pnlPropertyHeight = 0;
                                divPropertyHeight = 0;
                            }

                        }

                        #endregion
                    }
                    else
                    {
                        #region Concrete

                        foreach (IConcreteModel crm in wdm.lst_concrete)
                        {
                            if (wndrObject.Name == crm.Concrete_Name)
                            {
                                if (crm.Concrete_Name == concreteUC.Name)
                                {
                                    _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight;
                                    return;
                                }
                                else
                                {
                                    concretePropertyHeight += constants.concrete_propertyHeight_default;
                                }
                            }
                        }
                        #endregion
                    }


                }
            }
            catch (Exception)
            {

            }
        }

        private void _concreteUC_deleteToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to DELETE?",
                                "Deletion",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteConcrete();
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void DeleteConcrete()
        {
            _basePlatformUCP.ViewDeleteControl((UserControl)_concreteUC);
            _basePlatformUCP.InvalidateBasePlatform();
            _basePlatformUCP.Invalidate_flpMain();
            _mainPresenter.DeleteConcretePropertiesUC(_concreteModel.Concrete_Id);
            _mainPresenter.DeleteConcrete_OnConcreteList_WindoorModel(_concreteModel);
            _mainPresenter.DeleteConcrete_OnObjectList_WindoorModel((UserControl)_concreteUC);
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            if (_mainPresenter.windoorModel_MainPresenter.lst_concrete.Count == 0)
            {
                _mainPresenter.windoorModel_MainPresenter.concreteIDCounter = 0;

            }

        }

        private void _concreteUC_ConcreteUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            UserControl concrete = (UserControl)sender;

            int cond = concrete.Width + concrete.Height;

            for (int i = 10; i < cond; i += 10)
            {
                g.DrawLine(Pens.Black, new Point(0, i), new Point(i, 0));
            }

            int w = 1;
            g.DrawRectangle(new Pen(color, w), new Rectangle(0,
                                                             0,
                                                             concrete.ClientRectangle.Width - w,
                                                             concrete.ClientRectangle.Height - w));
        }

        private void _concreteUC_ConcreteUCLoadEventRaised(object sender, EventArgs e)
        {
            _concreteUC.ThisBinding(CreateBindingDictionary());
        }

        public IConcreteUC GetConcreteUC()
        {
            return _concreteUC;
        }

        public IConcreteUCPresenter GetNewInstance(IUnityContainer unityC,
                                                   IConcreteModel concreteModel,
                                                   IMainPresenter mainPresenter,
                                                   IBasePlatformPresenter basePlatformUCP)
        {
            unityC
                .RegisterType<IConcreteUC, ConcreteUC>()
                .RegisterType<IConcreteUCPresenter, ConcreteUCPresenter>();
            ConcreteUCPresenter presenter = unityC.Resolve<ConcreteUCPresenter>();
            presenter._concreteModel = concreteModel;
            presenter._mainPresenter = mainPresenter;
            presenter._unityC = unityC;
            presenter._basePlatformUCP = basePlatformUCP;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Concrete_WidthToBind", new Binding("Width", _concreteModel, "Concrete_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Concrete_HeightToBind", new Binding("Height", _concreteModel, "Concrete_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Concrete_ID", new Binding("Concrete_ID", _concreteModel, "Concrete_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Concrete_Name", new Binding("Name", _concreteModel, "Concrete_Name", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
