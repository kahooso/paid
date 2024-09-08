namespace ArchiveFashionStore
{
    partial class ReportForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.startMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.toLabel = new System.Windows.Forms.Label();
            this.endMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.fromLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.periodCheckBox = new System.Windows.Forms.CheckBox();
            this.periodPanel = new System.Windows.Forms.Panel();
            this.reportChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.periodPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportChart)).BeginInit();
            this.SuspendLayout();
            // 
            // startMaskedTextBox
            // 
            this.startMaskedTextBox.Location = new System.Drawing.Point(25, 3);
            this.startMaskedTextBox.Mask = "0000-00-00";
            this.startMaskedTextBox.Name = "startMaskedTextBox";
            this.startMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.startMaskedTextBox.TabIndex = 3;
            this.startMaskedTextBox.Text = "20010101";
            this.startMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(131, 7);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(19, 13);
            this.toLabel.TabIndex = 6;
            this.toLabel.Text = "по";
            // 
            // endMaskedTextBox
            // 
            this.endMaskedTextBox.Location = new System.Drawing.Point(156, 3);
            this.endMaskedTextBox.Mask = "0000-00-00";
            this.endMaskedTextBox.Name = "endMaskedTextBox";
            this.endMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.endMaskedTextBox.TabIndex = 4;
            this.endMaskedTextBox.Text = "20240101";
            this.endMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(9, 7);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(13, 13);
            this.fromLabel.TabIndex = 5;
            this.fromLabel.Text = "с";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(353, 21);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(92, 27);
            this.refreshButton.TabIndex = 13;
            this.refreshButton.Text = "Сброс";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // periodCheckBox
            // 
            this.periodCheckBox.AutoSize = true;
            this.periodCheckBox.Location = new System.Drawing.Point(9, 27);
            this.periodCheckBox.Name = "periodCheckBox";
            this.periodCheckBox.Size = new System.Drawing.Size(64, 17);
            this.periodCheckBox.TabIndex = 12;
            this.periodCheckBox.Text = "Период";
            this.periodCheckBox.UseVisualStyleBackColor = true;
            this.periodCheckBox.CheckedChanged += new System.EventHandler(this.periodCheckBox_CheckedChanged);
            // 
            // periodPanel
            // 
            this.periodPanel.Controls.Add(this.startMaskedTextBox);
            this.periodPanel.Controls.Add(this.toLabel);
            this.periodPanel.Controls.Add(this.endMaskedTextBox);
            this.periodPanel.Controls.Add(this.fromLabel);
            this.periodPanel.Enabled = false;
            this.periodPanel.Location = new System.Drawing.Point(78, 21);
            this.periodPanel.Name = "periodPanel";
            this.periodPanel.Size = new System.Drawing.Size(269, 27);
            this.periodPanel.TabIndex = 11;
            // 
            // reportChart
            // 
            this.reportChart.BackColor = System.Drawing.Color.Transparent;
            this.reportChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            chartArea2.Name = "ChartArea1";
            this.reportChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.reportChart.Legends.Add(legend2);
            this.reportChart.Location = new System.Drawing.Point(12, 81);
            this.reportChart.Name = "reportChart";
            this.reportChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Полная стоимость";
            this.reportChart.Series.Add(series2);
            this.reportChart.Size = new System.Drawing.Size(776, 357);
            this.reportChart.TabIndex = 14;
            this.reportChart.Text = "reportChart";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ArchiveFashionStore.Properties.Resources.cat_and_mouse;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.reportChart);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.periodCheckBox);
            this.Controls.Add(this.periodPanel);
            this.Name = "ReportForm";
            this.Text = "Отчёт";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.periodPanel.ResumeLayout(false);
            this.periodPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox startMaskedTextBox;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.MaskedTextBox endMaskedTextBox;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.CheckBox periodCheckBox;
        private System.Windows.Forms.Panel periodPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart reportChart;
    }
}