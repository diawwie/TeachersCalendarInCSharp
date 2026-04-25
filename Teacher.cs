using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWAPTeachersCalendar
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Speciality { get; set; }  // this will be related to the subject -> we assign every teacher a subject they teach  
    
        // method that combines the names
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}