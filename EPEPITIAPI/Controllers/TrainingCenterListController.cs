using EPEPITIAPI.DBHelper;
using EPEPITIAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EPEPITIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingCenterListController : ControllerBase
    {
        private readonly TrainingCenterListDAL _oCenterListDAL;

        public TrainingCenterListController(TrainingCenterListDAL centerListDAL)
        {
            _oCenterListDAL = centerListDAL;
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
                    a.status
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
                    a.imageURL
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
                        status = cList.status
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
    }
}
