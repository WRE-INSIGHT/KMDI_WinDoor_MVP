using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Variables;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

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

        public List<IPP_LouverGallerySetOptionPropertyUCPresenter> _lst_gallerySetOptionUCP { get; set; }

        private Panel _pnlLouverBody;
        private ConstantVariables constants = new ConstantVariables();
        string lvrDesc, handleLocDesc, handleTypeDesc, ColorDesc;


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
            _LouverGallerySetPropertyUC.cmbBladeHeightSelectedValueChangedEventRaised += _LouverGallerySetPropertyUC_cmbBladeHeightSelectedValueChangedEventRaised;
            _LouverGallerySetPropertyUC.cmbHandleTypeSelectedValueChangedEventRaised += _LouverGallerySetPropertyUC_cmbHandleTypeSelectedValueChangedEventRaised;
            _LouverGallerySetPropertyUC.cmbHandleLocationSelectedValueChangedEventRaised += _LouverGallerySetPropertyUC_cmbHandleLocationSelectedValueChangedEventRaised;
            _LouverGallerySetPropertyUC.cmbGalleryColorSelectedValueChangedEventRaised += _LouverGallerySetPropertyUC_cmbGalleryColorSelectedValueChangedEventRaised;
        }

        private void _LouverGallerySetPropertyUC_cmbBladeHeightSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_LouverBladeHeight = (BladeHeight_Option)((ComboBox)sender).SelectedValue;
        }

        private void _LouverGallerySetPropertyUC_cmbHandleTypeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_LouverHandleType = (LouverHandleType_Option)((ComboBox)sender).SelectedValue;
            if (_panelModel.Panel_LouverHandleType == LouverHandleType_Option._none)
            {
                _panelModel.Panel_LouverHandleLocation = LouverHandleLoc_Option._none;
            }
        }
        private void _LouverGallerySetPropertyUC_cmbHandleLocationSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_LouverHandleLocation = (LouverHandleLoc_Option)((ComboBox)sender).SelectedValue;
        }

        private void _LouverGallerySetPropertyUC_cmbGalleryColorSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_LouverGalleryColor = (LouverColor_Option)((ComboBox)sender).SelectedValue;

        }

        private void _LouverGallerySetPropertyUC_btnAddLouverClickEventRaised(object sender, EventArgs e)
        {
            if (_panelModel.Panel_LouverNumberBladesPerSet >= 2 &&
                _panelModel.Panel_LouverNumberBladesPerSet <= 17)
            {
                if (_panelModel.Panel_LstLouverArtNo == null)
                {
                    _panelModel.Panel_LstLouverArtNo = new List<string>();
                }

                if (_panelModel.Panel_LstSealForHandleMultiplier == null)
                {
                    _panelModel.Panel_LstSealForHandleMultiplier = new List<int>();
                }

                if (_lst_gallerySetOptionUCP == null)
                {
                    _lst_gallerySetOptionUCP = new List<IPP_LouverGallerySetOptionPropertyUCPresenter>();
                }

                IPP_LouverGallerySetOptionPropertyUCPresenter GallerySetOption = _pp_LouverGallerySetOptionPropertyUCPresenter.GetNewInstance(_unityC, _mainPresenter, _panelModel, this);
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


                if (_panelModel.Panel_LouverHandleType == LouverHandleType_Option._single)
                {
                    handleTypeDesc = "-S";
                }
                else if (_panelModel.Panel_LouverHandleType == LouverHandleType_Option._dual)
                {
                    handleTypeDesc = "-D";

                }
                else if (_panelModel.Panel_LouverHandleType == LouverHandleType_Option._ringPullControl)
                {
                    handleTypeDesc = "-R";
                }
                else if (_panelModel.Panel_LouverHandleType == LouverHandleType_Option._none)
                {
                    handleTypeDesc = "";
                }

                if (_panelModel.Panel_LouverHandleLocation == LouverHandleLoc_Option._LH)
                {
                    handleLocDesc = "-LH";
                }
                else if (_panelModel.Panel_LouverHandleLocation == LouverHandleLoc_Option._RH)
                {
                    handleLocDesc = "-RH";
                }
                else if (_panelModel.Panel_LouverHandleLocation == LouverHandleLoc_Option._none)
                {
                    handleLocDesc = "";
                }

                if (_panelModel.Panel_LouverGalleryColor == LouverColor_Option._black)
                {
                    ColorDesc = "-BLK";
                }
                else if (_panelModel.Panel_LouverGalleryColor == LouverColor_Option._white)
                {
                    ColorDesc = "-WHT";
                }

                lvrDesc = "LVRG-" +
                      _panelModel.Panel_LouverBladeHeight +
                      "-" + _panelModel.Panel_LouverNumberBladesPerSet.ToString() +
                      handleTypeDesc +
                      handleLocDesc +
                      ColorDesc;

                _panelModel.Panel_LstLouverArtNo.Add(lvrDesc);
                GallerySetOption.GetLouverGallerySetOptionPropertyUC().GetCmbLouverGalleryArtNo().Text = lvrDesc;

                gallerySet_count++;
                _panelModel.Panel_LouverGallerySetCount++;
                GallerySetOption.GetLouverGallerySetOptionPropertyUC().lblGallerySetArtNo = "Set " + gallerySet_count.ToString();

                if (_panelModel.Panel_LouverNumberBladesPerSet >= 2 &&
                    _panelModel.Panel_LouverNumberBladesPerSet <= 6)
                {
                    _panelModel.Panel_LstSealForHandleMultiplier.Add(1);
                }
                else if (_panelModel.Panel_LouverNumberBladesPerSet >= 7 &&
                   _panelModel.Panel_LouverNumberBladesPerSet <= 12)
                {
                    _panelModel.Panel_LstSealForHandleMultiplier.Add(2);
                }
                else if (_panelModel.Panel_LouverNumberBladesPerSet >= 13 &&
                   _panelModel.Panel_LouverNumberBladesPerSet <= 17)
                {
                    _panelModel.Panel_LstSealForHandleMultiplier.Add(3);
                }
                _mainPresenter.GetCurrentPrice();
                _mainPresenter.itemDescription();

            }
            else
            {
                MessageBox.Show("Louver blades must be 2 - 17 only");
            }
        }

        public void Remove_GallerySet(IPP_LouverGallerySetOptionPropertyUCPresenter GallerySetOptionUCP)
        {
            _lst_gallerySetOptionUCP.Remove(GallerySetOptionUCP);
        }

        public void SortGallerySetOrderNumber()
        {
            int GallerySet = 1;
            foreach (IPP_LouverGallerySetOptionPropertyUCPresenter LouverGallerySet in _lst_gallerySetOptionUCP)
            {
                LouverGallerySet.GetLouverGallerySetOptionPropertyUC().lblGallerySetArtNo = "Set " + GallerySet;
                GallerySet++;
            }
        }
        private void _LouverGallerySetPropertyUC_LouverGallerySetPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            //_panelModel.Panel_LouverBladeHeight = BladeHeight_Option._152;
            _panelModel.Panel_LouverNumberBladesPerSet = 2;
            //_panelModel.Panel_LouverHandleType = LouverHandleType_Option._single;
            //_panelModel.Panel_LouverHandleLocation = LouverHandleLoc_Option._RH;
            //_panelModel.Panel_LouverGalleryColor = LouverColor_Option._black;
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
            // binding.Add("Panel_LouverBladeHeight", new Binding("Text", _panelModel, "Panel_LouverBladeHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_LouverNumberBladesPerSet", new Binding("Value", _panelModel, "Panel_LouverNumberBladesPerSet", true, DataSourceUpdateMode.OnPropertyChanged));
            //binding.Add("Panel_LouverHandleType", new Binding("Text", _panelModel, "Panel_LouverHandleType", true, DataSourceUpdateMode.OnPropertyChanged));
            //binding.Add("Panel_LouverHandleLocation", new Binding("Text", _panelModel, "Panel_LouverHandleLocation", true, DataSourceUpdateMode.OnPropertyChanged));
            //binding.Add("Panel_LouverGalleryColor", new Binding("Text", _panelModel, "Panel_LouverGalleryColor", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
