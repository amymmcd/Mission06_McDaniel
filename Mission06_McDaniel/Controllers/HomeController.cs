using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_McDaniel.Models;

namespace Mission06_McDaniel.Controllers;

public class HomeController : Controller
{
    private MovieContext _context;

    public HomeController(MovieContext somename)
    {
        _context = somename;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddMovies()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddMovies(Movie response)
    {
        _context.Movies.Add(response); // add record to database
        _context.SaveChanges();
        
        return View("Confirmation", response);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}