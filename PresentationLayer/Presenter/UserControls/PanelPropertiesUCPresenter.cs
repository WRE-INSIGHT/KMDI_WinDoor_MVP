﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views.UserControls;
using ModelLayer.Model.Quotation.Panel;
using System.Windows.Forms;
using Unity;
using CommonComponents;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls
{
    public class PanelPropertiesUCPresenter : IPanelPropertiesUCPresenter, IPresenterCommon
    {
        IPanelPropertiesUC _panelPropertiesUC;

        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;

        public PanelPropertiesUCPresenter(IPanelPropertiesUC panelPropertiesUC)
        {
            _panelPropertiesUC = panelPropertiesUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _panelPropertiesUC.PanelPropertiesLoadEventRaised += new EventHandler(OnPanelPropertiesLoadEventRaised);
            _panelPropertiesUC.ChkOrientationCheckChangedEventRaised += _panelPropertiesUC_ChkOrientationCheckChangedEventRaised;
            _panelPropertiesUC.CmbGlassThickSelectedValueChangedEventRaised += _panelPropertiesUC_CmbGlassThickSelectedValueChangedEventRaised;
            //_panelPropertiesUC.PnumWidthValueChangedEventRaised += _panelPropertiesUC_PnumWidthValueChangedEventRaised;
            //_panelPropertiesUC.PnumHeightValueChangedEventRaised += _panelPropertiesUC_PnumHeightValueChangedEventRaised;
        }

        private void _panelPropertiesUC_CmbGlassThickSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_GlassThickness = (Glass_Thickness)((ComboBox)sender).SelectedValue;
        }

        //int prev_Width, prev_Height;
        //private void _panelPropertiesUC_PnumHeightValueChangedEventRaised(object sender, EventArgs e)
        //{
        //    NumericUpDown numH = (NumericUpDown)sender;
        //    if (numH.Enabled)
        //    {
        //        _panelModel.Panel_Height += (prev_Height - (int)numH.Value);
        //        prev_Height = (int)numH.Value;
        //    }
        //}

        //private void _panelPropertiesUC_PnumWidthValueChangedEventRaised(object sender, EventArgs e)
        //{
        //    NumericUpDown numW = (NumericUpDown)sender;
        //    if (numW.Enabled)
        //    {
        //        _panelModel.Panel_Width += (prev_Width - (int)numW.Value);
        //        prev_Width = (int)numW.Value;
        //    }
        //}

        private void _panelPropertiesUC_ChkOrientationCheckChangedEventRaised(object sender, EventArgs e)
        {
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
        }

        private void OnPanelPropertiesLoadEventRaised(object sender, EventArgs e)
        {
            _panelPropertiesUC.ThisBinding(CreateBindingDictionary());
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Width", new Binding("Value", _panelModel, "Panel_DisplayWidth", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Height", new Binding("Value", _panelModel, "Panel_DisplayHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Name", new Binding("Text", _panelModel, "Panel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Type", new Binding("Text", _panelModel, "Panel_Type", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_ChkText", new Binding("Text", _panelModel, "Panel_ChkText", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Orient", new Binding("Checked", _panelModel, "Panel_Orient", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_PNumEnable1", new Binding("Enabled", _panelModel, "Panel_PNumEnable", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_PNumEnable2", new Binding("Enabled", _panelModel, "Panel_PNumEnable", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_GlassThickness", new Binding("Text", _panelModel, "Panel_GlassThickness", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelGlazingBead_ArtNo", new Binding("Text", _panelModel, "PanelGlazingBead_ArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelGlass_ID", new Binding("PanelGlass_ID", _panelModel, "PanelGlass_ID", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }

        public IPanelPropertiesUC GetPanelPropertiesUC()
        {
            return _panelPropertiesUC;
        }


        public IPanelPropertiesUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IPanelPropertiesUC, Panel_PropertiesUC>()
                .RegisterType<IPanelPropertiesUCPresenter, PanelPropertiesUCPresenter>();
            PanelPropertiesUCPresenter panelPropUCP = unityC.Resolve<PanelPropertiesUCPresenter>();
            panelPropUCP._panelModel = panelModel;
            panelPropUCP._mainPresenter = mainPresenter;

            return panelPropUCP;
        }

    }
}
