﻿namespace JIC.Charting.Examples
{
    partial class AnimatedChart2D_Example
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._chart = new JIC.Charting.Chart2D();
            this.SuspendLayout();
            // 
            // _chart
            // 
            this._chart.Area.BackColour = System.Drawing.Color.White;
            this._chart.Area.Border = 50;
            this._chart.Area.BorderColour = System.Drawing.Color.Silver;
            this._chart.Axes.TickColour = System.Drawing.Color.Gray;
            this._chart.Axes.TickFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chart.Axes.XAutoScale = true;
            this._chart.Axes.XMax = 5D;
            this._chart.Axes.XMin = -5D;
            this._chart.Axes.XTick = 1D;
            this._chart.Axes.XTickFormat = "N2";
            this._chart.Axes.YAutoScale = true;
            this._chart.Axes.YMax = 3D;
            this._chart.Axes.YMin = -3D;
            this._chart.Axes.YTick = 1D;
            this._chart.Axes.YTickFormat = "N2";
            this._chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chart.Grid.Colour = System.Drawing.Color.Silver;
            this._chart.Grid.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this._chart.Grid.Thickness = 1F;
            this._chart.Grid.XGridVisible = true;
            this._chart.Grid.YGridVisible = true;
            this._chart.Labels.Colour = System.Drawing.Color.Gray;
            this._chart.Labels.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chart.Labels.LabelX = "X Axis";
            this._chart.Labels.LabelY = "Y Axis";
            this._chart.Location = new System.Drawing.Point(0, 0);
            this._chart.Name = "_chart";
            this._chart.Size = new System.Drawing.Size(1025, 639);
            this._chart.TabIndex = 1;
            this._chart.Title.Colour = System.Drawing.Color.Gray;
            this._chart.Title.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chart.Title.Title = "Chart2D Example";
            // 
            // AnimatedChart2D_Example
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 639);
            this.Controls.Add(this._chart);
            this.Name = "AnimatedChart2D_Example";
            this.Text = "Animated 2D Chart Example";
            this.Load += new System.EventHandler(this.AnimatedChart2D_Example_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Chart2D _chart;
    }
}