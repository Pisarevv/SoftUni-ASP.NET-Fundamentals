namespace Watchlist.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Contracts;
using Watchlist.Models.Genre;
using Watchlist.Models.Movie;

[Authorize]
public class MoviesController : Controller
{
    private readonly IMovieService movieService;
    private readonly IGenreService genreService;

    public MoviesController(IMovieService movieService, IGenreService genreService)
    {
        this.movieService = movieService;   
        this.genreService = genreService;
    }

    public async Task<IActionResult> All()
    {
        ICollection<AllMoviesViewModel> movies = await movieService.GetAllAsync();

        return View(movies);
    }

    public async Task<IActionResult> Add()
    {
        FormMovieViewModel model = new FormMovieViewModel();

        ICollection<GenreViewModel> genres = await genreService.GetAllAsync();

        model.Genres = genres;

        return View(model);
        
    }
}
