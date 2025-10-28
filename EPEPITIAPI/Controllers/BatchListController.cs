using EPEPITIAPI.DBHelper;
using EPEPITIAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPEPITIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchListController : ControllerBase
    {
        private readonly BatchListDAL _oBatchListDAL;

        public BatchListController(BatchListDAL batchListDAL)
        {
            _oBatchListDAL = batchListDAL;
        }

        [HttpGet("Get-GetTrainedBatchDetail")]
        public IActionResult GetTrainedBatchDetail()
        {
            try
            {
                List<BatchList> bLists = new List<BatchList>();
                bLists = _oBatchListDAL.GetTrainedBatchDetail();
                var sList = bLists.Select(a => new
                {
                    a.id,
                    a.batchID,
                    a.sectorName,
                    a.jobRole,
                    a.jobDetail,
                    a.trainingCenter,
                    a.trainer,
                    a.assessor,
                    a.startDate,
                    a.endDate,
                    a.status
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpGet("Get-GetBatchDetailAll")]
        public IActionResult GetBatchDetailAll()
        {
            try
            {
                List<BatchList> bLists = new List<BatchList>();
                bLists = _oBatchListDAL.GetBatchDetailAll();
                var sList = bLists.Select(a => new
                {
                    a.id,
                    a.batchID,
                    a.sectorName,
                    a.jobRole,
                    a.jobDetail,
                    a.trainingCenter,
                    a.trainer,
                    a.assessor,
                    a.startDate,
                    a.endDate,
                    a.status
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpGet("Get-GetBatchDetailByTrainerID")]
        public IActionResult GetBatchDetailByTrainerID(int trainerID)
        {
            try
            {
                List<BatchList> bLists = new List<BatchList>();
                bLists = _oBatchListDAL.GetBatchDetailByTrainerID(trainerID);
                var sList = bLists.Select(a => new
                {
                    a.id,
                    a.batchID,
                    a.sectorName,
                    a.jobRole,
                    a.jobDetail,
                    a.trainingCenter,
                    a.trainer,
                    a.assessor,
                    a.startDate,
                    a.endDate,
                    a.status
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpGet("Get-GetBatchDetailByAssessorID")]
        public IActionResult GetBatchDetailByAssessorID(int assessorID)
        {
            try
            {
                List<BatchList> bLists = new List<BatchList>();
                bLists = _oBatchListDAL.GetBatchDetailByAssessorID(assessorID);
                var sList = bLists.Select(a => new
                {
                    a.id,
                    a.batchID,
                    a.sectorName,
                    a.jobRole,
                    a.jobDetail,
                    a.trainingCenter,
                    a.trainer,
                    a.assessor,
                    a.startDate,
                    a.endDate,
                    a.status
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpGet("Get-GetBatchDetailToViewByID")]
        public IActionResult GetBatchDetailToViewByID(int id)
        {
            try
            {
                BatchList bList = _oBatchListDAL.GetBatchDetailToViewByID(id);
                if (bList != null)
                {
                    // Return only necessary user information
                    var responseData = new
                    {
                        id = bList.id,
                        batchID = bList.batchID,
                        sectorName = bList.sectorName,
                        jobRole = bList.jobRole,
                        jobDetail = bList.jobDetail,
                        trainingCenter = bList.trainingCenter,
                        trainer = bList.trainer,
                        assessor = bList.assessor,
                        startDate = bList.startDate,
                        endDate = bList.endDate
                    };
                }

                return Ok(bList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpGet("Get-GetBatchDetailToEditByID")]
        public IActionResult GetBatchDetailToEditByID(int id)
        {
            try
            {
                BatchList bList = _oBatchListDAL.GetBatchDetailToEditByID(id);
                if (bList != null)
                {
                    // Return only necessary user information
                    var responseData = new
                    {
                        id = bList.id,
                        sectorID = bList.sectorID,
                        jobRoleID = bList.jobRoleID,
                        jobDetailID = bList.jobDetailID,
                        trainingCenterID = bList.trainingCenterID,
                        trainerID = bList.trainerID,
                        assessorID = bList.assessorID,
                        startDate = bList.startDate,
                        endDate = bList.endDate
                    };
                }

                return Ok(bList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpPost("Add-InsertBatchDetail")]
        public IActionResult InsertBatchDetail(BatchListDTO bList)
        {
            try
            {
                bool result = _oBatchListDAL.InsertBatchDetail(bList);
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

        [HttpPut("Update-UpdateBatchDetail")]
        public IActionResult UpdateBatchDetail(BatchListDTO bList)
        {
            try
            {
                bool result = _oBatchListDAL.UpdateBatchDetail(bList);
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

        [HttpPut("Update-ChangeBatchStatus")]
        public IActionResult ChangeBatchStatus(int id)
        {
            try
            {
                bool result = _oBatchListDAL.ChangeBatchStatus(id);
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

        [HttpGet("Get-GetBatchWiseImages")]
        public IActionResult GetBatchWiseImages(int batchID)
        {
            try
            {
                List<BatchImageDTO> bLists = new List<BatchImageDTO>();
                bLists = _oBatchListDAL.GetBatchWiseImages(batchID);
                var sList = bLists.Select(a => new
                {
                    a.id,
                    a.batchID,
                    a.imageURLName,
                    a.createdOn
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }


        [HttpPost("Add-InsertBatchImages")]
        public async Task<IActionResult> InsertBatchImages([FromForm] BatchImageDTO iList)
        {
            try
            {
                if (iList.imageURL == null || iList.imageURL.Count == 0)
                    return BadRequest("No images uploaded.");

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "batchImages");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                List<string> savedFiles = new List<string>();

                foreach (var formFile in iList.imageURL)
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
                bool result = _oBatchListDAL.InsertBatchImages(iList.batchID, iList.createdBy, savedFiles);

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

        [HttpDelete("Delete-DeleteBatchInages")]
        public IActionResult DeleteBatchInages(int id)
        {
            try
            {
                bool result = _oBatchListDAL.DeleteBatchInages(id);
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
