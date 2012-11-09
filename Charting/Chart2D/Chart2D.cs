﻿using System;
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

            _area = new ChartArea(this);
            _grid = new Grid2D(this);
            _title = new ChartTitle(this);
            _labels = new AxesLabels(this);
            _axes = new Axes2D(this);
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
