using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Models.Dtos;
using LibraryManagement.ConsoleUI.Repository.Concrete;

namespace LibraryManagement.ConsoleUI.Service;

public class BookService
{
  BookRepository bookRepository = new BookRepository();

  public void GetAllBooks()
  {
    List<Book> books = bookRepository.GetAll();

    foreach (Book book in books)
    {
      Console.WriteLine(book);
    }
  }

  public void GetById(Guid id)
  {
    Book? book = bookRepository.GetById(id);

    if (book == null)
    {
      Console.WriteLine("Aradığınız Id'ye göre kitap bulunamadı.");
      return;
    }

    Console.WriteLine(book);
  }

  public void Add(Book book)
  {
    BookIdBusinessRules(book.Id);
    BookISBNBusinessRules(book.ISBN);

    Book createdBook = bookRepository.Add(book);
    Console.WriteLine("Kitap eklendi");
    Console.WriteLine(createdBook);
  }

  public void Remove(Guid id)
  {
    Book? deletedBook = bookRepository.Remove(id);

    if (deletedBook == null)
    {
      Console.WriteLine("Silmek istediğiniz kitap silinemedi çünkü zaten yok.");
      return;
    }

    Console.WriteLine("Kitap silindi.");
    Console.WriteLine(deletedBook);
  }

  public void GetDetails()
  {
    List<BookDetailDto> books = bookRepository.GetDetails();
    foreach (BookDetailDto bookDetail in books)
    {
      Console.WriteLine(bookDetail);
    }
  }

  public void GetDetailsSecondary()
  {
    List<BookDetailDto> books = bookRepository.GetDetailsSecondary();
    foreach (BookDetailDto bookDetail in books)
    {
      Console.WriteLine(bookDetail);
    }
  }

  public void GetAllAuthorAndBookDetails()
  {
    List<BookDetailDto> details = bookRepository.GetAllAuthorAndBookDetails();
    details.ForEach(b => Console.WriteLine(b));
  }

  public void GetAllDetailsByCategoryId(int categoryId)
  {
    List<BookDetailDto> result = bookRepository.GetAllDetailsByCategoryId(categoryId);
    result.ForEach(b => Console.WriteLine(b));
  }

  public void GetAllBooksOrderByTitle()
  {
    List<Book> books = bookRepository.GetAllBooksOrderByTitle();
    foreach (Book book in books)
    {
      Console.WriteLine(book);
    }
  }

  public void GetAllBooksOrderByDescendingTitle()
  {
    List<Book> books = bookRepository.GetAllBooksOrderByDescendingTitle();
    foreach (Book book in books)
    {
      Console.WriteLine(book);
    }
  }

  public void GetAllBooksByTitleContains(string text)
  {
    List<Book> books = bookRepository.GetAllBooksByTitleContains(text);
    foreach (Book book in books)
    {
      Console.WriteLine(book);
    }
  }

  public void GetAllBooksByPageSizeFilter(int min, int max)
  {
    List<Book> books = bookRepository.GetAllBooksByPageSizeFilter(min, max);
    foreach (Book book in books)
    {
      Console.WriteLine(book.Title);
    }
  }

  public void getBookByISBN(string isbn)
  {
    Book? book = bookRepository.GetBookByISBN(isbn);

    if (book == null)
    {
      Console.WriteLine("Aradığınız ISBN numarasına göre kitap bulunamadı.");
      return;
    }

    Console.WriteLine(book);
  }

  public void GetBookByMaxPageSize()
  {
    Book? book = bookRepository.GetBookByMaxPageSize();
    Console.WriteLine($"Maximum sayfa sayısına sahip kitap: {book?.Title}");
  }

  public void GetBookByMinPageSize()
  {
    Book? book = bookRepository.GetBookByMinPageSize();
    Console.WriteLine($"Minimum sayfa sayısına sahip kitap: {book?.Title}");
  }

  private void BookIdBusinessRules(Guid id)
  {
    Book? getByIdBook = bookRepository.GetById(id);
    if (getByIdBook != null)
    {
      Console.WriteLine("Girmiş olduğunuz kitabın Id alanı benzersiz olmalıdır.");
      return;
    }
  }

  private void BookISBNBusinessRules(string isbn)
  {
    Book? getBookByISBN = bookRepository.GetBookByISBN(isbn);
    if (getBookByISBN != null)
    {
      Console.WriteLine("ISBN alanı benzersiz olmalıdır.");
      return;
    }
  }
}
