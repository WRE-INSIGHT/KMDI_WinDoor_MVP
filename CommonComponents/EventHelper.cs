using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonComponents
{
    public static class EventHelpers
    {
        public static void RaiseEvent(object objectRaisingEvent, EventHandler eventHandlerRaised, EventArgs eventArgs)
        {
            eventHandlerRaised?.Invoke(objectRaisingEvent, eventArgs); // Notify all subscribers
        }
        public static void RaiseMouseEvent(object objectRaisingEvent, MouseEventHandler mouseeventHandlerRaised, MouseEventArgs mouseeventArgs)
        {
            mouseeventHandlerRaised?.Invoke(objectRaisingEvent, mouseeventArgs); // Notify all subscribers
        }
        public static void RaisePaintEvent(object objectRaisingEvent, PaintEventHandler paintEventHandlerRaised, PaintEventArgs paintEventArgs)
        {
            paintEventHandlerRaised?.Invoke(objectRaisingEvent, paintEventArgs); // Notify all subscribers
        }
        public static void RaiseDragEvent(object objectRaisingEvent, DragEventHandler dragEventHandlerRaised, DragEventArgs dragEventArgs)
        {
            dragEventHandlerRaised?.Invoke(objectRaisingEvent, dragEventArgs); // Notify all subscribers
        }
        public static void RaiseKeyEvent(object objectRaisingEvent, KeyEventHandler keyEventHandlerRaised, KeyEventArgs keyEventArgs)
        {
            keyEventHandlerRaised?.Invoke(objectRaisingEvent, keyEventArgs); // Notify all subscribers
        }
        public static void RaiseControlEvent(object objectRaisingEvent, ControlEventHandler controlEventHandlerRaised, ControlEventArgs controlEventArgs)
        {
            controlEventHandlerRaised?.Invoke(objectRaisingEvent, controlEventArgs);
        }
        public static void RaiseDatagridviewRowpostpaintEvent(object objectRaisingEvent, DataGridViewRowPostPaintEventHandler controlEventHandlerRaised, DataGridViewRowPostPaintEventArgs controlEventArgs)
        {
            controlEventHandlerRaised?.Invoke(objectRaisingEvent, controlEventArgs);
        }
        public static void RaiseDatagridviewCellEvent(object objectRaisingEvent, DataGridViewCellEventHandler controlEventHandlerRaised, DataGridViewCellEventArgs controlEventArgs)
        {
            controlEventHandlerRaised?.Invoke(objectRaisingEvent, controlEventArgs);
        }
        public static void RaiseDatagridviewCellMouseEvent(object objectRaisingEvent, DataGridViewCellMouseEventHandler controlEventHandlerRaised, DataGridViewCellMouseEventArgs controlEventArgs)
        {
            controlEventHandlerRaised?.Invoke(objectRaisingEvent, controlEventArgs);
        }
        public static void RaiseFormClosedEvent(object objectRaisingEvent, FormClosedEventHandler controlEventHandlerRaised, FormClosedEventArgs controlEventArgs)
        {
            controlEventHandlerRaised?.Invoke(objectRaisingEvent, controlEventArgs);
        }

        public static void RaiseDatagridviewRowStateChangedEvent(object objectRaisingEvent, DataGridViewRowStateChangedEventHandler controlEventHandlerRaised, DataGridViewRowStateChangedEventArgs controlEventArgs)
        {
            controlEventHandlerRaised?.Invoke(objectRaisingEvent, controlEventArgs);
        }
        public static void RaiseFormClosingEvent(object objectRaisingEvent, FormClosingEventHandler controlEventHandlerRaised, FormClosingEventArgs controlEventArgs)
        {
            controlEventHandlerRaised?.Invoke(objectRaisingEvent, controlEventArgs);
        }
    }
}
