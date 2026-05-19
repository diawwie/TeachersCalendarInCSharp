// these are for serialization
using CustomControlsLib;
using System.IO;    // file system 
using System.Text.Json; // json translators
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

            // waking up the db
            DatabaseHelper.InitializeDatabase();

            // check if we already have teachers in the db
            teacherList = DatabaseHelper.LoadTeachers();

            if (teacherList.Count == 0)
            {
                // if the db is completely brand new and empty, add these initial 5 hardcoded starters
                DatabaseHelper.SaveTeacher(new Teacher { FirstName = "Fred", LastName = "Hermann", Speciality = "Economics" });
                DatabaseHelper.SaveTeacher(new Teacher { FirstName = "Tiffany", LastName = "Rose", Speciality = "Algebra" });
                DatabaseHelper.SaveTeacher(new Teacher { FirstName = "Britney", LastName = "Chairsman", Speciality = "Data Structures" });
                DatabaseHelper.SaveTeacher(new Teacher { FirstName = "Gregory", LastName = "Zabroski", Speciality = "Data Analysis" });
                DatabaseHelper.SaveTeacher(new Teacher { FirstName = "Stephen", LastName = "Kinger", Speciality = "Computer Science" });

                // re pull them so they have their database-generated ids
                teacherList = DatabaseHelper.LoadTeachers();
            }

            // TEACHER COMBO BOX SETUP
            // adding test data
            //teacherList.Add(new Teacher { TeacherId = 1, FirstName = "Fred", LastName = "Hermann", Speciality = "Economics" });
            //teacherList.Add(new Teacher { TeacherId = 2, FirstName = "Tiffany", LastName = "Rose", Speciality = "Algebra" });
            //teacherList.Add(new Teacher { TeacherId = 3, FirstName = "Britney", LastName = "Chairsman", Speciality = "Data Structures" });
            //teacherList.Add(new Teacher { TeacherId = 4, FirstName = "Gregory", LastName = "Zabroski", Speciality = "Data Analysis" });
            //teacherList.Add(new Teacher { TeacherId = 5, FirstName = "Stephen", LastName = "Kinger", Speciality = "Computer Science" });

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
            roomList.Add(new Room { RoomId = 103, RoomName = "Seminar room 1", RoomCapacity = 30 });
            roomList.Add(new Room { RoomId = 104, RoomName = "Seminar room 2", RoomCapacity = 25 });
            roomList.Add(new Room { RoomId = 105, RoomName = "Seminar room 3", RoomCapacity = 20 });

            // connecting the list to the room comboBox
            roomComboBox.DataSource = roomList;

            // displaying on the screen
            roomComboBox.DisplayMember = "RoomName";    // displays Amphitheatre 1 for example
            // roomComboBox.DisplayMember = "RoomCapacity";    // displays 100
            roomComboBox.ValueMember = "RoomId";    // keeps hidden 101

            // DESERIALIZATION -> telling the app to look for this file the moment it opens 
            // checking if the file actually exists before trying to open it
            if (File.Exists("my_schedule.json"))
            {
                // read the text from the file 
                string savedJson = File.ReadAllText("my_schedule.json");

                // translate it back into a list of subjects
                scheduleList = JsonSerializer.Deserialize<List<Subject>>(savedJson);
            }

            // DESERIALIZATION IN DB
            scheduleList = DatabaseHelper.LoadSubjects();

            // connecting the grid to the master schedule list 
            scheduleDataGridView.DataSource = scheduleList;

            UpdateStatus();

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

            // standard & custom exceptions 
            try
            {
                //CHECK FOR A CUSTOM EXCEPTION
                // we don't allow the user to pick a date in the past, we're not in a time machine lol
                if (subjectDateTimePicker.Value.Date < DateTime.Now.Date)
                {
                    throw new InvalidScheduleException("You cannot schedule a class in the past!");
                }

                // CHECK FOR STANDARD EXCEPTION (ex: teacher and room ids must be valid
                if ((int)teacherComboBox.SelectedValue <= 0)
                {
                    // ArgumentException is standard for C#
                    throw new ArgumentException("Invalid teacher ID!");
                }
                if ((int)roomComboBox.SelectedValue <= 0)
                {
                    throw new ArgumentException("Invalid room ID!");
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

                UpdateStatus();




                // ALSO SAVING INTO THE DB
                // save it to the master database!
                DatabaseHelper.InsertSubject(newClass);

                // Reload from database so the UI has the correct database-generated IDs
                scheduleList = DatabaseHelper.LoadSubjects();

                // refreshing the grid to show the new data
                scheduleDataGridView.DataSource = null;
                scheduleDataGridView.DataSource = scheduleList;






                // give feedback to the user
                MessageBox.Show("Class added to the schedule successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                subjectTextBox.Clear(); // this empties the text box for the next entry :3
            }
            catch (InvalidScheduleException ex) // the custom exception
            {
                MessageBox.Show(ex.Message, "Scheduling error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) // all the standard exceptions
            {
                MessageBox.Show("A system error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void subjectTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // checking if the user typed something but it's too short
            if (!string.IsNullOrWhiteSpace(subjectTextBox.Text) && subjectTextBox.Text.Length < 3)
            {
                scheduleErrorProvider.SetError(subjectTextBox, "Subject name must be at least 3 characters long!");
                e.Cancel = true;    // this traps their cursor in the box until they fix it
            }
        }

        private void subjectTextBox_Validated(object sender, EventArgs e)
        {
            // if the user fixed the error and successfully validated, clear the error - red icon
            scheduleErrorProvider.SetError(subjectTextBox, "");
        }

        // SERIALIZATION - SAVING THE FILE as json
        private void saveScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // translating the list into a formatted JSON string
                var options = new JsonSerializerOptions { WriteIndented = true };   // makes the file look pretty uwu
                string jsonString = JsonSerializer.Serialize(scheduleList, options);

                // saving the string into a text file on the computer
                File.WriteAllText("my_schedule.json", jsonString);

                MessageBox.Show("Schedule saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Your schedule is connected to a live SQLite database and saves automatically on every action!", "Database Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // closes the app instantly and safely
        }

        private void saveAstxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // list to hold all the lines of the text file 
                List<string> reportLines = new List<string>();

                // adding a fancy header to look pretty :3
                reportLines.Add("======================================");
                reportLines.Add("        TEACHER SCHEDULE REPORT       ");
                reportLines.Add("======================================");
                reportLines.Add("Generated on: " + DateTime.Now.ToString());
                reportLines.Add("");    // adding blank lines for spacing

                // looping through the schedule list and writing each class:
                if (scheduleList.Count == 0)
                {
                    reportLines.Add("There are no classes scheduled at this time!");
                }
                else
                {
                    foreach (Subject s in scheduleList)
                    {
                        reportLines.Add($"Subject:      {s.SubjectName}");  // $ = string interpolation 
                        reportLines.Add($"Teacher:      {s.TeacherName}");
                        reportLines.Add($"Room:      {s.RoomName}");
                        reportLines.Add($"Date/Time:      {s.ClassDate.ToString("g")}");    // the built-in "General date/short time" specifier
                        reportLines.Add("-------------------------------------------");
                    }
                }
                // save all the lines into a real .txt file
                File.WriteAllLines("ScheduleReport.txt", reportLines);

                MessageBox.Show("Report exported successfully at ScheduleReport.txt!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // check if the user actually has a row selected in their grid
            if (scheduleDataGridView.SelectedRows.Count > 0)
            {
                // ask for confirmation so they don't actually delete something they don't want
                DialogResult result = MessageBox.Show("Are you sure you want to delete this class?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // grab the data from the selected row and tell the program it's a Subject object!
                    Subject classToDelete = (Subject)scheduleDataGridView.SelectedRows[0].DataBoundItem;


                    // Remove from database!
                    DatabaseHelper.DeleteSubject(classToDelete.SubjectId);
                    // Re-sync memory list
                    scheduleList = DatabaseHelper.LoadSubjects();



                    // remove it from the master list 
                    scheduleList.Remove(classToDelete);

                    // now refresh the grid to show the updated list
                    scheduleDataGridView.DataSource = null;
                    scheduleDataGridView.DataSource = scheduleList;

                    // hiding the fugly ID columns 
                    scheduleDataGridView.Columns["TeacherId"].Visible = false;
                    scheduleDataGridView.Columns["RoomId"].Visible = false;

                    UpdateStatus();
                }
                else
                {
                    MessageBox.Show("Please select a class from the list to delete.", "Select a class", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            // it automatically clicks the existing Menu button
            saveScheduleToolStripMenuItem.PerformClick();
        }

        private void exportToolStripButton_Click(object sender, EventArgs e)
        {
            saveAstxtToolStripMenuItem.PerformClick();
        }

        private void UpdateStatus()
        {
            classCountLabel.Text = "Total Classes Scheduled: " + scheduleList.Count.ToString();
        }

        private void addNewTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create the popup form
            AddTeacherForm popup = new AddTeacherForm();

            // open it using ShowDialog() - this pauses form1until the popup closes
            if (popup.ShowDialog() == DialogResult.OK)
            {
                // grab thr "package" we made in the other form
                Teacher createdTeacher = popup.NewTeacher;

                // save to the database instantly
                DatabaseHelper.SaveTeacher(createdTeacher);

                // re-load the master list from the database to ensure it's perfectly in sync
                teacherList = DatabaseHelper.LoadTeachers();

                // force a hard reset of theComboBox
                teacherComboBox.DataSource = null;
                teacherComboBox.DataSource = new List<Teacher>(teacherList);
                teacherComboBox.DisplayMember = "FullName";
                teacherComboBox.ValueMember = "TeacherId";

                teacherComboBox.SelectedIndex = teacherComboBox.Items.Count - 1;

                MessageBox.Show(createdTeacher.FullName + " was added to the database system!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //// give them an ID number based on how many teachers already exist
                //createdTeacher.TeacherId = scheduleList.Count + 1;


                // virtually refresh the combobox
                // Force a hard reset of the ComboBox
                teacherComboBox.DataSource = null;
                // Wrapping it in 'new List' forces the ComboBox to redraw it from scratch!
                teacherComboBox.DataSource = new List<Teacher>(teacherList);
                teacherComboBox.DisplayMember = "FullName";
                teacherComboBox.ValueMember = "TeacherId";

                // Select the newly added teacher automatically so the user sees it immediately
                teacherComboBox.SelectedIndex = teacherComboBox.Items.Count - 1;

                MessageBox.Show(createdTeacher.FullName + " was added in the system!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void scheduleDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // if a row is actually selected:
            if (scheduleDataGridView.SelectedRows.Count > 0)
            {
                // Un-hide the card!
                teacherProfileCard.Visible = true;


                // grab the selected class
                Subject selectedClass = (Subject)scheduleDataGridView.SelectedRows[0].DataBoundItem;

                // fill up the inputs on the screen with its current data
                teacherComboBox.SelectedValue = selectedClass.TeacherId;
                roomComboBox.SelectedValue = selectedClass.RoomId;
                subjectDateTimePicker.Value = selectedClass.ClassDate;

                // (the teacherComboBox_SelectedIndexChanged will automatically fill the subjectTextBox)

                // updating the USER CONTROL
                string[] nameParts = selectedClass.TeacherName.Split(' ');
                string fName = nameParts[0];
                string lName = nameParts.Length > 1 ? nameParts[1] : "";
                string spec = selectedClass.SubjectName;

                teacherProfileCard.UpdateProfile(fName, lName, spec);
            }
            else
            {
                // If NO row is selected (like after adding a new class), hide it again!
                teacherProfileCard.Visible = false;
            }
        }

        private void updateClassBtn_Click(object sender, EventArgs e)
        {
            // make sure the user actually selected a row to update
            if (scheduleDataGridView.SelectedRows.Count > 0)
            {
                try
                {
                    // grab the exact class they are trying to edit 
                    Subject classToUpdate = (Subject)scheduleDataGridView.SelectedRows[0].DataBoundItem;

                    // overwrite the old data with whatever is currently in the boxes
                    classToUpdate.TeacherId = (int)teacherComboBox.SelectedValue;
                    classToUpdate.TeacherName = teacherComboBox.Text;
                    classToUpdate.RoomId = (int)roomComboBox.SelectedValue;
                    classToUpdate.RoomName = roomComboBox.Text;
                    classToUpdate.ClassDate = subjectDateTimePicker.Value;
                    classToUpdate.SubjectName = subjectTextBox.Text;


                    // PUSH UPDATES TO DB
                    DatabaseHelper.UpdateSubject(classToUpdate);
                    //resync memory list
                    scheduleList = DatabaseHelper.LoadSubjects();


                    // refreshing the grid so it shows the new data
                    scheduleDataGridView.DataSource = null;
                    scheduleDataGridView.DataSource = scheduleList;
                    scheduleDataGridView.Columns["TeacherId"].Visible = false;
                    scheduleDataGridView.Columns["RoomId"].Visible = false;

                    MessageBox.Show("Class updated successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Make sure all fields are filled correctly! Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a class from the list to update first.", "Select a class", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scheduleDataGridView.ClearSelection();

            teacherComboBox.SelectedIndex = -1;
            roomComboBox.SelectedIndex = -1;
            subjectTextBox.Clear();

            subjectDateTimePicker.Value = DateTime.Now;

            // Hide the profile card when the app first opens
            teacherProfileCard.Visible = false;
        }

        private void viewStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create a new chart window and hand it to the master schedule list 
            ChartForm myChart = new ChartForm(scheduleList);

            // open the window dialog so the user can see it
            myChart.ShowDialog();
        }
    }
}
