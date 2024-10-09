namespace LibraryManagement.ConsoleUI.Models;

public class Member : Entity<string>
{
  public Member()
  {
        
  }
  public Member(string id, string name, string surname, int age) : base(id)
  {
    Name = name;
    Surname = surname;
    Age = age;
  }
  public string Name { get; set; } = string.Empty;
  public string Surname { get; set; } = string.Empty;
  public int Age { get; set; }

  public override string ToString()
  {
    return $"Id: {Id}, Name: {Name}, Surname: {Surname}, Age: {Age}";
  }
}