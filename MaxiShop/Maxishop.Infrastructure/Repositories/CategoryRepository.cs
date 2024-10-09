using Maxishop.Domain.Contracts;
using Maxishop.Domain.Model;
using Maxishop.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public async Task UpdateAsync(Category objcategory)
        {
            _dbContext.Update(objcategory);
            await _dbContext.SaveChangesAsync();

        }
    }
}
