using Library.Contracts;
using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ICollection<AllViewBookModel>> GetAllAsync()
        {
            return await dbContext.Books
                         .AsNoTracking()
                         .Select(b => new AllViewBookModel
                         {
                             Id = b.Id,
                             Author = b.Author,
                             Category = b.Category.Name,
                             Title = b.Title,
                             Rating = b.Rating.ToString(),
                             ImageUrl = b.ImageUrl
                         })
                         .ToListAsync();
        }

        public async Task<ICollection<UserBookViewModel>> GetUserBooksAsync(string userId)
        {
            return await dbContext.IdentitiesUsers
                         .AsNoTracking()
                         .Where(u => u.CollectorId == userId)
                         .Select(b => new UserBookViewModel
                         {
                             Id = b.Book.Id,
                             Author = b.Book.Author,
                             Category = b.Book.Category.Name,
                             Title = b.Book.Title,
                             ImageUrl = b.Book.ImageUrl,
                             Description = b.Book.Description
                         })                        
                         .ToListAsync();
                         
        }
    }
}
