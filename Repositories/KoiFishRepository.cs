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
        public void DeleteKoiFish(KoiFish koiFish) => KoiFishDAO.DeleteKoiFish(koiFish);
        public List<KoiFish> GetAllKoi() => KoiFishDAO.GetAllKoi();
        public KoiFish GetKoiFishById(int id) => KoiFishDAO.GetKoiFishById(id);
        public void SaveKoi(KoiFish koiFish) => KoiFishDAO.SaveKoi(koiFish);
        public void UpdateKoiFish(KoiFish koiFish) => KoiFishDAO.UpdateKoiFish(koiFish);
        public List<KoiFish> SortedDesc() =>KoiFishDAO.SortedDesc();
        public List<KoiFish> SortedAsc() =>KoiFishDAO.SortedAsc();
        public List<KoiFish> FindByCategory(int CategoryId) => KoiFishDAO.FindByCategory(CategoryId);
    }
}
