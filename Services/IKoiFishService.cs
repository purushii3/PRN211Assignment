using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IKoiFishService
    {
        List<KoiFish> GetAllKoi();
        KoiFish GetKoiFishById(int id);
        void DeleteKoiFish(KoiFish koiFish);
        void UpdateKoiFish(KoiFish koiFish);
        void SaveKoi(KoiFish koiFish);
        List<KoiFish> SortedDesc();
        List<KoiFish> SortedAsc();
        List<KoiFish> FindByCategory(string categoryName);
        List<KoiFish> FindByName(string name);
    }
}
