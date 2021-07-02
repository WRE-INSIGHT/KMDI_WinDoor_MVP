using PresentationLayer.Views;
using System.Data;
using Unity;

namespace PresentationLayer.Presenter
{
   public class CreateNewGlassTypePresenter : ICreateNewGlassTypePresenter
    {
        ICreateNewGlassTypeView _createNewGlassTypeView;

        private IMainPresenter _mainPresenter;
        private DataTable _glassTypeDT;

        public CreateNewGlassTypePresenter(ICreateNewGlassTypeView createNewGlassTypeView)
        {
            _createNewGlassTypeView = createNewGlassTypeView;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            //events
        }


        public ICreateNewGlassTypePresenter GetNewInstance(IUnityContainer unityC,
                                                       IMainPresenter mainPresenter,
                                                       DataTable glassTypeDT)
        {
            unityC
                .RegisterType<ICreateNewGlassTypeView, CreateNewGlassTypeView>()
                .RegisterType<ICreateNewGlassTypePresenter, CreateNewGlassTypePresenter>();
            CreateNewGlassTypePresenter createNewGlassTypePresenter = unityC.Resolve<CreateNewGlassTypePresenter>();
            createNewGlassTypePresenter._mainPresenter = mainPresenter;
            createNewGlassTypePresenter._glassTypeDT = glassTypeDT;

            return createNewGlassTypePresenter;
        }



        public void ShowCreateNewGlassTypeView()
        {
            _createNewGlassTypeView.ShowThis();
        }

    }
}
