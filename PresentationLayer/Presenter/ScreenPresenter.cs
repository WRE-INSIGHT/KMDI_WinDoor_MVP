using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public class ScreenPresenter : IScreenPresenter
    {
        IScreenView _screenView;

        private IUnityContainer _unityC;

        #region Variables
        decimal
        ExchangeRate = 64m,
        HeadRailPrice,
        SlidingBarPrice,
        MeshWithTubePrice,
        GuidePrice,
        PilePrice,
        AntiwindBrushPrice,
        KitForVerticalOpeningHeadrailPrice,
        BrakePrice,
        SupportForFixingHeadRailPrice,
        SpringLoadedPrice,
        WasteCost,
        FreightCost,
        DandTCost,
        SmallShopItemCost,
        OverheadCost,
        ContingenciesCost,
        TotalPrice;

        #endregion

        public ScreenPresenter(IScreenView screenView)
        {
            _screenView = screenView;

            SubscribeToEventSetup();
        }


        private void SubscribeToEventSetup()
        {
            _screenView.nudHeightValueChangedEventRaised += _screenViewnudHeightValueChangedEventRaised;
            _screenView.nudWidthValueChangedEventRaised += _screenView_nudWidthValueChangedEventRaised;
            _screenView.nudFactorValueChangedEventRaised += _screenView_nudFactorValueChangedEventRaised;
            _screenView.cmbScreenTypeSelectedValueChangedEventRaised += _screenView_cmbScreenTypeSelectedValueChangedEventRaised;
            _screenView.ScreenViewLoadEventRaised += _screenView_ScreenViewLoadEventRaised;
        }

        #region Events

        private void _screenView_ScreenViewLoadEventRaised(object sender, System.EventArgs e)
        {

        }

        private void _screenView_cmbScreenTypeSelectedValueChangedEventRaised(object sender, System.EventArgs e)
        {

        }

        private void _screenView_nudFactorValueChangedEventRaised(object sender, System.EventArgs e)
        {

        }

        private void _screenView_nudWidthValueChangedEventRaised(object sender, System.EventArgs e)
        {

        }

        private void _screenViewnudHeightValueChangedEventRaised(object sender, System.EventArgs e)
        {

        }
        #endregion

        public IScreenView GetScreenView()
        {
            return _screenView;
        }

        public IScreenPresenter CreateNewInstance(IUnityContainer unityC)
        {
            unityC
                    .RegisterType<IScreenView, ScreenView>()
                    .RegisterType<IScreenPresenter, ScreenPresenter>();
            ScreenPresenter screen = unityC.Resolve<ScreenPresenter>();
            screen._unityC = unityC;

            return screen;
        }


    }
}
