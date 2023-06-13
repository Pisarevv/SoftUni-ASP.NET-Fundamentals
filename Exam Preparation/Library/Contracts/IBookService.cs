using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        public Task<ICollection<AllViewBookModel>> GetAllAsync();

        public Task<ICollection<UserBookViewModel>> GetUserBooksAsync(string userId);
    }
}
