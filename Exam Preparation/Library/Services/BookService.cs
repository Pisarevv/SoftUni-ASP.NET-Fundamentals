using Library.Contracts;
using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ICollection<AllViewBookModel>> GetAll()
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
    }
}
