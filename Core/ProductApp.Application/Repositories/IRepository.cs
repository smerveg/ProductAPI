using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table {  get; }
        IQueryable<T> GetAll(Expression<Func<T, bool>>? pre=null,string? inc=null);
        Task<T> GetById(int id);
        Task<T> GetWhere(Expression<Func<T, bool>> pre, string? inc);
        Task<bool> Add(T entity);
        bool Update(T entity);
        Task<bool> Delete(int id);
        Task<int> SaveAsync();

    }
}
