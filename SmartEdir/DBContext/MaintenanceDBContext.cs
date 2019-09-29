using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdir.DBContext
{
    class MaintenanceDBContext
    {
        //data base constants
        private const string SERVER = "localhost";
        private const string DATABASE = "smart_edir";
        private const string UID = "root";
        private const string PASSWORD = "";
        private static MySqlConnection dbCon;

        //member properties
        public int Id { get; private set; }
        public int MaterialId { get; private set; }
        public string MaterialName { get; private set; }
        public string MaterialType { get; private set; }
        public double MaintenanceCost { get; private set; }
        public string MaintenanceDate { get; private set; }

        public MaintenanceDBContext(int id, int materialId, string materialName, string materialType, double maintenanceCost, string maintenanceDate)
        {
            Id = id;
            MaterialId = materialId;
            MaterialName = materialName;
            MaterialType = materialType;
            MaintenanceCost = maintenanceCost;
            MaintenanceDate = maintenanceDate;
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
        public static List<MaintenanceDBContext> GetMaintenances()
        {
            List<MaintenanceDBContext> maintenances = new List<MaintenanceDBContext>();
            string query = "SELECT * FROM maintenance";
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["maintenanceId"];
                int materialId = (int)reader["materialId"];
                string materialName = reader["materialName"].ToString();
                string materialType = reader["materialType"].ToString();
                double maintenanceCost = (double)reader["maintenanceCost"];
                string maintenanceDate = reader["maintenanceDate"].ToString();

                maintenances.Add(new MaintenanceDBContext(id,materialId, materialName, materialType, maintenanceCost, maintenanceDate));
            }
            dbCon.Close();
            return maintenances;
        }
        public static void Inserst(int materialId, string mName, string mType, double mCost, string mDate)
        {
            string query = string.Format($"INSERT INTO maintenance(materialId,materialName,materialType,maintenanceCost,maintenanceDate) values({materialId},'{mName}','{mType}',{mCost},'{mDate}')");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }

        public static void Update(int id,int materialId, string mName, string mType, double mCost, string mDate)
        {
            string query = string.Format($"UPDATE maintenance SET materialId ={materialId}, materialName = '{mName}',materialType = '{mType}',maintenanceCost = {mCost},maintenanceDate = '{mDate}' WHERE maintenanceId={id}");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
        public static void Delete(int id)
        {
            string query = string.Format($"DELETE FROM maintenance WHERE maintenanceId={id}");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
    }
}
