using ADMIN.DbConnect;
using QLY_LMS.Modal;
using System.Data;
using System.Data.SqlClient;

namespace QLY_LMS.DAL.Admin.Implementations
{
    public class DAL_CourseTable
    {
        private readonly DBConnect _db;

        public DAL_CourseTable()
        {
            _db = new DBConnect();
        }

        public List<Course_table> GetAllCourses()
        {
            var list = new List<Course_table>();
            using (SqlConnection conn = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_course_get_all", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Course_table
                    {
                        CourseID = (int)reader["courseID"],
                        TeacherID = (int)reader["teacherID"],
                        CourseName = reader["courseName"].ToString(),
                        CourseType = reader["courseType"].ToString(),
                        CourseDes = reader["courseDes"].ToString(),
                        CourseDate = (DateTime)reader["courseDate"],
                        CoursePrice = (decimal)reader["coursePrice"],
                        CourseStatus = reader["courseStatus"].ToString(),
                        CourseImage = reader["courseImage"].ToString()
                    });
                }
            }
            return list;
        }

        public Course_table GetCourseById(int id)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_course_get_by_id", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@courseID", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Course_table
                    {
                        CourseID = (int)reader["courseID"],
                        TeacherID = (int)reader["teacherID"],
                        CourseName = reader["courseName"].ToString(),
                        CourseType = reader["courseType"].ToString(),
                        CourseDes = reader["courseDes"].ToString(),
                        CourseDate = (DateTime)reader["courseDate"],
                        CoursePrice = (decimal)reader["coursePrice"],
                        CourseStatus = reader["courseStatus"].ToString(),
                        CourseImage = reader["courseImage"].ToString()
                    };
                }
                return null;
            }
        }

        public bool CreateCourse(Course_table model)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_course_create", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Gán giá trị hợp lệ cho CourseStatus nếu chưa có
                if (string.IsNullOrWhiteSpace(model.CourseStatus))
                {
                    model.CourseStatus = "active"; // hoặc "completed", "incomplete"
                }

                cmd.Parameters.AddWithValue("@teacherID", model.TeacherID);
                cmd.Parameters.AddWithValue("@courseName", model.CourseName);
                cmd.Parameters.AddWithValue("@courseType", model.CourseType);
                cmd.Parameters.AddWithValue("@courseDes", model.CourseDes);
                cmd.Parameters.AddWithValue("@courseSDate", model.CourseSDate);
                cmd.Parameters.AddWithValue("@courseEDate", model.CourseEDate);
                cmd.Parameters.AddWithValue("@coursePrice", model.CoursePrice);
                cmd.Parameters.AddWithValue("@courseStatus", model.CourseStatus);
                cmd.Parameters.AddWithValue("@courseImage", model.CourseImage);

                conn.Open();
                var result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }


        public bool UpdateCourse(Course_table model)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_course_update", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@courseID", model.CourseID);
                cmd.Parameters.AddWithValue("@teacherID", model.TeacherID);
                cmd.Parameters.AddWithValue("@courseName", model.CourseName);
                cmd.Parameters.AddWithValue("@courseType", model.CourseType);
                cmd.Parameters.AddWithValue("@courseDes", model.CourseDes);
                cmd.Parameters.AddWithValue("@courseDate", model.CourseDate);
                cmd.Parameters.AddWithValue("@coursePrice", model.CoursePrice);
                cmd.Parameters.AddWithValue("@courseStatus", model.CourseStatus);
                cmd.Parameters.AddWithValue("@courseImage", model.CourseImage);

                conn.Open();
                var result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool DeleteCourse(int id)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_course_delete", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@courseID", id);

                conn.Open();
                var result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
