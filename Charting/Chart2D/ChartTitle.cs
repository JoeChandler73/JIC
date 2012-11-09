using System;
using System.Drawing;
using System.ComponentModel;

namespace JIC.Charting
{
    /// <summary>
    /// A title to be displayed on a chart.
    /// </summary>
    [TypeConverter(typeof(ChartTitleConverter))]
    public class ChartTitle
    {
        #region Private Members

        /// <summary>
        /// The parent chart.
        /// </summary>
        private readonly Chart2D _chart;

        /// <summary>
        /// The chart title to display.
        /// </summary>
        private string _title = "Title";

        /// <summary>
        /// The font to use to display the title.
        /// </summary>
        private Font _font = new Font("Arial", 12, FontStyle.Regular);

        /// <summary>
        /// The colour used to display the title.
        /// </summary>
        private Color _colour = Color.Black;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new <see cref="ChartTitle"/>.
        /// </summary>
        /// <param name="chart"></param>
        public ChartTitle(Chart2D chart)
        {
            _chart = chart;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// The chart title to display.
        /// </summary>
        [Description("The chart title to display."),
        Category("Appearance")]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                _chart.Invalidate();
            }
        }

        /// <summary>
        /// The font to use to display the title.
        /// </summary>
        [Description("The font used to display the title."),
        Category("Appearance")]
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
        /// The colour used to display the title.
        /// </summary>
        [Description("The colour used to display the title."),
        Category("Appearance")]
        public Color Color
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

        internal void Draw(Graphics g)
        {
            using (Brush brush = new SolidBrush(Color))
            {
                if (Title.Length > 0)
                {
                    SizeF size = g.MeasureString(Title, Font);

                    g.DrawString(Title,
                                 Font,
                                 brush,
                                 _chart.Area.PlotRectangle.Left + _chart.Area.PlotRectangle.Width / 2 - size.Width / 2,
                                 0);
                }
            }
        }

        #endregion
    }
}
