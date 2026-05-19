namespace ProjectWAPTeachersCalendar
{
    partial class ChartForm
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
            chartPanel = new Panel();
            SuspendLayout();
            // 
            // chartPanel
            // 
            chartPanel.BackColor = Color.FromArgb(255, 192, 255);
            chartPanel.Location = new Point(81, 108);
            chartPanel.Name = "chartPanel";
            chartPanel.Size = new Size(923, 346);
            chartPanel.TabIndex = 0;
            chartPanel.Paint += chartPanel_Paint;
            // 
            // ChartForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1196, 522);
            Controls.Add(chartPanel);
            Name = "ChartForm";
            Text = "ChartForm";
            ResumeLayout(false);
        }

        #endregion

        private Panel chartPanel;
    }
}