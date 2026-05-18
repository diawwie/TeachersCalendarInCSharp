using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectWAPTeachersCalendar
{
    public partial class AddTeacherForm : Form
    {
        // we create a public "package" that Form1 can grab later
        public Teacher NewTeacher {  get; private set; }
        public AddTeacherForm()
        {
            InitializeComponent();
        }

        private void saveTeacherBtn_Click(object sender, EventArgs e)
        {
            // build the teacher object using what the user just typed
            // we will let Form1 to figure out the ID number later 
            NewTeacher = new Teacher
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Speciality = tbSpeciality.Text
            };

            // tell windows that the user successfully finished the form
            this.DialogResult = DialogResult.OK;

            // close the popup
            this.Close();
        }
    }
}
