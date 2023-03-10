using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Common.Repositories
{
    public interface IReservationRepository<TEntity, TId> : IRepository<TEntity, TId>        where TEntity : IReservation
    {
        IEnumerable<TEntity> GetMyReservation(int id);
        IEnumerable<TEntity> GetReservationLogement(int id);



        

    }
}
