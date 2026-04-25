using WinFormsApp1ProjectWAPTeachersCalendar;

namespace ProjectWAPTeachersCalendar
{
    public partial class Form1 : Form
    {
        List<Teacher> teacherList = new List<Teacher>();
        List<Room> roomList = new List<Room>();
        List<Subject> scheduleList = new List<Subject>();
        public Form1()
        {
            InitializeComponent();  // this draws our form

            // TEACHER COMBO BOX SETUP
            // adding test data
            teacherList.Add(new Teacher { TeacherId = 1, FirstName = "Fred", LastName = "Hermann", Speciality = "Computer Science" });
            teacherList.Add(new Teacher { TeacherId = 2, FirstName = "Tiffany", LastName = "Rose", Speciality = "Algebra" });

            // connecting the list to the teacher comboBox
            teacherComboBox.DataSource = teacherList;

            // displaying on the screen
            //teacherComboBox.DisplayMember = "LastName";
            //teacherComboBox.DisplayMember = "FirstName";

            teacherComboBox.DisplayMember = "FullName"; // replacing just the name that was writing over the last name with the full name of the teacher 
            teacherComboBox.ValueMember = "TeacherId"; // keeps it hidden



            // ROOM COMBO BOX SETUP
            roomList.Add(new Room { RoomId = 101, RoomName = "Amphitheatre 1", RoomCapacity = 100 });
            roomList.Add(new Room { RoomId = 102, RoomName = "Amphitheatre 2", RoomCapacity = 150 });

            // connecting the list to the room comboBox
            roomComboBox.DataSource = roomList;

            // displaying on the screen
            roomComboBox.DisplayMember = "RoomName";    // displays Amphitheatre 1 for example
            // roomComboBox.DisplayMember = "RoomCapacity";    // displays 100
            roomComboBox.ValueMember = "RoomId";    // keeps hidden 101

            // connecting the grid to the master schedule list 
            scheduleDataGridView.DataSource = scheduleList;

            // force the boxes to not have an initial value already selected, clear them out so we can test the error providers 
            teacherComboBox.SelectedIndex = -1;
            roomComboBox.SelectedIndex = -1;

            subjectTextBox.Clear(); 
        }

        private void teacherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // check if the user selected a teacher and not just cleared the box
            if (teacherComboBox.SelectedItem != null)
            {
                // let c# know the selected item is a teacher object
                Teacher selectedTeacher = (Teacher)teacherComboBox.SelectedItem;

                // auto-fill the text box
                subjectTextBox.Text = selectedTeacher.Speciality;
            }
            else
            {
                // if no teacher is selected clear the box (like when the app starts)
                subjectTextBox.Clear();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            scheduleErrorProvider.Clear(); // clear any old errors from the last time the button was clicked 

            bool isValid = true;    // a flag to track if everything is okay

            // check the teacherComboBox
            if (teacherComboBox.SelectedValue == null)
            {
                scheduleErrorProvider.SetError(teacherComboBox, "You must select a teacher!");
                isValid = false;
            }

            // check the roomComboBox
            if (roomComboBox.SelectedValue == null)
            {
                scheduleErrorProvider.SetError(roomComboBox, "You must select a room!");
                isValid = false;
            }

            // if anything is missing, stop
            if (isValid == null)
            {
                return;
            }

            //// validation to make sure the user actually picks something
            //if(teacherComboBox.SelectedValue == null || roomComboBox.SelectedValue == null)
            //{
            //    MessageBox.Show("Please select a teacher and a room first!", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return; // stop running this code 
            //}

            // extract the hidden ids using a cast to turn the object into an int
            int selectedTeacher = (int)teacherComboBox.SelectedValue;
            int selectedRoom = (int)roomComboBox.SelectedValue;

            // get the date from the date time picker
            DateTime selectedTime = subjectDateTimePicker.Value;

            // building the connector object
            Subject newClass = new Subject
            {
                SubjectId = scheduleList.Count + 1, // generating the id
                SubjectName = subjectTextBox.Text,

                TeacherId = selectedTeacher,
                TeacherName = teacherComboBox.Text, // grabs the teacher names like "Rose"

                RoomId = selectedRoom,
                RoomName = roomComboBox.Text,    // grabs the room names like "amph.. 1"

                ClassDate = selectedTime
            };

            // save it to the master list
            scheduleList.Add(newClass);

            // refreshing the grid to show the new data
            scheduleDataGridView.DataSource = null;
            scheduleDataGridView.DataSource = scheduleList;

            // hiding the raw id columns:
            scheduleDataGridView.Columns["TeacherId"].Visible = false;
            scheduleDataGridView.Columns["RoomId"].Visible = false;

            scheduleDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // keep these here too so it can reset the boxes to empty after creating a class 
            teacherComboBox.SelectedIndex = -1;
            roomComboBox.SelectedIndex = -1;

            // give feedback to the user
            MessageBox.Show("Class added to the schedule successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            subjectTextBox.Clear(); // this empties the text box for the next entry :3
        }
    }
}
