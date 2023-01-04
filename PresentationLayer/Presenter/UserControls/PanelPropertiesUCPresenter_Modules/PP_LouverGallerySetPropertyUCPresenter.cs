using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Variables;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_LouverGallerySetPropertyUCPresenter : IPP_LouverGallerySetPropertyUCPresenter
    {
        IPP_LouverGallerySetPropertyUC _LouverGallerySetPropertyUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;

        private IPP_LouverGallerySetOptionPropertyUCPresenter _pp_LouverGallerySetOptionPropertyUCPresenter;
        private IPP_GlassPropertyUCPresenter _pp_GlassPropertyUCPresenter;

        private List<IPP_LouverGallerySetOptionPropertyUCPresenter> _lst_gallerySetOptionUCP = new List<IPP_LouverGallerySetOptionPropertyUCPresenter>();
        private Panel _pnlLouverBody;
        private ConstantVariables constants = new ConstantVariables();
        int gallerySet_count = 0;
        public int GallerySet_Count
        {
            get
            {
                return gallerySet_count;
            }
            set
            {
                gallerySet_count = value;
                //if (cladding_count == 0)
                //{
                //    _divModel.Div_claddingBracketVisibility = false;
                //    _divModel.AdjustPropertyPanelHeight("minusCladdingBracket");
                //    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusCladdingBracket");
                //    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusCladdingBracket");

                //}
                //else if (cladding_count > 0)
                //{
                //    if (_divModel.Div_claddingBracketVisibility == false)
                //    {
                //        _divModel.Div_claddingBracketVisibility = true;
                //        _divModel.AdjustPropertyPanelHeight("addCladdingBracket");
                //        _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addCladdingBracket");
                //        _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addCladdingBracket");
                //    }
                //}

            }
        }

        public PP_LouverGallerySetPropertyUCPresenter(IPP_LouverGallerySetPropertyUC LouverGallerySetPropertyUC,
                                                      IPP_LouverGallerySetOptionPropertyUCPresenter pp_LouverGallerySetOptionPropertyUCPresenter,
                                                      IPP_GlassPropertyUCPresenter pp_GlassPropertyUCPresenter)
        {
            _LouverGallerySetPropertyUC = LouverGallerySetPropertyUC;
            _pp_LouverGallerySetOptionPropertyUCPresenter = pp_LouverGallerySetOptionPropertyUCPresenter;
            _pnlLouverBody = _LouverGallerySetPropertyUC.GetPanelBody();
            _pp_GlassPropertyUCPresenter = pp_GlassPropertyUCPresenter;

            SubcribeToEventSetUp();
        }

        private void SubcribeToEventSetUp()
        {
            _LouverGallerySetPropertyUC.LouverGallerySetPropertyUCLoadEventRaised += _LouverGallerySetPropertyUC_LouverGallerySetPropertyUCLoadEventRaised;
            _LouverGallerySetPropertyUC.btnAddLouverClickEventRaised += _LouverGallerySetPropertyUC_btnAddLouverClickEventRaised;
        }

        private void _LouverGallerySetPropertyUC_btnAddLouverClickEventRaised(object sender, EventArgs e)
        {
            IPP_LouverGallerySetOptionPropertyUCPresenter GallerySetOption = _pp_LouverGallerySetOptionPropertyUCPresenter.GetNewInstance(_unityC, _mainPresenter, _panelModel);
            _lst_gallerySetOptionUCP.Add(GallerySetOption);
            UserControl GallerySetOptionUC = (UserControl)GallerySetOption.GetLouverGallerySetOptionPropertyUC();
            GallerySetOptionUC.Dock = DockStyle.Top;
            _pnlLouverBody.Controls.Add(GallerySetOptionUC);


            _panelModel.Panel_LouverGallerySetOptionVisibility = true;

            _panelModel.AdjustPropertyPanelHeight("addLouverGallerySetArtNo");

            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addLouverGallerySetArtNo");

            if (_panelModel.Panel_ParentMultiPanelModel != null)
            {
                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addLouverGallerySetArtNo");
            }

            GallerySetOptionUC.BringToFront();
            ((UserControl)_LouverGallerySetPropertyUC).Height += constants.panel_property_LouverGallerySetArtNoOptionsheight;

            gallerySet_count++;
            _panelModel.Panel_claddingCount++;
        }



        private void _LouverGallerySetPropertyUC_LouverGallerySetPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _LouverGallerySetPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_LouverGallerySetPropertyUC GetLouverGallerySetPropertyUC()
        {
            return _LouverGallerySetPropertyUC;
        }

        public IPP_LouverGallerySetPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                             IMainPresenter mainPresenter,
                                                             IPanelModel panelModel)
        {
            unityC
                  .RegisterType<IPP_LouverGallerySetPropertyUC, PP_LouverGallerySetPropertyUC>()
                  .RegisterType<IPP_LouverGallerySetPropertyUCPresenter, PP_LouverGallerySetPropertyUCPresenter>();
            PP_LouverGallerySetPropertyUCPresenter gallerySet = unityC.Resolve<PP_LouverGallerySetPropertyUCPresenter>();
            gallerySet._unityC = unityC;
            gallerySet._mainPresenter = mainPresenter;
            gallerySet._panelModel = panelModel;

            return gallerySet;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_LouverGallerySetVisibility", new Binding("Visible", _panelModel, "Panel_LouverGallerySetVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_LouverBladeHeight", new Binding("Text", _panelModel, "Panel_LouverBladeHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_LouverNumberBladesPerSet", new Binding("Value", _panelModel, "Panel_LouverNumberBladesPerSet", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_LouverHandleType", new Binding("Text", _panelModel, "Panel_LouverHandleType", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_LouverHandleLocation", new Binding("Text", _panelModel, "Panel_LouverHandleLocation", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_LouverGalleryColor", new Binding("Text", _panelModel, "Panel_LouverGalleryColor", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
