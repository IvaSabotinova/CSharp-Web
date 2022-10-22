using Library.Data.Entities;
using Library.Models.Books;

namespace Library.Contracts
{
    public interface IBookService
    {

        Task AddBookAsync(BookFormModel bookFormModel);

        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<IEnumerable<BookViewModel>> GetAllBooksAsync();      

        Task AddBookToCollection(int bookId, string userId);

        Task<IEnumerable<BookViewModel>> Mine (string userId);

        Task RemoveBookFromCollectionAsync(int bookId, string userId);
    }
}
