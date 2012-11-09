using System;

namespace JIC.Charting
{
    /// <summary>
    /// Represents a single point in a <see cref="Series2D"/>.
    /// </summary>
    public struct Point2D
    {
        /// <summary>
        /// Create a new point.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// The x value.
        /// </summary>
        public double X;

        /// <summary>
        /// The y value.
        /// </summary>
        public double Y;
    }
}
