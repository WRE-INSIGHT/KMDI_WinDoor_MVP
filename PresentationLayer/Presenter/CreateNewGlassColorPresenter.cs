using PresentationLayer.Views;
using System.Data;
using Unity;

namespace PresentationLayer.Presenter
{
    public class CreateNewGlassColorPresenter : ICreateNewGlassColorPresenter
    {
        ICreateNewGlassColorView _createNewGlassColorView;
        private IMainPresenter _mainPresenter;
        private DataTable _colorDT;
        public CreateNewGlassColorPresenter(ICreateNewGlassColorView createNewGlassColorView)
        {
            _createNewGlassColorView = createNewGlassColorView;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            //event
        }

        public ICreateNewGlassColorPresenter GetNewInstance(IUnityContainer unityC,
                                                      IMainPresenter mainPresenter,
                                                      DataTable colorDT)
        {
            unityC
                .RegisterType<ICreateNewGlassColorView ,CreateNewGlassColorView>()
                .RegisterType<ICreateNewGlassColorPresenter, CreateNewGlassColorPresenter>();
            CreateNewGlassColorPresenter createNewGlassColorPresenter = unityC.Resolve<CreateNewGlassColorPresenter>();
            createNewGlassColorPresenter._mainPresenter = mainPresenter;
            createNewGlassColorPresenter._colorDT = colorDT;

            return createNewGlassColorPresenter;
        }


        public void ShowCreateNewGlassColorView()
        {
            _createNewGlassColorView.ShowThis();
        }


    }
}
