using Commentifier.Models;
using Commentifier.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commentifier.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntityBase, new()
    {
        protected CommentifierContext _context;

        public BaseRepository(CommentifierContext context)
        {
            _context = context;
        }
        
        public virtual void Add(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
    }
}
