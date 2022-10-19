using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Watchlist.Data.DataConstants.MovieConstants;


namespace Watchlist.Data.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DirectorNameMaxLength)]
        public string Director { get; set; } = null!;


        [Required]
       public string ImageUrl { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Rating { get; set; }

        [ForeignKey(nameof(Genre))]
        public int? GenreId { get; set; }

        public Genre? Genre { get; set; }

        public List<UserMovie> UsersMovies = new List<UserMovie>();
    }

//    •	Has Id – a unique integer, Primary Key
//•	Has Title – a string with min length 10 and max length 50 (required)
//•	Has Director – a string with min length 5 and max length 50 (required)
//•	Has ImageUrl – a string (required)
//•	Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
//•	Has GenreId – an integer
//•	Has Genre – a Genre
//•	Has UsersMovies – a collection of type UserMovie

}