using Maxishop.Application.DTO.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Application.Service.Interface
{
    public interface IBrandService
    {
        Task<BrandDTO> CreatedAsync(CreateBrandDTO brand);

        Task<IEnumerable<BrandDTO>> GetAllAsync();

        Task<BrandDTO> GetByIdAsync(int id);

        Task UpdateAsync(UpdateBrandDTO objUpdateBrandDTO);

        Task DeleteAsync(int id);
    }
}
