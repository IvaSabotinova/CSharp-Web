using Library.Contracts;
using Library.Data.Entities;
using Library.Models.Books;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Library.Data.DataConstants.BookConstants;
using static Library.Data.DataConstants.ControllerConstants;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]

        public async Task<IActionResult> All()
        {
            IEnumerable<BookViewModel> bookViewModels = await _bookService.GetAllBooksAsync();
            return View(bookViewModels);

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            BookFormModel bookFormModel = new BookFormModel()
            {
                Categories = await _bookService.GetAllCategoriesAsync()
            };
            return View(bookFormModel);

        }
        [HttpPost]

        public async Task<IActionResult> Add(BookFormModel bookFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(bookFormModel);
            }
            try
            {
                await _bookService.AddBookAsync(bookFormModel);
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, InvalidBookMessage);
                return View(bookFormModel);
            }

      

        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {

            try
            {
               string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _bookService.AddBookToCollection(bookId, userId);

            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, GeneralErrorMessage);
            }
            return RedirectToAction(nameof(All));

        }
        [HttpGet]
        public async Task<IActionResult> Mine()
        {

            IEnumerable<BookViewModel> bookViewModels = new List<BookViewModel>();
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                bookViewModels = await _bookService.Mine(userId);
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, GeneralErrorMessage);
            }

            return View(bookViewModels);

        }

        [HttpPost]

        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _bookService.RemoveBookFromCollectionAsync(bookId, userId);
            return RedirectToAction(nameof(Mine));

        }
    }
}
