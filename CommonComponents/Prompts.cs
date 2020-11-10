using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonComponents
{
    public class Prompts : Exception
    {
        public Prompts(Exception innerException,
                       string content,
                       string caption, 
                       string stackTrace, 
                       bool log) : base(content, innerException)
        {
            MessageBox.Show(content, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
