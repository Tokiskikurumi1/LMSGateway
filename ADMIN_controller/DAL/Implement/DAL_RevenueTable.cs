using ADMIN.DbConnect;
using ADMIN_controller.Models.respose;
using System.Data;
using System.Data.SqlClient;

namespace ADMIN_controller.DAL.Implement
{
    public class DAL_RevenueTable
    {
        private readonly DBConnect _db = new DBConnect();

        public List<Revenue_table> GetAllRevenue()
        {
            var list = new List<Revenue_table>();
            using (SqlConnection conn = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_revenue_get_all", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Revenue_table
                    {
                        RevenueID = (int)reader["RevenueID"],
                        StudentName = reader["StudentName"].ToString(),
                        CourseName = reader["CourseName"].ToString(),
                        Amount = (decimal)reader["Amount"],
                        PaymentMethod = reader["PaymentMethod"].ToString(),
                        PaymentDate = (DateTime)reader["PaymentDate"],
                        Status = reader["Status"].ToString()
                    });
                }
            }
            return list;
        }

        public bool CreateRevenue(Revenue_table model)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_revenue_create", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentName", model.StudentName);
                cmd.Parameters.AddWithValue("@CourseName", model.CourseName);
                cmd.Parameters.AddWithValue("@Amount", model.Amount);
                cmd.Parameters.AddWithValue("@PaymentMethod", model.PaymentMethod);
                cmd.Parameters.AddWithValue("@PaymentDate", model.PaymentDate);
                cmd.Parameters.AddWithValue("@Status", model.Status);

                conn.Open();
                var result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
        public bool UpdateRevenue(Revenue_table model)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_revenue_update", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RevenueID", model.RevenueID);
                cmd.Parameters.AddWithValue("@StudentName", model.StudentName);
                cmd.Parameters.AddWithValue("@CourseName", model.CourseName);
                cmd.Parameters.AddWithValue("@Amount", model.Amount);
                cmd.Parameters.AddWithValue("@PaymentMethod", model.PaymentMethod);
                cmd.Parameters.AddWithValue("@PaymentDate", model.PaymentDate);
                cmd.Parameters.AddWithValue("@Status", model.Status);

                conn.Open();
                var result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool DeleteRevenue(int id)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_revenue_delete", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RevenueID", id);

                conn.Open();
                var result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

    }

}
