using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories;

public class CategoryRepository : ICategoryRepository
{
    public void AddCategory(Category category) => CategoryDAO.CreateCategory(category);

    public void DeleteCategory(Category category) => CategoryDAO.DeleteCategory(category);
    public List<Category> GetCategories() => CategoryDAO.GetCategories();

    public void UpdateCategory(Category category) => CategoryDAO.UpdateCategory(category);
    public Category GetCategoryById(int id) => CategoryDAO.GetCategoryNameById(id);
}