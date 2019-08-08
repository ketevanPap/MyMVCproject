using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMVCproject.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Relase Date")]
        public DateTime RelaseDate { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}