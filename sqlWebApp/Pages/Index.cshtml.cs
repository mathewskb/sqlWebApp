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

        private readonly IProductService _productService;
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product>  Products { get; set; }

        public void OnGet()
        {
            Products = _productService.GetProducts();
        }
    }
}