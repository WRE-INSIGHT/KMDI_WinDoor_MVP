using CommonComponents;
using ModelLayer.Model.Quotation.Concrete;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            UserControl concrete = (UserControl)sender;

            int cond = concrete.Width + concrete.Height;

            for (int i = 10; i < cond; i += 10)
            {
                g.DrawLine(Pens.Black, new Point(0, i), new Point(i, 0));
            }

            int w = 1;
            g.DrawRectangle(new Pen(color, w), new Rectangle(0,
                                                             0,
                                                             concrete.ClientRectangle.Width - w,
                                                             concrete.ClientRectangle.Height - w));
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
            ConcreteUCPresenter presenter = unityC.Resolve<ConcreteUCPresenter>();
            presenter._concreteModel = concreteModel;
            presenter._mainPresenter = mainPresenter;
            presenter._unityC = unityC;
            presenter._basePlatformUCP = basePlatformUCP;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Concrete_WidthToBind", new Binding("Width", _concreteModel, "Concrete_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Concrete_HeightToBind", new Binding("Height", _concreteModel, "Concrete_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Concrete_ID", new Binding("Concrete_ID", _concreteModel, "Concrete_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Concrete_Name", new Binding("Name", _concreteModel, "Concrete_Name", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
