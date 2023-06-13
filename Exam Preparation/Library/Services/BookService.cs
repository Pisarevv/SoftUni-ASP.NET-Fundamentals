using Library.Contracts;
using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Data.Models;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBookToUserCollection(string userId, int bookId)
        {
            IdentityUserBook userBook = new IdentityUserBook()
            {
                CollectorId = userId,
                BookId = bookId
            };

            await dbContext.IdentitiesUsers
                         .AddAsync(userBook);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveBookFromUserCollection(string userId, int bookId)
        {
            IdentityUserBook? bookToRemove = await dbContext.IdentitiesUsers
                                                  .FirstOrDefaultAsync(b => b.CollectorId == userId && b.BookId == bookId);

            if(bookToRemove != null)
            {
                dbContext.IdentitiesUsers.Remove(bookToRemove);
                await dbContext.SaveChangesAsync();
            }

        }
        public async Task<bool> DoesUserHaveBook(string userId, int bookId)
        {
            return await dbContext.IdentitiesUsers
                         .AnyAsync(b => b.CollectorId == userId && b.BookId == bookId);
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
