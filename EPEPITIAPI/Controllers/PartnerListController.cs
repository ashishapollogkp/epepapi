using EPEPITIAPI.DBHelper;
using EPEPITIAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPEPITIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerListController : ControllerBase
    {
        private readonly PartnerListDAL _oPartnerListDAL;

        public PartnerListController(PartnerListDAL partnerListDAL)
        {
            _oPartnerListDAL = partnerListDAL;
        }

        [HttpGet("Get-GetPartnerDetailAll")]
        public IActionResult GetPartnerDetailAll()
        {
            try
            {
                List<PartnerList> pLists = new List<PartnerList>();
                pLists = _oPartnerListDAL.GetPartnerDetailAll();
                var sList = pLists.Select(a => new
                {
                    a.id,
                    a.partnerType,
                    a.firmName,
                    a.contactPerson,
                    a.contactMobile,
                    a.contactEmail,
                    a.firmAddress,
                    a.status
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpGet("Get-GetPartnerDetailToViewByID")]
        public IActionResult GetPartnerDetailToViewByID(int id)
        {
            try
            {
                PartnerList pList = _oPartnerListDAL.GetPartnerDetailToViewByID(id);
                if (pList != null)
                {
                    // Return only necessary user information
                    var responseData = new
                    {
                        id = pList.id,
                        partnerType = pList.partnerType,
                        firmName = pList.firmName,
                        contactPerson = pList.contactPerson,
                        contactMobile = pList.contactMobile,
                        contactEmail = pList.contactEmail,
                        firmAddress = pList.firmAddress,
                        status = pList.status,
                        createdByName = pList.createdByName,
                        createdOn = pList.createdOn,
                        updatedByName = pList.updatedByName,
                        updatedOn = pList.updatedOn
                    };
                }

                return Ok(pList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }


        [HttpGet("Get-GetPartnerDetailToEditByID")]
        public IActionResult GetPartnerDetailToEditByID(int id)
        {
            try
            {
                PartnerList pList = _oPartnerListDAL.GetPartnerDetailToEditByID(id);
                if (pList != null)
                {
                    // Return only necessary user information
                    var responseData = new
                    {
                        id = pList.id,
                        partnerTypeID = pList.partnerTypeID,
                        firmName = pList.firmName,
                        contactPerson = pList.contactPerson,
                        contactMobile = pList.contactMobile,
                        contactEmail = pList.contactEmail,
                        firmAddress = pList.firmAddress
                    };
                }

                return Ok(pList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpPost("Add-InsertPartnerData")]
        public IActionResult InsertPartnerData(PartnerListDTO pList)
        {
            try
            {
                bool result = _oPartnerListDAL.InsertPartnerData(pList);
                if (result)
                {
                    return Ok("Data saved successfully");
                }
                else
                {
                    return BadRequest("Failed to save data");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }

        }


        [HttpPut("Update-UpdatePartnerData")]
        public IActionResult UpdatePartnerData(PartnerListDTO jList)
        {
            try
            {
                bool result = _oPartnerListDAL.UpdatePartnerData(jList);
                if (result)
                {
                    return Ok("Data updated successfully");
                }
                else
                {
                    return BadRequest("Failed to update data");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }

        }


        [HttpPut("Update-ChangePartnerStatus")]
        public IActionResult ChangePartnerStatus(int id)
        {
            try
            {
                bool result = _oPartnerListDAL.ChangePartnerStatus(id);
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
