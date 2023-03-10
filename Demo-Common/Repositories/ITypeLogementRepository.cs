using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Common.Repositories
{
    public interface ITypeLogementRepository<TEntity,TId> : IGetRepository<TEntity,TId> where TEntity : ITypeLogement
    {
    }
}
