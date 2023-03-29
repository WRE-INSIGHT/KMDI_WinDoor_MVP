using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PresentationLayer.Presenter
{
    public class PDFWaitFormPresenter : IPDFWaitFormPresenter
    {
        IPDFWaitFormView _waitFormView;
        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;

        #region Variables
        Object Rm;
        int randomValue;
        long lastDigit;
        #endregion

        public IPDFWaitFormView GetPDFWaitFormView()
        {
            return _waitFormView;
        }

        public PDFWaitFormPresenter(IPDFWaitFormView waitFormView)
        {
            _waitFormView = waitFormView;
            _waitFormView.PDFWaitFormViewLoadEventRaised += new EventHandler(OnPDFWaitFormViewLoadEventRaised);
        }

        private void OnPDFWaitFormViewLoadEventRaised(object sender, EventArgs e)
        {
            //RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider();

            //byte[] rno = new byte[4];
            //rg.GetBytes(rno);
            //randomValue = BitConverter.ToInt32(rno, 0);
            Random rand = new Random();
            randomValue = rand.Next();

            lastDigit = randomValue % (10);
            if (lastDigit % 2 == 0)
            {
                Rm = Properties.Resources.ResourceManager.GetObject("fade90");
            }
            else
            {
                Rm = Properties.Resources.ResourceManager.GetObject("fade90v2");
            }
            Bitmap myimg = (Bitmap)Rm;
            _waitFormView.GetImagelabel().Image = myimg;
        }
        public IPDFWaitFormPresenter GetNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IPDFWaitFormView, PDFWaitFormView>()
                .RegisterType<IPDFWaitFormPresenter, PDFWaitFormPresenter>();
            PDFWaitFormPresenter PDFPresenter = unityC.Resolve<PDFWaitFormPresenter>();
            PDFPresenter._mainPresenter = mainPresenter;
            PDFPresenter._unityC = unityC;

            return PDFPresenter;
        }
    }
}
