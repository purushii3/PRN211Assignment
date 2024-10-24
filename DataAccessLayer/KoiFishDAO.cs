using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                koiList = context.KoiFishes.ToList();
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
            if(koiFish == null)
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
                context.KoiFishes.Remove(koi);
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
            using var context = new KoiFishContext();
            return context.KoiFishes.FirstOrDefault(k => k.KoiFishId.Equals(id));
        }

    }
}
