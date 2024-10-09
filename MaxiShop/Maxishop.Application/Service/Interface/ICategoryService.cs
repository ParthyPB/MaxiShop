using Maxishop.Application.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Application.Service.Interface
{
    public interface ICategoryService
    {
        Task<CreateCategoryDTO> GetbyIDAsync(int id);

        Task<IEnumerable<CategoryDTO>> GetAllAsync();

        Task<CategoryDTO> CreateAsync(CreateCategoryDTO categoryDTO);

        Task UpdateAsync(UpdateCategoryDTO _updateCAtegoryDTO);

        Task DeleteAsync(int id);
    }
}
