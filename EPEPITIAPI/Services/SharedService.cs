using EPEPITIAPI.Data;
using EPEPITIAPI.EPEPDbContext;
using EPEPITIAPI.Interfaces;
using EPEPITIAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EPEPITIAPI.Services
{
    public class SharedService : IShared
    {
        private readonly EPEPITIDbContext _jwtContext;
        protected APIResponse _response;
        public SharedService(EPEPITIDbContext jwtContext)
        {
            _jwtContext = jwtContext;
            _response = new();
        }


        public async Task<APIResponse> GetRequestStatusList()
        {
            List<CommanModel> result;

            result = await (from e in _jwtContext.request_master
                   
                            select new CommanModel
                            {
                               Key=e.pk_request_id,
                               Value=e.request_name

                            }).OrderBy(x => x.Key).ToListAsync();


            if (result.Count > 0)
            {
                _response.Result = result;
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;

            }
            else
            {
                _response.ActionResponse = "No  Data";
                _response.Result = null;
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = false;

            }
            return _response;
        }
    }
}
