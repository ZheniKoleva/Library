using Library.Contracts;
using Library.Data.Common;
using Library.Data.Models;
using Library.Models.Book;
using Microsoft.EntityFrameworkCore;
using Book = Library.Data.Models.Book;
using Category = Library.Data.Models.Category;

namespace Library.Services
{
    public class BookService : IBookService
    {
        public readonly IRepository repo;

        public BookService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooks()
        {
            return await repo.AllReadonly<Book>()
               .Select(m => new AllBookViewModel()
               {
                   Id = m.Id,
                   Title = m.Title,
                   Author = m.Author,
                   ImageUrl = m.ImageUrl,
                   Rating = m.Rating,
                   Category = m.Category.Name
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await repo.AllReadonly<Category>()
                .ToListAsync();
        }

        public async Task AddBook(BookAddViewModel model)
        {
            var bookToAdd = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId,
            };

            await repo.AddAsync<Book>(bookToAdd);
            await repo.SaveChangesAsync();
        }


        public async Task AddBookToUserCollection(string userId, int bookId)
        {
            var user = await repo.All<ApplicationUser>(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user credentials");
            }

            var book = await repo.GetByIdAsync<Book>(bookId);

            if (book == null)
            {                
                throw new ArgumentException("There is no book with such ID");
            }

            if (!user.ApplicationUsersBooks.Any(um => um.BookId == book.Id))
            {
                var bookToAdd = new ApplicationUserBook()
                {
                    ApplicationUserId = userId,
                    ApplicationUser = user,
                    BookId = bookId,
                    Book = book
                };

                user?.ApplicationUsersBooks.Add(bookToAdd);
                await repo.SaveChangesAsync();
            }
        }  


        public async Task<IEnumerable<MyBookViewModel>> GetMyBooks(string userId)
        {
            var user = await repo.AllReadonly<ApplicationUser>(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .ThenInclude(um => um.Book)
                .ThenInclude(m => m.Category)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user credentials");
            }

            return user.ApplicationUsersBooks
                .Select(m => new MyBookViewModel()
                {
                    Id = m.BookId,
                    Title = m.Book.Title,
                    Author = m.Book.Author,
                    ImageUrl = m.Book.ImageUrl,
                    Description = m.Book.Description,
                    Category = m.Book.Category.Name
                });
        }


        public async Task RemoveBookFromUserCollection(string userId, int bookId)
        {
            var user = await repo.All<ApplicationUser>(u => u.Id == userId)
               .Include(u => u.ApplicationUsersBooks)
               .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user credentials");
            }

            var bookToRemove = user.ApplicationUsersBooks.FirstOrDefault(um => um.BookId == bookId);

            if (bookToRemove != null)
            {
                user.ApplicationUsersBooks.Remove(bookToRemove);
                await repo.SaveChangesAsync();
            }
        }
    }
}
