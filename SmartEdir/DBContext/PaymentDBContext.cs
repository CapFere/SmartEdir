using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdir.DBContext
{
    class PaymentDBContext
    {
        //data base constants
        private const string SERVER = "localhost";
        private const string DATABASE = "smart_edir";
        private const string UID = "root";
        private const string PASSWORD = "";
        private static MySqlConnection dbCon;

        //user properties

        public int ReceiptNumber { get; private set; }
        public byte[] Receipt { get; private set; }
        public int MemberId { get; private set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public string Status { get; set; }
        public string Seen { get; set; }

        public PaymentDBContext(int receiptNumber, byte[] receipt, int memberId, string day, string month, int year, string status,string seen)
        {
            ReceiptNumber = receiptNumber;
            Receipt = receipt;
            MemberId = memberId;
            Day = day;
            Month = month;
            Year = year;
            Status = status;
            Seen = seen;
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

        public static List<PaymentDBContext> GetPayments()
        {
            List<PaymentDBContext> payments = new List<PaymentDBContext>();
            string query = "SELECT * FROM payment";
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int receiptNumber = (int)reader["receiptNumber"];
                byte[] receipt = (byte[])reader["receipt"];
                int memberId = (int)reader["memberId"];
                string day = (string)reader["day"];
                string month = (string)reader["month"];
                int year = (int)reader["year"];
                string status = (string)reader["status"];
                string seen = (string)reader["seen"];
                payments.Add(new PaymentDBContext(receiptNumber, receipt, memberId, day, month,year,status,seen));
            }
            dbCon.Close();
            return payments;
        }


        public static bool Inserst(int receiptNumber, byte[] receipt, int memberId, string day, string month, int year, string status)
        {
            try
            {
                string query = string.Format($"INSERT INTO payment(receiptNumber,receipt,memberId,day,month,year,status,seen) values((@rn), (@r), (@mi), (@d), (@m), (@y), (@s),(@se))");
                MySqlCommand cmd = new MySqlCommand(query, dbCon);
                cmd.Parameters.AddWithValue("@rn", receiptNumber);
                cmd.Parameters.AddWithValue("@r", receipt);
                cmd.Parameters.AddWithValue("@mi", memberId);
                cmd.Parameters.AddWithValue("@d", day);
                cmd.Parameters.AddWithValue("@m", month);
                cmd.Parameters.AddWithValue("@y", year);
                cmd.Parameters.AddWithValue("@s", status);
                cmd.Parameters.AddWithValue("@se", "NO");
                dbCon.Open();
                cmd.ExecuteNonQuery();
                dbCon.Close();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
        public static void Update(int receiptNumer, string status)
        {
            string query = string.Format($"UPDATE payment SET status = (@s), seen = (@se) WHERE receiptNumber = (@r)");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            cmd.Parameters.AddWithValue("@s", status);
            cmd.Parameters.AddWithValue("@se", "NO");
            cmd.Parameters.AddWithValue("@r", receiptNumer);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
        public static void Update(int receiptNumer)
        {
            string query = string.Format($"UPDATE payment SET seen = (@s) WHERE receiptNumber = (@r)");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            cmd.Parameters.AddWithValue("@s", "YES");
            cmd.Parameters.AddWithValue("@r", receiptNumer);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
        public static void Delete(int receiptNumber)
        {
            string query = string.Format($"DELETE FROM payment WHERE receiptNumber={receiptNumber}");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
    }
}
