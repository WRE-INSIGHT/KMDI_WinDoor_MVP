using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;
using System.IO;
using System.Drawing.Drawing2D;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public partial class MultiPanelTransomUC : UserControl, IMultiPanelTransomUC
    {
        public MultiPanelTransomUC()
        {
            InitializeComponent();
        }

        private int _mpanelID;
        public int MPanel_ID
        {
            get
            {
                return _mpanelID;
            }
            set
            {
                _mpanelID = value;
            }
        }
        public event PaintEventHandler flpMulltiPaintEventRaised;
        public event EventHandler flpMultiMouseEnterEventRaised;
        public event EventHandler flpMultiMouseLeaveEventRaised;
        public event EventHandler divCountClickedEventRaised;
        public event EventHandler deleteClickedEventRaised;
        public event DragEventHandler flpMultiDragDropEventRaised;

        public void InvalidateFlp()
        {
            flp_MultiTransom.Invalidate();
        }

        public void DeletePanel(UserControl panel)
        {
            flp_MultiTransom.Controls.Remove(panel);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["MPanel_ID"]);
            this.DataBindings.Add(ModelBinding["MPanel_Dock"]);
            this.DataBindings.Add(ModelBinding["MPanel_Width"]);
            this.DataBindings.Add(ModelBinding["MPanel_Height"]);
            this.DataBindings.Add(ModelBinding["MPanel_Visibility"]);
        }

        private void flp_MultiTransom_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, flpMulltiPaintEventRaised, e);
        }

        private void flp_MultiTransom_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, flpMultiMouseEnterEventRaised, e);
        }

        private void flp_MultiTransom_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, flpMultiMouseLeaveEventRaised, e);
        }

        private void flp_MultiTransom_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmenu_mulltiP.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void divCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, divCountClickedEventRaised, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteClickedEventRaised, e);
        }

        private void flp_MultiTransom_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flp_MultiTransom_DragDrop(object sender, DragEventArgs e)
        {
            EventHelpers.RaiseDragEvent(sender, flpMultiDragDropEventRaised, e);
        }

        public Bitmap GetPartImageThis(int height)
        {
            Bitmap bgThis = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bgThis, new Rectangle(0, 0, this.Width, this.Height));

            bgThis.Save(@"C:\Users\KMDI\Documents\Windoor Maker files\img\5.png", System.Drawing.Imaging.ImageFormat.Jpeg);
            int crop_wd = this.Width,
                crop_ht = height;

            Bitmap cropped = new Bitmap(crop_wd, crop_ht);

            //Load image from file
            using (Bitmap image = new Bitmap(bgThis))
            {
                // Create a Graphics object to do the drawing, *with the new bitmap as the target*
                using (Graphics g = Graphics.FromImage(cropped))
                {
                    // Draw the desired area of the original into the graphics object
                    
                    Point[] polyPoints = {
new Point(10, 10),
new Point(150, 10),
new Point(100, 75),
new Point(100, 150)};
                    GraphicsPath path = new GraphicsPath();
                    path.AddPolygon(polyPoints);

                    // Construct a region based on the path.
                    Region region = new Region(path);
                    // Set the clipping region of the Graphics object.
                    g.SetClip(region, CombineMode.Replace);

                    g.DrawImage(image, new Rectangle(0, 0, crop_wd, crop_ht),
                                       new Rectangle(0, 0, crop_wd, crop_ht),
                                       GraphicsUnit.Pixel);

                    // Save the result
                    //cropped.Save(@"C:\Users\KMDI\Documents\Windoor Maker files\img\2.png");
                }
            }

            cropped.Save(@"C:\Users\KMDI\Documents\Windoor Maker files\img\6.png", System.Drawing.Imaging.ImageFormat.Jpeg);
            return cropped;
        }
    }
}
