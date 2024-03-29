﻿using CommonComponents;
using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Variables;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Views.UserControls.Dividers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using ServiceLayer.Services.DividerServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class LouverPanelUCPresenter : ILouverPanelUCPresenter, IPresenterCommon
    {
        ILouverPanelUC _louverPanelUC;

        private IUnityContainer _unityC;

        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;
        private IFrameModel _frameModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelMullionUCPresenter _multiPanelMullionUCP;
        private IMultiPanelTransomUCPresenter _multiPanelTransomUCP;
        private IFrameUCPresenter _frameUCP;

        private ITransomUCPresenter _transomUCP;
        private IMullionUCPresenter _mullionUCP;

        private IDividerServices _divServices;

        private CommonFunctions _commonFunctions = new CommonFunctions();
        Timer _tmr = new Timer();
        bool _initialLoad;

        public LouverPanelUCPresenter(ILouverPanelUC louverPanelUC,
                                      IDividerServices divServices,
                                      ITransomUCPresenter transomUCP,
                                      IMullionUCPresenter mullionUCP)
        {
            _louverPanelUC = louverPanelUC;
            _divServices = divServices;
            _transomUCP = transomUCP;
            _mullionUCP = mullionUCP;

            _tmr = new Timer();
            _tmr.Interval = 200;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _louverPanelUC.louverPanelUCLoadEventRaised += _louverPanelUC_louverPanelUCLoadEventRaised;
            _louverPanelUC.louverPanelUCMouseEnterEventRaised += _louverPanelUC_louverPanelUCMouseEnterEventRaised;
            _louverPanelUC.louverPanelUCMouseLeaveEventRaised += _louverPanelUC_louverPanelUCMouseLeaveEventRaised;
            _louverPanelUC.louverPanelUCSizeChangedEventRaised += _louverPanelUC_louverPanelUCSizeChangedEventRaised;
            _louverPanelUC.louverPanelUCPaintEventRaised += _louverPanelUC_louverPanelUCPaintEventRaised;
            _louverPanelUC.deleteToolStripClickedEventRaised += _louverPanelUC_deleteToolStripClickedEventRaised;
            _louverPanelUC.louverPanelUCMouseClickEventRaised += _louverPanelUC_louverPanelUCMouseClickEventRaised;
        }
        private UserControl louvreUC;
        private ConstantVariables constants = new ConstantVariables();
        private void _louverPanelUC_louverPanelUCMouseClickEventRaised(object sender, MouseEventArgs e)
        {
            try
            {
                louvreUC = (UserControl)sender;
                IWindoorModel wdm = _frameModel.Frame_WindoorModel;
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
                                framePropertyHeight += constants.frame_propertyHeight_default;
                                if (_frameModel.Frame_BotFrameVisible == true)
                                {
                                    framePropertyHeight += constants.frame_botframeproperty_PanelHeight;
                                }
                                if (_frameModel.Frame_SlidingRailsQtyVisibility == true)
                                {
                                    framePropertyHeight += constants.frame_SlidingRailsQtyproperty_PanelHeight;
                                }
                                if (_frameModel.Frame_ConnectionTypeVisibility == true && _frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6052)
                                {
                                    framePropertyHeight += constants.frame_ConnectionTypeproperty_PanelHeight;
                                }
                                if (_frameModel.Frame_ScreenVisibility == true)
                                {
                                    framePropertyHeight += constants.frame_ScreenHeightProperty_PanelHeight;
                                    if (_frameModel.Frame_ScreenOption == true)
                                    {
                                        framePropertyHeight += constants.frame_ScreenHeightProperty_PanelHeight;
                                    }
                                }
                                #region  Frame Panel
                                foreach (PanelModel pnl in frm.Lst_Panel)
                                {
                                    if (pnl.Panel_Name == louvreUC.Name)
                                    {
                                        _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight - 3;
                                        return;
                                    }
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
                                                    if (pnl.Panel_Name == louvreUC.Name)
                                                    {
                                                        _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight - 11;
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                    }
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
                                                                    if (pnl.Panel_Name == louvreUC.Name)
                                                                    {
                                                                        _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight - 19;
                                                                        return;

                                                                    }
                                                                    else
                                                                    {
                                                                        pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                                    }
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
                                                                                if (pnl.Panel_Name == louvreUC.Name)
                                                                                {
                                                                                    _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight - 27;
                                                                                    return;

                                                                                }
                                                                                else
                                                                                {
                                                                                    pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                                                }
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
                                                        //mpnlPropertyHeight -= 1;

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
                                concretePropertyHeight += constants.concrete_propertyHeight_default;
                                break;
                            }
                        }
                        #endregion
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _louverPanelUC_louverPanelUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            try
            {
                UserControl louver = (UserControl)sender;

                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Pen p = new Pen(Color.Black);
                Pen p2 = new Pen(Color.Black, 2);
                Pen LvrPen = new Pen(Color.Black, 7);
                Pen LvrPen2 = new Pen(Color.FromArgb(240, 240, 240), 7);

                Brush b = new SolidBrush(Color.Black);

                g.DrawRectangle(new Pen(color, 2), new Rectangle(0,
                                                                 0,
                                                                 louver.ClientRectangle.Width - 2,
                                                                 louver.ClientRectangle.Height - 2));



                // jelusi

                //int Lvr_NewLocation = 0,
                //    Lvr_Gap = 0,
                //    pInnerY = 0,
                //    pInnerX = 0,
                //    pInnerHt = louver.Height,
                //    pInnerWd = louver.Width,
                //    NoOfBlades = _panelModel.Panel_LouverBladesCount;

                //float Ht_Allowance = 20 * _frameModel.Frame_Zoom; // tag 10px na allowance sa taas at baba if 100%
                //double Lvr_GlassHt = 0;

                ////side blade
                //for (int ii = 0; ii < _panelModel.Panel_LouverBladesCount; ii++)
                //{
                //    Lvr_GlassHt = (((pInnerHt - (((int)NoOfBlades))) / (int)NoOfBlades) / 2) + (int)NoOfBlades;
                //    Lvr_NewLocation = ((pInnerY + (int)Ht_Allowance) + Lvr_Gap) + (int)Lvr_GlassHt;
                //    Lvr_Gap += (pInnerHt - (int)Lvr_GlassHt) / ((int)NoOfBlades);

                //    Point[] LvrSideBlade =
                //     {
                //        new Point((pInnerY - 7) + pInnerWd - 2, Lvr_NewLocation-(int)Lvr_GlassHt),
                //        new Point((pInnerY - 7) + pInnerWd + 4, Lvr_NewLocation+(int)Lvr_GlassHt),

                //        new Point(pInnerY-2, Lvr_NewLocation-(int)Lvr_GlassHt),
                //        new Point(pInnerY+4, Lvr_NewLocation+(int)Lvr_GlassHt),

                //        new Point(pInnerY-4, Lvr_NewLocation-(int)Lvr_GlassHt-1),
                //        new Point(pInnerY-4, Lvr_NewLocation+(int)Lvr_GlassHt+1)
                //     };

                //    for (int i = 0; i < LvrSideBlade.Length; i += 2)
                //    {
                //        if (i == 4)
                //        {
                //            g.DrawLine(LvrPen2, LvrSideBlade[i], LvrSideBlade[i + 1]);
                //        }
                //        else
                //        {
                //            g.DrawLine(LvrPen, LvrSideBlade[i], LvrSideBlade[i + 1]);
                //        }
                //    }

                //    //blade
                //    Point[] blade =
                //    {
                //        new Point(pInnerX, Lvr_NewLocation-(int)Lvr_GlassHt),
                //        new Point((int)louver.Width - pInnerX - 7, Lvr_NewLocation-(int)Lvr_GlassHt),
                //        new Point((int)louver.Width ,Lvr_NewLocation+(int)Lvr_GlassHt), // - 19 para mag slant yung blade
                //        new Point(pInnerX, Lvr_NewLocation+(int)Lvr_GlassHt)
                //    };
                //    for (int i = 0; i < blade.Length; i += 2)
                //    {
                //        g.DrawLine(p, blade[i], blade[i + 1]);
                //    }
                //}



                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //int Lvr_NewLocation = 0,
                // Lvr_Gap = 0,
                // pInnerY = 0,
                // pInnerX = 0,
                // pInnerHt = louver.Height,
                // pInnerWd = louver.Width,
                // NoOfBlades = _panelModel.Panel_LouverBladesCount;
                //float Ht_Allowance = 20 * _frameModel.Frame_Zoom; // tag 10px na allowance sa taas at baba if 100%
                //double Lvr_GlassHt = 0, Total_Lvr_GlassHt = 0;
                //pInnerHt -= (int)Ht_Allowance;
                ////side blade
                //for (int ii = 0; ii < _panelModel.Panel_LouverBladesCount; ii++)
                //{
                //    //Lvr_GlassHt = (((pInnerHt - (((int)NoOfBlades))) / (int)NoOfBlades) / 2) + (int)NoOfBlades;
                //    Lvr_GlassHt = pInnerHt / (int)NoOfBlades;
                //    Total_Lvr_GlassHt += Lvr_GlassHt;
                //    Lvr_NewLocation = ((pInnerY + (int)Ht_Allowance) + Lvr_Gap) + (int)Total_Lvr_GlassHt;
                //    int New_Lvr_GlassHt_Location = (int)Lvr_GlassHt;
                //    if (Lvr_GlassHt != Total_Lvr_GlassHt)
                //    {
                //        New_Lvr_GlassHt_Location = (int)Total_Lvr_GlassHt - ((int)Lvr_GlassHt * ii);
                //    }
                //    //Lvr_Gap += (pInnerHt - (int)Lvr_GlassHt) / ((int)NoOfBlades);
                //    Point[] LvrSideBlade =
                //     {
                //        new Point((pInnerY - 7) + pInnerWd - 2, Lvr_NewLocation-(int)New_Lvr_GlassHt_Location) ,
                //        new Point((pInnerY - 7) + pInnerWd + 4, (int)Total_Lvr_GlassHt),

                //        new Point(pInnerY-2, Lvr_NewLocation-(int)Lvr_GlassHt),
                //        new Point(pInnerY+4, (int)Total_Lvr_GlassHt),

                //        new Point(pInnerY-4, Lvr_NewLocation-(int)New_Lvr_GlassHt_Location-1),
                //        new Point(pInnerY-4, Lvr_NewLocation+(int)Lvr_GlassHt+1)
                //     };

                //    for (int i = 0; i < LvrSideBlade.Length; i += 2)
                //    {
                //        if (i == 4)
                //        {
                //            g.DrawLine(LvrPen2, LvrSideBlade[i], LvrSideBlade[i + 1]);
                //        }
                //        else
                //        {
                //            g.DrawLine(LvrPen, LvrSideBlade[i], LvrSideBlade[i + 1]);
                //        }
                //    }

                //    //blade
                //    Point[] blade =
                //    {
                //        new Point(pInnerX, Lvr_NewLocation-(int)Lvr_GlassHt),
                //        new Point((int)louver.Width - pInnerX - 7, Lvr_NewLocation-(int)Lvr_GlassHt),
                //        new Point((int)louver.Width ,(int)Total_Lvr_GlassHt), // - 19 para mag slant yung blade
                //        new Point(pInnerX,(int)Total_Lvr_GlassHt)
                //    };
                //    for (int i = 0; i < blade.Length; i += 2)
                //    {
                //        g.DrawLine(p, blade[i], blade[i + 1]);
                //    }
                //}
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                int Lvr_NewLocation = 0,
                Lvr_Gap = 0,
                pInnerY = 0,
                pInnerX = 0,
                pInnerHt = louver.Height,
                pInnerWd = louver.Width,
                NoOfBlades = _panelModel.Panel_LouverBladesCount;
                float Ht_Allowance = 20 * _frameModel.Frame_Zoom; // tag 10px na allowance sa taas at baba if 100%
                double Lvr_GlassHt = 0, Total_Lvr_GlassHt = (int)(Ht_Allowance/2);
                pInnerHt -= (int)Ht_Allowance;
                double ht_allowance_deci = 0.0, Lvr_GlassHt_deci = 0.0;
                IDictionary<Point[], Point[]> lvrBlade = new Dictionary<Point[], Point[]>();
                //side blade
                for (int ii = 0; ii < _panelModel.Panel_LouverBladesCount; ii++)
                {
                    //Lvr_GlassHt = (((pInnerHt - (((int)NoOfBlades))) / (int)NoOfBlades) / 2) + (int)NoOfBlades;
                    Lvr_GlassHt = (double)pInnerHt / NoOfBlades;
                    Total_Lvr_GlassHt += (int)Lvr_GlassHt;
                    Lvr_NewLocation = ((pInnerY + (int)Ht_Allowance) + Lvr_Gap) + (int)Total_Lvr_GlassHt;
                    int New_Lvr_GlassHt_Location = (int)Lvr_GlassHt;
                    ht_allowance_deci += (double)(Ht_Allowance - Math.Truncate(Ht_Allowance) );
                    Lvr_GlassHt_deci += (Lvr_GlassHt - Math.Truncate(Lvr_GlassHt));
                    if ((Lvr_GlassHt + (int)(Ht_Allowance / 2)) != Total_Lvr_GlassHt)
                    {
                        New_Lvr_GlassHt_Location = (int)Total_Lvr_GlassHt - ((int)Lvr_GlassHt * ii) - (int)(Ht_Allowance / 2);
                    }
                    //Lvr_Gap += (pInnerHt - (int)Lvr_GlassHt) / ((int)NoOfBlades);
                    Point[] LvrSideBlade =
                     {
                        new Point((pInnerY - 7) + pInnerWd - 2, Lvr_NewLocation-(int)New_Lvr_GlassHt_Location) ,
                        new Point((pInnerY - 7) + pInnerWd + 4, (int)Total_Lvr_GlassHt),

                        new Point(pInnerY-2, Lvr_NewLocation-(int)Lvr_GlassHt),
                        new Point(pInnerY+4, (int)Total_Lvr_GlassHt),

                        new Point(pInnerY-4, Lvr_NewLocation-(int)New_Lvr_GlassHt_Location-1),
                        new Point(pInnerY-4, Lvr_NewLocation+(int)Lvr_GlassHt+1)
                     };
                    //blade
                    Point[] blade =
                    {
                        new Point(pInnerX, Lvr_NewLocation-(int)Lvr_GlassHt),
                        new Point((int)louver.Width - pInnerX - 7, Lvr_NewLocation-(int)Lvr_GlassHt),
                        new Point((int)louver.Width ,(int)Total_Lvr_GlassHt), // - 19 para mag slant yung blade
                        new Point(pInnerX,(int)Total_Lvr_GlassHt)
                    };
                    lvrBlade.Add(LvrSideBlade, blade);

                }


                for (int ii = 0; ii < _panelModel.Panel_LouverBladesCount; ii++)
                {
                    IList<Point> lstPtsSide = new List<Point>();
                    foreach (Point pnts in lvrBlade.ElementAt(ii).Key)
                    {
                        lstPtsSide.Add(new Point(pnts.X, pnts.Y + (int)(Lvr_GlassHt_deci / 2) + (int)((ht_allowance_deci * _frameModel.Frame_Zoom) / 2)));
                    }
                    IList<Point> lstPtsblade = new List<Point>();
                    foreach (Point pnts in lvrBlade.ElementAt(ii).Value)
                    {
                        lstPtsblade.Add(new Point(pnts.X, pnts.Y + (int)(Lvr_GlassHt_deci / 2) + (int)((ht_allowance_deci * _frameModel.Frame_Zoom) /2)));
                    }
                    for (int i = 0; i < lvrBlade.ElementAt(ii).Key.Length; i += 2)
                    {
                        if (i == 4)
                        {
                            g.DrawLine(LvrPen2, lstPtsSide[i], lstPtsSide[i + 1]);
                        }
                        else
                        {
                            g.DrawLine(LvrPen, lstPtsSide[i], lstPtsSide[i + 1]);
                        }
                    }

                    for (int i = 0; i < lvrBlade.ElementAt(ii).Value.Length; i += 2)
                    {
                        g.DrawLine(p, lstPtsblade[i], lstPtsblade[i + 1]);
                    }

                }



            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void _louverPanelUC_deleteToolStripClickedEventRaised(object sender, EventArgs e)
        {
            try
            {
                #region Delete Divider
                if (_multiPanelModel != null &&
                    _multiPanelModel.MPanel_DividerEnabled &&
                    _panelModel.Panel_Placement != "Last")
                {
                    int this_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((UserControl)_louverPanelUC);
                    Control nextCtrl = null,
                      prevCtrl = null;
                    if (_multiPanelModel.MPanelLst_Objects.Count > (this_indx + 2))
                    {
                        nextCtrl = _multiPanelModel.MPanelLst_Objects[this_indx + 2];
                        if (!nextCtrl.Name.Contains("Multi"))
                        {
                            nextCtrl = null;
                        }
                        if (this_indx > 1)
                        {
                            prevCtrl = _multiPanelModel.MPanelLst_Objects[this_indx - 2];
                            if (!prevCtrl.Name.Contains("Multi"))
                            {
                                prevCtrl = null;
                            }
                        }

                    }
                    if (this_indx > 1 && _multiPanelModel.MPanel_DividerEnabled && nextCtrl != null)
                    {
                        Control prevmPanel = _multiPanelModel.MPanelLst_Objects[this_indx - 2];
                        Control divCtrl = _multiPanelModel.MPanelLst_Objects[this_indx - 1];
                        IMultiPanelModel leftMpnl = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == prevmPanel.Name);

                        int div_mpnl_deduct_Tobind = 8;
                        if (_multiPanelModel.MPanel_Zoom > 0.26f)
                        {
                            div_mpnl_deduct_Tobind = (int)(div_mpnl_deduct_Tobind * _multiPanelModel.MPanel_Zoom);//4
                        }
                        else if (_multiPanelModel.MPanel_Zoom <= 0.26f)
                        {
                            div_mpnl_deduct_Tobind = 2; //13 - 2 = 11 - 2 = 9px default on div obj for 2-stack multipanel
                        }

                        if (divCtrl.Name.Contains("Mullion"))
                        {
                            IMullionUC mullionUC = (MullionUC)_multiPanelModel.MPanelLst_Objects[this_indx - 1];


                            if (prevCtrl == null)
                            {
                                IDividerModel leftDiv = _multiPanelModel.MPanelLst_Divider.Find(divs => divs.Div_Name == ((UserControl)mullionUC).Name);
                                leftDiv.Div_WidthToBind -= div_mpnl_deduct_Tobind;
                                leftDiv.Div_Width -= 8;
                            }

                            _multiPanelModel.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                            mullionUC.InvalidateThis();
                            if (leftMpnl != null)
                            {
                                leftMpnl.MPanel_WidthToBind -= div_mpnl_deduct_Tobind;
                            }
                        }
                        else if (divCtrl.Name.Contains("Transom"))
                        {
                            ITransomUC transomUC = (TransomUC)_multiPanelModel.MPanelLst_Objects[this_indx - 1];
                            if (prevCtrl == null)
                            {
                                IDividerModel leftDiv = _multiPanelModel.MPanelLst_Divider.Find(divs => divs.Div_Name == ((UserControl)transomUC).Name);
                                leftDiv.Div_HeightToBind -= div_mpnl_deduct_Tobind;
                                leftDiv.Div_Height -= 8;
                            }
                            _multiPanelModel.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)transomUC, _frameModel.Frame_Type.ToString());
                            transomUC.InvalidateThis();
                            if (leftMpnl != null)
                            {
                                leftMpnl.MPanel_HeightToBind -= div_mpnl_deduct_Tobind;
                            }
                        }
                    }
                    Control divUC = _multiPanelModel.MPanelLst_Objects[this_indx + 1];
                    _multiPanelModel.MPanelLst_Objects.Remove((UserControl)divUC);

                    //string imgr_type = "";

                    if (_multiPanelMullionUCP != null)
                    {
                        _multiPanelMullionUCP.DeletePanel((UserControl)divUC);
                        //imgr_type = "MullionImager";
                    }
                    if (_multiPanelTransomUCP != null)
                    {
                        _multiPanelTransomUCP.DeletePanel((UserControl)divUC);
                        //imgr_type = "TransomImager";
                    }

                    IDividerModel div = _multiPanelModel.MPanelLst_Divider.Find(divd => divd.Div_Name == divUC.Name);
                    _mainPresenter.DeleteDividerPropertiesUC(div.Div_ID);
                    div.Div_MPanelParent.MPanelLst_Divider.Remove(div);
                    _frameModel.Lst_Divider.Remove(div);

                    _multiPanelModel.DeductPropertyPanelHeight(div.Div_PropHeight);
                    _frameModel.DeductPropertyPanelHeight(div.Div_PropHeight);
                }
                #endregion

                #region Delete Casement

                if (_multiPanelModel != null)
                {
                    _multiPanelModel.DeleteControl_MPanelLstObjects((UserControl)_louverPanelUC, _frameModel.Frame_Type.ToString());
                    Control imager = _commonFunctions.FindImagerControl(_panelModel.Panel_ID, "Panel", _multiPanelModel);
                    _multiPanelModel.MPanelLst_Imagers.Remove(imager);

                    _multiPanelModel.Reload_PanelMargin();

                    _multiPanelModel.DeductPropertyPanelHeight(_panelModel.Panel_PropertyHeight);

                }
                if (_multiPanelMullionUCP != null)
                {
                    _multiPanelMullionUCP.DeletePanel((UserControl)_louverPanelUC);
                }
                if (_multiPanelTransomUCP != null)
                {
                    _multiPanelTransomUCP.DeletePanel((UserControl)_louverPanelUC);
                }
                if (_frameUCP != null)
                {
                    _frameUCP.ViewDeleteControl((UserControl)_louverPanelUC);
                }


                if (_multiPanelModel != null)
                {
                    _multiPanelModel.Object_Indexer();
                    _multiPanelModel.Reload_PanelMargin();
                    _multiPanelModel.Reload_MultiPanelMargin();
                    if (_multiPanelModel.MPanel_DividerEnabled)
                    {
                        _commonFunctions.Automatic_Div_Addition(_mainPresenter,
                                                            _frameModel,
                                                            _divServices,
                                                            //_frameUCP,
                                                            _transomUCP,
                                                            _unityC,
                                                            _mullionUCP,
                                                            //_mullionImagerUCP,
                                                            //_transomImagerUCP,
                                                            _mainPresenter.GetDividerCount(),
                                                            _multiPanelModel,
                                                            _panelModel,
                                                            _multiPanelTransomUCP,
                                                            _multiPanelMullionUCP);
                        //_multiPanelMullionImagerUCP,
                        //_multiTransomImagerUCP);
                    }
                }


                _mainPresenter.DeletePanelPropertiesUC(_panelModel.Panel_ID);
                _mainPresenter.SetChangesMark();
                if (_frameModel != null)
                {
                    _frameModel.Lst_Panel.Remove(_panelModel);
                }
                if (_multiPanelModel != null)
                {
                    _multiPanelModel.MPanelLst_Panel.Remove(_panelModel);
                }

                _frameModel.DeductPropertyPanelHeight(_panelModel.Panel_PropertyHeight);

                _mainPresenter.DeductPanelGlassID();
                _mainPresenter.SetPanelGlassID();
                #endregion
                _mainPresenter.DeselectDivider();
                _mainPresenter.itemDescription();
                _mainPresenter.GetCurrentPrice();
                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        int prev_Width = 0,
            prev_Height = 0;

        bool _HeightChange = false,
             _WidthChange = false;
        private void _louverPanelUC_louverPanelUCSizeChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (!_initialLoad)
                {
                    int thisWd = ((UserControl)sender).Width,
                        thisHt = ((UserControl)sender).Height,
                        pnlModelWd = _panelModel.Panel_WidthToBind,
                        pnlModelHt = _panelModel.Panel_HeightToBind;

                    if (thisWd != pnlModelWd || prev_Width != pnlModelWd)
                    {
                        //_multiPanelModel.MPanel_Width = thisWd;
                        _WidthChange = true;
                    }
                    if (thisHt != pnlModelHt || prev_Height != pnlModelHt)
                    {
                        //_multiPanelModel.MPanel_Height = thisHt;
                        _HeightChange = true;
                    }
                }
                prev_Width = _panelModel.Panel_WidthToBind;
                prev_Height = _panelModel.Panel_HeightToBind;

                _tmr.Start();
                ((UserControl)sender).Invalidate();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        Color color = Color.Black;

        private void _louverPanelUC_louverPanelUCMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            ((IPanelUC)_louverPanelUC).InvalidateThis();
        }

        private void _louverPanelUC_louverPanelUCMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            ((IPanelUC)_louverPanelUC).InvalidateThis();
        }

        private void _louverPanelUC_louverPanelUCLoadEventRaised(object sender, EventArgs e)
        {
            _louverPanelUC.ThisBinding(CreateBindingDictionary());

            _panelModel.Panel_OrientVisibility = false;
            _panelModel.Set_LouverBladesCount();
        }

        public ILouverPanelUC GetLouverPanelUC()
        {
            _initialLoad = true;
            return _louverPanelUC;
        }


        public ILouverPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                      IPanelModel panelModel,
                                                      IFrameModel frameModel,
                                                      IMainPresenter mainPresenter,
                                                      IFrameUCPresenter frameUCP)
        {
            unityC
                .RegisterType<ILouverPanelUC, LouverPanelUC>()
                .RegisterType<ILouverPanelUCPresenter, LouverPanelUCPresenter>();
            LouverPanelUCPresenter louverUCP = unityC.Resolve<LouverPanelUCPresenter>();
            louverUCP._panelModel = panelModel;
            louverUCP._frameModel = frameModel;
            louverUCP._mainPresenter = mainPresenter;
            louverUCP._frameUCP = frameUCP;
            louverUCP._unityC = unityC;

            return louverUCP;
        }

        public ILouverPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelMullionUCPresenter multiPanelUCP)
        {
            unityC
                .RegisterType<ILouverPanelUC, LouverPanelUC>()
                .RegisterType<ILouverPanelUCPresenter, LouverPanelUCPresenter>();
            LouverPanelUCPresenter louverUCP = unityC.Resolve<LouverPanelUCPresenter>();
            louverUCP._panelModel = panelModel;
            louverUCP._frameModel = frameModel;
            louverUCP._mainPresenter = mainPresenter;
            louverUCP._multiPanelModel = multiPanelModel;
            louverUCP._multiPanelMullionUCP = multiPanelUCP;
            louverUCP._unityC = unityC;

            return louverUCP;
        }

        public ILouverPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelTransomUCPresenter multiPanelTransomUCP)
        {
            unityC
                .RegisterType<ILouverPanelUC, LouverPanelUC>()
                .RegisterType<ILouverPanelUCPresenter, LouverPanelUCPresenter>();
            LouverPanelUCPresenter louverUCP = unityC.Resolve<LouverPanelUCPresenter>();
            louverUCP._panelModel = panelModel;
            louverUCP._frameModel = frameModel;
            louverUCP._mainPresenter = mainPresenter;
            louverUCP._multiPanelModel = multiPanelModel;
            louverUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            louverUCP._unityC = unityC;

            return louverUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Name", new Binding("Name", _panelModel, "Panel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Dock", new Binding("Dock", _panelModel, "Panel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_WidthToBind", new Binding("Width", _panelModel, "Panel_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_HeightToBind", new Binding("Height", _panelModel, "Panel_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Margin", new Binding("Margin", _panelModel, "Panel_MarginToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Placement", new Binding("Panel_Placement", _panelModel, "Panel_Placement", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_CmenuDeleteVisibility", new Binding("Panel_CmenuDeleteVisibility", _panelModel, "Panel_CmenuDeleteVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }
    }
}