using CommonComponents;
using ModelLayer.Model.Quotation.Concrete;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class ConcretePropertiesUCPresenter
    {
        IConcretePropertiesUC _concretePropertiesUC;
        IUnityContainer _unityC;

        private IConcreteModel _concreteModel;
        private IMainPresenter _mainPresenter;

        public ConcretePropertiesUCPresenter(IConcretePropertiesUC concretePropertiesUC)
        {
            _concretePropertiesUC = concretePropertiesUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _concretePropertiesUC.ConcretePropertiesUCLoadEventRaised += _concretePropertiesUC_ConcretePropertiesUCLoadEventRaised;
            _concretePropertiesUC.numcWidthValueChangedEventRaised += _concretePropertiesUC_numcWidthValueChangedEventRaised;
            _concretePropertiesUC.numcHeightValueChangedEventRaised += _concretePropertiesUC_numcHeightValueChangedEventRaised;
        }

        private void _concretePropertiesUC_numcHeightValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void _concretePropertiesUC_numcWidthValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void _concretePropertiesUC_ConcretePropertiesUCLoadEventRaised(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }
    }
}
