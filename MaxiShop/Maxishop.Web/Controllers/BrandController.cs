using Maxishop.Application.ApplicationConstant;
using Maxishop.Application.Common;
using Maxishop.Application.DTO.Brand;
using Maxishop.Application.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Maxishop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        private readonly IBrandService _brandService;
        protected APIResponse _apiresponse;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
            _apiresponse = new APIResponse();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> Get()
        {
            try
            {
                var ResultObj = await _brandService.GetAllAsync();
                _apiresponse.Result = ResultObj;
                _apiresponse.StatusCode = HttpStatusCode.OK;
                _apiresponse.DisplayMessage = CommonMessage.CreateOperationSuccess;

            }
            catch (Exception objerr)
            {
                _apiresponse.AddError(errorMessage: CommonMessage.CreateOperationFailed);
                _apiresponse.StatusCode = HttpStatusCode.BadRequest;

            }
            return _apiresponse;
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<APIResponse>> GetByID(int ID)
        {
            try
            {
                var result = await _brandService.GetByIdAsync(ID);
                _apiresponse.Result = result;
                _apiresponse.StatusCode= HttpStatusCode.OK;
                _apiresponse.DisplayMessage= CommonMessage.UpdateOperationSuccess;
            }
            catch (Exception objerr)
            {
                _apiresponse.AddError(CommonMessage.SystemError);
                _apiresponse.StatusCode=HttpStatusCode.BadRequest;
            }
            return _apiresponse;
        }

        
        [HttpPost]
        public async Task<ActionResult<APIResponse>> Create([FromBody]CreateBrandDTO brandDTO)
        {
            try
            {
                var result = await _brandService.CreatedAsync(brandDTO);
                _apiresponse.Result = result;
                _apiresponse.StatusCode=HttpStatusCode.OK;
                _apiresponse.DisplayMessage = CommonMessage.CreateOperationSuccess;
            }
            catch (Exception objerr)
            {
                _apiresponse.AddError(CommonMessage.SystemError);
                _apiresponse.StatusCode=HttpStatusCode.BadRequest;
            }
            return _apiresponse;

        }
        [HttpPut]
        public async Task<ActionResult<APIResponse>> Update([FromBody] UpdateBrandDTO updateDTO)
        {
            try
            {
                await _brandService.UpdateAsync(updateDTO);
                _apiresponse.IsSuccess = true;
                _apiresponse.StatusCode = HttpStatusCode.OK;

            }
            catch (Exception objerr)
            {
                _apiresponse.AddError(CommonMessage.SystemError);
                _apiresponse.StatusCode = HttpStatusCode.BadRequest;

            }
            return _apiresponse;
        }

        [HttpDelete]
        public async Task<ActionResult<APIResponse>> Detele(int ID)
        {
            try
            {
                await _brandService.DeleteAsync(ID);
                _apiresponse.IsSuccess = true;
                _apiresponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception objerr)
            {
                _apiresponse.AddError(CommonMessage.SystemError);
                _apiresponse.StatusCode = HttpStatusCode.BadRequest;
            }
            return _apiresponse;
        }

    }
}
