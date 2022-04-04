using CommonComponents;
using ModelLayer.Model.Quotation.Concrete;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class ConcreteUCPresenter : IConcreteUCPresenter, IPresenterCommon
    {
        IConcreteUC _concreteUC;

        private IUnityContainer _unityC;
        private IConcreteModel _concreteModel;
        private IMainPresenter _mainPresenter;
        private IBasePlatformPresenter _basePlatformUCP;

        Color color = Color.Black;

        public ConcreteUCPresenter(IConcreteUC concreteUC)
        {
            _concreteUC = concreteUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _concreteUC.ConcreteUCLoadEventRaised += _concreteUC_ConcreteUCLoadEventRaised;
            _concreteUC.ConcreteUCPaintEventRaised += _concreteUC_ConcreteUCPaintEventRaised;
        }

        private void _concreteUC_ConcreteUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            Pen blkPen = new Pen(Color.Black);

            Graphics g = e.Graphics;

            UserControl pfr = (UserControl)sender;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(color, w), new Rectangle(0,
                                                             0,
                                                             pfr.ClientRectangle.Width - w,
                                                             pfr.ClientRectangle.Height - w));
        }

        private void _concreteUC_ConcreteUCLoadEventRaised(object sender, EventArgs e)
        {
            _concreteUC.ThisBinding(CreateBindingDictionary());
        }

        public IConcreteUC GetConcreteUC()
        {
            return _concreteUC;
        }

        public IConcreteUCPresenter GetNewInstance(IUnityContainer unityC,
                                                   IConcreteModel concreteModel,
                                                   IMainPresenter mainPresenter,
                                                   IBasePlatformPresenter basePlatformUCP)
        {
            unityC
                .RegisterType<IConcreteUC, ConcreteUC>()
                .RegisterType<IConcreteUCPresenter, ConcreteUCPresenter>();
            ConcreteUCPresenter Presenter = unityC.Resolve<ConcreteUCPresenter>();
            Presenter._concreteModel = concreteModel;
            Presenter._mainPresenter = mainPresenter;
            Presenter._unityC = unityC;
            Presenter._basePlatformUCP = basePlatformUCP;

            return Presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Concrete_HeightToBind", new Binding("Width", _concreteModel, "Concrete_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Concrete_HeightToBind", new Binding("Height", _concreteModel, "Concrete_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Concrete_ID", new Binding("Concrete_ID", _concreteModel, "Concrete_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Concrete_Name", new Binding("Name", _concreteModel, "Concrete_Name", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
