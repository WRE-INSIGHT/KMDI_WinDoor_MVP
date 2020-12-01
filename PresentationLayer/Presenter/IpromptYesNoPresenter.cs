using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;

namespace PresentationLayer.Presenter
{
    public interface IpromptYesNoPresenter
    {
        promptYesNoPresenter.promptResult result { get; set; }
        IpromptYesNo GetPromptYesNo();
        void SetValues(IFrameUCPresenter frameUCP, IMainPresenter mainPresenter);
    }
}