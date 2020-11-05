using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views
{
    public interface ILoginView
    {
        event EventHandler LoginBtnClickEventRaised;
        event EventHandler CancelBtnClickEventRaised;
        string username { get; set; }
        string password { get; set; }
        bool pboxVisibility { get; set; }
        bool frmVisibility { set; }
        void ShowLoginView();
        void CloseLoginView();
    }
}
