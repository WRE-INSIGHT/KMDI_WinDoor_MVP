using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonComponents
{
    public interface IViewCommon
    {
        void ThisBinding(Dictionary<string, Binding> ModelBinding);
    }
}
