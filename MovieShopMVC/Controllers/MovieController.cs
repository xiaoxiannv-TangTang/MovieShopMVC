﻿using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MovieController : Controller
    {



        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }




        // GET: Movie/Detail/5
        public async Task<ActionResult> Detail(int id)
        {

            // go to db Movie table and get the movie by id==1
            // connect to sql server and execute SQL Query
            // select * from Movie where id = 2;
            // get the movie object/entity

            // create repositories about data access logic 
            // create services => business logic 
            // controllers action methods -> service method -> repository method -> call DB
            // get the model data from service and send data to view(M)
            // model is the data you want to pass to view 
            // call Onion architecture or N -layer architecture 
            // 

            // Remote DB
            // CPU operation      => calculations, 
            // I/O bound operation  => DB calls, files, images, videos, 




            MovieDetailsModel movieDetail = await _movieService.GetMovieDetailsById(id);
            return View(movieDetail);


        }

        // get movies by genre 

        public ActionResult MoviesByGenre(string genre, int pageSize = 30, int pageNumber = 1)
        {

            var movies = _movieService.GetMoviesByGenre(genre);





            return View("../Home/Index", movies);
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




    }
}
