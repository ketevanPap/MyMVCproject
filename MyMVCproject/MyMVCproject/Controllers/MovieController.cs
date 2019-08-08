using MyMVCproject.Models;
using MyMVCproject.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System;

namespace MyMVCproject.Controllers
{
    public class MovieController : Controller
    {
        #region Private Fields

        private CustomerDBContext _dBContext;

        #endregion

        #region Constructor
        public MovieController()
        {
            _dBContext = new CustomerDBContext();
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            _dBContext.Dispose();
        }

        #region Actions

        public ActionResult Index()
        {
            var movies = _dBContext.Movies.Include(g => g.Genre).ToList();

            return View(movies);
        }

        public ActionResult New()
        {
            var genres = _dBContext.Genres.ToList();

            var viewMovie = new NewMovieViewModel()
            {
                Genres = genres
            };

            return View(viewMovie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            var genries = _dBContext.Genres.ToList();

            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel
                {
                    Genres = genries
                };

                return View("New", viewModel);
            }

            if (movie.Id == 0)
            {
                _dBContext.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _dBContext.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.RelaseDate = movie.RelaseDate;
                movieInDb.GenreId = movie.GenreId;
            }

            _dBContext.SaveChanges();
            

            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int Id)
        {
            var movie = _dBContext.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genres = _dBContext.Genres.ToList()
            };

            return View("New", viewModel);
        }

        #endregion
    }
}