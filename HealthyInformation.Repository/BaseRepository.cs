using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected DbContext _context;
        DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public void Update(TEntity tEntity)
        {
            this._dbSet.Attach(tEntity);
            this._context.Entry(tEntity).State = EntityState.Modified;
        }

        public void Remove(TEntity tEntity)
        {
            if (_context.Entry(tEntity).State == EntityState.Detached)
            {
                _dbSet.Attach(tEntity);
            }
            _dbSet.Remove(tEntity);
        }

        public void Create(TEntity tEntity)
        {
            _dbSet.Add(tEntity);
        }
    }
}
