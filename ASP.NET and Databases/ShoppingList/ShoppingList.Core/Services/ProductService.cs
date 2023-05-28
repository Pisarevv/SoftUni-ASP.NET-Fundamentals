﻿using Microsoft.EntityFrameworkCore;
using ShoppingList.Core.Contracts;
using ShoppingList.Core.Models;
using ShoppingList.Infrastructure.Context;
using ShoppingList.Infrastructure.Model;
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


        public async Task CreateAsync(ProductAddModel product)
        {

            Product newProduct = new Product
            {
                Id = Guid.NewGuid().ToString(),
                ProductName = product.Name,
                Price = product.Price,
            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
           
        }
    }
}
