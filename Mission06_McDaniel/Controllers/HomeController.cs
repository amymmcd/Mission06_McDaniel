using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View(new Movie());
    }
    
    [HttpPost]
    public IActionResult AddMovies(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); // add record to database
            _context.SaveChanges();
            return View("Confirmation", response);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(response);
        }
    }
    
    public IActionResult ViewMovies()
    {
        var movies = _context.Movies
            .Include(x => x.Category)
            .OrderBy(x => x.Title)
            .ToList();
        
        return View(movies);
    }

    [HttpGet]
    public IActionResult EditMovie(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("AddMovies", recordToEdit);
    }

    [HttpPost]
    public IActionResult EditMovie(Movie updatedMovie)
    {
        _context.Update(updatedMovie);
        _context.SaveChanges();
        
        return RedirectToAction("ViewMovies");
    }

    [HttpGet]
    public IActionResult DeleteMovie(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult DeleteMovie(Movie recordToDelete)
    {
        _context.Movies.Remove(recordToDelete);
        _context.SaveChanges();
        
        return RedirectToAction("ViewMovies");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}