using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdir.DBContext
{
    class YearDBContext
    {
        //data base constants
        private const string SERVER = "localhost";
        private const string DATABASE = "smart_edir";
        private const string UID = "root";
        private const string PASSWORD = "";
        private static MySqlConnection dbCon;

        //user properties

        public int Year { get; private set; }
        public double Amount { get; private set; }

        public YearDBContext(int year, double amount)
        {
            Year = year;
            Amount = amount;
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
        public static List<YearDBContext> GetYears()
        {
            List<YearDBContext> years = new List<YearDBContext>();
            string query = "SELECT * FROM years";
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int year = (int)reader["year"];
                double amount = (double)reader["amount"];              
                years.Add(new YearDBContext(year,amount));
            }
            dbCon.Close();
            return years;
        }
        public static bool Inserst(int year, double amount)
        {
            try
            {
                string query = string.Format($"INSERT INTO years(year,amount) values((@y), (@a))");
                MySqlCommand cmd = new MySqlCommand(query, dbCon);
                cmd.Parameters.AddWithValue("@y", year);
                cmd.Parameters.AddWithValue("@a", amount);
                dbCon.Open();
                cmd.ExecuteNonQuery();
                dbCon.Close();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
    }
}
