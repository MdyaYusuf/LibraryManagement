using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Models.Dtos;
using LibraryManagement.ConsoleUI.Repository.Abstract;

namespace LibraryManagement.ConsoleUI.Repository.Concrete;

public class BookRepository : BaseRepository, IBookRepository
{
  // Dependency injection ilk adım
  private List<Book> books;
  private List<Category> categories;
  private List<Author> authors;

  public BookRepository()
  {
    books = Books(); // books = base.Books()
    categories = Categories();
    authors = Authors();
  }

  public List<Book> GetAll()
  {
    return books;
  }

  public Book? GetById(Guid id)
  {
    Book? book = books.FirstOrDefault(b => b.Id == id);
    return book;
  }

  public Book Add(Book createdBook)
  {
    books.Add(createdBook);
    return createdBook;
  }

  public Book? Remove(Guid id)
  {
    Book? deletedBook = GetById(id);

    if (deletedBook == null)
    {
      return null;
    }
    else
    {
      books.Remove(deletedBook);
      return deletedBook;
    }
  }

  // İkiden fazla tablo için bu yöntem kullanılır.
  public List<BookDetailDto> GetDetails()
  {
    var result = from b in books
                  join c in categories on b.CategoryId equals c.Id
                  select new BookDetailDto(Id: b.Id, "", CategoryName: c.Name, Title: b.Title, Description: b.Description, PageSize: b.PageSize, PublishDate: b.PublishDate, ISBN: b.ISBN);

    return result.ToList();
  }

  // Database kullanmadan memory üzerinde iki koleksiyon birleştirilirken bu kullanılmalı. Yukarıdaki daha eski bir yöntem.
  public List<BookDetailDto> GetDetailsSecondary()
  {
    List<BookDetailDto> details = books.Join(categories, b => b.CategoryId, c => c.Id, (book, category) => new BookDetailDto(Id: book.Id, "", CategoryName: category.Name, Title: book.Title, Description: book.Description, PageSize: book.PageSize, PublishDate: book.PublishDate, ISBN: book.ISBN)).ToList();
    return details;
  }

  public List<BookDetailDto> GetAllAuthorAndBookDetails()
  {
    var result = from b in books
                  join c in categories on b.CategoryId equals c.Id
                  join a in authors on b.AuthorId equals a.Id

                  select new BookDetailDto(Id: b.Id, AuthorName: $"{a.Name} {a.Surname}", CategoryName: c.Name, Title: b.Title, Description: b.Description, PageSize: b.PageSize, PublishDate: b.PublishDate, ISBN: b.ISBN);

    return result.ToList();
  }

  public List<BookDetailDto> GetAllDetailsByCategoryId(int categoryId)
  {
    var result = from b in books
                  where b.CategoryId == categoryId
                  join c in categories on b.CategoryId equals c.Id
                  join a in authors on b.AuthorId equals a.Id

                  select new BookDetailDto(Id: b.Id, AuthorName: $"{a.Name} {a.Surname}", CategoryName: c.Name, Title: b.Title, Description: b.Description, PageSize: b.PageSize, PublishDate: b.PublishDate, ISBN: b.ISBN);

    return result.ToList();
  }

  public List<Book> GetAllBooksOrderByTitle()
  {
    List<Book> orderedBooks = books.OrderBy(b => b.Title).ToList();
    return orderedBooks;
  }

  public List<Book> GetAllBooksOrderByDescendingTitle()
  {
    List<Book> orderedBooks = books.OrderByDescending(b => b.Title).ToList();
    return orderedBooks;
  }

  public List<Book> GetAllBooksByTitleContains(string text)
  {

    List<Book> booksByTitle = books.FindAll(b => b.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase));
    return booksByTitle;

    /* 

    // Yöntem 2

    List<Book> booksByTitle = books.Where(b => b.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase)).ToList();
    return booksByTitle; 

    */

    /* 

    // Yöntem 3

    List<Book> booksFilteredByTitle = new List<Book>();

    foreach (Book book in books)
    {
      if (book.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase))
      {
        booksFilteredByTitle.Add(book);
      }
    }
    return booksFilteredByTitle;

    */
  }

  public List<string> GetAllBookTitles()
  {
    var bookTitles = books.Select(book => book.Title).ToList();
    return bookTitles;
  }

  // Language Integrated Query
  public List<Book> GetAllBooksByPageSizeFilter(int min, int max)
  {
    // Kesin olarak sadece liste istiyorsak daha performanslıdır.
    List<Book> result = books.FindAll(b => b.PageSize <= max && b.PageSize >= min);
    return result;

    /* Where'den sonra tekil dönüştürme işlemleri yapılabilmesi artısıdır.

    List<Book> result = books.Where(b => b.PageSize <= max && b.PageSize >= min).ToList();
    return result;

    */

    /* Eski Tip Linq

    List<Book> result = (from b in books where b.PageSize <= max && b.PageSize >= min select b).ToList();

    return result;

    */

    /* Geleneksel Yöntem

    List<Book> filteredBooks = new List<Book>();

    foreach (Book book in books)
    {
      if (book.PageSize <= max && book.PageSize >= min)
      {
        filteredBooks.Add(book);
      }
    }
    return filteredBooks;

    */
  }

  public Book? GetBookByISBN(string isbn)
  {
    Book? book = books.SingleOrDefault(b => b.ISBN == isbn);
    return book;

    /* 

    // Yöntem 2

    Book? book = books.Where(b => b.ISBN == isbn).FirstOrDefault();
    return book;

    */

    /* 

    // Yöntem 3

    Book? book = (from b in books where b.ISBN == isbn select b).FirstOrDefault();
    return book;

    */

    /* 

    // Yöntem 4

    Book? book1 = null;

    foreach (Book item in books)
    {
      if (item.ISBN == isbn)
      {
        book1 = item;
      }
    }

    if (book1 == null)
    {
      return null;
    }

    return book1;

    */
  }

  public Book? GetBookByMaxPageSize()
  {
    Book? book = books.OrderBy(b => b.PageSize).LastOrDefault();
    return book;

    /*

    var orderedBooks = books.OrderByDescending(b => b.PageSize).ToList();
    Book MaxPageSizeBook = orderedBooks[0];
    return MaxPageSizeBook;

    */
  }

  public Book? GetBookByMinPageSize()
  {
    Book? book = books.OrderByDescending(b => b.PageSize).LastOrDefault();
    return book;

    /*

    var orderedBooks = books.OrderBy(b => b.PageSize).ToList();
    Book MinPageSizeBook = orderedBooks[0];
    return MinPageSizeBook;

    */
  }

  public double PageSizeTotalCalculator()
  {
    double total = books.Sum(b => b.PageSize);
    return total;
  }
}
