using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class KoiFishDAO
    {
        //get koi
        public static List<KoiFish> GetAllKoi()
        {
            var koiList = new List<KoiFish>();
            try
            {
                using var context = new KoiFishContext();
                koiList = context.KoiFishes
                .Include(k => k.Category)
                .Where(k => k.Status == true)
                .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return koiList;
        }
        //create koi
        public static void SaveKoi(KoiFish koiFish)
        {
            if (koiFish == null)
            {
                throw new ArgumentNullException(nameof(koiFish), "Koi can't be null!");
            }
            try
            {
                using var context = new KoiFishContext();
                context.KoiFishes.Add(koiFish);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Update koi
        public static void UpdateKoiFish(KoiFish koiFish)
        {
            try
            {
                using var context = new KoiFishContext();
                context.Entry<KoiFish>(koiFish).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Delete koi

        public static void DeleteKoiFish(KoiFish koiFish)
        {
            try
            {
                using var context = new KoiFishContext();
                var koi = context.KoiFishes.SingleOrDefault(k => k.KoiFishId == koiFish.KoiFishId);
                if (koi != null)
                    koi.Status = false;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Get koi by id
        public static KoiFish GetKoiFishById(int id)
        {
            try
            {
                using var context = new KoiFishContext();
                return context.KoiFishes.FirstOrDefault(k => k.KoiFishId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Koi does not exist!!"+ ex.Message);
            }

        }
        //sort by price Desc
        public static List<KoiFish> SortedDesc()
        {
            using var context = new KoiFishContext();

            var sortedKoiList = context.KoiFishes.Where(k => k.Status == true).OrderByDescending(k => k.KoiFishPrice).ToList();
            return sortedKoiList;
        }
        //sort by price Asc
        public  static List<KoiFish> SortedAsc()
        {
            using var context = new KoiFishContext();
            var sortedKoiList = context.KoiFishes.Where(k => k.Status == true).OrderBy(k =>  k.KoiFishPrice).ToList();
            return sortedKoiList;
        }
        //find by Category
        public static List<KoiFish> FindByCategory(int CategoryId)
        {
            try
            {
                using var context = new KoiFishContext();
                var koiList = context.KoiFishes.Where(k => k.CategoryId == CategoryId).ToList();
                return koiList;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Koi" +ex.Message);
            }
        }
    }
}
