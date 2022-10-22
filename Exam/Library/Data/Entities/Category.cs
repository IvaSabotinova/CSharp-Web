using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using static Library.Data.DataConstants.CategoryConstants;

namespace Library.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }


}