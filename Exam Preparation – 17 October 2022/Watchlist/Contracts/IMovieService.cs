namespace Watchlist.Contracts;

using Watchlist.Models.Movie;
public interface IMovieService
{
    public Task<ICollection<AllMoviesViewModel>> GetAllAsync();
}
