using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class KoiFishService : IKoiFishService
    {
        private readonly IKoiFishRepository iKoiFishRepository;
        public KoiFishService()
        {
            iKoiFishRepository = new KoiFishRepository();
        }

        public void DeleteKoiFish(KoiFish koiFish)
        {
            if (koiFish == null)
            {
                throw new ArgumentNullException(nameof(koiFish), "Koi can't be null!");
            }
            iKoiFishRepository.DeleteKoiFish(koiFish);
        }

        public List<KoiFish> GetAllKoi()
        {
             return iKoiFishRepository.GetAllKoi();
        }

        public KoiFish GetKoiFishById(int id)
        {
            return iKoiFishRepository.GetKoiFishById(id);
        }

        public void SaveKoi(KoiFish koiFish)
        {
            if (koiFish == null)
            {
                throw new ArgumentNullException(nameof(koiFish), "Koi can't be null!");
            }
            iKoiFishRepository.SaveKoi(koiFish);
        }

        public void UpdateKoiFish(KoiFish koiFish)
        {
            if (koiFish == null)
            {
                throw new ArgumentNullException(nameof(koiFish), "Koi can't be null!");
            }
            iKoiFishRepository.UpdateKoiFish(koiFish);
        }
        public List<KoiFish> SortedDesc()
        {
            return iKoiFishRepository.SortedDesc();
        }
        public List<KoiFish> SortedAsc()
        {
            return iKoiFishRepository.SortedAsc();
        }

        public List<KoiFish> FindByCategory(int categoryId)
        {
            return iKoiFishRepository.FindByCategory(categoryId);
        }
    }
}
