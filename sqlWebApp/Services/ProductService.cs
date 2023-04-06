using sqlWebApp.Models;
using System.Data.SqlClient;

namespace sqlWebApp.Services
{
    public class ProductService
    {
        private static string db_source = "mathews.database.windows.net";
        private static string db_user = "matuser";
        private static string db_password = "M@thews1";
        private static string db_database = "mathews";


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
            SqlConnection _connection = GetConnection();

            List<Product> _products = new List<Product>();
            var query = "select ProductID, productName,Quandity from Products";

            _connection.Open();

            SqlCommand cmd = new SqlCommand(query, _connection);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quandity = reader.GetInt32(2)
                    };
                    _products.Add(product);

                }
            }
            return _products;

        }

    }
}
