using Microsoft.Data.Sqlite;    // This is our new database toolkit!
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWAPTeachersCalendar
{
    internal class DatabaseHelper
    {
        // This points to where our database file will live on your computer
        private const string ConnectionString = "Data Source=calendar.db;";

        public static void InitializeDatabase()
        {
            // open a secure connection to our database file
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                // create a teachers table if it doesn't exist yet
                string createTeachersTable = @"
                    CREATE TABLE IF NOT EXISTS Teachers(
                        TeacherId INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT,
                        LastName TEXT,
                        Speciality TEXT
                    );";

                using (var command = new SqliteCommand(createTeachersTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                // create the Subjects (Schedule) Table if it doesn't exist yet
                string createSubjectsTable = @"
                    CREATE TABLE IF NOT EXISTS Subjects (
                        SubjectId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectName TEXT,
                        TeacherId INTEGER,
                        TeacherName TEXT,
                        RoomId INTEGER,
                        RoomName TEXT,
                        ClassDate TEXT
                    );";

                using (var command = new SqliteCommand(createSubjectsTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
