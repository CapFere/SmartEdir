using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdir.DBContext
{
    class MemberDBContext
    {
        //data base constants
        private const string SERVER = "localhost";
        private const string DATABASE = "smart_edir";
        private const string UID = "root";
        private const string PASSWORD = "";
        private static MySqlConnection dbCon;

        //member properties

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string BirthDate { get; private set; }
        public string Gender { get; private set; }
        public string Occupation { get; private set; }

        public MemberDBContext(int id, string firstName, string middleName, string lastName, string birthDate, string gender, string occupation)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            Occupation = occupation;
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
        public static List<MemberDBContext> GetMembers()
        {
            List<MemberDBContext> members = new List<MemberDBContext>();
            string query = "SELECT * FROM members";
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["memberId"] ;
                string firstName = reader["firstName"].ToString();
                string middleName = reader["middleName"].ToString();
                string lastName = reader["lastName"].ToString();
                string birthDate = reader["birthDate"].ToString();
                string gender = reader["gender"].ToString();
                string occupaiton = reader["occupation"].ToString();

                members.Add(new MemberDBContext(id,firstName,middleName,lastName,birthDate,gender,occupaiton));
            }
            dbCon.Close();
            return members;
        }
        public static MemberDBContext GetMember(int memberId)
        {
            MemberDBContext member;
            string query =string.Format($"SELECT * FROM members WHERE memberId={memberId}");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();            
            int id = (int)reader["memberId"];
            string firstName = reader["firstName"].ToString();
            string middleName = reader["middleName"].ToString();
            string lastName = reader["lastName"].ToString();
            string birthDate = reader["birthDate"].ToString();
            string gender = reader["gender"].ToString();
            string occupaiton = reader["occupation"].ToString();

            member = new MemberDBContext(id, firstName, middleName, lastName, birthDate, gender, occupaiton);

            dbCon.Close();
            return member;
        }
        public static void Inserst(string fName,string mName, string lName, string bDate, string gender, string occupation) {
            string query = string.Format($"INSERT INTO members(firstName,middleName,lastName,birthDate,gender,occupation) values('{fName}','{mName}','{lName}','{bDate}','{gender}','{occupation}')");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();           
            dbCon.Close();
        }
        public static void Update(int id, string fName, string mName, string lName, string bDate, string gender, string occupation)
        {
            string query = string.Format($"UPDATE members SET firstName = '{fName}',middleName = '{mName}',lastName = '{lName}',birthDate = '{bDate}',gender = '{gender}',occupation ='{occupation}' WHERE memberId={id}");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
        public static void Delete(int id)
        {
            string query = string.Format($"DELETE FROM members WHERE memberId={id}");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
    }
}
