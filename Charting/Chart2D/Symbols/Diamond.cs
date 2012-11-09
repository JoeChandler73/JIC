using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JIC.Charting
{
    /// <summary>
    /// Diamond symbol.
    /// </summary>
    public sealed class Diamond : Symbol
    {
        /// <summary>
        /// Draw the symbol.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        internal override void Draw(Graphics g, float x, float y)
        {
            using (var pen = new Pen(BorderColour, BorderSize))
            {
                using (var brush = new SolidBrush(FillColour))
                {
                    var halfSize = Size / 2;
                    var rectangle = new RectangleF(x - halfSize, y - halfSize, Size, Size);

                    var points = new PointF[4];
                    points[0].X = x;
                    points[0].Y = y - halfSize;
                    points[1].X = x + halfSize;
                    points[1].Y = y;
                    points[2].X = x;
                    points[2].Y = y + halfSize;
                    points[3].X = x - halfSize;
                    points[3].Y = y;

                    g.FillPolygon(brush, points);
                    g.DrawPolygon(pen, points);
                }
            }
        }
    }
}
