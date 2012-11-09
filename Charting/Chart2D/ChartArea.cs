using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace JIC.Charting
{
    /// <summary>
    /// Represents a canvas with a border on which charts will be drawn.
    /// </summary>
    [TypeConverter(typeof(ChartAreaConverter))]
    public class ChartArea
    {
        #region Private Members

        /// <summary>
        /// The parent chart of this area.
        /// </summary>
        private readonly Chart2D _chart;

        /// <summary>
        /// The background color of the chart area.
        /// </summary>
        private Color _backColor;

        /// <summary>
        /// The border color of the chart area.
        /// </summary>
        private Color _borderColor;

        /// <summary>
        /// The rectangle contained by this chart area.
        /// </summary>
        private Rectangle _chartRectangle;

        /// <summary>
        /// The rectangle contained by the border.
        /// </summary>
        private Rectangle _plotRectangle;

        /// <summary>
        /// The border size of the chart area.
        /// </summary>
        private int _border;

        #endregion

        #region Constructors

        public ChartArea(Chart2D chart)
        {
            _chart = chart;
            _backColor = chart.BackColor;
            _borderColor = chart.BackColor;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// The background color of the chart area.
        /// </summary>
        [Description("The background color of the chart area."),
        Category("Appearance")]
        public Color BackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The border color of the chart area.
        /// </summary>
        [Description("The border color of the chart area."),
        Category("Appearance")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The border size of the chart area.
        /// </summary>
        [Description("The border size of the chart area."),
        Category("Appearance")]
        public int Border
        {
            get { return _border; }
            set
            {
                _border = value;
                _chart.Invalidate();
            }
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The rectangle contained by this chart area.
        /// </summary>
        internal Rectangle ChartRectangle
        {
            get { return _chartRectangle; }
        }

        /// <summary>
        /// The rectangle contained by the border.
        /// </summary>
        internal Rectangle PlotRectangle
        {
            get { return _plotRectangle; }
        }

        /// <summary>
        /// Draw this chart area.
        /// </summary>
        /// <param name="g"></param>
        internal void Draw(Graphics g)
        {
            _chartRectangle = _chart.ClientRectangle;
            _plotRectangle = new Rectangle(_chartRectangle.Location, _chartRectangle.Size);
            _plotRectangle.Inflate(-Border, -Border);

            using (Brush brush = new SolidBrush(BackColor))
            {
                g.FillRectangle(brush, _chartRectangle);
            }

            using (Pen pen = new Pen(BorderColor))
            {
                g.DrawRectangle(pen, _plotRectangle);
            }
        }

        #endregion
    }
}
