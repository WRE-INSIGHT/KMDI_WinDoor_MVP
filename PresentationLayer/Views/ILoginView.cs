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
        event EventHandler OffLoginBtnClickEventRaised;
        event EventHandler FormLoadEventRaised;
        string username { get; set; }
        string password { get; set; }
        bool pboxVisibility { get; set; }
        bool frmVisibility { set; }
        bool chkRememberMe { get;  set; }
        void ShowLoginView();
        void CloseLoginView();
    }
}
