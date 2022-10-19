using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Contracts;
using Watchlist.Data.Entities;
using Watchlist.Models.Movies;
using static Watchlist.Data.DataConstants.MovieConstants;
using static Watchlist.Data.DataConstants.ControllerConstants;

namespace Watchlist.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]

        public async Task<IActionResult> All()
        {
            MoviesAllViewModel moviesAllViewModel = await _movieService.GetAllMoviesAsync();
            return View(moviesAllViewModel);    

        }


        [HttpGet]

        public async Task<IActionResult> Add()
        {
            MovieFormModel movieFormModel = new MovieFormModel()
            {
                Genres = await _movieService.GetAllGenresAsync()
            };
            return View(movieFormModel);

        }
        [HttpPost]

        public async Task<IActionResult> Add(MovieFormModel movieFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(movieFormModel);
            }
            //try
            //{
            //    await _movieService.AddMovieAsync(movieFormModel);
            //    return RedirectToAction(nameof(All));
            //}
            //catch (Exception)
            //{
            //    ModelState.AddModelError(string.Empty, InvalidMovieMessage);
            //    return View(movieFormModel);
            //}

            IEnumerable<Genre> allGenres = await _movieService.GetAllGenresAsync();

            if (!allGenres.Any(g => g.Id == movieFormModel.GenreId))
            {
                ModelState.AddModelError(nameof(movieFormModel.GenreId), InexistantGenre);
                return View(movieFormModel);
            }
            await _movieService.AddMovieAsync(movieFormModel);
            return RedirectToAction(nameof(All));

        }

        public async Task<IActionResult> AddToCollection(int movieId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await _movieService.AddMovieToCollection(movieId, userId);
               
            }
            catch (Exception)
            {
                ModelState.AddModelError("", GeneralErrorMessage);               
            }
            return RedirectToAction(nameof(All));

        }
        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            MoviesAllViewModel moviesAllViewModel = null!;
            try
            {
                moviesAllViewModel = await _movieService.Watched(userId);
            }
            catch (Exception)
            {

                ModelState.AddModelError("", GeneralErrorMessage);
            }

            return View("Mine", moviesAllViewModel);

        }
        //[HttpGet]

        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _movieService.RemoveMovieFromCollectionAsync(movieId, userId);    
            return RedirectToAction(nameof(Watched));   

        }





    }
}
