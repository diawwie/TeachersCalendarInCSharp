namespace ProjectWAPTeachersCalendar
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            teacherComboBox = new ComboBox();
            teacherComboBoxLabel = new Label();
            roomComboBox = new ComboBox();
            roomComboBoxLabel = new Label();
            subjectDateTimePicker = new DateTimePicker();
            dateTimeLabel = new Label();
            addButton = new Button();
            scheduleDataGridView = new DataGridView();
            scheduleErrorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)scheduleDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scheduleErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // teacherComboBox
            // 
            teacherComboBox.FormattingEnabled = true;
            teacherComboBox.Location = new Point(34, 63);
            teacherComboBox.Name = "teacherComboBox";
            teacherComboBox.Size = new Size(151, 28);
            teacherComboBox.TabIndex = 0;
            teacherComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // teacherComboBoxLabel
            // 
            teacherComboBoxLabel.AutoSize = true;
            teacherComboBoxLabel.Location = new Point(34, 36);
            teacherComboBoxLabel.Name = "teacherComboBoxLabel";
            teacherComboBoxLabel.Size = new Size(100, 20);
            teacherComboBoxLabel.TabIndex = 1;
            teacherComboBoxLabel.Text = "Pick a teacher";
            // 
            // roomComboBox
            // 
            roomComboBox.FormattingEnabled = true;
            roomComboBox.Location = new Point(34, 125);
            roomComboBox.Name = "roomComboBox";
            roomComboBox.Size = new Size(151, 28);
            roomComboBox.TabIndex = 2;
            // 
            // roomComboBoxLabel
            // 
            roomComboBoxLabel.AutoSize = true;
            roomComboBoxLabel.Location = new Point(34, 101);
            roomComboBoxLabel.Name = "roomComboBoxLabel";
            roomComboBoxLabel.Size = new Size(87, 20);
            roomComboBoxLabel.TabIndex = 3;
            roomComboBoxLabel.Text = "Pick a room";
            // 
            // subjectDateTimePicker
            // 
            subjectDateTimePicker.Format = DateTimePickerFormat.Short;
            subjectDateTimePicker.Location = new Point(34, 195);
            subjectDateTimePicker.Name = "subjectDateTimePicker";
            subjectDateTimePicker.Size = new Size(151, 27);
            subjectDateTimePicker.TabIndex = 4;
            // 
            // dateTimeLabel
            // 
            dateTimeLabel.AutoSize = true;
            dateTimeLabel.Location = new Point(34, 169);
            dateTimeLabel.Name = "dateTimeLabel";
            dateTimeLabel.Size = new Size(81, 20);
            dateTimeLabel.TabIndex = 5;
            dateTimeLabel.Text = "Pick a date";
            // 
            // addButton
            // 
            addButton.Location = new Point(38, 252);
            addButton.Name = "addButton";
            addButton.Size = new Size(94, 29);
            addButton.TabIndex = 6;
            addButton.Text = "&Add Class";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // scheduleDataGridView
            // 
            scheduleDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            scheduleDataGridView.Location = new Point(206, 36);
            scheduleDataGridView.Name = "scheduleDataGridView";
            scheduleDataGridView.RowHeadersWidth = 51;
            scheduleDataGridView.Size = new Size(832, 270);
            scheduleDataGridView.TabIndex = 7;
            // 
            // scheduleErrorProvider
            // 
            scheduleErrorProvider.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 500);
            Controls.Add(scheduleDataGridView);
            Controls.Add(addButton);
            Controls.Add(dateTimeLabel);
            Controls.Add(subjectDateTimePicker);
            Controls.Add(roomComboBoxLabel);
            Controls.Add(roomComboBox);
            Controls.Add(teacherComboBoxLabel);
            Controls.Add(teacherComboBox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)scheduleDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)scheduleErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox teacherComboBox;
        private Label teacherComboBoxLabel;
        private ComboBox roomComboBox;
        private Label roomComboBoxLabel;
        private DateTimePicker subjectDateTimePicker;
        private Label dateTimeLabel;
        private Button addButton;
        private DataGridView scheduleDataGridView;
        private ErrorProvider scheduleErrorProvider;
    }
}
