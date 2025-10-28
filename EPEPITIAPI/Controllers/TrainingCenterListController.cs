using EPEPITIAPI.DBHelper;
using EPEPITIAPI.EPEPDbContext;
using EPEPITIAPI.Models;
using EPEPITIAPI.Models.TrainingSection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace EPEPITIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingCenterListController : ControllerBase
    {
        private readonly TrainingCenterListDAL _oCenterListDAL;

        private readonly EPEPITIDbContext _jwtContext;
        protected APIResponse _response;

        public TrainingCenterListController(TrainingCenterListDAL centerListDAL, EPEPITIDbContext jwtContext)
        {
            _oCenterListDAL = centerListDAL;
            _jwtContext = jwtContext;
            _response = new();
        }


        [HttpGet("Get-GetTrainingCenterDetailAll")]
        public IActionResult GetTrainingCenterDetailAll()
        {
            try
            {
                List<TrainingCenterList> cLists = new List<TrainingCenterList>();
                cLists = _oCenterListDAL.GetTrainingCenterDetailAll();
                var sList = cLists.Select(a => new
                {
                    a.id,
                    a.centerName,
                    a.contactName,
                    a.mobile,
                    a.email,
                    a.address,                    
                    a.longitude,
                    a.latitude,
                    a.pin,
                    a.stateName,
                    a.district,
                    a.status,
                    a.approval_status,
                    a.approval_date,
                    a.image_path1,
                    a.image_path2,
                    a.image_path3,
                    a.reject_reason
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpGet("Get-GetTrainingCenterDetailToViewByID")]
        public IActionResult GetTrainingCenterDetailToViewByID(int id)
        {
            try
            {
                List<TrainingCenterList> cLists = new List<TrainingCenterList>();
                cLists = _oCenterListDAL.GetTrainingCenterDetailToViewByID(id);
                var sList = cLists.Select(a => new
                {
                    a.id,
                    a.centerName,
                    a.contactName,
                    a.mobile,
                    a.email,
                    a.address,
                    a.longitude,
                    a.latitude,
                    a.pin,
                    a.stateName,
                    a.district,
                    a.imageURL,
                    a.approval_status,
                    a.approval_date,
                    a.image_path1,
                    a.image_path2,
                    a.image_path3,
                    a.reject_reason
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }


        [HttpGet("Get-GetTrainingCenterDetailToEditByID")]
        public IActionResult GetTrainingCenterDetailToEditByID(int id)
        {
            try
            {
                TrainingCenterList cList = _oCenterListDAL.GetTrainingCenterDetailToEditByID(id);
                if (cList != null)
                {
                    // Return only necessary user information
                    var responseData = new
                    {
                        id = cList.id,
                        centerName = cList.centerName,
                        contactName = cList.contactName,
                        mobile = cList.mobile,
                        email = cList.email,
                        address = cList.address,                        
                        longitude = cList.longitude,
                        latitude = cList.latitude,
                        pin = cList.pin,
                        stateID = cList.stateID,
                        district = cList.district,
                        status = cList.status,

                        approval_status= cList.approval_status,
                        approval_date= cList.approval_date,
                        image_path1= cList.image_path1,
                        image_path2= cList.image_path2,
                        image_path3 = cList.image_path3,
                        reject_reason= cList.reject_reason


                    };
                }

                return Ok(cList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpPost("Add-InsertTrainingCenterDetail")]
        public IActionResult InsertTrainingCenterDetail(TrainingCenterList cList)
        {
            try
            {
                bool result = _oCenterListDAL.InsertTrainingCenterDetail(cList);
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

        [HttpPut("Update-UpdateTrainingCenterDetail")]
        public IActionResult UpdateTrainingCenterDetail(TrainingCenterList cList)
        {
            try
            {
                bool result = _oCenterListDAL.UpdateTrainingCenterDetail(cList);
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

        [HttpPut("Update-ChangeTrainingCenterStatus")]
        public IActionResult ChangeTrainingCenterStatus(int id)
        {
            try
            {
                bool result = _oCenterListDAL.ChangeTrainingCenterStatus(id);
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

        [HttpGet("Get-GetTrainingCenterImageByCenterID")]
        public IActionResult GetTrainingCenterImageByCenterID(int centerID)
        {
            try
            {
                List<TrainingCenterImageList> pLists = new List<TrainingCenterImageList>();
                pLists = _oCenterListDAL.GetTrainingCenterImageByCenterID(centerID);
                var cList = pLists.Select(a => new
                {
                    a.id,
                    a.imageURLName
                });
                return Ok(cList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }


        [HttpPost("Add-InsertTrainingCenterImage")]
        public async Task<IActionResult> InsertTrainingCenterImage([FromForm] TrainingCenterImageList cList)
        {
            try
            {
                if (cList.imageURL == null || cList.imageURL.Count == 0)
                    return BadRequest("No images uploaded.");

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "centerImages");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                List<string> savedFiles = new List<string>();

                foreach (var formFile in cList.imageURL)
                {
                    if (formFile.Length > 0)
                    {
                        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                        var filePath = Path.Combine(uploadPath, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }

                        savedFiles.Add(uniqueFileName);
                    }
                }

                // Save to DB (centerID, imageURL, createdBy, etc.)
                bool result = _oCenterListDAL.InsertTrainingCenterImage(cList.trainingCenterID, cList.createdBy, savedFiles);

                if (result)
                    return Ok("Images saved successfully.");
                else
                    return BadRequest("Failed to save data.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }


        [HttpDelete("Delete-DeleteTrainingCenterImage")]
        public IActionResult DeleteTrainingCenterImage(int id)
        {
            try
            {
                bool result = _oCenterListDAL.DeleteTrainingCenterImageByID(id);
                if (result)
                {
                    return Ok("Image Deleted Successfully");
                }
                else
                {
                    return BadRequest("Failed to delete Image");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }





        [HttpPost("ApprovedRejectTrainingCenter")]
        public async Task<APIResponse> ApprovedRejectTrainingCenter(ApproveRejectReq req)
        {
            var response = new APIResponse();

            // Validate input
            if (req.id == 0)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Invalid Training Center Id!");
                return response;
            }

            try
            {
                // Find training center
                var centerData = await _jwtContext.TMTrainingCenter
                    .FirstOrDefaultAsync(x => x.id == req.id);
                if (centerData == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("No Training Center found!");
                    return response;
                }

                if (!string.IsNullOrEmpty(centerData.approval_status) && centerData.approval_status.ToUpper() == "APPROVED")
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Status cannot be updated after approval.");
                    return response;
                }


                // Update approval status & related fields
                centerData.approval_status = req.approval_status; // e.g., "APPROVED" or "REJECTED"
                centerData.approval_date = DateTime.Now;
                centerData.reject_reason = req.reject_reason;
               
                centerData.updatedOn = DateTime.Now;

                _jwtContext.TMTrainingCenter.Update(centerData);
                await _jwtContext.SaveChangesAsync();

                // Prepare success response
                response.StatusCode = HttpStatusCode.OK;
                response.IsSuccess = true;
                response.ActionResponse = $"Training Center {(req.approval_status?.ToUpper() == "APPROVED" ? "approved" : "rejected")} successfully.";
                response.Result = new
                {
                    centerData.id,
                    centerData.centerName,
                    centerData.approval_status,
                    centerData.reject_reason
                };
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("An error occurred while updating training center data.");
                // Optionally add for debugging:
                // response.ErrorMessages.Add(ex.Message);
            }

            return response;
        }






    }
}
