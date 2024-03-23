using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookShopping.DataAccess.Data;
using BookShopping.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookShopping.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbcontext;
        internal DbSet<T> dbset;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
            this.dbset = dbContext.Set<T>();
            // Above line same as _dbcontext.Categories == this.dbset
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> queryable = dbset;
            queryable = queryable.Where(filter);
            return queryable.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbset;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbset.RemoveRange(entity);
        }
    }
}
