using PresentationLayer.Views;
using System.Windows.Forms;
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

        int _screen_Width, _screen_Height;
        decimal _factor;
        private void SubscribeToEventSetup()
        {
            _screenView.nudHeightValueChangedEventRaised += _screenViewnudHeightValueChangedEventRaised;
            _screenView.nudWidthValueChangedEventRaised += _screenView_nudWidthValueChangedEventRaised;
            _screenView.nudFactorValueChangedEventRaised += _screenView_nudFactorValueChangedEventRaised;
            _screenView.cmbScreenTypeSelectedValueChangedEventRaised += _screenView_cmbScreenTypeSelectedValueChangedEventRaised;
            _screenView.ScreenViewLoadEventRaised += _screenView_ScreenViewLoadEventRaised;

            _screen_Width = _screenView.screen_width;
            _screen_Height = _screenView.screen_height;
            _factor = _screenView.screen_factor;
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

        public void ComputeScreen()
        {

        }

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
