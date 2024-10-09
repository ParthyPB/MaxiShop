using AutoMapper;
using Maxishop.Application.Common;
using Maxishop.Application.DTO.Category;
using Maxishop.Application.Service.Interface;
using Maxishop.Domain.Model;
using Maxishop.Domain.Contracts;
using Maxishop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Application.Service
{
    public class CategoryService : ICategoryService
    {
        readonly public ICategoryRepository _categoryRepository;
        readonly public IMapper _mappingProfile;
        public CategoryService(CategoryRepository categoryRepository, IMapper mappingProfile) 
        { 
          _categoryRepository = categoryRepository;
          _mappingProfile = mappingProfile;


        }
        public async Task<CategoryDTO> CreateAsync(CreateCategoryDTO categoryDTO)
        {
            var objCategory = _mappingProfile.Map<Category>(categoryDTO);
            await _categoryRepository.CreateAsync(objCategory);

            var entity = _mappingProfile.Map<CategoryDTO>(objCategory);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
           var filter = await _categoryRepository.GetbyIDAsync(X=>X.ID== id);
           await _categoryRepository.DeleteAsync(filter);

        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var Categorylist = await _categoryRepository.GetAllAsync();
            var CategoryDTOList = _mappingProfile.Map<IEnumerable<CategoryDTO>>(Categorylist);
            return CategoryDTOList;
            
        }

        public async Task<CreateCategoryDTO> GetbyIDAsync(int id)
        {
            var filterCategory= await _categoryRepository.GetbyIDAsync(x=>x.ID== id);
            return _mappingProfile.Map<CreateCategoryDTO>(filterCategory);
        }

        public async Task UpdateAsync(UpdateCategoryDTO _updateCAtegoryDTO)
        {
            var category = _mappingProfile.Map<Category>(_updateCAtegoryDTO);
            await _categoryRepository.UpdateAsync(category);
            
        }
    }
}
