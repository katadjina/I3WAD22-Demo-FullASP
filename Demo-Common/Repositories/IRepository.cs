using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Common.Repositories
{
    public interface IRepository<TEntity, TId> : 
            IGetRepository<TEntity, TId>,
            IInsertRepository<TEntity,TId>, 
            IUpdateRepository<TEntity,TId>,
            IDeleteRepository<TEntity,TId>
    {
    }
}
