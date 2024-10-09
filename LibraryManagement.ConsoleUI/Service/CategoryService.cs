using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Repository.Concrete;

namespace LibraryManagement.ConsoleUI.Service;

public class CategoryService
{
  CategoryRepository categoryRepository = new CategoryRepository();

  public void GetAllCategories()
  {
    List<Category> categories = categoryRepository.GetAll();

    foreach (Category category in categories)
    {
      Console.WriteLine(category);
    }
  }

  public void GetById(int id)
  {
    Category? category = categoryRepository.GetById(id);

    if (category == null)
    {
      Console.WriteLine("Aradığınız id'ye göre kategori bulunamadı.");
      return;
    }

    Console.WriteLine(category);
  }

  public void Add(Category category)
  {
    Category createdCategory = categoryRepository.Add(category);
    Console.WriteLine("Kategori eklendi.");
    Console.WriteLine(createdCategory);
  }

  public void Remove(int id)
  {
    Category? deletedCategory = categoryRepository.Remove(id);

    if (deletedCategory == null)
    {
      Console.WriteLine("Silmek istediğiniz kategori silinemedi çünkü zaten yok.");
      return;
    }

    Console.WriteLine("Kategori silindi.");
    Console.WriteLine(deletedCategory);
  }
}
