using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views;

namespace PresentationLayer.Presenter
{
    public class frmDimensionPresenter : IfrmDimensionPresenter
    {
        IfrmDimensionView _frmDimensionView;
        private IMainPresenter _mainPresenter;

        public frmDimensionPresenter(IfrmDimensionView frmDimensionView)
        {
            _frmDimensionView = frmDimensionView;
            SubscribeToEventsSetup();
        }

        public IfrmDimensionView GetDimensionView()
        {
            return _frmDimensionView;
        }
        private void SubscribeToEventsSetup()
        {
            _frmDimensionView.frmDimensionLoadEventRaised += new EventHandler(OnfrmDimensionLoadEventRaised);
            _frmDimensionView.btnOKClickedEventRaised += new EventHandler(OnbtnOKClickedEventRaised);
            _frmDimensionView.btnCancelClickedEventRaised += new EventHandler(OnbtnCancelClickedEventRaised);
        }

        private void OnbtnCancelClickedEventRaised(object sender, EventArgs e)
        {
            _frmDimensionView.ClosefrmDimension();
        }

        private void OnbtnOKClickedEventRaised(object sender, EventArgs e)
        {
            _mainPresenter.SetValues_flpBase(_frmDimensionView.InumWidth, _frmDimensionView.InumHeight);
            _frmDimensionView.ClosefrmDimension();
        }

        private void OnfrmDimensionLoadEventRaised(object sender, EventArgs e)
        {
            _frmDimensionView.InumWidth = 400;
            _frmDimensionView.InumHeight = 400;
        }

        public void SetValues(IMainPresenter mainPresenter)
        {
            _mainPresenter = mainPresenter;
        }
    }
}
