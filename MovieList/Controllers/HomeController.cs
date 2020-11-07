using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieList.Models;
using Microsoft.EntityFrameworkCore;


namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext context { get; set; }                          //added property

        public HomeController(MovieContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var movies = context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();    //added INclude and OrderBy
            return View(movies);
        }
    }
}
