using BusinessObjects.Models;

namespace DataAccessLayer;

public class CategoryDAO
{
    public static List<Category> GetCategories()
    {
        List<Category> koiCategories;

        try
        {
            using var db = new KoiFishContext();
            koiCategories = db.Categories.ToList();
        }
        catch (Exception e) { throw new Exception(e.Message); }
        
        
        return koiCategories;
    }
    //create 
    public static void CreateCategory(Category category)
    {
        using var db = new KoiFishContext();
        db.Categories.Add(category);
        db.SaveChanges();
    }
    //delete
    public static void DeleteCategory(Category category)
    {
        using var db = new KoiFishContext();
        db.Categories.Remove(category);
        db.SaveChanges();
    }
    //update
    public static void UpdateCategory(Category category)
    {
        using var db = new KoiFishContext();
        db.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        db.SaveChanges();
    }
}