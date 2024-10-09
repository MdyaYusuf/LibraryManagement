namespace LibraryManagement.ConsoleUI.Models;

public class Book : Entity<Guid>
{
  public Book()
  {
        
  }
  public Book(Guid id, int categoryId, int authorId, string title, string description, int pageSize, string publishDate, string ıSBN) : base(id)
  {
    CategoryId = categoryId;
    AuthorId = authorId;
    Title = title;
    Description = description;
    PageSize = pageSize;
    PublishDate = publishDate;
    ISBN = ıSBN;
  }

  public int CategoryId { get; set; }
  public int AuthorId { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public int PageSize { get; set; }
  public string PublishDate { get; set; } = string.Empty;
  public string ISBN { get; set; } = string.Empty;

  public override string ToString()
  {
    return $"Id: {Id}, CategoryId: {CategoryId}, AuthorId: {AuthorId}, Title: {Title}, Description: {Description}, PageSize: {PageSize}, PublisDate: {PublishDate}, ISBN: {ISBN}";
  }
}
