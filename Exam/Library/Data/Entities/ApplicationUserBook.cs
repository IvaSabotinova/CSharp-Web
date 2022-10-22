using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class ApplicationUserBook
    {
        [ForeignKey(nameof(ApplicationUser))]
        [Required]
        public string ApplicationUserId  { get; set; } = null!;
        public ApplicationUser 	ApplicationUser  { get; set; } = null!;

        [ForeignKey(nameof(Book))]
        [Required]
        public int 	BookId  { get; set; }

        public Book Book { get; set; } = null!;
    }
}