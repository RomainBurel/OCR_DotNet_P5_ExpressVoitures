using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return this._dbSet.ToList();
        }

        public T GetById(int id)
        {
            return this._dbSet.Find(id);
        }

        public void Add(T entity)
        {
            this._dbSet.Add(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this._dbSet.Where(expression);
        }

        public void Remove(T entity)
        {
            this._dbSet.Remove(entity);
        }

        void IGenericRepository<T>.SaveChanges()
        {
            this._context.SaveChanges();
        }

        void IGenericRepository<T>.Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
