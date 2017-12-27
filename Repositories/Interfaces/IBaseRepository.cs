using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commentifier.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class, IEntityBase, new()
    {
        void Add(T entity);
    }
}
