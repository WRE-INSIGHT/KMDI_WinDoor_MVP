using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PresentationLayer.Tests
{
    [TestClass]
    public class Draw2BmpUnitTest
    {
        [TestMethod]
        public void Draw2BmpTest()
        {
            frmDraw2BmpTesting frm = new frmDraw2BmpTesting();
            Panel pnl = frm.panel1;
            Panel pnl2 = frm.panel2;
            Bitmap bgThis = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(bgThis, new Rectangle(0, 0, pnl.Width, pnl.Height));

            //bgThis.Save(@"C:\Users\KMDI\Documents\Windoor Maker files\img\1.png", System.Drawing.Imaging.ImageFormat.Png);

            Bitmap cropped = new Bitmap(pnl.Width - 20, pnl.Height - 20);

            //Load image from file
            using (Bitmap image = new Bitmap(bgThis))
            {
                // Create a Graphics object to do the drawing, *with the new bitmap as the target*
                using (Graphics g = Graphics.FromImage(cropped))
                {
                    // Draw the desired area of the original into the graphics object
                    g.DrawImage(image, new Rectangle(0, 0, pnl.Width - 20, pnl.Height - 20), 
                                       new Rectangle(10, 10, pnl.Width - 20, pnl.Height - 20), GraphicsUnit.Pixel);
                    // Save the result
                    //cropped.Save(@"C:\Users\KMDI\Documents\Windoor Maker files\img\2.png");
                }
            }
            pnl2.BackgroundImage = cropped;
            frm.ShowDialog();
        }
    }
}
