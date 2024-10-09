namespace LibraryManagement.ConsoleUI.Models.Dtos
{
  public record BookDetailDto(Guid Id, string AuthorName, string CategoryName, string Title, string Description, int PageSize, string PublishDate, string ISBN);
}
