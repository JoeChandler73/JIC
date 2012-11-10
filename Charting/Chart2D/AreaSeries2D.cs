using System;
using System.Drawing;
using System.Collections.Generic;

namespace JIC.Charting
{
    /// <summary>
    /// Represents an xy area series for charting
    /// </summary>
    public class AreaSeries2D
    {
        #region Private Members

        /// <summary>
        /// The collection of points making up the lower series.
        /// </summary>
        private readonly List<Point2D> _lowerPoints = new List<Point2D>();

        /// <summary>
        /// The collection of points making up the upper series.
        /// </summary>
        private readonly List<Point2D> _upperPoints = new List<Point2D>();

        /// <summary>
        /// The minimum x value.
        /// </summary>
        private double _xMin = double.MaxValue;

        /// <summary>
        /// The maximum x value.
        /// </summary>
        private double _xMax = double.MinValue;

        /// <summary>
        /// The minimum y value.
        /// </summary>
        private double _yMin = double.MaxValue;

        /// <summary>
        /// The maximum y value.
        /// </summary>
        private double _yMax = double.MinValue;

        #endregion

        #region Public Members

        /// <summary>
        /// The name of this series.
        /// </summary>
        public string Name;

        /// <summary>
        /// The fill colour to use.
        /// </summary>
        public Color FillColour = Color.White;

        /// <summary>
        /// The opacity to use when applying the fill.
        /// </summary>
        public int Opacity = 255;

        /// <summary>
        /// Add a new pair of points to this series.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        public void AddPoint(double x, double lower, double upper)
        {
            _lowerPoints.Add(new Point2D(x, lower));
            _upperPoints.Add(new Point2D(x, upper));

            _xMin = Math.Min(_xMin, x);
            _xMax = Math.Max(_xMax, x);

            _yMin = Math.Min(_yMin, lower);
            _yMin = Math.Min(_yMin, upper);

            _yMax = Math.Max(_yMax, lower);
            _yMax = Math.Max(_yMax, upper);
        }

        /// <summary>
        /// The number of points in this series.
        /// </summary>
        public int Count
        {
            get
            {
                return _lowerPoints.Count;
            }
        }

        /// <summary>
        /// Clear all points from this series.
        /// </summary>
        public void Clear()
        {
            _lowerPoints.Clear();
            _upperPoints.Clear();
        }

        /// <summary>
        /// The minimum x value.
        /// </summary>
        public double XMin
        {
            get
            {
                return _xMin;
            }
        }

        /// <summary>
        /// The maximum x value.
        /// </summary>
        public double XMax
        {
            get
            {
                return _xMax;
            }
        }

        /// <summary>
        /// The minimum y value.
        /// </summary>
        public double YMin
        {
            get
            {
                return _yMin;
            }
        }

        /// <summary>
        /// The maximum y value.
        /// </summary>
        public double YMax
        {
            get
            {
                return _yMax;
            }
        }

        public IEnumerable<Point2D> Lower
        {
            get
            {
                return _lowerPoints;
            }
        }

        public IEnumerable<Point2D> Upper
        {
            get
            {
                return _upperPoints;
            }
        }

        #endregion
    }
}
