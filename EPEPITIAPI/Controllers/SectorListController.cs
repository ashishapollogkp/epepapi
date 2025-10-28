using EPEPITIAPI.DBHelper;
using EPEPITIAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPEPITIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorListController : ControllerBase
    {
        private readonly SectorListDAL _oSectorListDAL;

        public SectorListController(SectorListDAL sectorListDAL)
        {
            _oSectorListDAL = sectorListDAL;
        }

        [HttpGet("Get-GetSectorAll")]
        public IActionResult GetSectorAll()
        {
            try
            {
                List<SectorList> pLists = new List<SectorList>();
                pLists = _oSectorListDAL.GetSectorAll();
                var sList = pLists.Select(a => new
                {
                    a.id,
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

        [HttpGet("Get-GetSectorToEditByID")]
        public IActionResult GetSectorToEditByID(int id)
        {
            try
            {
                SectorList pList = _oSectorListDAL.GetSectorToEditByID(id);
                if (pList != null)
                {
                    // Return only necessary user information
                    var responseData = new
                    {
                        id = pList.id,
                        sectorName = pList.sectorName,
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


        [HttpPost("Add-InsertSectorData")]
        public IActionResult InsertSectorData(SectorList sList)
        {
            try
            {
                int duplicateCount = _oSectorListDAL.InsertSectorData(sList);

                // Directly return result so UI can decide message
                return Ok(new { DuplicateCount = duplicateCount });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }

        }


        [HttpPut("Update-UpdateSectorData")]
        public IActionResult UpdateSectorData(SectorList sList)
        {
            try
            {
                int duplicateCount = _oSectorListDAL.UpdateSectorData(sList);

                // Directly return result so UI can decide message
                return Ok(new { DuplicateCount = duplicateCount });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }

        }


        [HttpPut("Update-ChangeSectorStatus")]
        public IActionResult ChangeSectorStatus(int id)
        {
            try
            {
                bool result = _oSectorListDAL.ChangeSectorStatus(id);
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
