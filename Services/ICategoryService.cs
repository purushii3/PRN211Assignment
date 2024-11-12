using BusinessObjects.Models;

namespace Services;

public interface ICategoryService
{
    List<Category> GetCategories();
    void CreateCategories(Category category);
    void UpdateCategories(Category category);
    void DeleteCategories(Category category);
}