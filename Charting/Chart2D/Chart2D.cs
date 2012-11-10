using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace JIC.Charting
{
    /// <summary>
    /// Chart for displaying xy data in 2D
    /// </summary>
    public partial class Chart2D : UserControl
    {
        #region Private Members

        /// <summary>
        /// Preferred scale steps used for auto-scaling the axes.
        /// </summary>
        private static readonly double[] PreferredScaleSteps = 
        { 0.01, 0.025, 0.05, 0.1, 0.25, 0.5, 1, 1.5, 2, 2.5, 5, 10, 20, 50, 100, 200, 500, 1000 };

        /// <summary>
        /// Synchronization context used to marshal calls onto the UI thread.
        /// </summary>
        private readonly SynchronizationContext _synchronizationContext;

        /// <summary>
        /// The list of series being displayed by this chart.
        /// </summary>
        private readonly List<Series2D> _seriesList;

        /// <summary>
        /// The list of area series being displayed by this chart.
        /// </summary>
        private readonly List<AreaSeries2D> _areaSeriesList;

        /// <summary>
        /// The canvas or background area for this chart.
        /// </summary>
        private ChartArea _area;

        /// <summary>
        /// The chart grid.
        /// </summary>
        private Grid2D _grid;

        /// <summary>
        /// The title to display on the chart.
        /// </summary>
        private ChartTitle _title;

        /// <summary>
        /// The axes labels.
        /// </summary>
        private AxesLabels _labels;

        /// <summary>
        /// The chart axes.
        /// </summary>
        private Axes2D _axes;

        #endregion

        #region Constructors

        public Chart2D()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);

            _synchronizationContext = SynchronizationContext.Current;

            _area = new ChartArea(this);
            _grid = new Grid2D(this);
            _title = new ChartTitle(this);
            _labels = new AxesLabels(this);
            _axes = new Axes2D(this);

            _seriesList = new List<Series2D>();
            _areaSeriesList = new List<AreaSeries2D>();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// The canvas or background area for this chart.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ChartArea Area
        {
            get { return _area; }

            set
            {
                if (value != null)
                {
                    _area = value;
                }
            }
        }

        /// <summary>
        /// The chart grid.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Grid2D Grid
        {
            get { return _grid; }

            set
            {
                if (value != null)
                {
                    _grid = value;
                }
            }
        }

        /// <summary>
        /// The title to display on the chart.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ChartTitle Title
        {
            get { return _title; }

            set
            {
                if (value != null)
                {
                    _title = value;
                }
            }
        }

        /// <summary>
        /// The axes labels.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public AxesLabels Labels
        {
            get { return _labels; }

            set
            {
                if (value != null)
                {
                    _labels = value;
                }
            }
        }

        /// <summary>
        /// The chart axes.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Axes2D Axes
        {
            get { return _axes; }

            set
            {
                if (value != null)
                {
                    _axes = value;
                }
            }
        }

        /// <summary>
        /// Add a new series to the chart.
        /// </summary>
        /// <param name="series"></param>
        public void AddSeries(Series2D series)
        {
            _synchronizationContext.Post(state => AddSeriesPrivate((Series2D)state), series);
        }

        /// <summary>
        /// Add a new are series to the chart.
        /// </summary>
        /// <param name="series"></param>
        public void AddSeries(AreaSeries2D series)
        {
            _synchronizationContext.Post(state => AddSeriesPrivate((AreaSeries2D)state), series);
        }

        /// <summary>
        /// Clear all series from the chart.
        /// </summary>
        public void Clear()
        {
            _synchronizationContext.Post(state => ClearPrivate(), null);
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Paint the chart.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            _area.Draw(g);
            _grid.Draw(g);
            _title.Draw(g);
            _labels.Draw(g);
            _axes.Draw(g);

            GraphicsState graphicsState = g.Save();
            g.SmoothingMode = SmoothingMode.HighQuality;

            DrawAreaSeries(g);
            DrawSeries(g);

            g.Restore(graphicsState);
        }

        /// <summary>
        /// Handles SizeChanged event by repainting the chart.
        /// </summary>
        /// <param name="arguments"></param>
        protected override void OnSizeChanged(EventArgs arguments)
        {
            base.OnSizeChanged(arguments);

            Invalidate();
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Add a new series to the chart.
        /// </summary>
        /// <param name="series"></param>
        private void AddSeriesPrivate(Series2D series)
        {
            _seriesList.Add(series);

            series.Changed += SeriesChangedEventHandler;

            if (Axes.XAutoScale)
            {
                AutoScaleX();
            }

            if (Axes.YAutoScale)
            {
                AutoScaleY();
            }

            Invalidate();
        }

        /// <summary>
        /// Add a new area series to the chart.
        /// </summary>
        /// <param name="series"></param>
        private void AddSeriesPrivate(AreaSeries2D series)
        {
            _areaSeriesList.Add(series);

            if (Axes.XAutoScale)
            {
                AutoScaleX();
            }

            if (Axes.YAutoScale)
            {
                AutoScaleY();
            }

            Invalidate();
        }

        /// <summary>
        /// Clear all series from the chart.
        /// </summary>
        private void ClearPrivate()
        {
            foreach (var series in _seriesList)
            {
                series.Changed -= SeriesChangedEventHandler;
            }

            _seriesList.Clear();
            _areaSeriesList.Clear();

            Invalidate();
        }

        /// <summary>
        /// Determine the best scale for the x axis.
        /// </summary>
        private void AutoScaleX()
        {
            if (_seriesList.Count == 0 && 
                _areaSeriesList.Count == 0)
            {
                return;
            }

            double min = double.MaxValue;
            double max = double.MinValue;

            foreach (var series in _seriesList)
            {
                min = Math.Min(min, series.XMin);
                max = Math.Max(max, series.XMax);
            }

            foreach (var series in _areaSeriesList)
            {
                min = Math.Min(min, series.XMin);
                max = Math.Max(max, series.XMax);
            }

            CalculateXTickScale(min, max);
        }

        /// <summary>
        /// Determine the best scale for the y axis.
        /// </summary>
        private void AutoScaleY()
        {
            if (_seriesList.Count == 0 &&
                _areaSeriesList.Count == 0)
            {
                return;
            }

            double min = double.MaxValue;
            double max = double.MinValue;

            foreach (Series2D series in _seriesList)
            {
                min = Math.Min(min, series.YMin);
                max = Math.Max(max, series.YMax);
            }

            foreach (var series in _areaSeriesList)
            {
                min = Math.Min(min, series.YMin);
                max = Math.Max(max, series.YMax);
            }

            if (min == max)
            {
                double temp = min;
                min -= 0.05 * temp;
                max += 0.05 * temp;
            }

            CalculateYTickScale(min, max);
        }

        /// <summary>
        /// Determine the best x tick scale.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        private void CalculateXTickScale(double min, double max)
        {
            double range = max - min;
            double delta = double.MaxValue;
            double bestStep = PreferredScaleSteps[0];

            foreach (double step in PreferredScaleSteps)
            {
                double difference = Math.Abs((range / step) - 8);

                if (difference < delta)
                {
                    bestStep = step;
                    delta = difference;
                }
            }

            float xMin = (float)bestStep * (int)Math.Floor(min / bestStep);
            float xMax = (float)bestStep * (int)Math.Ceiling(max / bestStep);
            float xTick = (float)bestStep;

            Axes.ReScaleX(xMin, xMax, xTick);
        }

        /// <summary>
        /// Determine the best y tick scale.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        private void CalculateYTickScale(double min, double max)
        {
            double range = max - min;
            double delta = double.MaxValue;
            double bestStep = PreferredScaleSteps[0];

            foreach (double step in PreferredScaleSteps)
            {
                double difference = Math.Abs((range / step) - 8);

                if (difference < delta)
                {
                    bestStep = step;
                    delta = difference;
                }
            }

            float yMin = (float)bestStep * (int)Math.Floor(min / bestStep);
            float yMax = (float)bestStep * (int)Math.Ceiling(max / bestStep);
            float yTick = (float)bestStep;

            Axes.ReScaleY(yMin, yMax, yTick);
        }

        /// <summary>
        /// Draw any series added to this chart.
        /// </summary>
        /// <param name="g"></param>
        private void DrawSeries(Graphics g)
        {
            foreach (var series in _seriesList)
            {
                using (var pen = new Pen(series.LineStyle.Colour, series.LineStyle.Thickness))
                {
                    pen.DashStyle = series.LineStyle.DashStyle;

                    var points = new PointF[series.Count];

                    int i = 0;

                    foreach (var point in series)
                    {
                        var x = (float)(Area.PlotRectangle.X + ((float)point.X - Axes.XMin) * Area.PlotRectangle.Width / (Axes.XMax - Axes.XMin));
                        var y = (float)(Area.PlotRectangle.Bottom - ((float)point.Y - Axes.YMin) * Area.PlotRectangle.Height / (Axes.YMax - Axes.YMin));

                        series.Symbol.Draw(g, x, y);

                        points[i] = new PointF(x, y);

                        i++;
                    }

                    if (series.LineStyle.Visible)
                    {
                        if (series.LineStyle.Interpolation == Interpolation.Linear)
                        {
                            g.DrawLines(pen, points);
                        }

                        if (series.LineStyle.Interpolation == Interpolation.Spline)
                        {
                            g.DrawCurve(pen, points, 0.5f);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Draw any area series added to this chart.
        /// </summary>
        /// <param name="g"></param>
        private void DrawAreaSeries(Graphics g)
        {
            foreach (var series in _areaSeriesList)
            {
                var colour = Color.FromArgb(series.Opacity, series.FillColour.R, series.FillColour.G, series.FillColour.B);

                using (var brush = new SolidBrush(colour))
                {
                    var lowerPoints = new List<PointF>();
                    var upperPoints = new List<PointF>();

                    foreach (var point in series.Lower)
                    {
                        float x = (float)(Area.PlotRectangle.X + ((float)point.X - Axes.XMin) * Area.PlotRectangle.Width / (Axes.XMax - Axes.XMin));
                        float y = (float)(Area.PlotRectangle.Bottom - ((float)point.Y - Axes.YMin) * Area.PlotRectangle.Height / (Axes.YMax - Axes.YMin));

                        lowerPoints.Add(new PointF(x, y));
                    }

                    foreach (var point in series.Upper)
                    {
                        float x = (float)(Area.PlotRectangle.X + ((float)point.X - Axes.XMin) * Area.PlotRectangle.Width / (Axes.XMax - Axes.XMin));
                        float y = (float)(Area.PlotRectangle.Bottom - ((float)point.Y - Axes.YMin) * Area.PlotRectangle.Height / (Axes.YMax - Axes.YMin));

                        upperPoints.Add(new PointF(x, y));
                    }

                    var points = new PointF[lowerPoints.Count + upperPoints.Count];

                    int index = 0;

                    for (int i = 0; i < lowerPoints.Count; i++)
                    {
                        points[index++] = lowerPoints[i];
                    }

                    for (int i = upperPoints.Count - 1; i >= 0; i--)
                    {
                        points[index++] = upperPoints[i];
                    }

                    g.FillPolygon(brush, points);
                }
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handler for series changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeriesChangedEventHandler(object sender, EventArgs e)
        {
            _synchronizationContext.Post(state =>
            {
                if (Axes.XAutoScale)
                {
                    AutoScaleX();
                }

                if (Axes.YAutoScale)
                {
                    AutoScaleY();
                }

                Invalidate();
            }, null);
        }

        #endregion
    }
}
