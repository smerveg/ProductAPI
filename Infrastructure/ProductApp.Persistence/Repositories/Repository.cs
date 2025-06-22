using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductApp.Application.Repositories;
using ProductApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProductApp.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ProductContext _context;

        public Repository(ProductContext context)
        {
            _context = context; 
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> Add(T entity)
        {
            EntityEntry<T> entry = await Table.AddAsync(entity);
            return entry.State== EntityState.Added;
        }

        public async Task<bool> Delete(int id)
        {
            var record =await GetById(id);
            EntityEntry<T> entry =  Table.Remove(record);
            return entry.State== EntityState.Deleted;
        }

        public IQueryable<T> GetAll(Expression<Func<T,bool>>? pre=null,string? inc=null)
        {
            if (inc != null)
            {
                var query=Table.Include(inc);

                if(pre!=null)
                {
                    return query.Where(pre).AsQueryable();
                }

                return query;
            }
            else
            {
                if (pre != null)
                {
                    return Table.Where(pre).AsQueryable();
                }

                return Table.AsQueryable();
            }

        }

        public async Task<T> GetById(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> GetWhere(Expression<Func<T, bool>> pre, string? inc=null)
        {
            return await Table.Where(pre).Include(inc).FirstOrDefaultAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool Update(T entity)
        {
            EntityEntry<T> entry =  Table.Update(entity);
            return entry.State== EntityState.Modified;
        }
    }
}
