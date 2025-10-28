using EPEPITIAPI.DBHelper;
using EPEPITIAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPEPITIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateListController : ControllerBase
    {
        private readonly CandidateListDAL _oCandidateListDAL;

        public CandidateListController(CandidateListDAL candidateListDAL)
        {
            _oCandidateListDAL = candidateListDAL;
        }

        [HttpGet("Get-GetCandidateDetailAll")]
        public IActionResult GetCandidateDetailAll()
        {
            try
            {
                List<CandidateList> cLists = new List<CandidateList>();
                cLists = _oCandidateListDAL.GetCandidateDetailAll();
                var sList =cLists.Select(a => new
                {
                    a.id,
                    a.candidateName,
                    a.mobile,
                    a.aadhaar,
                    a.aadhaarLinkedMobile,
                    a.gender,
                    a.dob,
                    a.fhName,
                    a.religion,
                    a.category,
                    a.pan,
                    a.sectorName,
                    a.jobRole,
                    a.jobDetail,
                    a.pin,
                    a.state,
                    a.district,
                    a.address,
                    a.qualification,
                    a.disability,
                    a.profileImageName,
                    a.aadhaarFrontName,
                    a.aadhaarBackName,
                    a.status
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpGet("Get-GetAllocatedCandidateDetailAll")]
        public IActionResult GetAllocatedCandidateDetailAll()
        {
            try
            {
                List<CandidateList> cLists = new List<CandidateList>();
                cLists = _oCandidateListDAL.GetAllocatedCandidateDetailAll();
                var sList = cLists.Select(a => new
                {
                    a.id,
                    a.batchID,
                    a.candidateName,
                    a.mobile,
                    a.aadhaar,
                    a.aadhaarLinkedMobile,
                    a.gender,
                    a.dob,
                    a.fhName,
                    a.religion,
                    a.category,
                    a.pan,
                    a.sectorName,
                    a.jobRole,
                    a.jobDetail,
                    a.pin,
                    a.state,
                    a.district,
                    a.address,
                    a.qualification,
                    a.disability,
                    a.profileImageName,
                    a.aadhaarFrontName,
                    a.aadhaarBackName,
                    a.status
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }


        [HttpGet("Get-GetCandidateDetailToEditByID")]
        public IActionResult GetCandidateDetailToEditByID(int id)
        {
            try
            {
                CandidateList cList = _oCandidateListDAL.GetCandidateDetailToEditByID(id);
                if (cList != null)
                {
                    // Return only necessary user information
                    var responseData = new
                    {
                        id = cList.id,
                        candidateName = cList.candidateName,
                        mobile = cList.mobile,
                        aadhaar = cList.aadhaar,
                        aadhaarLinkedMobile = cList.aadhaarLinkedMobile,
                        dob = cList.dob,
                        gender = cList.gender,
                        fhName = cList.fhName,
                        religionID = cList.religionID,
                        categoryID = cList.categoryID,
                        pan = cList.pan,
                        sectorID = cList.sectorID,
                        jobRoleID = cList.jobRoleID,
                        jobDetailID = cList.jobDetailID,                        
                        pin = cList.pin,
                        stateID = cList.stateID,
                        district = cList.district,
                        address = cList.address,
                        qualificationID = cList.qualificationID,
                        disabilityYN = cList.disabilityYN,
                        disability = cList.disability,
                        profileImageName = cList.profileImageName,
                        aadhaarFrontName = cList.aadhaarFrontName,
                        aadhaarBackName = cList.aadhaarBackName
                    };
                }

                return Ok(cList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }


        [HttpPost("Add-InsertCandidatetData")]
        public async Task<IActionResult> InsertCandidateData([FromForm] CandidateListDTO formData)
        {
            try
            {
                string SaveFile(IFormFile file, string subFolder)
                {
                    if (file != null && file.Length > 0)
                    {
                        var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", subFolder);
                        Directory.CreateDirectory(uploadFolder);

                        string fileName = $"{Guid.NewGuid()}_{file.FileName}";
                        string filePath = Path.Combine(uploadFolder, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        return fileName;
                    }
                    return null;
                }

                // Save to respective folders
                string profileImageName = SaveFile(formData.profileImage, "profilePic");
                string aadhaarFrontName = SaveFile(formData.aadhaarFront, "aadhaarDocs");
                string aadhaarBackName = SaveFile(formData.aadhaarBack, "aadhaarDocs");


                // Create DTO to save
                CandidateListDTO dto = new CandidateListDTO
                {
                    candidateName = formData.candidateName,
                    mobile = formData.mobile,
                    aadhaar = formData.aadhaar,
                    aadhaarLinkedMobile = formData.aadhaarLinkedMobile,
                    dob = formData.dob,
                    gender = formData.gender,
                    fhName = formData.fhName,
                    religionID = formData.religionID,
                    categoryID = formData.categoryID,
                    pan = formData.pan,
                    sectorID = formData.sectorID,
                    jobRoleID = formData.jobRoleID,
                    jobDetailID = formData.jobDetailID,                    
                    pin = formData.pin,
                    stateID = formData.stateID,
                    district = formData.district,
                    address = formData.address,
                    qualificationID = formData.qualificationID,
                    disabilityYN = formData.disabilityYN,
                    disability = formData.disability,
                    profileImageName = profileImageName,
                    aadhaarFrontName = aadhaarFrontName,
                    aadhaarBackName = aadhaarBackName,
                    createdBy = formData.createdBy

                };

                bool result = _oCandidateListDAL.InsertCandidateData(dto);

                if (result)
                {
                    return Ok("Data Saved Successfully");
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

        [HttpPost("Update-UpdateCandidateData")]
        public async Task<IActionResult> UpdateCandidateData([FromForm] CandidateListDTO formData)
        {
            try
            {
                string SaveFile(IFormFile file, string subFolder)
                {
                    if (file != null && file.Length > 0)
                    {
                        var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", subFolder);
                        Directory.CreateDirectory(uploadFolder);

                        string fileName = $"{Guid.NewGuid()}_{file.FileName}";
                        string filePath = Path.Combine(uploadFolder, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        return fileName;
                    }
                    return null;
                }

                // Save to respective folders
                string profileImageName = SaveFile(formData.profileImage, "profilePic");
                string aadhaarFrontName = SaveFile(formData.aadhaarFront, "aadhaarDocs");
                string aadhaarBackName = SaveFile(formData.aadhaarBack, "aadhaarDocs");


                // Create DTO to save
                CandidateListDTO dto = new CandidateListDTO
                {
                    id = formData.id,
                    candidateName = formData.candidateName,
                    mobile = formData.mobile,
                    aadhaar = formData.aadhaar,
                    aadhaarLinkedMobile = formData.aadhaarLinkedMobile,
                    dob = formData.dob,
                    gender = formData.gender,
                    fhName = formData.fhName,
                    religionID = formData.religionID,
                    categoryID = formData.categoryID,
                    pan = formData.pan,
                    sectorID = formData.sectorID,
                    jobRoleID = formData.jobRoleID,
                    jobDetailID = formData.jobDetailID,
                    pin = formData.pin,
                    stateID = formData.stateID,
                    district = formData.district,
                    address = formData.address,
                    qualificationID = formData.qualificationID,
                    disabilityYN = formData.disabilityYN,
                    disability = formData.disability,
                    profileImageName = profileImageName,
                    aadhaarFrontName = aadhaarFrontName,
                    aadhaarBackName = aadhaarBackName,
                    createdBy = formData.createdBy

                };

                bool result = _oCandidateListDAL.UpdateCandidateData(dto);

                if (result)
                {
                    return Ok("Data updated Successfully");
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


        [HttpPut("Update-ChangeCandidateStatus")]
        public IActionResult ChangeCandidateStatus(int id)
        {
            try
            {
                bool result = _oCandidateListDAL.ChangeCandidateStatus(id);
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

        [HttpPost("Add-InsertBulkCandidates")]
        public IActionResult InsertBulkCandidates([FromBody] List<CandidateListUploadDTO> candidate)
        {
            try
            {
                bool result = _oCandidateListDAL.InsertBulkCandidate(candidate);
                if (result)
                {
                    return Ok("Candidate data uploaded successfully");
                }
                else
                {
                    return BadRequest("Failed to ipload candidate data");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }


        [HttpPost("Check-CheckDuplicateAadhaar")]
        public IActionResult CheckDuplicateAadhaar(string aadhaar)
        {
            try
            {
                bool exists = _oCandidateListDAL.CheckDuplicateAadhaar(aadhaar);
                return Ok(new { isDuplicateAadhaar = exists });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }

        }
    }
}
