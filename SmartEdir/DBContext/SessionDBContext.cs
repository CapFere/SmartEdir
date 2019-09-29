using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdir.DBContext
{
    class SessionDBContext
    {
        //user properties

        public string Email { get; private set; }
        public string Role { get; private set; }
        private static SqlConnection sqldbCon;
        public SessionDBContext(string email, string role)
        {
            Email = email;
            Role = role;
        }
        public static void IntitalizeSqlDB()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.IntegratedSecurity = true;
            builder.InitialCatalog = "SessionDB";
            builder.AttachDBFilename = @"|DataDirectory|\SessionDB.mdf";
            builder.DataSource = @"(LocalDB)\MSSQLLocalDB";
            string connectionString = builder.ToString();
            builder = null;
            sqldbCon = new SqlConnection(connectionString);
        }
        public static SessionDBContext GetUser()
        {
            try
            {
                SessionDBContext session;
                string query = string.Format($"SELECT * FROM session");
                SqlCommand cmd = new SqlCommand(query, sqldbCon);
                sqldbCon.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                string email = reader["email"].ToString();
                string role = reader["role"].ToString();
                session = new SessionDBContext(email, role);
                sqldbCon.Close();
                return session;
            }
            catch (Exception) {
                return null;
            }
        }
        public static void Inserst(string email, string role)
        {
            string query = string.Format($"INSERT INTO session(email,role) values(@e, @r)");
            SqlCommand cmd = new SqlCommand(query, sqldbCon);
            cmd.Parameters.AddWithValue("@e", email);
            cmd.Parameters.AddWithValue("@r", role);
            sqldbCon.Open();
            cmd.ExecuteNonQuery();
            sqldbCon.Close();
        }
        public static void Delete(string email)
        {
            string query = string.Format($"DELETE FROM session");
            SqlCommand cmd = new SqlCommand(query, sqldbCon);
            sqldbCon.Open();
            cmd.ExecuteNonQuery();
            sqldbCon.Close();
        }
    }
}
