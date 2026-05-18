namespace ProjectWAPTeachersCalendar
{
    partial class AddTeacherForm
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
            firstNameLabel = new Label();
            lastNameLabel = new Label();
            specialityLabel = new Label();
            tbFirstName = new TextBox();
            tbLastName = new TextBox();
            tbSpeciality = new TextBox();
            saveTeacherBtn = new Button();
            SuspendLayout();
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(157, 102);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(80, 20);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "First Name";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(333, 102);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(79, 20);
            lastNameLabel.TabIndex = 1;
            lastNameLabel.Text = "Last Name";
            // 
            // specialityLabel
            // 
            specialityLabel.AutoSize = true;
            specialityLabel.Location = new Point(512, 102);
            specialityLabel.Name = "specialityLabel";
            specialityLabel.Size = new Size(73, 20);
            specialityLabel.TabIndex = 2;
            specialityLabel.Text = "Speciality";
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(135, 125);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(125, 27);
            tbFirstName.TabIndex = 3;
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(311, 125);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(125, 27);
            tbLastName.TabIndex = 4;
            // 
            // tbSpeciality
            // 
            tbSpeciality.Location = new Point(487, 125);
            tbSpeciality.Name = "tbSpeciality";
            tbSpeciality.Size = new Size(125, 27);
            tbSpeciality.TabIndex = 5;
            // 
            // saveTeacherBtn
            // 
            saveTeacherBtn.BackColor = Color.MediumOrchid;
            saveTeacherBtn.Location = new Point(302, 217);
            saveTeacherBtn.Name = "saveTeacherBtn";
            saveTeacherBtn.Size = new Size(143, 47);
            saveTeacherBtn.TabIndex = 6;
            saveTeacherBtn.Text = "SAVE";
            saveTeacherBtn.UseVisualStyleBackColor = false;
            saveTeacherBtn.Click += saveTeacherBtn_Click;
            // 
            // AddTeacherForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Plum;
            ClientSize = new Size(800, 450);
            Controls.Add(saveTeacherBtn);
            Controls.Add(tbSpeciality);
            Controls.Add(tbLastName);
            Controls.Add(tbFirstName);
            Controls.Add(specialityLabel);
            Controls.Add(lastNameLabel);
            Controls.Add(firstNameLabel);
            Name = "AddTeacherForm";
            Text = "AddTeacherForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label firstNameLabel;
        private Label lastNameLabel;
        private Label specialityLabel;
        private TextBox tbFirstName;
        private TextBox tbLastName;
        private TextBox tbSpeciality;
        private Button saveTeacherBtn;
    }
}