using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JIC.Charting
{
    /// <summary>
    /// Circle symbol.
    /// </summary>
    public sealed class Circle : Symbol
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

                    g.DrawEllipse(pen, rectangle);
                }
            }
        }
    }
}
