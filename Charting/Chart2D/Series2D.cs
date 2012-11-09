using System;
using System.Collections;
using System.Collections.Generic;

namespace JIC.Charting
{
    /// <summary>
    /// Represent a series for chrting.
    /// </summary>
    public class Series2D : IEnumerable<Point2D>
    {
        #region Private Members

        /// <summary>
        /// The collection of points making up this series.
        /// </summary>
        private readonly List<Point2D> _points = new List<Point2D>();

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
        /// The <see cref="LineStyle"/> to use when charting this series.
        /// </summary>
        public LineStyle LineStyle = new LineStyle();

        /// <summary>
        /// The <see cref="Symbol"/> to use when charting this series.
        /// </summary>
        public Symbol Symbol = None.Instance;

        /// <summary>
        /// Add a new point to this series.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AddPoint(double x, double y)
        {
            _points.Add(new Point2D(x, y));

            _xMin = Math.Min(_xMin, x);
            _xMax = Math.Max(_xMax, x);

            _yMin = Math.Min(_yMin, y);
            _yMax = Math.Max(_yMax, y);
        }

        /// <summary>
        /// The number of points in this series.
        /// </summary>
        public int Count
        {
            get
            {
                return _points.Count;
            }
        }

        /// <summary>
        /// Clear all points from this series.
        /// </summary>
        public void Clear()
        {
            _points.Clear();
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

        #endregion

        #region IEnumerable<Point2D> Members

        public IEnumerator<Point2D> GetEnumerator()
        {
            return _points.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
