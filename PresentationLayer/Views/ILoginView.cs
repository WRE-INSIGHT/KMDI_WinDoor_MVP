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
        void ShowLoginView();
    }
}
