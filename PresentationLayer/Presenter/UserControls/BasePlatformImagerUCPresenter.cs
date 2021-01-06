using CommonComponents;
using ModelLayer.Model.Quotation.WinDoor;
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
    public class BasePlatformImagerUCPresenter : IBasePlatformImagerUCPresenter, IPresenterCommon
    {
        IBasePlatformImagerUC _basePlatformImagerUC;

        IWindoorModel _windoorModel;

        public BasePlatformImagerUCPresenter(IBasePlatformImagerUC basePlatformImagerUC)
        {
            _basePlatformImagerUC = basePlatformImagerUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _basePlatformImagerUC.basePlatformPaintEventRaised += _basePlatformImagerUC_basePlatformPaintEventRaised;
            _basePlatformImagerUC.flpFrameDragDropPaintEventRaised += _basePlatformImagerUC_flpFrameDragDropPaintEventRaised;
        }

        private void _basePlatformImagerUC_flpFrameDragDropPaintEventRaised(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color col = Color.Black;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                           0,
                                                           pnl.ClientRectangle.Width - w,
                                                           pnl.ClientRectangle.Height - w));
        }

        private void _basePlatformImagerUC_basePlatformPaintEventRaised(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            
        }

        public IBasePlatformImagerUC GetBasePlatformImagerUC()
        {
            return _basePlatformImagerUC;
        }

        public IBasePlatformImagerUCPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel)
        {
            unityC
                .RegisterType<IBasePlatformImagerUC, BasePlatformImagerUC>()
                .RegisterType<IBasePlatformImagerUCPresenter, BasePlatformImagerUCPresenter>();
            BasePlatformImagerUCPresenter imagerUCP = unityC.Resolve<BasePlatformImagerUCPresenter>();
            imagerUCP._windoorModel = windoorModel;
            imagerUCP._basePlatformImagerUC.ClearBinding((UserControl)_basePlatformImagerUC);

            return imagerUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            throw new NotImplementedException();
        }

        public void InvalidateBasePlatform()
        {
            throw new NotImplementedException();
        }
    }
}
