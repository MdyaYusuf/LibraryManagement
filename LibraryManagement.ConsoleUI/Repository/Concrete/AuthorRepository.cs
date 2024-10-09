using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Repository.Abstract;

namespace LibraryManagement.ConsoleUI.Repository.Concrete;

public class AuthorRepository : BaseRepository, IAuthorRepository
{
  private List<Author> authors;

  public AuthorRepository()
  {
    authors = Authors();
  }

  public List<Author> GetAll()
  {
    return authors;
  }

  public Author? GetById(int id)
  {
    Author? author = authors.FirstOrDefault(a => a.Id == id);
    return author;
  }

  public Author Add(Author createdAuthor)
  {
    authors.Add(createdAuthor);
    return createdAuthor;
  }

  public Author? Remove(int id)
  {
    Author? removedAuthor = GetById(id);

    if (removedAuthor != null)
    {
      authors.Remove(removedAuthor);
      return removedAuthor;
    }
    return null;
  }
}
