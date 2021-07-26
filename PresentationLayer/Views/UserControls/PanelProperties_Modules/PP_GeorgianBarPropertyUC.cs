using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_GeorgianBarPropertyUC : UserControl, IPP_GeorgianBarPropertyUC
    {
        public PP_GeorgianBarPropertyUC()
        {
            InitializeComponent();
        }
        public event EventHandler PPGeorgianBarPropertyUCLoadEventRaised;
        public event EventHandler nudVerticalQuantityValueChanged;
        public event EventHandler nudHorizontalQuantityValueChanged;
        private void PP_GeorgianBarPropertyUC_Load(object sender, EventArgs e)
        {
            List<GeorgianBar_ArticleNo> GeorgianBarArtNo = new List<GeorgianBar_ArticleNo>();
            foreach (GeorgianBar_ArticleNo GBaritem in GeorgianBar_ArticleNo.GetAll())
            {
                GeorgianBarArtNo.Add(GBaritem);
            }
            cmbGBArtNum.DataSource = GeorgianBarArtNo;

            EventHelpers.RaiseEvent(sender, PPGeorgianBarPropertyUCLoadEventRaised, e);
        }

        private void nudVertical_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudVerticalQuantityValueChanged, e);
        }

        private void nudHorizontal_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudHorizontalQuantityValueChanged, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmbGBArtNum.DataBindings.Add(ModelBinding["Panel_GeorgianBarArticleNo"]);
            nudVertical.DataBindings.Add(ModelBinding["Panel_GeorgianBarVerticalQuantity"]);
            nudHorizontal.DataBindings.Add(ModelBinding["Panel_GeorgianBarHorizontalQuantity"]);

        }
    }
}
