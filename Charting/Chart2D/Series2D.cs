using System;
using System.Collections;
using System.Collections.Generic;

namespace JIC.Charting
{
    /// <summary>
    /// Represent an xy series for charting.
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
        /// Event raised when the series has been changed.
        /// </summary>
        public event EventHandler Changed;

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
        /// Accessors for the points in the series.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Point2D this[int index]
        {
            get
            {
                return _points[index];
            }

            set
            {
                _points[index] = value;

                _xMin = Math.Min(_xMin, value.X);
                _xMax = Math.Max(_xMax, value.X);

                _yMin = Math.Min(_yMin, value.Y);
                _yMax = Math.Max(_yMax, value.Y);
            }
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

        /// <summary>
        /// Raise a series changed event to any listeners. 
        /// </summary>
        public void RaiseChangedEvent()
        {
            var handler = Changed;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
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
