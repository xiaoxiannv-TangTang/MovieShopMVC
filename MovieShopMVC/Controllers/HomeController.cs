﻿using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //


        private readonly IMovieService _movieService;
        private readonly MovieShopDbContext _context;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService, MovieShopDbContext context)
        {
            _logger = logger;
            // need to initiate _movieService; find the implementation
            _movieService = movieService;
            // want my code rely on abstractions rathen than concrete types
            _context = context;
        }
        // index
        // specify the type of http request
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // newing up 
            // we can have some higher level framework to create instances. 
            // this index method is tightly couple with movieSerice;
            //var movieService = new MovieService();

            // ==== tried to pass deveral models using dynamic
            //dynamic homeContent = new ExpandoObject();
            var movieCards = await _movieService.GetTop30GlossingMovies();



            // passing the data from Controller action method to View
            return View(movieCards);


        }


        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        // https://localhost:7169/home/topratedmovies


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




    }
}