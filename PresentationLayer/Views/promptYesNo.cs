using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views
{
    public partial class promptYesNo : Form, IpromptYesNo
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public promptYesNo()
        {
            InitializeComponent();
        }

        public string QuestionLblText
        {
            get
            {
                return lblQuestion.Text;
            }
            set
            {
                lblQuestion.Text = value;
            }
        }

        public event EventHandler questionLblSizeChangeEventRaised;
        public event EventHandler btnYesClickedEventRaised;
        public event EventHandler btnNoClickedEventRaised;

        public void PromptYesNo(string question)
        {
            lblQuestion.Text = question;
            this.Show();
        }

        private void lblQuestion_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, questionLblSizeChangeEventRaised, e);
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnYesClickedEventRaised, e);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnNoClickedEventRaised, e);
        }

        public void ClosePrompt()
        {
            this.Hide();
        }
    }
}
