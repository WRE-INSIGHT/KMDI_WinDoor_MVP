using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views;
using PresentationLayer.Presenter.UserControls;
using System.Windows.Forms;

namespace PresentationLayer.Presenter
{
    public class promptYesNoPresenter : IpromptYesNoPresenter
    {
        public enum promptResult
        {
            Yes = 1,
            No = 2
        }

        IpromptYesNo _promptYesNo;
        private IMainPresenter _mainPresenter;
        private IFrameUCPresenter _frameUCP;
        private promptResult this_result;

        public promptResult result
        {
            get
            {
                return this_result;
            }

            set
            {
                this_result = value;
            }
        }

        public promptYesNoPresenter(IpromptYesNo promptYesNo)
        {
            _promptYesNo = promptYesNo;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _promptYesNo.questionLblSizeChangeEventRaised += new EventHandler(OnQuestionLblSizeChangeEventRaised);
            _promptYesNo.btnYesClickedEventRaised += new EventHandler(OnBtnYesClickedEventRaised);
            _promptYesNo.btnNoClickedEventRaised += new EventHandler(OnBtnNoClickedEventRaised);
        }

        private void OnBtnNoClickedEventRaised(object sender, EventArgs e)
        {
            this_result = promptResult.No;
            _frameUCP.PromptYesNo_Results();
           
        }

        private void OnBtnYesClickedEventRaised(object sender, EventArgs e)
        {
            this_result = promptResult.Yes;
            _frameUCP.PromptYesNo_Results();
        }

        private void OnQuestionLblSizeChangeEventRaised(object sender, EventArgs e)
        {
            Label questionLbl = (Label)sender;
            int cX, cY;
            cX = (300 - questionLbl.Width) / 2;
            cY = (150 - questionLbl.Height) / 2;

            questionLbl.Location = new System.Drawing.Point(cX, 33);
        }

        public void SetValues(IFrameUCPresenter frameUCP, IMainPresenter mainPresenter)
        {
            _frameUCP = frameUCP;
            _mainPresenter = mainPresenter;
        }

        public IpromptYesNo GetPromptYesNo()
        {
            return _promptYesNo;
        }
    }
}
