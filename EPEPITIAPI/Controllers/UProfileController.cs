using EPEPITIAPI.Data;
using EPEPITIAPI.DBHelper;
using EPEPITIAPI.EPEPDbContext;
using EPEPITIAPI.Models;
using EPEPITIAPI.Models.TrainingSection;
using EPEPITIAPI.Models.userInfoSection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EPEPITIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UProfileController : ControllerBase
    {
        private readonly EPEPITIDbContext _service;
        protected APIResponse _response;

        public UProfileController( EPEPITIDbContext service)
        {
            _service = service;
            _response = new();
        }


        [HttpPost("UpdateTProfile")]
        public async Task<APIResponse> UpdateTProfile(TrainerInfoReq req)
        {
            var _response = new APIResponse();

            // ✅ Input validation
            if (req == null || req.fk_user_id == null || req.fk_user_id <= 0)
            {
                _response.ActionResponse = "Invalid User ID";
                _response.Result = null;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return _response;
            }

            try
            {
                // ✅ Check user existence in TMUser table
                var user = await _service.TMUser.FirstOrDefaultAsync(x => x.Id == req.fk_user_id);
                if (user == null)
                {
                    _response.ActionResponse = "User not found!";
                    _response.Result = null;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return _response;
                }

                // ✅ Check if profile already exists
                var userProfile = await _service.master_trainer_info
                    .FirstOrDefaultAsync(x => x.fk_user_id == req.fk_user_id);

                if (userProfile != null)
                {
                    // -------- UPDATE EXISTING PROFILE --------
                    userProfile.official_Name = req.official_Name;
                    userProfile.official_id = req.official_id;
                    userProfile.dob = req.dob;
                    userProfile.gender = req.gender;
                    userProfile.qualification = req.qualification;
                    userProfile.adddhar_no = req.adddhar_no;
                    userProfile.official_mobileno = req.official_mobileno;
                    userProfile.is_certify = req.is_certify;
                    userProfile.certificate_no = req.certificate_no;
                    userProfile.updatd_date = DateTime.Now;

                    _service.master_trainer_info.Update(userProfile);
                    await _service.SaveChangesAsync();

                    _response.ActionResponse = "Profile updated successfully!";
                    _response.Result = userProfile;
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    return _response;
                }
                else
                {
                    // -------- CREATE NEW PROFILE --------
                    var newTrainer = new master_trainer_info
                    {
                        fk_user_id = req.fk_user_id,
                        official_Name = req.official_Name,
                        official_id = req.official_id,
                        dob = req.dob,
                        gender = req.gender,
                        qualification = req.qualification,
                        adddhar_no = req.adddhar_no,
                        official_mobileno = req.official_mobileno,
                        is_certify = req.is_certify,
                        certificate_no = req.certificate_no,
                        created_date = DateTime.Now,
                        updatd_date = DateTime.Now
                    };

                    await _service.master_trainer_info.AddAsync(newTrainer);
                    await _service.SaveChangesAsync();

                    _response.ActionResponse = "Profile created successfully!";
                    _response.Result = newTrainer;
                    _response.StatusCode = HttpStatusCode.Created;
                    _response.IsSuccess = true;
                    return _response;
                }
            }
            catch (DbUpdateException dbEx)
            {
                _response.ActionResponse = "Database update failed.";
                _response.Result = dbEx.InnerException?.Message;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                return _response;
            }
            catch (Exception ex)
            {
                _response.ActionResponse = "An unexpected error occurred.";
                _response.Result = ex.Message;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                return _response;
            }
        }


        [HttpGet("GetTProfile/{userId}")]
        public async Task<APIResponse> GetTProfile(int userId)
        {
            var _response = new APIResponse();

            // ✅ Input validation
            if (userId <= 0)
            {
                _response.ActionResponse = "Invalid User ID";
                _response.Result = null;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return _response;
            }

            try
            {
                // ✅ Check if user exists in TMUser table
                var user = await _service.TMUser.FirstOrDefaultAsync(x => x.Id == userId);
                if (user == null)
                {
                    _response.ActionResponse = "User not found!";
                    _response.Result = null;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return _response;
                }

                // ✅ Fetch trainer profile
                var userProfile = await _service.master_trainer_info
                    .FirstOrDefaultAsync(x => x.fk_user_id == userId);

                if (userProfile == null)
                {
                    _response.ActionResponse = "Profile not found!";
                    _response.Result = null;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return _response;
                }

                // ✅ Combine user & profile info (optional)
                var result = new
                {
                    user.Id,
                    user.UserName,
                    user.UserMobile,
                    user.UserEmail,
                    userProfile.pk_trainer_info_id,
                    userProfile.fk_user_id,
                    userProfile.official_Name,
                    userProfile.official_id,
                    userProfile.dob,
                    userProfile.gender,
                    userProfile.qualification,
                    userProfile.adddhar_no,
                    userProfile.official_mobileno,
                    userProfile.is_certify,
                    userProfile.certificate_no,
                    userProfile.created_date,
                    userProfile.updatd_date
                };

                // ✅ Success response
                _response.ActionResponse = "Trainer profile fetched successfully!";
                _response.Result = result;
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return _response;
            }
            catch (Exception ex)
            {
                _response.ActionResponse = "An error occurred while fetching trainer profile.";
                _response.Result = ex.Message;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                return _response;
            }
        }


    }
}
