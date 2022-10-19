using System.ComponentModel.DataAnnotations;
using static Watchlist.Data.DataConstants.GenreConstants;

namespace Watchlist.Data.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        public string Name { get; set; } = null!;

    }

//    •	Has Id – a unique integer, Primary Key
//•	Has Name – a string with min length 5 and max length 50 (required)

}