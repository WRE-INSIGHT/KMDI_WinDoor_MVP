using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelLayer.Model.Quotation.Frame.FrameModel;

namespace PresentationLayer.Views.UserControls
{
    public interface IFramePropertiesUC
    {
        event EventHandler FramePropertiesLoadEventRaised;
        string Frame_Name { set; }
        Frame_Padding Frame_Type { set; }
        int fWidth { get; set; }
        int fHeight { get; set; }
        int ThisHeight { set; }

        void BringToFrontThis();
    }
}
