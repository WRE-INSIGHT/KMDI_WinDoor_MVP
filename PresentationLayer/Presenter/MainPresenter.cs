using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        IMainView _mainView;

        public MainPresenter(IMainView mainView)
        {
            _mainView = mainView;
            SubscribeToEventsSetup();
        }
        public IMainView GetMainView()
        {
            return _mainView;
        }

        private void SubscribeToEventsSetup()
        {
            _mainView.MainViewLoadEventRaised += new EventHandler(OnMainViewLoadEventRaised);
        }

        public void OnMainViewLoadEventRaised(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Hello World");
        }
    }
}
