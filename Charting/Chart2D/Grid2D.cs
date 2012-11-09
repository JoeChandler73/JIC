using System;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace JIC.Charting
{
    /// <summary>
    /// A 2D grid for an xy chart.
    /// </summary>
    [TypeConverter(typeof(ChartGridConverter))]
    public class Grid2D
    {
        #region Private Members

        /// <summary>
        /// The parent chart.
        /// </summary>
        private readonly Chart2D _chart;

        /// <summary>
        /// The dash style for the gridlines.
        /// </summary>
        private DashStyle _dashStyle = DashStyle.Solid;

        /// <summary>
        /// The colour of the gridlines.
        /// </summary>
        private Color _colour = Color.LightGray;

        /// <summary>
        /// The thickness of the gridlines.
        /// </summary>
        private float _thickness = 1.0f;

        /// <summary>
        /// Determines if the vertical grid is visible.
        /// </summary>
        private bool _xGridVisible = true;

        /// <summary>
        /// Determines if the horizontal grid is visible.
        /// </summary>
        private bool _yGridVisible = true;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new <see cref="Grid2D"/> instance.
        /// </summary>
        /// <param name="chart"></param>
        public Grid2D(Chart2D chart)
        {
            _chart = chart;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Determines if the vertical grid is visible.
        /// </summary>
        [Description("Determines if the vertical grid is visible."), Category("Appearance")]
        public bool XGridVisible
        {
            get { return _xGridVisible; }
            set
            {
                _xGridVisible = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// Determines if the horizontal grid is visible.
        /// </summary>
        [Description("Determines if the horizontal grid is visible."), Category("Appearance")]
        public bool YGridVisible
        {
            get { return _yGridVisible; }
            set
            {
                _yGridVisible = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The dash style for the gridlines.
        /// </summary>
        [Description("The dash style for the gridlines."), Category("Appearance")]
        virtual public DashStyle DashStyle
        {
            get { return _dashStyle; }
            set
            {
                _dashStyle = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The thickness of the gridlines.
        /// </summary>
        [Description("The thickness of the gridlines."), Category("Appearance")]
        public float Thickness
        {
            get { return _thickness; }
            set
            {
                _thickness = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The colour of the gridlines.
        /// </summary>
        [Description("The colour of the gridlines."), Category("Appearance")]
        virtual public Color Colour
        {
            get { return _colour; }
            set
            {
                _colour = value;
                _chart.Invalidate();
            }
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// Draw the grid.
        /// </summary>
        /// <param name="g"></param>
        internal void Draw(Graphics g)
        {
            using (var pen = new Pen(_colour, _thickness))
            {
                pen.DashStyle = DashStyle;

                if (_xGridVisible)
                {
                    double x;

                    for (x = _chart.Axes.XMin; x < _chart.Axes.XMax; x += _chart.Axes.XTick)
                    {
                        var xx = (float)(_chart.Area.PlotRectangle.X + (x - _chart.Axes.XMin) * _chart.Area.PlotRectangle.Width / (_chart.Axes.XMax - _chart.Axes.XMin));
                        g.DrawLine(pen, xx, _chart.Area.PlotRectangle.Bottom, xx, _chart.Area.PlotRectangle.Bottom - _chart.Area.PlotRectangle.Height);
                    }
                }

                if (_yGridVisible)
                {
                    double y;

                    for (y = _chart.Axes.YMin; y < _chart.Axes.YMax; y += _chart.Axes.YTick)
                    {
                        var yy = (float)(_chart.Area.PlotRectangle.Bottom - (y - _chart.Axes.YMin) * _chart.Area.PlotRectangle.Height / (_chart.Axes.YMax - _chart.Axes.YMin));
                        g.DrawLine(pen, _chart.Area.PlotRectangle.X, yy, _chart.Area.PlotRectangle.X + _chart.Area.PlotRectangle.Width, yy);
                    }
                }
            }
        }

        #endregion
    }
}
