using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class KoiFishService : IKoiFishService
    {
        private readonly IKoiFishRepository iKoiFishRepository;
        public KoiFishService()
        {
            iKoiFishRepository = new KoiFishRepository();
        }

        public void DeleteKoiFish(KoiFish koiFish)
        {
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
            iKoiFishRepository.SaveKoi(koiFish);
        }

        public void UpdateKoiFish(KoiFish koiFish)
        {
            iKoiFishRepository.UpdateKoiFish(koiFish);
        }
    }
}
