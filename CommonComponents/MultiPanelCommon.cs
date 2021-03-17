using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Divider;

namespace CommonComponents
{
    public class MultiPanelCommon
    {
        public List<Point[]> GetTransomDividerDrawingPoints(int width,
                                                            int height,
                                                            string nxtobj_name,
                                                            string placement,
                                                            string frameType,
                                                            bool allowed = false)
        {
            List<Point[]> MullionDraw_Points = new List<Point[]>();

            Point[] upperLine = new Point[2];
            Point[] botLine = new Point[2];
            Point[] leftCurve = new Point[3];
            Point[] rightCurve = new Point[3];

            int accessible_Wd = width - 2,
                Wd_beforeCurve = width - 5;
            int pixels_count = 0, accessible_Ht_start = 0, frameTypeInt = 0, midPoint = 0;

            if (frameType == "Window")
            {
                pixels_count = 8;
                frameTypeInt = Convert.ToInt32(FrameModel.Frame_Padding.Window);
            }
            else if (frameType == "Door")
            {
                pixels_count = 10;
                frameTypeInt = Convert.ToInt32(FrameModel.Frame_Padding.Door);
            }

            if (placement == "First" || (placement == "Somewhere in Between" && allowed == true))
            {
                if (nxtobj_name.Contains("Transom"))
                {
                    int bot_EndPoint = height + 16;

                    accessible_Ht_start = height - pixels_count;
                    midPoint = height + 4;
                        
                    upperLine[0] = new Point(5, accessible_Ht_start);
                    upperLine[1] = new Point(Wd_beforeCurve, accessible_Ht_start);

                    rightCurve[0] = new Point(Wd_beforeCurve, accessible_Ht_start);
                    rightCurve[1] = new Point(accessible_Wd, midPoint); //midpoint = 12; (26 - 2) / 2; then 8 + 4 = 12; 8 is height allowance for transom divider on this code
                    rightCurve[2] = new Point(Wd_beforeCurve, bot_EndPoint); //bottom endPoint is 24; then 8 + 16 = 24 

                    botLine[0] = new Point(Wd_beforeCurve, bot_EndPoint);
                    botLine[1] = new Point(5, bot_EndPoint);

                    leftCurve[0] = new Point(5, bot_EndPoint);
                    leftCurve[1] = new Point(1, midPoint);
                    leftCurve[2] = new Point(5, accessible_Ht_start);
                }
            }
            else if (placement == "Last" || placement == "Somewhere in Between")
            {
                accessible_Ht_start = ((frameTypeInt - pixels_count) - 1) * -1;
                midPoint = (pixels_count - ((frameTypeInt - 2) / 2)) - 3;

                upperLine[0] = new Point(5, accessible_Ht_start);
                upperLine[1] = new Point(Wd_beforeCurve, accessible_Ht_start);

                rightCurve[0] = new Point(Wd_beforeCurve, accessible_Ht_start);
                rightCurve[1] = new Point(accessible_Wd, midPoint);
                rightCurve[2] = new Point(Wd_beforeCurve, pixels_count);

                botLine[0] = new Point(Wd_beforeCurve, pixels_count);
                botLine[1] = new Point(5, pixels_count);

                leftCurve[0] = new Point(5, pixels_count);
                leftCurve[1] = new Point(1, midPoint);
                leftCurve[2] = new Point(5, accessible_Ht_start);
            }

            MullionDraw_Points.Add(upperLine);
            MullionDraw_Points.Add(rightCurve);
            MullionDraw_Points.Add(botLine);
            MullionDraw_Points.Add(leftCurve);

            return MullionDraw_Points;
        }

        public List<Point[]> GetMullionDividerDrawingPoints(int width,
                                                            int height,
                                                            string nxtobj_name,
                                                            string placement,
                                                            string frameType,
                                                            bool allowed = false)
        {
            List<Point[]> MullionDraw_Points = new List<Point[]>();

            Point[] leftLine = new Point[2];
            Point[] botCurve = new Point[3];
            Point[] rightLine = new Point[2];
            Point[] upperCurve = new Point[3];

            int accessible_Ht = height - 2,
                HT_beforeCurve = height - 5;

            int pixels_count = 0, accessible_Wd_start = 0, frameTypeInt = 0, midPoint = 0;

            if (frameType == "Window")
            {
                pixels_count = 8;
                frameTypeInt = Convert.ToInt32(FrameModel.Frame_Padding.Window);
            }
            else if (frameType == "Door")
            {
                pixels_count = 10;
                frameTypeInt = Convert.ToInt32(FrameModel.Frame_Padding.Door);
            }

            if (placement == "First" || (placement == "Somewhere in Between" && allowed == true))
            {
                if (nxtobj_name.Contains("Mullion"))
                {
                    int right_EndPoint = width + 16;
                    accessible_Wd_start = width - pixels_count;
                    midPoint = width + 4;
                        
                    leftLine[0] = new Point(accessible_Wd_start, 5);
                    leftLine[1] = new Point(accessible_Wd_start, HT_beforeCurve);

                    botCurve[0] = new Point(accessible_Wd_start, HT_beforeCurve);
                    botCurve[1] = new Point(midPoint, accessible_Ht);
                    botCurve[2] = new Point(right_EndPoint, HT_beforeCurve);

                    rightLine[0] = new Point(right_EndPoint, HT_beforeCurve);
                    rightLine[1] = new Point(right_EndPoint, 5);

                    upperCurve[0] = new Point(right_EndPoint, 5);
                    upperCurve[1] = new Point(midPoint, 1);
                    upperCurve[2] = new Point(accessible_Wd_start, 5);
                }
            }
            else if (placement == "Last" || placement == "Somewhere in Between")
            {
                accessible_Wd_start = ((frameTypeInt - pixels_count) - 1) * -1;
                midPoint = (pixels_count - ((frameTypeInt - 2) / 2)) - 3;

                leftLine[0] = new Point(accessible_Wd_start, 5);
                leftLine[1] = new Point(accessible_Wd_start, HT_beforeCurve);
                
                botCurve[0] = new Point(accessible_Wd_start, HT_beforeCurve);
                botCurve[1] = new Point(midPoint, accessible_Ht);
                botCurve[2] = new Point(pixels_count, HT_beforeCurve);
                
                rightLine[0] = new Point(pixels_count, HT_beforeCurve);
                rightLine[1] = new Point(pixels_count, 5);

                upperCurve[0] = new Point(pixels_count, 5);
                upperCurve[1] = new Point(midPoint, 1);
                upperCurve[2] = new Point(accessible_Wd_start, 5);
            }

            MullionDraw_Points.Add(leftLine);
            MullionDraw_Points.Add(botCurve);
            MullionDraw_Points.Add(rightLine);
            MullionDraw_Points.Add(upperCurve);

            return MullionDraw_Points;
        }
        public IEnumerable<Control> GetAll(Control control, string name)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, name))
                                      .Concat(controls)
                                      .Where(c => c.Visible == true)
                                      .Where(c => c.Name.Contains(name));
        }
    }
}
