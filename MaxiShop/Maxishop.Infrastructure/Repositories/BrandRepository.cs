using Maxishop.Domain.Contracts;
using Maxishop.Domain.Model;
using Maxishop.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Infrastructure.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IProductRepository
    {
        public BrandRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        
        }
        public async Task UpdateAsync(Brand objBrand)
        {
            _dbContext.Update(objBrand);
           await _dbContext.SaveChangesAsync();

        }

    }
}
