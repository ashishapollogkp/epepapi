using EPEPITIAPI.Interfaces;
using EPEPITIAPI.Models;
using EPEPITIAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            _response = new();
        }

        [HttpGet]
        [Route("GetRequestStatusList")]
        public async Task<ActionResult<APIResponse>> GetRequestStatusList()
        {
            try
            {


                _response = await _service.GetRequestStatusList();
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;


        }
    }
}
