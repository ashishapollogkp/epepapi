using EPEPITIAPI.Interfaces;
using EPEPITIAPI.Models;
using EPEPITIAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EPEPITIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private readonly IShared _service;
        protected APIResponse _response;
        public SharedController(IShared Service)
        {
            _service = Service;
          
        }

        //[HttpGet]
        //[Route("GetRequestStatusList")]
        //public async Task<IActionResult> GetRequestStatusList()
        //{
        //    _response = new APIResponse();
        //    try
        //    {
        //        //_response = await _service.GetRequestStatusList();
        //        //return Ok(_response);
        //        _response.Result = await _service.GetRequestStatusList(); 
        //        _response.StatusCode = HttpStatusCode.OK;
        //        _response.IsSuccess = true;

        //    }
        //    catch (Exception ex)
        //    {
        //        _response.Result = null;
        //        _response.StatusCode = HttpStatusCode.InternalServerError;
        //        _response.IsSuccess = true;
        //        _response.ActionResponse = "An error occurred while updating the training center status.";
        //    }

        //    return _response;
          


        //}



        [HttpGet]
        [Route("GetRequestStatusList")]
        public async Task<IActionResult> GetRequestStatusList()
        {
            try
            {
                var response = await _service.GetRequestStatusList();

                if (response.StatusCode == HttpStatusCode.OK && response.IsSuccess)
                    return Ok(response);

                if (response.StatusCode == HttpStatusCode.NoContent)
                    return NoContent();

                return StatusCode((int)response.StatusCode, response);
            }
            catch (Exception ex)
            {
                var errorResponse = new APIResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    ActionResponse = "An unexpected error occurred.",
                    Result = ex.Message
                };

                return StatusCode(500, errorResponse);
            }
        }

    }
}
