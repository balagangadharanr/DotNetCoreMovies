using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreMovies.Models
{
    public class Movie
    {
        public int Id{ get; set; }

        
        [Display(Name = "Title"), Required, StringLength(60,MinimumLength = 3)]
        public string MovieName { get; set; }
        
        [DataType(DataType.Date), Required, Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        public string Genre { get; set; }
        
        [Required, Range(1,1000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required, Range(1,5)]
        public int Rating { get; set;}
    }
}