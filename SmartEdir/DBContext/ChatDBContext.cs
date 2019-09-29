using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdir.DBContext
{
    class ChatDBContext
    {
        //data base constants
        private const string SERVER = "localhost";
        private const string DATABASE = "smart_edir";
        private const string UID = "root";
        private const string PASSWORD = "";
        private static MySqlConnection dbCon;

        //event properties
        public int Id { get; private set; }
        public string Sender { get; private set; }
        public string Receiver { get; private set; }
        public string Message { get; private set; }
        public string Seen { get; private set; }

        public ChatDBContext(int id, string sender, string receiver, string message, string seen)
        {
            Id = id;
            Sender = sender;
            Receiver = receiver;
            Message = message;
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
        public static List<ChatDBContext> GetChats()
        {
            List<ChatDBContext> chats = new List<ChatDBContext>();
            string query = "SELECT * FROM conversations";
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["conversationId"];
                string sender = reader["sender"].ToString();
                string receiver = reader["receiver"].ToString();
                string message = reader["message"].ToString();
                string seen = reader["seen"].ToString();
                chats.Add(new ChatDBContext(id, sender, receiver, message,seen));
            }
            dbCon.Close();
            return chats;
        }
        public static void Inserst(string sender, string receiver, string message)
        {
            string query = string.Format($"INSERT INTO conversations(sender,receiver,message,seen) values('{sender}','{receiver}','{message}','{"NO"}')");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
        public static void Update(string sender, string receiver)
        {
            string query = string.Format($"UPDATE conversations SET seen = '{"YES"}' WHERE sender='{sender}' AND receiver='{receiver}'");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
    }
}
