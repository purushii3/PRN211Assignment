﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IKoiFishRepository
    {
        List<KoiFish> GetAllKoi();
        KoiFish GetKoiFishById(int id);
        void DeleteKoiFish(KoiFish koiFish);
        void UpdateKoiFish(KoiFish koiFish);
        void SaveKoi(KoiFish koiFish);

    }
}