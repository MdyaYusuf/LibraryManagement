using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Models.Dtos;

namespace LibraryManagement.ConsoleUI.Repository.Abstract;

public interface IBookRepository : IRepository<Book, Guid>
{
  List<BookDetailDto> GetDetails();
  List<BookDetailDto> GetDetailsSecondary();
  List<BookDetailDto> GetAllAuthorAndBookDetails();
  List<BookDetailDto> GetAllDetailsByCategoryId(int categoryId);
  List<Book> GetAllBooksOrderByTitle();
  List<Book> GetAllBooksOrderByDescendingTitle();
  List<Book> GetAllBooksByTitleContains(string text);
  List<string> GetAllBookTitles();
  List<Book> GetAllBooksByPageSizeFilter(int min, int max);
  Book? GetBookByISBN(string isbn);
  Book? GetBookByMaxPageSize();
  Book? GetBookByMinPageSize();
  double PageSizeTotalCalculator();
}
