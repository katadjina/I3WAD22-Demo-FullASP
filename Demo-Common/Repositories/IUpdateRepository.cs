using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Common.Repositories
{
    public interface IUpdateRepository<TEntity, TId>
    {
        bool Update(TId id, TEntity entity);
    }
}
