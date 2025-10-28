using Microsoft.AspNetCore.Mvc;
using EPEPITIAPI.DBHelper;
using EPEPITIAPI.Models;


namespace EPEPITIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindDropDownController : ControllerBase
    {

        private readonly BindDropDownListDAL _oDropDownListDAL;

        public BindDropDownController(BindDropDownListDAL dropDownListDAL)
        {
            _oDropDownListDAL = dropDownListDAL;
        }


        [HttpGet("Bind-BindReligionDropDownList")]
        public IActionResult BindReligionDropDownList()
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindReligionDropDownList();
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.religion
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("Bind-BindCategoryDropDownList")]
        public IActionResult BindCategoryDropDownList()
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindCategoryDropDownList();
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.category
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("Bind-BindStateDropDownList")]
        public IActionResult BindStateDropDownList()
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindStateDropDownList();
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.statename
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("Bind-BindQualificationDropDownList")]
        public IActionResult BindQualificationDropDownList()
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindQualificationDropDownList();
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.qualification
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("Bind-BindUserRoleDropDownList")]
        public IActionResult BindUserRoleDropDownList()
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindUserRoleDropDownList();
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.userRole
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("Bind-BindNSQFCodeDropDownList")]
        public IActionResult BindNSQFCodeDropDownList()
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindNSQFCodeDropDownList();
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.nsqfCode
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpGet("Bind-BindSectorDropDownList")]
        public IActionResult BindSectorDropDownList()
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindSectorDropDownList();
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.sectorname
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpGet("Bind-BindJobRoleDropDownListBySectorID")]
        public IActionResult BindJobRoleDropDownListBySectorID( int sectorID)
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindJobRoleDropDownListBySectorID(sectorID);
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.jobRole
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpGet("Bind-BindJobDetailDropDownListByJobRoleID")]
        public IActionResult BindJobDetailDropDownListByJobRoleID(int jobRoleID)
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindJobDetailDropDownListByJobRoleID(jobRoleID);
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.jobDetail
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpGet("Bind-BindPartnerTypeDropDownList")]
        public IActionResult BindPartnerTypeDropDownList()
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindPartnerTypeDropDownList();
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.partnerType
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }



        [HttpGet("Bind-BindPartnerDropDownListByPartnerTypeID")]
        public IActionResult BindPartnerDropDownListByPartnerTypeID( int partnerTypeID)
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindPartnerDropDownListByPartnerTypeID(partnerTypeID);
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.partnerName
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpGet("Bind-BindTrainingCenterDropDownList")]
        public IActionResult BindTrainingCenterDropDownList()
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindTrainingCenterDropDownList();
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.trainingCenter
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("Bind-BindTrainerDropDownList")]
        public IActionResult BindTrainerDropDownList()
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindTrainerDropDownList();
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.trainer
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("Bind-BindAssessorDropDownList")]
        public IActionResult BindAssessorDropDownList()
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindAssessorDropDownList();
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.assessor
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpGet("Bind-BindBatchDropDownList")]
        public IActionResult BindBatchDropDownList()
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindBatchDropDownList();
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.batchID
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("Bind-BindBatchDropDownListAttendance")]
        public IActionResult BindBatchDropDownListAttendance()
        {
            try
            {
                List<BindDropDownList> bList = new List<BindDropDownList>();
                bList = _oDropDownListDAL.BindBatchDropDownListAttendance();
                // Projecting only the required fields
                var result = bList.Select(p => new
                {
                    p.id,
                    p.batchID
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
