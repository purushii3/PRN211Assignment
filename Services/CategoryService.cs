using BusinessObjects.Models;
using Repositories;

namespace Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService()
    {
        _categoryRepository = new CategoryRepository();
    }

    public void CreateCategories(Category category) => _categoryRepository.AddCategory(category);

    public void DeleteCategories(Category category) => _categoryRepository.DeleteCategory(category);

    public List<Category> GetCategories() => _categoryRepository.GetCategories();

    public void UpdateCategories(Category category) => _categoryRepository.UpdateCategory(category);    
}