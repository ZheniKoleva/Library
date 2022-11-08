using Library.Contracts;
using Library.Models.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
     
        public BooksController(IBookService _bookService)
        {
            bookService = _bookService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var movies = await bookService.GetAllBooks();

            return View(movies);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new BookAddViewModel()
            {
                Categories = await bookService.GetAllCategories()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(BookAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await bookService.AddBook(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Book was not added! Please, try again!");

                return View(model);
            }

            return RedirectToAction(nameof(All));
        }


        public async Task<IActionResult> AddToCollection(int bookId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                await bookService.AddBookToUserCollection(userId, bookId);
            }
            catch (Exception error)
            {
                ModelState.AddModelError(string.Empty, error.Message);
            }

            return RedirectToAction(nameof(All));
        }


        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                var movies = await bookService.GetMyBooks(userId);

                return View(nameof(Mine), movies);
            }
            catch (Exception error)
            {
                ModelState.AddModelError(string.Empty, error.Message);
                return View();
            }
            
        }


        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                await bookService.RemoveBookFromUserCollection(userId, bookId);
            }
            catch (Exception error)
            {
                ModelState.AddModelError(string.Empty, error.Message);                
            }

            return RedirectToAction(nameof(Mine));
        }
    }
}
