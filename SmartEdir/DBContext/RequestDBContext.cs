using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartEdir.DBContext
{
    class RequestDBContext
    {
        //data base constants
        private const string SERVER = "localhost";
        private const string DATABASE = "smart_edir";
        private const string UID = "root";
        private const string PASSWORD = "";
        private static MySqlConnection dbCon;

        //user properties
        public int RequestId { get; private set; }
        public int MemberId { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Date { get; private set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public RequestDBContext(int requestId, int memberId, string phoneNumber, string date, string subject, string body)
        {
            RequestId = requestId;
            MemberId = memberId;
            PhoneNumber = phoneNumber;
            Date = date;
            Subject = subject;
            Body = body;
        }
        public static void IntitalizeDB()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVER;
            builder.UserID = UID;
            builder.Password = PASSWORD;
            builder.Database = DATABASE;
            string connectionString = builder.ToString();
            builder = null;
            dbCon = new MySqlConnection(connectionString);

        }
        public static bool Inserst( int memberId, string phoneNumber, string date, string subject, string body)
        {
            try
            {
                string query = string.Format($"INSERT INTO requests(memberId,phone,responseDate,subject,body) values((@m), (@p), (@r), (@s), (@b))");
                MySqlCommand cmd = new MySqlCommand(query, dbCon);
                cmd.Parameters.AddWithValue("@m", memberId);
                cmd.Parameters.AddWithValue("@p", phoneNumber);
                cmd.Parameters.AddWithValue("@r", date);
                cmd.Parameters.AddWithValue("@s", subject);
                cmd.Parameters.AddWithValue("@b", body);
                dbCon.Open();
                cmd.ExecuteNonQuery();
                dbCon.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static List<RequestDBContext> GetRequests()
        {
            List<RequestDBContext> requests = new List<RequestDBContext>();
            string query = "SELECT * FROM requests";
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int requestId = (int)reader["requestId"];
                int memberId = (int)reader["memberId"];
                string phone = (string)reader["phone"];
                string date = (string)reader["responseDate"];
                string subject = (string)reader["subject"];
                string body = (string)reader["body"];
                requests.Add(new RequestDBContext(requestId, memberId, phone, date, subject, body));
            }
            dbCon.Close();
            return requests;
        }
    }
}
