﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.Dividers
{
    public partial class TransomUC : UserControl, ITransomUC
    {
        public TransomUC()
        {
            InitializeComponent();
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.Transparent;
        }

        private int _divID;
        public int Div_ID
        {
            get
            {
                return _divID;
            }
            set
            {
                _divID = value;
            }
        }

        public event MouseEventHandler transomUCMouseDownEventRaised;
        public event MouseEventHandler transomUCMouseMoveEventRaised;
        public event MouseEventHandler transomUCMouseUpEventRaised;
        public event PaintEventHandler transomUCPaintEventRaised;
        //public event EventHandler deleteToolStripMenuItemClickedEventRaised;
        public event EventHandler transomUCMouseEnterEventRaised;
        public event EventHandler transomUCMouseLeaveEventRaised;
        public event EventHandler transomUCSizeChangedEventRaised;
        public event MouseEventHandler transomUCMouseDoubleClickedEventRaised;
        public event KeyEventHandler transomUCKeyDownEventRaised;
        public event MouseEventHandler transomUCMouseClickedEventRaised;

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        private void TransomUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, transomUCPaintEventRaised, e);
        }

        private void TransomUC_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, transomUCMouseEnterEventRaised, e);
        }

        private void TransomUC_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, transomUCMouseLeaveEventRaised, e);
        }

        private void TransomUC_MouseUp(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, transomUCMouseUpEventRaised, e);
        }

        private void TransomUC_MouseDown(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, transomUCMouseDownEventRaised, e);
        }

        private void TransomUC_MouseMove(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, transomUCMouseMoveEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Div_ID"]);
            this.DataBindings.Add(ModelBinding["Div_Name"]);
            this.DataBindings.Add(ModelBinding["Div_Visible"]);
            this.DataBindings.Add(ModelBinding["Div_WidthToBind"]);
            this.DataBindings.Add(ModelBinding["Div_HeightToBind"]);
        }
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (this.Parent == null)
            {
                RemoveDataBinding();
            }

        }
        private void RemoveDataBinding()
        {
            this.DataBindings.Clear();
            this.Dispose();
            deleteToolStripMenuItem.Dispose();
            cmenu_transom.Dispose();
        }

        private void TransomUC_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    cmenu_transom.Show(new Point(MousePosition.X, MousePosition.Y));
            //}
            if (e.Button == MouseButtons.Left)
            {
                EventHelpers.RaiseMouseEvent(sender, transomUCMouseClickedEventRaised, e);
            }
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //EventHelpers.RaiseEvent(sender, deleteToolStripMenuItemClickedEventRaised, e);
        }

        private void TransomUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, transomUCSizeChangedEventRaised, e);
        }

        private void TransomUC_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, transomUCMouseDoubleClickedEventRaised, e);
        }

        private void TransomUC_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseKeyEvent(this, transomUCKeyDownEventRaised, e);
        }
        
        private void TransomUC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
            }
        }

        public void FocusOnThis()
        {
            this.Focus();
        }

    }
}
