using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IpromptYesNo
    {
        event EventHandler questionLblSizeChangeEventRaised;
        event EventHandler btnYesClickedEventRaised;
        event EventHandler btnNoClickedEventRaised;
        string QuestionLblText { get; set; }
        void PromptYesNo(string question);
        void ClosePrompt();
    }
}