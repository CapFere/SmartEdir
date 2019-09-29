using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdir.DBContext
{
    class EventDBContext
    {
        //data base constants
        private const string SERVER = "localhost";
        private const string DATABASE = "smart_edir";
        private const string UID = "root";
        private const string PASSWORD = "";
        private static MySqlConnection dbCon;

        //event properties
        public int Id { get; private set; }
        public string EventDate { get; private set; }
        public string EventAddress { get; private set; }
        public string EventDetail { get; private set; }

        public EventDBContext(int id, string eventDate, string eventAddress, string eventDetail)
        {
            Id = id;
            EventDate = eventDate;
            EventAddress = eventAddress;
            EventDetail = eventDetail;
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
        public static List<EventDBContext> GetEvents()
        {
            List<EventDBContext> materials = new List<EventDBContext>();
            string query = "SELECT * FROM events";
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["eventId"];
                string eventDate = reader["eventDate"].ToString();
                string eventAdress = reader["eventAddress"].ToString();
                string eventDetail = reader["eventDetail"].ToString();

                materials.Add(new EventDBContext(id, eventDate, eventAdress, eventDetail));
            }
            dbCon.Close();
            return materials;
        }

        public static void Inserst(string eventDate, string eventAddress,string eventDetail)
        {
            string query = string.Format($"INSERT INTO events(eventDate,eventAddress,eventDetail) values('{eventDate}','{eventAddress}','{eventDetail}')");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }

        public static void Update(int id, string eventDate, string eventAddress, string eventDetail)
        {
            string query = string.Format($"UPDATE events SET eventDate = '{eventDate}',eventAddress = '{eventAddress}',eventDetail = '{eventDetail}' WHERE eventId={id}");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
        public static void Delete(int id)
        {
            string query = string.Format($"DELETE FROM events WHERE eventId={id}");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
    }
}
