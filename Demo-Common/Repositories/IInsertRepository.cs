using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Common.Repositories
{
    public interface IInsertRepository<TEntity, TId>
    {
        TId Insert(TEntity entity);
    }
}
