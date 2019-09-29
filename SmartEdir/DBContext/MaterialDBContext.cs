using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEdir.DBContext
{
    class MaterialDBContext
    {
        //data base constants
        private const string SERVER = "localhost";
        private const string DATABASE = "smart_edir";
        private const string UID = "root";
        private const string PASSWORD = "";
        private static MySqlConnection dbCon;

        //member properties
        public int Id { get; private set; }
        public string MaterialName { get; private set; }
        public string BrandName { get; private set; }
        public string MaterialType { get; private set; }
        public double MaterialCost { get; private set; }
        public string PurchasedDate { get; private set; }

        public MaterialDBContext(int id, string materialName, string brandName, string materialType, double materialCost, string purchasedDate)
        {
            Id = id;
            MaterialName = materialName;
            BrandName = brandName;
            MaterialType = materialType;
            MaterialCost = materialCost;
            PurchasedDate = purchasedDate;
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
        public static List<MaterialDBContext> GetMaterials()
        {
            List<MaterialDBContext> materials = new List<MaterialDBContext>();
            string query = "SELECT * FROM materials";
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["materialId"];
                string materialName = reader["materialName"].ToString();
                string brandName = reader["brandName"].ToString();
                string materialType = reader["materialType"].ToString();
                double materialCost = (double)reader["materialCost"];
                string purchasedDate = reader["purchasedDate"].ToString();

                materials.Add(new MaterialDBContext(id, materialName, brandName, materialType, materialCost, purchasedDate));
            }
            dbCon.Close();
            return materials;
        }

        public static void Inserst(string mName, string bName, string mType, double mCost, string pDate)
        {
            string query = string.Format($"INSERT INTO materials(materialName,brandName,materialType,materialCost,purchasedDate) values('{mName}','{bName}','{mType}',{mCost},'{pDate}')");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }

        public static void Update(int id, string mName, string bName, string mType, double mCost, string pDate)
        {
            string query = string.Format($"UPDATE materials SET materialName = '{mName}',brandName = '{bName}',materialType = '{mType}',materialCost = {mCost},purchasedDate = '{pDate}' WHERE materialId={id}");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
        public static void Delete(int id)
        {
            string query = string.Format($"DELETE FROM materials WHERE materialId={id}");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
    }
}
