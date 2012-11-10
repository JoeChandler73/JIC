using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using JIC.Charting;

namespace JIC.Charting.Examples
{
    public partial class AnimatedChart2D_Example : Form
    {
        private Series2D _series1;
        private Series2D _series2;

        private double _dx;
        private double _multiplier1 = 1;
        private double _multiplier2 = 1;

        private System.Timers.Timer _timer;

        private const int Size = 100;

        public AnimatedChart2D_Example()
        {
            InitializeComponent();

            _dx = 4 * Math.PI / Size;

            _timer = new System.Timers.Timer(100);
            _timer.Elapsed += Tick;
            _timer.Enabled = false;
        }

        private void Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            _multiplier1 += 2;
            _multiplier2 += 1;

            for (int i = 0; i <= Size; i++)
            {
                double x = -2 * Math.PI + i * _dx;

                double y1New = _series1[i].Y + (1d / _multiplier1) * Math.Sin(_multiplier1 * x);
                double y2New = _series2[i].Y + (1d / _multiplier2) * Math.Sin(_multiplier2 * x);

                _series1[i] = new Point2D(x, y1New);
                _series2[i] = new Point2D(x, y2New);
            }

            if (_multiplier1 >= 100)
            {
                _timer.Stop();
            }

            _series1.RaiseChangedEvent();
            _series2.RaiseChangedEvent();
        }

        private void AnimatedChart2D_Example_Load(object sender, EventArgs e)
        {
            _series1 = new Series2D()
            {
                LineStyle = new LineStyle()
                {
                    Colour = Color.Red,
                    Thickness = 1f,
                    Interpolation = Interpolation.Spline
                },

                Symbol = new Dot()
                {
                    BorderColour = Color.DarkRed,
                    FillColour = Color.Orange,
                    Size = 6f,
                    BorderSize = 1f
                }
            };


            _series2 = new Series2D()
            {
                LineStyle = new LineStyle()
                {
                    Colour = Color.Blue,
                    Thickness = 1f,
                    Interpolation = Interpolation.Spline
                },

                Symbol = new Dot()
                {
                    BorderColour = Color.MidnightBlue,
                    FillColour = Color.LightSkyBlue,
                    Size = 6f,
                    BorderSize = 1f
                }
            };

            for (int i = 0; i <= Size; i++)
            {
                double x = -2 * Math.PI + i * _dx;

                _series1.AddPoint(x, Math.Sin(x));
                _series2.AddPoint(x, Math.Sin(x));
            }

            _chart.AddSeries(_series1);
            _chart.AddSeries(_series2);

            _timer.Enabled = true;
            _timer.Start();
        }
    }
}
