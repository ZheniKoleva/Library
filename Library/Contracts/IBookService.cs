using Library.Data.Models;
using Library.Models.Book;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBooks();

        Task<IEnumerable<Category>> GetAllCategories();

        Task AddBook(BookAddViewModel model);

        Task<IEnumerable<MyBookViewModel>> GetMyBooks(string userId);

        Task AddBookToUserCollection(string userId, int movieId);

        Task RemoveBookFromUserCollection(string userId, int movieId);
    }
}
