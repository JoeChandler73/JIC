using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace JIC.Charting
{
    public partial class Chart2D : UserControl
    {
        private ChartArea area;

        public Chart2D()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);

            area = new ChartArea(this);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ChartArea Area
        {
            get { return area; }

            set
            {
                if (value != null)
                {
                    area = value;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            area.Draw(g);
        }

        protected override void OnSizeChanged(EventArgs arguments)
        {
            base.OnSizeChanged(arguments);

            Invalidate();
        }
    }
}
