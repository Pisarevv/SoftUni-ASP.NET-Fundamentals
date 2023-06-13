using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        public Task<ICollection<AllViewBookModel>> GetAll();
    }
}
