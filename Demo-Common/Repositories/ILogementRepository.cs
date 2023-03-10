using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Common.Repositories
{
    public interface ILogementRepository<TEntity, TId> : IRepository<TEntity,TId> where TEntity : ILogement
    {
        IEnumerable<TEntity> GetBySpectacle(int idSpec);
        IEnumerable<TEntity> GetMyLogement(int id);

        IEnumerable<TEntity> GetLogementMonth(DateTime month);
        IEnumerable<TEntity> GetLogementTwoDate(DateTime date_deb, DateTime date_fin);




        IEnumerable<TEntity> GetByDate(DateTime date);
    }
}
