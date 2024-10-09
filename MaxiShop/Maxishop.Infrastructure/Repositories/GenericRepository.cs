using Maxishop.Domain.Contracts;
using Maxishop.Domain.Model.Common;
using Maxishop.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseModel
    {

        protected readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<T> CreateAsync(T entity)
        {
            var objentity = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return objentity.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetbyIDAsync(Expression<Func<T, bool>> condition)
        {
            var objentity = await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(condition);
            return objentity;
        }
    }
}
