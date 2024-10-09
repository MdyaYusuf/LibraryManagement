using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Repository.Concrete;

namespace LibraryManagement.ConsoleUI.Service;

public class AuthorService
{
  AuthorRepository authorRepository = new AuthorRepository();

  public void GetAllAuthors()
  {
    List<Author> authors = authorRepository.GetAll();

    foreach (Author author in authors)
    {
      Console.WriteLine(author);
    }
  }

  public void GetById(int id)
  {
    Author? author = authorRepository.GetById(id);

    if (author == null)
    {
      Console.WriteLine("Aradığınız yazar bulunamadı.");
    }
    else
    {
      Console.WriteLine(author);
    }
  }

  public void Add(Author author)
  {
    Author createdAuthor = authorRepository.Add(author);
    Console.WriteLine("Yazar eklendi.");
    Console.WriteLine(createdAuthor);
  }

  public void Remove(int id)
  {
    Author? removedAuthor = authorRepository.Remove(id);

    if (removedAuthor == null)
    {
      Console.WriteLine("Silmek istediğiniz yazar silinemedi çünkü zaten yok.");
      return;
    }
    else
    {
      Console.WriteLine("Yazar silindi.");
      Console.WriteLine(removedAuthor);
    }
  }
}
