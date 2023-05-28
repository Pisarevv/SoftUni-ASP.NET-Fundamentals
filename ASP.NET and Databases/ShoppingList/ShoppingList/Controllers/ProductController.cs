using Microsoft.AspNetCore.Mvc;
using ShoppingList.Core.Contracts;
using ShoppingList.Infrastructure.Context;

namespace ShoppingList.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.AllAsync();
            return View(products);
        }
    }
}
