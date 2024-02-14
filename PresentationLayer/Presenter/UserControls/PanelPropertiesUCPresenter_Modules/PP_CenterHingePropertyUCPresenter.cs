using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_CenterHingePropertyUCPresenter : IPP_CenterHingePropertyUCPresenter, IPresenterCommon
    {
        IPP_CenterHingePropertyUC _pp_centerHingePropertyUC;
        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;

        public PP_CenterHingePropertyUCPresenter(IPP_CenterHingePropertyUC pp_centerHingePropertyUC)
        {
            _pp_centerHingePropertyUC = pp_centerHingePropertyUC;
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _pp_centerHingePropertyUC.CmbCenterHingeSelectedValueChangedEventRaised += _pp_centerHingePropertyUC_CmbCenterHingeSelectedValueChangedEventRaised;
            _pp_centerHingePropertyUC.CenterHingePropertyUCLoadEventRaised += _pp_centerHingePropertyUC_CenterHingePropertyUCLoadEventRaised;

        }

        CenterHingeOption curr_centerHinge;
        private void _pp_centerHingePropertyUC_CmbCenterHingeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            ComboBox cmbCenterHinge = (ComboBox)sender;
            //if (_initialLoad == false)
            //{
            //    _panelModel.Panel_CenterHingeOptions = (CenterHingeOption)cmbCenterHinge.SelectedValue;
            //    CenterHingeOption sel_centerHinge = (CenterHingeOption)cmbCenterHinge.SelectedValue;
            //    if (curr_centerHinge != sel_centerHinge)
            //    {
            //        if (sel_centerHinge == CenterHingeOption._NTCenterHinge)
            //        {
            //            _panelModel.Panel_NTCenterHingeVisibility = true;
            //            _panelModel.AdjustPropertyPanelHeight("addNTCenterHinge");
            //            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addNTCenterHinge");
            //            if (_panelModel.Panel_ParentMultiPanelModel != null)
            //            {
            //                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addNTCenterHinge");
            //            }
            //        }
            //        else if (sel_centerHinge == CenterHingeOption._MiddleCloser)
            //        {
            //            _panelModel.Panel_NTCenterHingeVisibility = false;
            //            _panelModel.AdjustPropertyPanelHeight("minusNTCenterHinge");
            //            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusNTCenterHinge");
            //            if (_panelModel.Panel_ParentMultiPanelModel != null)
            //            {
            //                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusNTCenterHinge");
            //            }
            //        }
            //        curr_centerHinge = sel_centerHinge;
            //    }
            //}
            if (!_panelModel.PanelModelIsFromLoad)
            {
                _panelModel.Panel_CenterHingeOptions = (CenterHingeOption)cmbCenterHinge.SelectedValue;
                CenterHingeOption sel_centerHinge = (CenterHingeOption)cmbCenterHinge.SelectedValue;
                if (curr_centerHinge != sel_centerHinge)
                {
                    if (sel_centerHinge == CenterHingeOption._NTCenterHinge)
                    {
                        _panelModel.Panel_NTCenterHingeVisibility = true;
                        _panelModel.AdjustPropertyPanelHeight("addNTCenterHinge");
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addNTCenterHinge");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addNTCenterHinge");
                        }
                    }
                    else if (sel_centerHinge == CenterHingeOption._MiddleCloser)
                    {
                        _panelModel.Panel_NTCenterHingeVisibility = false;
                        _panelModel.AdjustPropertyPanelHeight("minusNTCenterHinge");
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusNTCenterHinge");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusNTCenterHinge");
                        }
                    }
                    curr_centerHinge = sel_centerHinge;
                }
            }
        }


        private void _pp_centerHingePropertyUC_CenterHingePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_centerHingePropertyUC.ThisBinding(CreateBindingDictionary());

            if (!_panelModel.PanelModelIsFromLoad)
            {
                curr_centerHinge = CenterHingeOption._NTCenterHinge;
                _panelModel.Panel_CenterHingeOptions = CenterHingeOption._NTCenterHinge;
            }
            // _initialLoad = false;
        }

        public IPP_CenterHingePropertyUC GetCenterHingePropertyUC()
        {
            return _pp_centerHingePropertyUC;
        }

        public IPP_CenterHingePropertyUCPresenter GetNewInstance(IPanelModel panelModel, IUnityContainer unityC)
        {
            unityC
                .RegisterType<IPP_CenterHingePropertyUC, PP_CenterHingePropertyUC>()
                .RegisterType<IPP_CenterHingePropertyUCPresenter, PP_CenterHingePropertyUCPresenter>();
            PP_CenterHingePropertyUCPresenter CenterHingePropertyUCPresenter = unityC.Resolve<PP_CenterHingePropertyUCPresenter>();
            CenterHingePropertyUCPresenter._unityC = unityC;
            CenterHingePropertyUCPresenter._panelModel = panelModel;

            return CenterHingePropertyUCPresenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_CenterHingeOptions", new Binding("Text", _panelModel, "Panel_CenterHingeOptions", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_CenterHingeOptionsVisibility", new Binding("Visible", _panelModel, "Panel_CenterHingeOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            return binding;
        }



    }
}
