namespace LibraryManagement.ConsoleUI.Models;

public sealed class Author : Entity<int>
{
  public Author()
  {
        
  }

  public Author(int id, string name, string surname) : base(id)
  {
    Name = name;
    Surname = surname;
  }

  public string Name { get; set; } = string.Empty;
  public string Surname { get; set; } = string.Empty;

  public override string ToString()
  {
    return $"Id: {Id}, Name: {Name}, Surname: {Surname}";
  }
}

