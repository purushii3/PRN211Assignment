using BusinessObjects.Models;

namespace Repositories;

public interface ICategoryRepository
{
    List<Category> GetCategories();
    void AddCategory(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(Category category);
}