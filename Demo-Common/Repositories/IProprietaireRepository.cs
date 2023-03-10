using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Common.Repositories
{
    public interface IProprietaireRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity: IProprietaire
    {
    }
}
