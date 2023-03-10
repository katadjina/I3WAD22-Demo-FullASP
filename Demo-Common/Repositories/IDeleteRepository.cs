using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Common.Repositories
{
    public interface IDeleteRepository<TEntity,TId>
    {
        bool Delete(TId id);
    }
}
