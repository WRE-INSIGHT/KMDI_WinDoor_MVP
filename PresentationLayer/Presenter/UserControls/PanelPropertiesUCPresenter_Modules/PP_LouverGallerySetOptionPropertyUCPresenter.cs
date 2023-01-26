using Microsoft.VisualBasic;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Variables;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_LouverGallerySetOptionPropertyUCPresenter : IPP_LouverGallerySetOptionPropertyUCPresenter
    {
        IPP_LouverGallerySetOptionPropertyUC _pp_LouverGallerySetOptionPropertyUC;

        private IUnityContainer _unityC;
        private IPanelModel _panelModel;
        private IMainPresenter _mainPresenter;
        private IPP_LouverGallerySetPropertyUCPresenter _louverGallerySetPropertyUCPresenter;

        private ConstantVariables constants = new ConstantVariables();


        public PP_LouverGallerySetOptionPropertyUCPresenter(IPP_LouverGallerySetOptionPropertyUC pp_LouverGallerySetOptionPropertyUC)
        {
            _pp_LouverGallerySetOptionPropertyUC = pp_LouverGallerySetOptionPropertyUC;

            SubcribeToEventSetup();
        }

        private void SubcribeToEventSetup()
        {
            _pp_LouverGallerySetOptionPropertyUC.LouverGallerySetOptionPropertyUCLoadEventRaised += _pp_LouverGallerySetOptionPropertyUC_LouverGallerySetOptionPropertyUCLoadEventRaised;
            _pp_LouverGallerySetOptionPropertyUC.btnDeleteGallerySetClickEventRaised += _pp_LouverGallerySetOptionPropertyUC_btnDeleteGallerySetClickEventRaised;
            _pp_LouverGallerySetOptionPropertyUC.changeArtNoToolStripMenuItemClickEventRaised += _pp_LouverGallerySetOptionPropertyUC_changeArtNoToolStripMenuItemClickEventRaised;

        }

        private void _pp_LouverGallerySetOptionPropertyUC_changeArtNoToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Please Input the Gallery Set Article Number", "WinDoor Maker", _pp_LouverGallerySetOptionPropertyUC.GetCmbLouverGalleryArtNo().Text);
            bool HasSpace = input.Contains(" ");

            if (input != "" &&
                input.Contains("-") &&
                HasSpace == false)
            {
                try
                {
                    string GetSetNum = _pp_LouverGallerySetOptionPropertyUC.lblGallerySetArtNo.Replace("Set ", string.Empty);
                    int lvrUpdate = Convert.ToInt32(GetSetNum);

                    _pp_LouverGallerySetOptionPropertyUC.GetCmbLouverGalleryArtNo().Text = input.ToUpper();
                    _panelModel.Panel_LstLouverArtNo[lvrUpdate] = input.ToUpper();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (input == "")
                {

                }
                else
                {
                    MessageBox.Show("Input correct format of gallery set");
                }
            }
        }

        private void _pp_LouverGallerySetOptionPropertyUC_btnDeleteGallerySetClickEventRaised(object sender, EventArgs e)
        {
            Control LouverGallerySetOptionUC = ((UserControl)_pp_LouverGallerySetOptionPropertyUC).Parent;
            LouverGallerySetOptionUC.Controls.Remove((UserControl)_pp_LouverGallerySetOptionPropertyUC);

            _panelModel.AdjustPropertyPanelHeight("minusLouverGallerySetArtNo");

            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusLouverGallerySetArtNo");

            if (_panelModel.Panel_ParentMultiPanelModel != null)
            {
                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusLouverGallerySetArtNo");
            }

            ((UserControl)_louverGallerySetPropertyUCPresenter.GetLouverGallerySetPropertyUC()).Height -= constants.panel_property_LouverGallerySetArtNoOptionsheight;
            _louverGallerySetPropertyUCPresenter.GallerySet_Count--;
            _panelModel.Panel_LouverGallerySetCount--;
            _louverGallerySetPropertyUCPresenter.Remove_GallerySet(this);

            string GetSetNum = _pp_LouverGallerySetOptionPropertyUC.lblGallerySetArtNo.Replace("Set ", string.Empty);

            int lstCheck = 1;
            foreach (string LouverAr in _panelModel.Panel_LstLouverArtNo)
            {
                if (lstCheck == Convert.ToInt32(GetSetNum))
                {
                    _panelModel.Panel_LstLouverArtNo.Remove(LouverAr);
                    break;
                }
                lstCheck++;
            }


            _louverGallerySetPropertyUCPresenter.SortGallerySetOrderNumber();
            _mainPresenter.GetCurrentPrice();
            _mainPresenter.itemDescription();
        }

        private void _pp_LouverGallerySetOptionPropertyUC_LouverGallerySetOptionPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_LouverGallerySetOptionPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_LouverGallerySetOptionPropertyUC GetLouverGallerySetOptionPropertyUC()
        {
            return _pp_LouverGallerySetOptionPropertyUC;
        }

        public IPP_LouverGallerySetOptionPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                    IMainPresenter mainPresenter,
                                                                    IPanelModel panelModel,
                                                                    IPP_LouverGallerySetPropertyUCPresenter louverGallerySetPropertyUCPresenter)
        {
            unityC
                .RegisterType<IPP_LouverGallerySetOptionPropertyUC, PP_LouverGallerySetOptionPropertyUC>()
                .RegisterType<IPP_LouverGallerySetOptionPropertyUCPresenter, PP_LouverGallerySetOptionPropertyUCPresenter>();

            PP_LouverGallerySetOptionPropertyUCPresenter GallerySetOption = unityC.Resolve<PP_LouverGallerySetOptionPropertyUCPresenter>();
            GallerySetOption._unityC = unityC;
            GallerySetOption._mainPresenter = mainPresenter;
            GallerySetOption._panelModel = panelModel;
            GallerySetOption._louverGallerySetPropertyUCPresenter = louverGallerySetPropertyUCPresenter;

            return GallerySetOption;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_LouverGallerySetOptionVisibility", new Binding("Visible", _panelModel, "Panel_LouverGallerySetOptionVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            //binding.Add("Panel_LouverGallerySetOptionArtNo", new Binding("Text", _panelModel, "Panel_LouverGallerySetOptionArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
