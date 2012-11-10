using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

using JIC.Charting;

namespace JIC.Charting.Examples
{
    public partial class MainForm : Form
    {
        private const int size = 200;

        private Series2D _sin;
        private Series2D _cos;

        private AreaSeries2D _area;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(BuildSeries);
            Task.Factory.StartNew(BuildAreaSeries);
        }

        private void BuildSeries()
        {
            _sin = new Series2D()
            {
                LineStyle = new LineStyle()
                {
                    Visible = false
                },

                Symbol = new Dot()
                {
                    Size = 4.0f,
                    BorderColour = Color.Blue
                }
            };

            _cos = new Series2D()
            {
                LineStyle = new LineStyle()
                {
                    Visible = false
                },

                Symbol = new Dot()
                {
                    Size = 4.0f,
                    BorderColour = Color.Red
                }
            };

            double dx = 4 * Math.PI / size;

            for (int i = 0; i <= size; i++)
            {
                double x = -2 * Math.PI + i * dx;

                _sin.AddPoint(x, Math.Sin(x));
                _cos.AddPoint(x, Math.Cos(x));
            }

            _chart.AddSeries(_sin);
            _chart.AddSeries(_cos);
        }

        private void BuildAreaSeries()
        {
            _area = new AreaSeries2D()
            {
                FillColour = Color.LightBlue,
                Opacity = 100
            };

            double dx = 4 * Math.PI / size;

            for (int i = 0; i <= size; i++)
            {
                double x = -2 * Math.PI + i * dx;

                _area.AddPoint(x, Math.Sin(x), Math.Sin(x) + 0.5);
            }

            _chart.AddSeries(_area);
        }
    }
}
