using EPEPITIAPI.DBHelper;
using EPEPITIAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPEPITIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceListController : ControllerBase
    {
        private readonly AttendanceListDAL _oAttListDAL;

        public AttendanceListController(AttendanceListDAL attListDAL)
        {
            _oAttListDAL = attListDAL;
        }

        [HttpGet("Get-GetBatchWiseCandidate")]
        public IActionResult GetBatchWiseCandidate(int batchID)
        {
            try
            {
                List<AttendanceList> aLists = new List<AttendanceList>();
                aLists = _oAttListDAL.GetBatchWiseCandidate(batchID);
                var sList = aLists.Select(a => new
                {
                    a.id,
                    a.batchID,
                    a.candidateName,
                    a.mobile,
                    a.aadhaar,
                    a.startDate,
                    a.endDate,  
                    a.candidateID,
                    a.sectorName,
                    a.jobRole,
                    a.jobRoleDetails,
                    a.fhName,
                    a.district,
                    a.stateName,
                    a.dob,
                    a.nsqfCode,
                    a.day1,
                    a.day2,
                    a.day3,
                    a.day4,
                    a.day5,
                    a.profileImage
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpGet("Get-GetAadhaarWiseCandidate")]
        public IActionResult GetAadhaarWiseCandidate(string aadhaar)
        {
            
            try
            {
                
                AttendanceList cList = _oAttListDAL.GetAadhaarWiseCandidate(aadhaar);
                if (cList != null)
                {
                    var responseDat = new
                    {
                        id= cList.id,
                        batchID = cList.batchID,
                        candidateName =cList.candidateName,
                        mobile = cList.mobile,
                        aadhaar = cList.aadhaar,
                        startDate = cList.startDate,
                        endDate = cList.endDate,
                        candidateID = cList.candidateID,
                        sectorName = cList.sectorName,
                        jobRole = cList.jobRole,
                        jobRoleDetails = cList.jobRoleDetails,
                        fhName = cList.fhName,
                        district = cList.district,
                        stateName = cList.stateName,
                        dob = cList.dob,
                        nsqfCode = cList.nsqfCode,
                        day1 = cList.day1,
                        day2 = cList.day2,
                        day3 = cList.day3,
                        day4 = cList.day4,
                        day5 = cList.day5,
                        profileImage = cList.profileImage
                    };
                }
                return Ok(cList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpGet("Get-GetBatchWiseAttendance")]
        public IActionResult GetBatchWiseAttendance(int batchID)
        {
            try
            {
                List<AttendanceList> aLists = new List<AttendanceList>();
                aLists = _oAttListDAL.GetBatchWiseAttendance(batchID);
                var sList = aLists.Select(a => new
                {
                    a.id,
                    a.batchID,
                    a.candidateName,
                    a.startDate,
                    a.endDate,
                    a.day1,
                    a.day2,
                    a.day3,
                    a.day4,
                    a.day5
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpPost("Add-MarkAttendance")]
        public IActionResult MarkAttendance(AttendanceListDTO aList)
        {
            try
            {
                bool result = _oAttListDAL.MarkAttendance(aList);
                if (result)
                {
                    return Ok("Attendance marked successfully");
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

        [HttpPut("Update-UnMarkAttendance")]
        public IActionResult UnMarkAttendance(AttendanceListDTO aList)
        {
            try
            {
                bool result = _oAttListDAL.UnMarkAttendance(aList);
                if (result)
                {
                    return Ok("Attendance Un-Marked successfully");
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

        [HttpGet("Get-GetCandidateToAllocateBatch")]
        public IActionResult GetCandidateToAllocateBatch(int batchID)
        {
            try
            {
                List<AttendanceList> aLists = new List<AttendanceList>();
                aLists = _oAttListDAL.GetCandidateToAllocateBatch(batchID);
                var sList = aLists.Select(a => new
                {
                    a.id,
                    a.candidateID,
                    a.candidateName,
                    a.aadhaar,
                    a.aadhaarLinkedMobile,
                    a.mobile,
                    a.address,
                    a.batchIDInt,
                    a.gender,
                    a.dob,
                    a.fhName,
                    a.religion,
                    a.category,
                    a.pan,
                    a.sectorName,
                    a.jobRole,
                    a.jobRoleDetails,
                    a.pin,
                    a.stateName,
                    a.district,
                    a.qualification,
                    a.disabilityYN,
                    a.disability
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpPost("Add-AllocateBatchToCandidates")]
        public IActionResult AllocateBatchToCandidates([FromBody] List<AttendanceListDTO> candidate)
        {
            try
            {
                bool result = _oAttListDAL.AllocateBatchToCandidates(candidate);
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
    }
}
