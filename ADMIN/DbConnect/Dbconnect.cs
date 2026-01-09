using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN.DbConnect
{
    public class DBConnect
    {
        private string Conn = @"Data Source=N\\MIRA;Initial Catalog=LMS_ADMIN;Integrated Security=True;Trust Server Certificate=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(Conn);
        }
    }
}