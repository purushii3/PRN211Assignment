using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class KoiFishRepository : IKoiFishRepository
    {
        public void DeleteKoiFish(KoiFish koiFish)
        {
            if (koiFish == null)
            {
                throw new ArgumentNullException(nameof(koiFish),"Koi can't be null!");
            }
            KoiFishDAO.DeleteKoiFish(koiFish);
        }
        public List<KoiFish> GetAllKoi() => KoiFishDAO.GetAllKoi();
        public KoiFish GetKoiFishById(int id) => KoiFishDAO.GetKoiFishById(id);
        public void SaveKoi(KoiFish koiFish)
        {
            if (koiFish == null)
            {
                throw new ArgumentNullException(nameof(koiFish), "Koi can't be null!");
            }
            KoiFishDAO.SaveKoi(koiFish);
        }
        public void UpdateKoiFish(KoiFish koiFish)
        {
            if (koiFish == null)
            {
                throw new ArgumentNullException(nameof(koiFish),"Koi can't be null!");
            }
            KoiFishDAO.UpdateKoiFish(koiFish);
        }

        public List<KoiFish> SortedDesc() =>KoiFishDAO.SortedDesc();
        public List<KoiFish> SortedAsc() =>KoiFishDAO.SortedAsc();
        public List<KoiFish> FindByCategory(string CategoryName) => KoiFishDAO.FindByCategory(CategoryName);
        public List<KoiFish> FindByName(string name) => KoiFishDAO.SearchByKoiName(name);
        
    }
}
