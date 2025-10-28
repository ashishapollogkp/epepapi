using EPEPITIAPI.Models;

namespace EPEPITIAPI.Interfaces
{
    public interface IShared
    {
        Task<APIResponse> GetRequestStatusList();
    }
}
