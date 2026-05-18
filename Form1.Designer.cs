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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            teacherComboBox = new ComboBox();
            teacherComboBoxLabel = new Label();
            roomComboBox = new ComboBox();
            roomComboBoxLabel = new Label();
            subjectDateTimePicker = new DateTimePicker();
            dateTimeLabel = new Label();
            addButton = new Button();
            scheduleDataGridView = new DataGridView();
            contextMenuStrip = new ContextMenuStrip(components);
            deleteClassToolStripMenuItem = new ToolStripMenuItem();
            scheduleErrorProvider = new ErrorProvider(components);
            subjectTextBox = new TextBox();
            subjectNameLabel = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveScheduleToolStripMenuItem = new ToolStripMenuItem();
            saveAstxtToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolStrip = new ToolStrip();
            saveToolStripButton = new ToolStripButton();
            exportAsTxtToolStripMenuItem = new ToolStripButton();
            statusStrip = new StatusStrip();
            classCountLabel = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)scheduleDataGridView).BeginInit();
            contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scheduleErrorProvider).BeginInit();
            menuStrip1.SuspendLayout();
            toolStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // teacherComboBox
            // 
            teacherComboBox.FormattingEnabled = true;
            teacherComboBox.Location = new Point(40, 155);
            teacherComboBox.Name = "teacherComboBox";
            teacherComboBox.Size = new Size(151, 28);
            teacherComboBox.TabIndex = 0;
            teacherComboBox.SelectedIndexChanged += teacherComboBox_SelectedIndexChanged;
            // 
            // teacherComboBoxLabel
            // 
            teacherComboBoxLabel.AutoSize = true;
            teacherComboBoxLabel.Location = new Point(40, 128);
            teacherComboBoxLabel.Name = "teacherComboBoxLabel";
            teacherComboBoxLabel.Size = new Size(100, 20);
            teacherComboBoxLabel.TabIndex = 1;
            teacherComboBoxLabel.Text = "Pick a teacher";
            // 
            // roomComboBox
            // 
            roomComboBox.FormattingEnabled = true;
            roomComboBox.Location = new Point(40, 217);
            roomComboBox.Name = "roomComboBox";
            roomComboBox.Size = new Size(151, 28);
            roomComboBox.TabIndex = 2;
            // 
            // roomComboBoxLabel
            // 
            roomComboBoxLabel.AutoSize = true;
            roomComboBoxLabel.Location = new Point(40, 193);
            roomComboBoxLabel.Name = "roomComboBoxLabel";
            roomComboBoxLabel.Size = new Size(87, 20);
            roomComboBoxLabel.TabIndex = 3;
            roomComboBoxLabel.Text = "Pick a room";
            // 
            // subjectDateTimePicker
            // 
            subjectDateTimePicker.Format = DateTimePickerFormat.Short;
            subjectDateTimePicker.Location = new Point(40, 287);
            subjectDateTimePicker.Name = "subjectDateTimePicker";
            subjectDateTimePicker.Size = new Size(151, 27);
            subjectDateTimePicker.TabIndex = 4;
            // 
            // dateTimeLabel
            // 
            dateTimeLabel.AutoSize = true;
            dateTimeLabel.Location = new Point(40, 261);
            dateTimeLabel.Name = "dateTimeLabel";
            dateTimeLabel.Size = new Size(81, 20);
            dateTimeLabel.TabIndex = 5;
            dateTimeLabel.Text = "Pick a date";
            // 
            // addButton
            // 
            addButton.Location = new Point(44, 344);
            addButton.Name = "addButton";
            addButton.Size = new Size(94, 29);
            addButton.TabIndex = 6;
            addButton.Text = "&Add Class";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // scheduleDataGridView
            // 
            scheduleDataGridView.BackgroundColor = Color.Purple;
            scheduleDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            scheduleDataGridView.ContextMenuStrip = contextMenuStrip;
            scheduleDataGridView.Location = new Point(364, 128);
            scheduleDataGridView.Name = "scheduleDataGridView";
            scheduleDataGridView.RowHeadersWidth = 51;
            scheduleDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            scheduleDataGridView.Size = new Size(813, 245);
            scheduleDataGridView.TabIndex = 7;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { deleteClassToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(160, 28);
            // 
            // deleteClassToolStripMenuItem
            // 
            deleteClassToolStripMenuItem.Name = "deleteClassToolStripMenuItem";
            deleteClassToolStripMenuItem.Size = new Size(159, 24);
            deleteClassToolStripMenuItem.Text = "Delete Class";
            deleteClassToolStripMenuItem.Click += deleteClassToolStripMenuItem_Click;
            // 
            // scheduleErrorProvider
            // 
            scheduleErrorProvider.ContainerControl = this;
            // 
            // subjectTextBox
            // 
            subjectTextBox.Location = new Point(214, 155);
            subjectTextBox.Name = "subjectTextBox";
            subjectTextBox.Size = new Size(125, 27);
            subjectTextBox.TabIndex = 8;
            subjectTextBox.Validating += subjectTextBox_Validating;
            subjectTextBox.Validated += subjectTextBox_Validated;
            // 
            // subjectNameLabel
            // 
            subjectNameLabel.AutoSize = true;
            subjectNameLabel.Location = new Point(214, 125);
            subjectNameLabel.Name = "subjectNameLabel";
            subjectNameLabel.Size = new Size(105, 20);
            subjectNameLabel.TabIndex = 9;
            subjectNameLabel.Text = "Subject Name:";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1242, 28);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveScheduleToolStripMenuItem, saveAstxtToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveScheduleToolStripMenuItem
            // 
            saveScheduleToolStripMenuItem.Name = "saveScheduleToolStripMenuItem";
            saveScheduleToolStripMenuItem.Size = new Size(187, 26);
            saveScheduleToolStripMenuItem.Text = "Save Schedule";
            saveScheduleToolStripMenuItem.Click += saveScheduleToolStripMenuItem_Click;
            // 
            // saveAstxtToolStripMenuItem
            // 
            saveAstxtToolStripMenuItem.Name = "saveAstxtToolStripMenuItem";
            saveAstxtToolStripMenuItem.Size = new Size(187, 26);
            saveAstxtToolStripMenuItem.Text = "Export as .txt";
            saveAstxtToolStripMenuItem.Click += saveAstxtToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(187, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { saveToolStripButton, exportAsTxtToolStripMenuItem });
            toolStrip.Location = new Point(0, 28);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1242, 27);
            toolStrip.TabIndex = 11;
            toolStrip.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            saveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveToolStripButton.Image = (Image)resources.GetObject("saveToolStripButton.Image");
            saveToolStripButton.ImageTransparentColor = Color.Magenta;
            saveToolStripButton.Name = "saveToolStripButton";
            saveToolStripButton.Size = new Size(29, 24);
            saveToolStripButton.Text = "&Save";
            saveToolStripButton.Click += saveToolStripButton_Click;
            // 
            // exportAsTxtToolStripMenuItem
            // 
            exportAsTxtToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            exportAsTxtToolStripMenuItem.Image = (Image)resources.GetObject("exportAsTxtToolStripMenuItem.Image");
            exportAsTxtToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            exportAsTxtToolStripMenuItem.Name = "exportAsTxtToolStripMenuItem";
            exportAsTxtToolStripMenuItem.Size = new Size(29, 24);
            exportAsTxtToolStripMenuItem.Text = "Export";
            exportAsTxtToolStripMenuItem.Click += exportToolStripButton_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { classCountLabel });
            statusStrip.Location = new Point(0, 474);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1242, 26);
            statusStrip.TabIndex = 12;
            statusStrip.Text = "statusStrip1";
            // 
            // classCountLabel
            // 
            classCountLabel.Name = "classCountLabel";
            classCountLabel.Size = new Size(50, 20);
            classCountLabel.Text = "Ready";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Orchid;
            ClientSize = new Size(1242, 500);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            Controls.Add(subjectNameLabel);
            Controls.Add(subjectTextBox);
            Controls.Add(scheduleDataGridView);
            Controls.Add(addButton);
            Controls.Add(dateTimeLabel);
            Controls.Add(subjectDateTimePicker);
            Controls.Add(roomComboBoxLabel);
            Controls.Add(roomComboBox);
            Controls.Add(teacherComboBoxLabel);
            Controls.Add(teacherComboBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)scheduleDataGridView).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scheduleErrorProvider).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
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
        private TextBox subjectTextBox;
        private Label subjectNameLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveScheduleToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem saveAstxtToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem deleteClassToolStripMenuItem;
        private ToolStrip toolStrip;
        private ToolStripButton saveToolStripButton;
        private ToolStripButton exportAsTxtToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel classCountLabel;
        //private Label label1;
    }
}
