using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public class MultiPanelCommon
    {
        public List<Point[]> GetTransomDividerDrawingPoints(int width,
                                                            int height,
                                                            int nxtobj_wd,
                                                            int nxtobj_ht,
                                                            string nxtobj_name,
                                                            string placement,
                                                            bool allowed = false)
        {
            List<Point[]> MullionDraw_Points = new List<Point[]>();

            Point[] upperLine = new Point[2];
            Point[] botLine = new Point[2];
            Point[] leftCurve = new Point[3];
            Point[] rightCurve = new Point[3];

            int accessible_Wd = width - 2,
                Wd_beforeCurve = width - 5;

            if (placement == "First" || (placement == "Somewhere in Between" && allowed == true))
            {
                if (nxtobj_name.Contains("Transom"))
                {
                    int accessible_Ht_start = height - 8,
                        midPoint = height + 4,
                        bot_EndPoint = height + 16;

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
                upperLine[0] = new Point(5, -17); //-17 to fill the 18 units upward that is the height of divider
                upperLine[1] = new Point(Wd_beforeCurve, -17);

                rightCurve[0] = new Point(Wd_beforeCurve, -17);
                rightCurve[1] = new Point(accessible_Wd, -4); //midpoint = -4 coz 4 units upward; then 8 + 4 = 12; 8 is height allowance for transom divider on this code
                rightCurve[2] = new Point(Wd_beforeCurve, 8);

                botLine[0] = new Point(Wd_beforeCurve, 8);
                botLine[1] = new Point(5, 8);

                leftCurve[0] = new Point(5, 8);
                leftCurve[1] = new Point(1, -4);
                leftCurve[2] = new Point(5, -17);
            }

            MullionDraw_Points.Add(upperLine);
            MullionDraw_Points.Add(rightCurve);
            MullionDraw_Points.Add(botLine);
            MullionDraw_Points.Add(leftCurve);

            return MullionDraw_Points;
        }
    }
}
