using System;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Class { get; set; }

        private DataAccessLayer dal;

        public Student()
        {
            dal = new DataAccessLayer();
        }

        public void Insert()
        {
            string query = "INSERT INTO Student (FirstName, LastName, BirthDate, Class) VALUES (@FirstName, @LastName, @BirthDate, @Class)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FirstName", FirstName),
                new SqlParameter("@LastName", LastName),
                new SqlParameter("@BirthDate", BirthDate),
                new SqlParameter("@Class", Class)
            };
            dal.ExecuteNonQuery(query, parameters);
        }

        public void Update()
        {
            string query = "UPDATE Student SET FirstName = @FirstName, LastName = @LastName, Class = @Class WHERE StudentID = @StudentID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", StudentID),
                new SqlParameter("@FirstName", FirstName),
                new SqlParameter("@LastName", LastName),
                new SqlParameter("@Class", Class)
            };
            dal.ExecuteNonQuery(query, parameters);
        }

        public void Delete()
        {
            string query = "DELETE FROM Student WHERE StudentID = @StudentID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", StudentID)
            };
            dal.ExecuteNonQuery(query, parameters);
        }

        public static Student SearchByLastName(string lastName)
        {
            string query = "SELECT StudentID, FirstName, LastName, BirthDate, Class FROM Student WHERE LastName = @LastName";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LastName", lastName)
            };

            DataAccessLayer dal = new DataAccessLayer();
            SqlDataReader reader = dal.ExecuteReader(query, parameters);

            if (reader.Read())
            {
                Student student = new Student()
                {
                    StudentID = Convert.ToInt32(reader["StudentID"]),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                    Class = reader["Class"].ToString()
                };
                reader.Close();
                return student;
            }

            reader.Close();
            return null;
        }

        public static DataTable GetAllStudents()
        {
            string query = "SELECT StudentID, FirstName, LastName, BirthDate, Class FROM Student";
            DataAccessLayer dal = new DataAccessLayer();
            return dal.SelectData(query);
        }
    }
}
