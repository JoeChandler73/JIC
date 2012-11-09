using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JIC.Charting
{
    /// <summary>
    /// Represents a style to use when drawing a line through chart points.
    /// </summary>
    public class LineStyle
    {
        #region Public Accessors

        /// <summary>
        /// The dash style of the line.
        /// </summary>
        public DashStyle DashStyle = DashStyle.Solid;

        /// <summary>
        /// The colour of the line.
        /// </summary>
        public Color Colour = Color.Black;

        /// <summary>
        /// The thickness of the line.
        /// </summary>
        public float Thickness = 1.0f;

        /// <summary>
        /// The interpolation to use when drawing through points.
        /// </summary>
        public Interpolation Interpolation = Interpolation.Linear;

        /// <summary>
        /// Whether the line is visible or not.
        /// </summary>
        public bool Visible = true;

        #endregion
    }
}
