using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Library.Data.Entities;
using static Library.Data.DataConstants.BookConstants;

namespace Library.Models.Books
{
    public class BookFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorNameMaxLength, MinimumLength = AuthorNameMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Column(TypeName = RatingDecimal)]
        [Range(typeof(decimal), RatingMin, RatingMax, ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }


        public int CategoryId { get; set; }


        public IEnumerable<Category> Categories = new List<Category>();
    }
}
