using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdir.DBContext
{
    class UserDBContext
    {
        //data base constants
        private const string SERVER = "localhost";
        private const string DATABASE = "smart_edir";
        private const string UID = "root";
        private const string PASSWORD = "";
        private static MySqlConnection dbCon;

        //user properties

        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public byte[] Image { get; set; }
        public int MemberID { get; set; }

        public UserDBContext(string email, string password, string role, byte[] image, int memberID)
        {
            Email = email;
            Password = password;
            Role = role;
            Image = image;
            MemberID = memberID;
        }

        public static void IntitalizeDB() {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVER;
            builder.UserID = UID;
            builder.Password = PASSWORD;
            builder.Database = DATABASE;
            string connectionString = builder.ToString();
            builder = null;
            dbCon = new MySqlConnection(connectionString);

        }        
        public static List<UserDBContext> GetUsers() {
            List<UserDBContext> users = new List<UserDBContext>();
            string query = "SELECT * FROM users";
            MySqlCommand cmd = new MySqlCommand(query,dbCon);
            dbCon.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                string email = reader["email"].ToString();
                string password = reader["password"].ToString();
                string role = reader["role"].ToString();
                byte[] image = (byte[])reader["image"];
                int memberId = (int)reader["mId"];
                users.Add(new UserDBContext(email,password,role,image,memberId));
            }
            dbCon.Close();
            return users;
        }
        public static UserDBContext GetUser(string emaill)
        {
            UserDBContext user;
            string query = string.Format($"SELECT * FROM users WHERE email='{emaill}'");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            string email = reader["email"].ToString();
            string password = reader["password"].ToString();
            string role = reader["role"].ToString();
            byte[] image = (byte[])reader["image"];
            int memberId = (int)reader["mId"];
            user = new UserDBContext(email, password, role, image, memberId);
            dbCon.Close();
            return user;
        }

        public static void Inserst(string email, string password, string role, byte[] imgByteArr, int mId)
        {
            string query = string.Format($"INSERT INTO users(email,password,role,image,mId) values((@e), (@p), (@r), (@i), (@m))");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            cmd.Parameters.AddWithValue("@e", email);
            cmd.Parameters.AddWithValue("@p", password);
            cmd.Parameters.AddWithValue("@r", role);
            cmd.Parameters.AddWithValue("@i", imgByteArr);
            cmd.Parameters.AddWithValue("@m", mId);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }

        public static void Update(string email, string password, string role, byte[] imgByteArr, int mId)
        {
            string query = string.Format($"UPDATE users SET password = (@p),role = (@r),image = (@i),mId = (@m) WHERE email = (@e)");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            cmd.Parameters.AddWithValue("@e", email);
            cmd.Parameters.AddWithValue("@p", password);
            cmd.Parameters.AddWithValue("@r", role);
            cmd.Parameters.AddWithValue("@i", imgByteArr);
            cmd.Parameters.AddWithValue("@m", mId);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
        public static void Update(string email, string password)
        {
            string query = string.Format($"UPDATE users SET password = (@p) WHERE email = (@e)");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            cmd.Parameters.AddWithValue("@e", email);
            cmd.Parameters.AddWithValue("@p", password);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
        public static void Delete(string email)
        {
            string query = string.Format($"DELETE FROM users WHERE email = (@e)");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            cmd.Parameters.AddWithValue("@e", email);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }

    }
}
