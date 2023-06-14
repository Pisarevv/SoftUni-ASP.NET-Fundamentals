using Library.Models;

namespace Library.Contracts;

public interface ICategoryService
{
    public Task<ICollection<CategoryViewModel>> GetAllAsync();
}
