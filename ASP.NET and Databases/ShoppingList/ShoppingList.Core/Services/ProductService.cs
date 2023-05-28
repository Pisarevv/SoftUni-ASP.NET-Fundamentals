using Microsoft.EntityFrameworkCore;
using ShoppingList.Core.Contracts;
using ShoppingList.Core.Models;
using ShoppingList.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ShoppingListDbContext _context;
        public ProductService(ShoppingListDbContext context)
        {
            this._context = context;
        }
        public async Task<ICollection<ProductViewModel>> AllAsync()
        {
            var products = await _context
                .Products
                .AsNoTracking()
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.ProductName,
                    Price = p.Price,


                })
                .ToListAsync();


            return products;
        }
    }
}
