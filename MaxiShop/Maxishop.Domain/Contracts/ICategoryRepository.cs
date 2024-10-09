using Maxishop.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Domain.Contracts
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task UpdateAsync(Category objcategory);

    }
}
