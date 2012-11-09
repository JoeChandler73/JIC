using System;
using System.Drawing;
using System.ComponentModel;

namespace JIC.Charting
{
    /// <summary>
    /// A set of axes for an xy 2D chart
    /// </summary>
    [TypeConverter(typeof(Axes2DConverter))]
    public class Axes2D
    {
        #region Private Members

        /// <summary>
        /// The parent chart.
        /// </summary>
        private readonly Chart2D _chart;

        /// <summary>
        /// The minimum x value.
        /// </summary>
        private double _xMin = -5f;

        /// <summary>
        /// The maximum x value.
        /// </summary>
        private double _xMax = 5f;

        /// <summary>
        /// The minimum y value.
        /// </summary>
        private double _yMin = -3f;

        /// <summary>
        /// The maximum y value.
        /// </summary>
        private double _yMax = 3f;

        /// <summary>
        /// The x tick size.
        /// </summary>
        private double _xTick = 1f;

        /// <summary>
        /// The y tick size.
        /// </summary>
        private double _yTick = 1f;

        /// <summary>
        /// The x tick format.
        /// </summary>
        private string _xTickFormat = "N2";

        /// <summary>
        /// The y tick format.
        /// </summary>
        private string _yTickFormat = "N2";

        /// <summary>
        /// Whether to autoscale the x axis.
        /// </summary>
        private bool _xAutoScale = false;

        /// <summary>
        /// Whether to autoscale the y axis.
        /// </summary>
        private bool _yAutoScale = false;

        /// <summary>
        /// The tick colour.
        /// </summary>
        private Color _tickColour = Color.Black;

        /// <summary>
        /// The tick font.
        /// </summary>
        private Font _tickFont;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new <see cref="Axes2D"/> instance.
        /// </summary>
        /// <param name="chart"></param>
        public Axes2D(Chart2D chart)
        {
            _chart = chart;
            _tickFont = _chart.Font;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// The minimum x value.
        /// </summary>
        [Description("The minimum x value."), Category("Appearance")]
        public double XMin
        {
            get { return _xMin; }
            set
            {
                _xMin = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The maximum x value.
        /// </summary>
        [Description("The maximum x value."), Category("Appearance")]
        public double XMax
        {
            get { return _xMax; }
            set
            {
                _xMax = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The x tick size.
        /// </summary>
        [Description("The x tick size."), Category("Appearance")]
        public double XTick
        {
            get { return _xTick; }
            set
            {
                _xTick = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// Whether to autoscale the x axis.
        /// </summary>
        [Description("Whether to autoscale the x axis."), Category("Appearance")]
        public bool XAutoScale
        {
            get { return _xAutoScale; }
            set
            {
                _xAutoScale = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The minimum y value.
        /// </summary>
        [Description("The minimum y value."), Category("Appearance")]
        public double YMin
        {
            get { return _yMin; }
            set
            {
                _yMin = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The maximum y value.
        /// </summary>
        [Description("The maximum y value."), Category("Appearance")]
        public double YMax
        {
            get { return _yMax; }
            set
            {
                _yMax = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The y tick size.
        /// </summary>
        [Description("The y tick size."), Category("Appearance")]
        public double YTick
        {
            get { return _yTick; }
            set
            {
                _yTick = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The x tick format.
        /// </summary>
        [Description("The x tick format."), Category("Appearance")]
        public string XTickFormat
        {
            get { return _xTickFormat; }
            set
            {
                _xTickFormat = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The y tick format.
        /// </summary>
        [Description("The y tick format."), Category("Appearance")]
        public string YTickFormat
        {
            get { return _yTickFormat; }
            set
            {
                _yTickFormat = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// Whether to autoscale the y axis.
        /// </summary>
        [Description("Determines whether the Y axis is auto-scaled."), Category("Appearance")]
        public bool YAutoScale
        {
            get { return _yAutoScale; }
            set
            {
                _yAutoScale = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The tick colour.
        /// </summary>
        [Description("The tick colour."), Category("Appearance")]
        public Color TickColour
        {
            get { return _tickColour; }
            set
            {
                _tickColour = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The tick font.
        /// </summary>
        [Description("The tick font."), Category("Appearance")]
        public Font TickFont
        {
            get { return _tickFont; }
            set
            {
                _tickFont = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// Rescale the x axis.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="tick"></param>
        public void ReScaleX(float min, float max, float tick)
        {
            _xMin = min;
            _xMax = max;
            _xTick = tick;
        }

        /// <summary>
        /// Rescale the y axis.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="tick"></param>
        public void ReScaleY(float min, float max, float tick)
        {
            _yMin = min;
            _yMax = max;
            _yTick = tick;
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// Draw the axes.
        /// </summary>
        /// <param name="g"></param>
        internal void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(_tickColour))
            {
                var size = g.MeasureString("0", _tickFont);

                double x;

                for (x = _xMin; x <= _xMax; x += _xTick)
                {
                    var xx = (float)(_chart.Area.PlotRectangle.X + (x - _xMin) * _chart.Area.PlotRectangle.Width / (_xMax - _xMin));
                    size = g.MeasureString(x.ToString(_xTickFormat), _tickFont);
                    var stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Far;

                    g.DrawString(x.ToString(_xTickFormat), 
                                 _tickFont, 
                                 brush, 
                                 xx + size.Width / 2,
                                 _chart.Area.PlotRectangle.Bottom + 4f, 
                                 stringFormat);
                }

                double y;

                size = g.MeasureString("0", _tickFont);

                for (y = _yMin; y <= _yMax; y += _yTick)
                {
                    var yy = (float)(_chart.Area.PlotRectangle.Bottom - (y - _yMin) * _chart.Area.PlotRectangle.Height / (_yMax - _yMin));
                    var stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Far;

                    g.DrawString(y.ToString(_yTickFormat), 
                                 _tickFont, 
                                 brush,
                                 _chart.Area.PlotRectangle.X - 3f, 
                                 yy - size.Height / 2, 
                                 stringFormat);
                }
            }
        }

        #endregion
    }
}
