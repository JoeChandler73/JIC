using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace JIC.Charting
{
    /// <summary>
    /// Chart for displaying xy data in 2D
    /// </summary>
    public partial class Chart2D : UserControl
    {
        #region Private Members

        /// <summary>
        /// The canvas or background area for this chart.
        /// </summary>
        private ChartArea _area;

        /// <summary>
        /// The title to display on the chart.
        /// </summary>
        private ChartTitle _title;

        /// <summary>
        /// The axes labels.
        /// </summary>
        private AxesLabels _labels;

        #endregion

        #region Constructors

        public Chart2D()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);

            _area = new ChartArea(this);
            _title = new ChartTitle(this);
            _labels = new AxesLabels(this);
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
            _title.Draw(g);
            _labels.Draw(g);
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
    }
}
