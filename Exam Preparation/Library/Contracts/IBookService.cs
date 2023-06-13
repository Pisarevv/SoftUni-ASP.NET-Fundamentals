using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        public Task<ICollection<AllViewBookModel>> GetAllAsync();

        public Task<ICollection<UserBookViewModel>> GetUserBooksAsync(string userId);

        public Task AddBookToUserCollection(string userId, int bookId);

        public Task<bool> DoesUserHaveBook(string userId, int bookId);
    }
}
