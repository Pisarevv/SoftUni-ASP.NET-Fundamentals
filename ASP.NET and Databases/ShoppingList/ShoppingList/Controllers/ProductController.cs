using Microsoft.AspNetCore.Mvc;
using ShoppingList.Core.Contracts;
using ShoppingList.Core.Models;
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

        public IActionResult Add()
        {
            return View(new ProductAddModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddModel model)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Add");
            }
            else
            {
                await _productService.CreateAsync(model);
            }
            return RedirectToAction("Index");
        }

    }
}
