#nullable enable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_McDaniel.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
   
    [Required(ErrorMessage = "You must enter a Title")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "You must enter a Year")]
    [Range(1888, int.MaxValue, ErrorMessage = "Please enter a year after 1888.")]
    public int Year { get; set; }
    
    public string? Director { get; set; }
    
    public string? Rating { get; set; }
    
    [Required(ErrorMessage = "You must choose an option for 'Edited'")]
    public bool Edited { get; set; } 
    
    public string? LentTo { get; set; }
    
    [Required(ErrorMessage = "You must choose an option for 'Copied to Plex'")]
    public bool CopiedToPlex { get; set; }
   
    [StringLength(25, ErrorMessage = "Notes cannot be longer than 25 characters.")]
    public string? Notes { get; set; } 
}