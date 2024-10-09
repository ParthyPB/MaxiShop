using Maxishop.Application.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maxishop.Domain.Contracts;
using AutoMapper;
using Maxishop.Application.DTO.Brand;
using Maxishop.Domain.Model;

namespace Maxishop.Application.Service
{
    public class BrandService :IBrandService
    {
        readonly IProductRepository _iBrandRepository;
        readonly IMapper _mappingProfile;

        public BrandService(IProductRepository brandRepository, IMapper mappingProfile)
        {
            _iBrandRepository = brandRepository;    
            _mappingProfile = mappingProfile;
        }

        public async Task<BrandDTO> CreatedAsync(CreateBrandDTO brand)
        {
            var ObjBrand = _mappingProfile.Map<Brand>(brand);
            await _iBrandRepository.CreateAsync(ObjBrand);

            var entity = _mappingProfile.Map<BrandDTO>(ObjBrand);
            return entity;
        }

        public async Task<IEnumerable<BrandDTO>> GetAllAsync()
        {
            var ObjBrand= await _iBrandRepository.GetAllAsync();
            var ObjeBrandDTO = _mappingProfile.Map<IEnumerable<BrandDTO>>(ObjBrand);
            return ObjeBrandDTO;
        }

        public async Task<BrandDTO> GetByIdAsync(int ID)
        {
            var ObjBrand = await _iBrandRepository.GetbyIDAsync(x=>x.ID==ID);
            var ObjBrandDTO = _mappingProfile.Map<BrandDTO>(ObjBrand);
            return ObjBrandDTO;
        }

        public async Task DeleteAsync(int ID)
        {
            var filterBrand = await _iBrandRepository.GetbyIDAsync(X=>X.ID==ID);
             await _iBrandRepository.DeleteAsync(filterBrand);
        }

        public async Task UpdateAsync (UpdateBrandDTO objUpdateBrandDTO)
        {
            var objbrand = _mappingProfile.Map<Brand>(objUpdateBrandDTO);
            await _iBrandRepository.UpdateAsync(objbrand);

        }

    }
}
