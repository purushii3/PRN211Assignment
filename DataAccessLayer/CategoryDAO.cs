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
}