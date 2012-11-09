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
        /// The background colour of the chart area.
        /// </summary>
        private Color _backColour;

        /// <summary>
        /// The border colour of the chart area.
        /// </summary>
        private Color _borderColour;

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
            _backColour = chart.BackColor;
            _borderColour = chart.BackColor;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// The background colour of the chart area.
        /// </summary>
        [Description("The background colour of the chart area."),
        Category("Appearance")]
        public Color BackColour
        {
            get { return _backColour; }
            set
            {
                _backColour = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The border colour of the chart area.
        /// </summary>
        [Description("The border colour of the chart area."),
        Category("Appearance")]
        public Color BorderColour
        {
            get { return _borderColour; }
            set
            {
                _borderColour = value;
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
        /// Draw the chart area.
        /// </summary>
        /// <param name="g"></param>
        internal void Draw(Graphics g)
        {
            _chartRectangle = _chart.ClientRectangle;
            _plotRectangle = new Rectangle(_chartRectangle.Location, _chartRectangle.Size);
            _plotRectangle.Inflate(-Border, -Border);

            using (Brush brush = new SolidBrush(BackColour))
            {
                g.FillRectangle(brush, _chartRectangle);
            }

            using (Pen pen = new Pen(BorderColour))
            {
                g.DrawRectangle(pen, _plotRectangle);
            }
        }

        #endregion
    }
}
