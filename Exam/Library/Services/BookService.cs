using Library.Contracts;
using Library.Data;
using Library.Data.Entities;
using Library.Models.Books;
using Microsoft.EntityFrameworkCore;
using static Library.Data.DataConstants.BookConstants;
using static Library.Data.DataConstants.ApplicationUserConstants;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _libraryDbContext;

        public BookService(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task AddBookAsync(BookFormModel bookFormModel)
        {
            Book book = new Book()
            {
                Title = bookFormModel.Title,
                Author = bookFormModel.Author,
                Description = bookFormModel.Description,
                ImageUrl = bookFormModel.ImageUrl,
                Rating = bookFormModel.Rating,
                CategoryId = bookFormModel.CategoryId
               
            };
            await _libraryDbContext.Books.AddAsync(book);
            await _libraryDbContext.SaveChangesAsync();

        }

        public async Task AddBookToCollection(int bookId, string userId)
        {
            Book book = await _libraryDbContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException(InvalidBookId);
            }
            ApplicationUser applicationUser = await _libraryDbContext.Users
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (applicationUser == null)
            {
                throw new ArgumentException(InvalidUserId);

            }
            if (!applicationUser.ApplicationUsersBooks.Any(ub => ub.BookId == bookId))
            {
                applicationUser.ApplicationUsersBooks.Add(new ApplicationUserBook { ApplicationUserId = applicationUser.Id, BookId = book.Id });
                await _libraryDbContext.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _libraryDbContext.Categories.ToListAsync();
        }

        public async Task<IEnumerable<BookViewModel>> GetAllBooksAsync()
        {
              return await _libraryDbContext.Books
                .Include(b => b.Category)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    Rating = b.Rating,
                    ImageUrl = b.ImageUrl,
                    Category = b.Category.Name

                })
                .ToListAsync();
        }

        public async Task<IEnumerable<BookViewModel>> Mine(string userId)
        {
            ApplicationUser applicationUser = await _libraryDbContext.Users
                .Include(ub => ub.ApplicationUsersBooks)
                .ThenInclude(b => b.Book)
                .ThenInclude(c => c.Category)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (applicationUser == null)
            {
                throw new ArgumentException(InvalidUserId);
            }

            return applicationUser.ApplicationUsersBooks.Select(ub => new BookViewModel
            {
                Id = ub.BookId,
                Title = ub.Book.Title,
                ImageUrl = ub.Book.ImageUrl,
                Author = ub.Book.Author,
                Description = ub.Book.Description,               
                Category = ub.Book.Category.Name,
            });
        }


        public async Task RemoveBookFromCollectionAsync(int bookId, string userId)
        {
            ApplicationUser applicationUser = await _libraryDbContext.Users
                .Include(ub => ub.ApplicationUsersBooks)
                .ThenInclude(b=>b.Book)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (applicationUser == null)
            {
                throw new ArgumentException(InvalidUserId);
            }

           ApplicationUserBook applicationUserBook = applicationUser
                .ApplicationUsersBooks.FirstOrDefault(ub => ub.BookId == bookId);

            if (applicationUserBook != null)
            {
                applicationUser.ApplicationUsersBooks.Remove(applicationUserBook);
                await _libraryDbContext.SaveChangesAsync();
            }
        }
    }
}
