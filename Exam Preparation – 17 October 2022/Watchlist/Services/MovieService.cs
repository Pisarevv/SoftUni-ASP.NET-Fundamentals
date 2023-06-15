using Microsoft.EntityFrameworkCore;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Models.Movie;

namespace Watchlist.Services;

public class MovieService : IMovieService
{
    private readonly WatchlistDbContext dbContext;

    public MovieService(WatchlistDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ICollection<AllMoviesViewModel>> GetAllAsync()
    {
        return await dbContext.Movies
                     .AsNoTracking()
                     .Select(m => new AllMoviesViewModel
                     {
                         Id = m.Id,
                         Title = m.Title,
                         Director = m.Director,
                         Genre = m.Genre.Name,
                         Rating = m.Rating.ToString(),
                         ImageUrl = m.ImageUrl,
                     })
                     .ToListAsync();
    }
}
