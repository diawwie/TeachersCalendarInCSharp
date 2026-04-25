using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1ProjectWAPTeachersCalendar
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public DateTime ClassDate { get; set; }
    }
}