using CommonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ModelLayer.Model.Quotation.Frame.FrameModel;

namespace PresentationLayer.Views.UserControls
{
    public interface IFramePropertiesUC: IViewCommon
    {
        int FrameID { get; set; }
        Frame_Padding Frame_Type { get; set; }

        event EventHandler FramePropertiesLoadEventRaised;
        event EventHandler NumFHeightValueChangedEventRaised;
        event EventHandler NumFWidthValueChangedEventRaised;
        event EventHandler RdBtnCheckedChangedEventRaised;
        event EventHandler cmbFrameProfileSelectedValueChangedEventRaised;
        event EventHandler cmbFrameReinfSelectedValueChangedEventRaised;
        void BringToFrontThis();
        Panel GetFramePropertiesPNL();
        Panel GetBodyPropertiesPNL();
        void SetFrameTypeRadioBtnEnabled(bool frameTypeEnabled);
        void AddHT_PanelBody(int addht);
    }
}
