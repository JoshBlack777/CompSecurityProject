namespace MyPacketCapture
{
    partial class frmData
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pieData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtAnalyzer = new System.Windows.Forms.TextBox();
            this.btnDataLoader = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pieData)).BeginInit();
            this.SuspendLayout();
            // 
            // pieData
            // 
            chartArea1.BackColor = System.Drawing.Color.Aqua;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartArea1";
            this.pieData.ChartAreas.Add(chartArea1);
            this.pieData.Cursor = System.Windows.Forms.Cursors.Default;
            legend1.Name = "Legend1";
            this.pieData.Legends.Add(legend1);
            this.pieData.Location = new System.Drawing.Point(392, 12);
            this.pieData.Name = "pieData";
            this.pieData.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "PieData";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            this.pieData.Series.Add(series1);
            this.pieData.Size = new System.Drawing.Size(396, 402);
            this.pieData.TabIndex = 0;
            this.pieData.Text = "NumberOfPackets";
            this.pieData.Click += new System.EventHandler(this.pieData_Click);
            // 
            // txtAnalyzer
            // 
            this.txtAnalyzer.Location = new System.Drawing.Point(12, 12);
            this.txtAnalyzer.Multiline = true;
            this.txtAnalyzer.Name = "txtAnalyzer";
            this.txtAnalyzer.ReadOnly = true;
            this.txtAnalyzer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAnalyzer.Size = new System.Drawing.Size(374, 402);
            this.txtAnalyzer.TabIndex = 1;
            this.txtAnalyzer.TextChanged += new System.EventHandler(this.txtAnalyzer_TextChanged);
            // 
            // btnDataLoader
            // 
            this.btnDataLoader.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDataLoader.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataLoader.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnDataLoader.Location = new System.Drawing.Point(316, 420);
            this.btnDataLoader.Name = "btnDataLoader";
            this.btnDataLoader.Size = new System.Drawing.Size(143, 59);
            this.btnDataLoader.TabIndex = 2;
            this.btnDataLoader.Text = "Load Data";
            this.btnDataLoader.UseVisualStyleBackColor = false;
            // 
            // frmData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.btnDataLoader);
            this.Controls.Add(this.txtAnalyzer);
            this.Controls.Add(this.pieData);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "frmData";
            this.Text = "PacketDataAnalysis";
            this.Load += new System.EventHandler(this.frmData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pieData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart pieData;
        private System.Windows.Forms.TextBox txtAnalyzer;
        private System.Windows.Forms.Button btnDataLoader;
    }
}