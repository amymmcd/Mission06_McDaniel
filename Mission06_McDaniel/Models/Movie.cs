#nullable enable
using System.ComponentModel.DataAnnotations;
namespace Mission06_McDaniel.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    [Required(ErrorMessage = "You must enter a Category")]
    public string Category { get; set; }
   
    [Required(ErrorMessage = "You must enter a Title")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "You must enter a Year")]
    public int Year { get; set; }
    
    [Required(ErrorMessage = "You must enter a Director")]
    public string Director { get; set; }
    
    [Required(ErrorMessage = "You must enter a rating.")]
    public string Rating { get; set; }
    
    // not required
    public bool? Edited { get; set; } // bool? indicates that it is nullable
    
    // not required
    public string? LentTo { get; set; } // string? indicates that it is nullable
   
    // not required
    [StringLength(25, ErrorMessage = "Notes cannot be longer than 25 characters.")]
    public string? Notes { get; set; } // string? indicates that it is nullable
}