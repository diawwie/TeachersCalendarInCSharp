using Microsoft.Data.Sqlite;    // This is our new database toolkit!
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1ProjectWAPTeachersCalendar;

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

        // save a single teacher to the database
        public static void SaveTeacher(Teacher t)
        {
            using(var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                string insertSql = "INSERT INTO Teachers (FirstName, LastName, Speciality) VALUES (@First, @Last, @Spec);";

                using (var command = new SqliteCommand(insertSql, connection))
                {
                    // using parameters prevents security issues or broken SQL syntax
                    command.Parameters.AddWithValue("@First", t.FirstName);
                    command.Parameters.AddWithValue("@Last", t.LastName);
                    command.Parameters.AddWithValue("@Spec", t.Speciality);

                    command.ExecuteNonQuery();
                }

            }
        }

        // load all teachers from the database
        public static List<Teacher> LoadTeachers()
        {
            List<Teacher> list = new List<Teacher>();

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                string selectSql = "SELECT * FROM Teachers;";

                using(var command = new SqliteCommand(selectSql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Teacher t = new Teacher
                        {
                            // convert the raw database values 
                            TeacherId = Convert.ToInt32(reader["TeacherId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Speciality = reader["Speciality"].ToString()
                        };
                        list.Add(t);
                    }
                }
            }
            return list;
        }


        // CREATE -> insert a new class
        public static void InsertSubject(Subject s)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                string sql = @"INSERT INTO Subjects (SubjectName, TeacherId, TeacherName, RoomId, RoomName, ClassDate)
                VALUES (@SubName, @TId, @TName, @RId, @RName, @CDate);";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@SubName", s.SubjectName);
                    command.Parameters.AddWithValue("@TId", s.TeacherId);
                    command.Parameters.AddWithValue("@TName", s.TeacherName);
                    command.Parameters.AddWithValue("@RId", s.RoomId);
                    command.Parameters.AddWithValue("@RName", s.RoomName);
                    command.Parameters.AddWithValue("@CDate", s.ClassDate.ToString("o"));   // "o" saves it as a standard round-trip date string
                    command.ExecuteNonQuery();
                }
            }
        }

        // READ -> pull all scheduled classes
        public static List<Subject> LoadSubjects()
        {
            List<Subject> list = new List<Subject>();

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Subjects;";

                using (var command = new SqliteCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Subject s = new Subject
                        {
                            SubjectId = Convert.ToInt32(reader["SubjectId"]),
                            SubjectName = reader["SubjectName"].ToString(),
                            TeacherId = Convert.ToInt32(reader["TeacherId"]),
                            TeacherName = reader["TeacherName"].ToString(),
                            RoomId = Convert.ToInt32(reader["RoomId"]),
                            RoomName = reader["RoomName"].ToString(),
                            ClassDate = DateTime.Parse(reader["ClassDate"].ToString())
                        };
                        list.Add(s);
                    }
                }
            }
            return list;
        }

        // UPDATE -> edit an existing class
        public static void UpdateSubject(Subject s)
        {
            using(var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                string sql = @"UPDATE Subjects 
                               SET SubjectName = @SubName, TeacherId = @TId, TeacherName = @TName, 
                                   RoomId = @RId, RoomName = @RName, ClassDate = @CDate 
                               WHERE SubjectId = @SubId;";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@SubId", s.SubjectId);
                    command.Parameters.AddWithValue("@SubName", s.SubjectName);
                    command.Parameters.AddWithValue("@TId", s.TeacherId);
                    command.Parameters.AddWithValue("@TName", s.TeacherName);
                    command.Parameters.AddWithValue("@RId", s.RoomId);
                    command.Parameters.AddWithValue("@RName", s.RoomName);
                    command.Parameters.AddWithValue("@CDate", s.ClassDate.ToString("o"));
                    command.ExecuteNonQuery();
                }
            }
        }


        // DELETE -> wipe out a class
        public static void DeleteSubject(int subjectId)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Subjects WHERE SubjectId = @SubId;";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@SubId", subjectId);
                    command.ExecuteNonQuery();
                }
            }

        }
    }
}
