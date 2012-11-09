namespace JIC.Charting.Examples
{
    partial class MainForm
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
            this._chart.Area.Border = 30;
            this._chart.Area.BorderColour = System.Drawing.Color.Silver;
            this._chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chart.Labels.Colour = System.Drawing.Color.Gray;
            this._chart.Labels.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chart.Labels.LabelX = "X Axis";
            this._chart.Labels.LabelY = "Y Axis";
            this._chart.Location = new System.Drawing.Point(0, 0);
            this._chart.Name = "_chart";
            this._chart.Size = new System.Drawing.Size(535, 396);
            this._chart.TabIndex = 0;
            this._chart.Title.Colour = System.Drawing.Color.Gray;
            this._chart.Title.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chart.Title.Title = "Chart2D Example";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 396);
            this.Controls.Add(this._chart);
            this.Name = "MainForm";
            this.Text = "Chart2D Example";
            this.ResumeLayout(false);

        }

        #endregion

        private Chart2D _chart;
    }
}

