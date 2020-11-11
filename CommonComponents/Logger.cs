using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonComponents
{
    public class Logger
    {
        public Logger(string content,
                      string stackTrace)
        {
            using (StreamWriter logfile = new StreamWriter(Application.StartupPath + @"\Error_Logs.txt", true))
            {
                logfile.WriteLine("Dated: " + DateTime.Now.ToString("dddd, MMMM dd, yyyy HH:mm:ss tt") +
                                 "\nError: " + content +
                                 "\nStacktrace: " + stackTrace +
                                 "\n");
            }
        }
    }
}
