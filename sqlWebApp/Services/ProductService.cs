using sqlWebApp.Models;
using System.Data.SqlClient;

namespace sqlWebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _config;

        public ProductService(IConfiguration config)
        {
            _config = config;
        }


        private SqlConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("SQLConnection"));
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
