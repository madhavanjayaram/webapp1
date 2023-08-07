using System.Data.SqlClient;
using webapp1.Models;

namespace webapp1.Services
{
    public class ProductService
    {
        private static string db_source = "sqlserver1az204.database.windows.net";
        private static string db_user = "madhavanjayaram";
        private static string db_password = "Baskball@221183";
        private static string db_database = "sqldb1";


        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }


        public List<Product> GetProducts()
        { 
            SqlConnection conn = GetConnection();
            var products = new List<Product>();
            string sqlstmt = "SELECT ProductID, ProductName, Quantity FROM Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlstmt, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            { 
                while (reader.Read()) {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    products.Add(product);
                }
            }
            conn.Close();
            return products;
        }
    }
}
