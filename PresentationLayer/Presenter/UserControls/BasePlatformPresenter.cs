using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views.UserControls;
using System.Windows.Forms;
using System.Drawing;

namespace PresentationLayer.Presenter.UserControls
{
    public class BasePlatformPresenter : IBasePlatformPresenter
    {
        IBasePlatformUC _basePlatfomrUC;
        FlowLayoutPanel _flpMain;

        public BasePlatformPresenter(IBasePlatformUC basePlatformUC)
        {
            _basePlatfomrUC = basePlatformUC;
            _flpMain = _basePlatfomrUC.GetFlpMain();
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _basePlatfomrUC.basePlatformPaintEventRaised += new PaintEventHandler(OnbasePlatformPaintEventRaised);
            _basePlatfomrUC.basePlatformSizeChangedEventRaised += new EventHandler(OnbasePlatformSizeChangedEventRaised);
        }

        private void OnbasePlatformSizeChangedEventRaised(object sender, EventArgs e)
        {
            UserControl basePlatform = (UserControl)sender;
            Panel pnlMain = (Panel)basePlatform.Parent;
            int cX, cY;
            cX = (pnlMain.Width - basePlatform.Width) / 2;
            cY = (pnlMain.Height - basePlatform.Height) / 2;

            if (cX <= 30 && cY <= 30)
            {
                basePlatform.Location = new Point(60, 60);
            }
            else if (cX <= 30)
            {
                basePlatform.Location = new Point(60, cY);
            }
            else if (cY <= 30)
            {
                basePlatform.Location = new Point(cX, 60);
            }
            else
            {
                basePlatform.Location = new Point(cX - 17, cY - 35);
            }
        }

        private void OnbasePlatformPaintEventRaised(object sender, PaintEventArgs e)
        {
            //dito ilagay ang drawing ng red-arrowlines

            int ctrl_Y = 35,
                ctrl_Width = 0;
            Pen redP = new Pen(Color.Red);
            redP.Width = 3.5f;
            Font dmnsion_font = new Font("Segoe UI", 20, FontStyle.Bold);

        }

        public IBasePlatformUC getBasePlatformViewUC()
        {
            return _basePlatfomrUC;
        }

        public void SetBasePlatformSize(int wd, int ht)
        {
            _basePlatfomrUC.bp_Width = wd;
            _basePlatfomrUC.bp_Height = ht;
        }

        public void AddFrame(IFrameUC frame)
        {
            _flpMain.Controls.Add((UserControl)frame);
        }

        public void InvalidateBasePlatform()
        {
            _basePlatfomrUC.InvalidateThis();
        }

        public void PerformLayoutBasePlatform()
        {
            _basePlatfomrUC.PerformLayoutThis();
        }
    }
}
