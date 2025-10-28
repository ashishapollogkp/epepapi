using EPEPITIAPI.DBHelper;
using EPEPITIAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPEPITIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobProfileListController : ControllerBase
    {

        private readonly JobProfileListDAL _oJobProfileListDAL;

        public JobProfileListController(JobProfileListDAL profileListDAL)
        {
            _oJobProfileListDAL = profileListDAL;
        }

        [HttpGet("Get-GetJobRoleAll")]
        public IActionResult GetJobRoleAll()
        {
            try
            {
                List<JobProfileList> pLists = new List<JobProfileList>();
                pLists = _oJobProfileListDAL.GetJobRoleAll();
                var sList = pLists.Select(a => new
                {
                    a.id,
                    a.sectorName,
                    a.jobRole,
                    a.status
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpGet("Get-GetJobRoleToEditByID")]
        public IActionResult GetJobRoleToEditByID(int id)
        {
            try
            {
                JobProfileList pList = _oJobProfileListDAL.GetJobRoleToEditByID(id);
                if (pList != null)
                {
                    // Return only necessary user information
                    var responseData = new
                    {
                        id = pList.id,
                        sectorID = pList.sectorID,
                        jobRole = pList.jobRole,
                        status = pList.status
                    };
                }

                return Ok(pList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpPost("Add-InsertJobRoleData")]
        public IActionResult InsertJobRoleData(JobProfileListDTO jList)
        {
            try
            {
                int duplicateCount = _oJobProfileListDAL.InsertJobRoleData(jList);

                // Directly return result so UI can decide message
                return Ok(new { DuplicateCount = duplicateCount });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }

        }

        [HttpPut("Update-UpdateJobRoleData")]
        public IActionResult UpdateJobRoleData(JobProfileListDTO jList)
        {
            try
            {
                int duplicateCount = _oJobProfileListDAL.UpdateJobRoleData(jList);

                // Directly return result so UI can decide message
                return Ok(new { DuplicateCount = duplicateCount });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }            

        }


        [HttpPut("Update-ChangeJobRoleStatus")]
        public IActionResult ChangeJobRoleStatus(int id)
        {
            try
            {
                bool result = _oJobProfileListDAL.ChangeJobRoleStatus(id);
                if (result)
                {
                    return Ok("Status Updated Successfully");
                }
                else
                {
                    return BadRequest("Failed to update status");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("Get-GetJobDetailsAll")]
        public IActionResult GetJobDetailsAll()
        {
            try
            {
                List<JobProfileList> pLists = new List<JobProfileList>();
                pLists = _oJobProfileListDAL.GetJobDetailsAll();
                var sList = pLists.Select(a => new
                {
                    a.id,
                    a.jobRoleDetails,
                    a.qpCode,
                    a.nsqfCode,
                    a.jobRole,
                    a.sectorName,
                    a.status
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpGet("Get-GetJobDetailToEditByID")]
        public IActionResult GetJobDetailToEditByID(int id)
        {
            try
            {
                JobProfileListDTO pList = _oJobProfileListDAL.GetJobDetailToEditByID(id);
                if (pList != null)
                {
                    // Return only necessary user information
                    var responseData = new
                    {
                        id = pList.id,
                        jobDetail = pList.jobDetail,
                        qpCode = pList.qpCode,
                        nsqfID = pList.nsqfID,
                        sectorID = pList.sectorID,
                        jobRoleID = pList.jobRoleID
                    };
                }

                return Ok(pList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpPost("Add-InsertJobDetailData")]
        public IActionResult InsertJobDetailData(JobProfileListDTO jList)
        {
            try
            {
                int duplicateCount = _oJobProfileListDAL.InsertJobDetailData(jList);

                // Directly return result so UI can decide message
                return Ok(new { DuplicateCount = duplicateCount });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }

        }

        [HttpPut("Update-UpdateJobDetailsData")]
        public IActionResult UpdateJobDetailsData(JobProfileListDTO jList)
        {
            try
            {
                int duplicateCount = _oJobProfileListDAL.UpdateJobDetailsData(jList);

                // Directly return result so UI can decide message
                return Ok(new { DuplicateCount = duplicateCount });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }            

        }


        [HttpPut("Update-ChangeJobDetailStatus")]
        public IActionResult ChangeJobDetailStatus(int id)
        {
            try
            {
                bool result = _oJobProfileListDAL.ChangeJobDetailStatus(id);
                if (result)
                {
                    return Ok("Status Updated Successfully");
                }
                else
                {
                    return BadRequest("Failed to update status");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
