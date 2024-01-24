using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class GeorgianBarCustomizeDesignView : Form, IGeorgianBarCustomizeDesignView
    {
        public GeorgianBarCustomizeDesignView()
        {
            InitializeComponent();
        }
        public event EventHandler GeorgianBarCustomizeDesignViewLoadEventRaised;

        public event EventHandler FormTimerTickEventRaised;
        public event PaintEventHandler GeorgianBarCustomizeDesignViewPaintEventRaised;
        public event MouseEventHandler GeorgianBarCustomizeDesignViewMouseDownEventRaised;
        public event MouseEventHandler GeorgianBarCustomizeDesignViewMouseMoveEventRaised;
        public event MouseEventHandler GeorgianBarCustomizeDesignViewMouseUpEventRaised;
        public event MouseEventHandler GeorgianBarCustomizeDesignViewMouseClickEventRaised;

        public Form GetFormView()
        {
            return this;
        }



        public void ShowView()
        {
            this.Show();
        }
        private void GeorgianBarCustomizeDesignView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, GeorgianBarCustomizeDesignViewLoadEventRaised, e);
        }



        private void FormTimerTickEvent(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, FormTimerTickEventRaised, e);

        }

        private void GeorgianBarCustomizeDesignView_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, GeorgianBarCustomizeDesignViewPaintEventRaised, e);
        }

        private void GeorgianBarCustomizeDesignView_MouseDown(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, GeorgianBarCustomizeDesignViewMouseDownEventRaised, e);
        }

        private void GeorgianBarCustomizeDesignView_MouseMove(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, GeorgianBarCustomizeDesignViewMouseMoveEventRaised, e);
        }

        private void GeorgianBarCustomizeDesignView_MouseUp(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, GeorgianBarCustomizeDesignViewMouseUpEventRaised, e);
        }

        private void GeorgianBarCustomizeDesignView_MouseClick(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, GeorgianBarCustomizeDesignViewMouseClickEventRaised, e);
        }
    }
}
