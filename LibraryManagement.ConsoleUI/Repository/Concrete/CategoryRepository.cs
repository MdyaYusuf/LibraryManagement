using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Repository.Abstract;

namespace LibraryManagement.ConsoleUI.Repository.Concrete;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
  private List<Category> categories;

  public CategoryRepository()
  {
    categories = Categories();
  }

  public List<Category> GetAll()
  {
    return categories;
  }

  public Category? GetById(int id)
  {
    Category? category = categories.Find(c => c.Id == id);
    return category;
  }

  public Category Add(Category category)
  {
    categories.Add(category);
    return category;
  }

  public Category? Remove(int id)
  {
    Category? removedCategory = GetById(id);

    if (removedCategory != null)
    {
      categories.Remove(removedCategory);
      return removedCategory;
    }
    return null;
  }
}
