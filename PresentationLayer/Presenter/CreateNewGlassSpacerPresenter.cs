using PresentationLayer.Views;
using System.Data;
using Unity;

namespace PresentationLayer.Presenter
{
    public class CreateNewGlassSpacerPresenter : ICreateNewGlassSpacerPresenter
    {
        ICreateNewGlassSpacerView _createNewGlassSpacerView;

        private IMainPresenter _mainPresenter;
        private DataTable _spacerDT;

        public CreateNewGlassSpacerPresenter(ICreateNewGlassSpacerView createNewGlassSpacerView)
        {
            _createNewGlassSpacerView = createNewGlassSpacerView;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            //event
        }


        public ICreateNewGlassSpacerPresenter GetNewInstance(IUnityContainer unityC,
                                                      IMainPresenter mainPresenter,
                                                      DataTable spacerDT)
        {
            unityC
                .RegisterType<ICreateNewGlassSpacerView, CreateNewGlassSpacerView>()
                .RegisterType<ICreateNewGlassSpacerPresenter, CreateNewGlassSpacerPresenter>();
            CreateNewGlassSpacerPresenter createNewGlassSpacerPresenter = unityC.Resolve<CreateNewGlassSpacerPresenter>();
            createNewGlassSpacerPresenter._mainPresenter = mainPresenter;
            createNewGlassSpacerPresenter._spacerDT = spacerDT;

            return createNewGlassSpacerPresenter;
        }

        public void ShowCreateNewGlassSpacerView()
        {
            _createNewGlassSpacerView.ShowThis();
        }
    }
}
