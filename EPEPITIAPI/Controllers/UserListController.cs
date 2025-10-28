using EPEPITIAPI.DBHelper;
using EPEPITIAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPEPITIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserListController : ControllerBase
    {
        private readonly UserListDAL _oUserListDAL;

        public UserListController(UserListDAL userListDAL)
        {
            _oUserListDAL = userListDAL;
        }

        [HttpGet("Get-GetUserDetailAll")]
        public IActionResult GetUserDetailAll()
        {
            try
            {
                List<UserList> uLists = new List<UserList>();
                uLists = _oUserListDAL.GetUserDetailAll();
                var sList = uLists.Select(a => new
                {
                    a.id,
                    a.userName,
                    a.genderName,
                    a.sectorName,
                    a.jobProfile,
                    a.userRole,
                    a.firmName,
                    a.userMobile,
                    a.userEmail,
                    a.address,
                    a.status
                });
                return Ok(sList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        [HttpGet("Get-GetUserDetailToViewByID")]
        public IActionResult GetUserDetailToViewByID(int id)
        {
            try
            {
                UserList uList = _oUserListDAL.GetUserDetailToViewByID(id);
                if (uList != null)
                {
                    // Return only necessary user information
                    var responseData = new
                    {
                        id = uList.id,
                        userName = uList.userName,
                        genderName = uList.genderName,
                        sectorName = uList.sectorName,
                        jobProfile = uList.jobProfile,
                        userRole = uList.userRole,
                        firmName = uList.firmName,
                        userMobile = uList.userMobile,
                        userEmail = uList.userEmail,
                        address = uList.address,
                        status = uList.status
                    };
                }

                return Ok(uList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }


        [HttpGet("Get-GetUserDetailToEditByID")]
        public IActionResult GetUserDetailToEditByID(int id)
        {
            try
            {
                UserList uList = _oUserListDAL.GetUserDetailToEditByID(id);
                if (uList != null)
                {
                    // Return only necessary user information
                    var responseData = new
                    {
                        id = uList.id,
                        userRoleID = uList.userRoleID,
                        partnerID = uList.partnerID,
                        userName = uList.userName,
                        gender = uList.gender,
                        userMobile = uList.userMobile,
                        userEmail = uList.userEmail,
                        address = uList.address,
                        sectorID = uList.sectorID,
                        jobProfile = uList.jobProfile
                    };
                }

                return Ok(uList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }


        [HttpPost("Add-InsertUserData")]
        public IActionResult InsertUserData(UserListDTO uList)
        {
            try
            {
                bool result = _oUserListDAL.InsertUserData(uList);
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

        [HttpPut("Update-UpdateUserData")]
        public IActionResult UpdateUserData(UserListDTO uList)
        {
            try
            {
                bool result = _oUserListDAL.UpdateUserData(uList);
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


        [HttpPut("Update-ChangeUserStatus")]
        public IActionResult ChangeUserStatus(int id)
        {
            try
            {
                bool result = _oUserListDAL.ChangeUserStatus(id);
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

        [HttpPost("Login-ValidateUser")]
        public IActionResult ValidateUser(string loginID, string password)
        {
            try
            {
                UserList user = _oUserListDAL.ValidateUser(loginID, password);
                if (user != null)
                {
                    var userData = new
                    {
                        id = user.id,
                        userRoleID = user.userRoleID,
                        userRole = user.userRole,
                        userName = user.userName,
                        userMobile = user.userMobile,
                        userEmail = user.userEmail,
                        LastLogin = user.lastLogin
                    };
                    return Ok(userData);
                }
                else
                {
                    return BadRequest(new { message = "Invalid User Details" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }

        }
    }
}
