using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        public Task<ICollection<AllViewBookModel>> GetAllAsync();

        public Task<ICollection<UserBookViewModel>> GetUserBooksAsync(string userId);

        public Task AddBookToUserCollectionAsync(string userId, int bookId);

        public Task RemoveBookFromUserCollectionAsync(string userId, int bookId);

        public Task<bool> DoesUserHaveBookAsync(string userId, int bookId);

        public Task AddBookAsync(BookFormViewModel model);
    }
}
