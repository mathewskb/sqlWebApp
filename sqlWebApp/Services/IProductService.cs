using sqlWebApp.Models;

namespace sqlWebApp.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}