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
        public static void RaiseEvent(Object objectRaisingEvent, EventHandler eventHandlerRaised, EventArgs eventArgs)
        {
            eventHandlerRaised?.Invoke(objectRaisingEvent, eventArgs); // Notify all subscribers
        }
        public static void RaiseMouseEvent(Object objectRaisingEvent, MouseEventHandler mouseeventHandlerRaised, MouseEventArgs mouseeventArgs)
        {
            mouseeventHandlerRaised?.Invoke(objectRaisingEvent, mouseeventArgs); // Notify all subscribers
        }
        public static void RaisePaintEvent(Object objectRaisingEvent, PaintEventHandler paintEventHandlerRaised, PaintEventArgs paintEventArgs)
        {
            paintEventHandlerRaised?.Invoke(objectRaisingEvent, paintEventArgs); // Notify all subscribers
        }
        public static void RaiseDragEvent(Object objectRaisingEvent, DragEventHandler dragEventHandlerRaised, DragEventArgs dragEventArgs)
        {
            dragEventHandlerRaised?.Invoke(objectRaisingEvent, dragEventArgs); // Notify all subscribers
        }
    }
}
