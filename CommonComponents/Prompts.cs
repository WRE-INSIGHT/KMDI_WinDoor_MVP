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
        //public string promptCaption { get; set; }
        //public string promptTitle { get; set; }
        //public string stackTrace { get; set; }
        //public bool logToFile { get; set; }
        //public MessageBoxButtons promptBtn { get; set; }
        //public MessageBoxIcon promptIcon { get; set; }
        //public MessageBoxOptions promptOpt { get; set; }
        //public MessageBoxDefaultButton promptDefault { get; set; }

        public void Prompt(string content,
                           string caption, 
                           string stackTrace, 
                           bool log, 
                           MessageBoxButtons msgBtn, 
                           MessageBoxIcon msgIcon,
                           MessageBoxDefaultButton msgDef = MessageBoxDefaultButton.Button1)
        {
            //promptCaption = caption;
            //promptTitle = title;
            MessageBox.Show(content, caption, msgBtn, msgIcon, msgDef);
        }
    }
}
