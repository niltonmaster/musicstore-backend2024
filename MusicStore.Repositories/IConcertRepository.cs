﻿using MusicStore.Entities;
using MusicStore.Entities.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repositories
{
    public interface IConcertRepository: IRepositoryBase<Concert>
    {
         Task<ICollection<ConcertInfo>> GetAsync(string? title);
        Task  FinalizeAsync(int id);


        //test nilton eliminar
        Task DeleteAsync2(int id);

    }
}
