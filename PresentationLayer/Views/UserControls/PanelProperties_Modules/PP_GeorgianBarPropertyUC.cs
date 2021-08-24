using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_GeorgianBarPropertyUC : UserControl, IPP_GeorgianBarPropertyUC
    {
        public bool enable_num
        {
            set
            {
                nudHorizontal.Enabled = value;
                nudVertical.Enabled = value;
            }
        }

        public PP_GeorgianBarPropertyUC()
        {
            InitializeComponent();
        }
        public event EventHandler PPGeorgianBarPropertyUCLoadEventRaised;
        public event EventHandler cmbGBArtNumSelectedValueChangedEventRaised;
        public event EventHandler numVerticalValueChangedEventRaised;
        public event EventHandler numHorizontalValueChangedEventRaised;

        private void PP_GeorgianBarPropertyUC_Load(object sender, EventArgs e)
        {
            nudHorizontal.Maximum = decimal.MaxValue;
            nudVertical.Maximum = decimal.MaxValue;

            List<GeorgianBar_ArticleNo> GeorgianBarArtNo = new List<GeorgianBar_ArticleNo>();
            foreach (GeorgianBar_ArticleNo GBaritem in GeorgianBar_ArticleNo.GetAll())
            {
                GeorgianBarArtNo.Add(GBaritem);
            }
            cmbGBArtNum.DataSource = GeorgianBarArtNo;

            EventHelpers.RaiseEvent(sender, PPGeorgianBarPropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmbGBArtNum.DataBindings.Add(ModelBinding["Panel_GeorgianBarArtNo"]);
            nudVertical.DataBindings.Add(ModelBinding["Panel_GeorgianBar_VerticalQty"]);
            nudHorizontal.DataBindings.Add(ModelBinding["Panel_GeorgianBar_HorizontalQty"]);
            this.DataBindings.Add(ModelBinding["Panel_GeorgianBarOptionVisibility"]);
        }

        private void cmbGBArtNum_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbGBArtNumSelectedValueChangedEventRaised, e);
        }

        private void nudVertical_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, numVerticalValueChangedEventRaised, e);
        }

        private void nudHorizontal_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, numHorizontalValueChangedEventRaised, e);
        }
    }
}
