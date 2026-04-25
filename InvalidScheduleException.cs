using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWAPTeachersCalendar 
{
    // making the new class inherit from Exception it makes it an official error type 
    internal class InvalidScheduleException : Exception
    {
        public InvalidScheduleException(string message) : base(message)
        { }
    }
}
