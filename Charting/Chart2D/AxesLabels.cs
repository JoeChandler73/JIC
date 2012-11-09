using System;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace JIC.Charting
{
    [TypeConverter(typeof(AxesLabelsConverter))]
    public class AxesLabels
    {
        #region Private Members

        /// <summary>
        /// The parent chart.
        /// </summary>
        private readonly Chart2D _chart;

        /// <summary>
        /// The label for the x axis.
        /// </summary>
        private string _labelX = "X Axis";

        /// <summary>
        /// The label for the Y axis.
        /// </summary>
        private string _labelY = "Y Axis";

        /// <summary>
        /// The font used to display labels.
        /// </summary>
        private Font _font = new Font("Arial", 10, FontStyle.Regular);

        /// <summary>
        /// The colour used to display labels.
        /// </summary>
        private Color _colour = Color.Black;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new <see cref="AxesLabels"/> instance.
        /// </summary>
        /// <param name="chart"></param>
        public AxesLabels(Chart2D chart)
        {
            _chart = chart;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// The label for the x axis.
        /// </summary>
        [Description("The label for the x axis."), Category("Appearance")]
        public string LabelX
        {
            get { return _labelX; }
            set
            {
                _labelX = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The label for the Y axis.
        /// </summary>
        [Description("The label for the Y axis."), Category("Appearance")]
        public string LabelY
        {
            get { return _labelY; }
            set
            {
                _labelY = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// /// <summary>
        /// The font used to display labels.
        /// </summary>
        /// </summary>
        [Description("The font used to display labels."), Category("Appearance")]
        public Font Font
        {
            get { return _font; }
            set
            {
                _font = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The colour used to display labels.
        /// </summary>
        [Description("The colour used to display labels."), Category("Appearance")]
        public Color Colour
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
        /// Draw the axes labels.
        /// </summary>
        /// <param name="g"></param>
        internal void Draw(Graphics g)
        {
            var offsetX = _chart.Area.ChartRectangle.Width / 30f;
            var offsetY = _chart.Area.ChartRectangle.Height / 30f;

            using (var brush = new SolidBrush(Colour))
            {
                if (LabelX.Length > 0)
                {
                    var size = g.MeasureString(LabelX, Font);

                    g.DrawString(LabelX,
                                 Font,
                                 brush,
                                 _chart.Area.ChartRectangle.Width / 2 - size.Width / 2,
                                 _chart.Area.ChartRectangle.Bottom - size.Height);
                }

                if (LabelY.Length > 0)
                {
                    var stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    var size = g.MeasureString(LabelY, Font);

                    var graphicsState = g.Save();

                    g.TranslateTransform(_chart.Area.ChartRectangle.X,
                                         _chart.Area.ChartRectangle.Height / 2);

                    g.RotateTransform(-90);
                    g.DrawString(LabelY, Font, brush, 0, 0, stringFormat);
                    g.Restore(graphicsState);
                }
            }
        }

        #endregion
    }
}
