using Maxishop.Application.ApplicationConstant;
using Maxishop.Application.Common;
using Maxishop.Application.DTO.Category;
using Maxishop.Application.Service;
using Maxishop.Application.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Maxishop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        protected APIResponse _response;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _response = new APIResponse();
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> Create([FromBody] CreateCategoryDTO ObjCategory)
        {
            try
            {
                await _categoryService.CreateAsync(ObjCategory);
                _response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ObjErr)
            {
                _response.AddError(ObjErr.Message);
                _response.StatusCode=HttpStatusCode.InternalServerError;
            }
            return _response;

        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> Get()
        {
            try
            {
                var catogarylist = await _categoryService.GetAllAsync();
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.DisplayMessage = CommonMessage.RegistrationSuccess;
                _response.Result = catogarylist;
                
               
            }
            catch (Exception ObjErr)
            {
                _response.AddError(CommonMessage.SystemError);
                _response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return _response;
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<APIResponse>> Get(int ID)
        {
            try
            {
                var sSelectcat = await _categoryService.GetbyIDAsync(ID);
                if (sSelectcat == null)
                {
                    _response.AddError(CommonMessage.RecordNotFound);
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }
                _response.IsSuccess = true;
                _response.Result = sSelectcat;
                _response.StatusCode=HttpStatusCode.OK;
                return _response;
               
            }
            catch (Exception)
            {
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;

        }

        [HttpPut]
        public async Task<ActionResult<APIResponse>> update([FromBody] UpdateCategoryDTO ObjCategory)
        {
            try
            {
                await _categoryService.UpdateAsync(ObjCategory);
                _response.IsSuccess=true;
                _response.StatusCode=HttpStatusCode.OK;
                _response.DisplayMessage = CommonMessage.UpdateOperationSuccess;
            }
            catch (Exception)
            {
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
        }
        [HttpDelete]
        public async Task<ActionResult<APIResponse>> Delete(int ID)
        {
            try
            {
                if (ID == 0)
                {
                    _response.AddError(CommonMessage.RecordNotFound);
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                var filterdata = await _categoryService.GetbyIDAsync(ID);

                if (filterdata == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.RecordNotFound;
                }
                _response.DisplayMessage = CommonMessage.DeleteOperationSuccess;

            }
            catch (Exception)
            {
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
        }


    }
}
