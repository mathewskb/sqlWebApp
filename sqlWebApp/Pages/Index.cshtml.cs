using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlWebApp.Models;
using sqlWebApp.Services;

namespace sqlWebApp.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public List<Product>  Products { get; set; }

        public void OnGet()
        {
            ProductService _service = new ProductService();
            Products =_service.GetProducts();
        }
    }
}