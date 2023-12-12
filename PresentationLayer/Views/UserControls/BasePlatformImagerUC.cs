using CommonComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class BasePlatformImagerUC : UserControl, IBasePlatformImagerUC
    {
        public BasePlatformImagerUC()
        {
            InitializeComponent();
        }

        public event EventHandler basePlatformSizeChangedEventRaised;
        public event EventHandler BasePlatformImagerUCLoadEventRaised;
        public event PaintEventHandler basePlatformPaintEventRaised;
        public event PaintEventHandler flpFrameDragDropPaintEventRaised;

        public void ClearBinding(Control _basePlatfomrUC)
        {
            _basePlatfomrUC.DataBindings.Clear();
        }

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["WD_width_4basePlatform_forImageRenderer"]);
            this.DataBindings.Add(ModelBinding["WD_height_4basePlatform_forImageRenderer"]);
            this.DataBindings.Add(ModelBinding["WD_visibility"]);
        }

        private void BasePlatformImagerUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, basePlatformPaintEventRaised, e);
        } 

        private void flp_frameDragDrop_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, flpFrameDragDropPaintEventRaised, e);
        }

        private void BasePlatformImagerUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, basePlatformSizeChangedEventRaised, e);
        }

        public FlowLayoutPanel GetFlpMain()
        {
            return flp_frameDragDrop;
        }

        public UserControl GetBasePlatformImagerUC()
        {
            return this;
        }

        public void BringToFront_baseImager()
        {
            this.BringToFront();
        }

        public void SendToBack_baseImager()
        {
            this.SendToBack();
        }

        private void BasePlatformImagerUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, BasePlatformImagerUCLoadEventRaised, e);
        }
        private void BasePlatformImagerUC_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Images|*.png;*.bmp;*.jpg";
            dialog.AddExtension = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(this.Width);
                int height = Convert.ToInt32(this.Height);
                using (Bitmap bmp = new Bitmap(width, height))
                {
                    this.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                    bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                }
            }
        }
    }
}
