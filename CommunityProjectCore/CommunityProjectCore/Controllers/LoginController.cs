using Community_Model;
using Community_Model.Login;
using Community_BAL.Login;
using Community_DAL.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace CommunityProjectCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginBal objloginbal;
        public LoginController(CommunityDbContext context)
        {
            objloginbal = new LoginBal(new Community_DAL.Login.LoginRepository(context));
        }
        
        [HttpGet(Name="GetAllSecurityQuestions")] 
        public IActionResult GetAllSecurityQuestions()
        {
            try
            {
                var securityQuestions = objloginbal.GetAllSecurityQuestions(); 
                return Ok(securityQuestions);
            }
            catch (Exception )
            {
                throw;
            }
        }
        
        [HttpPost("Register")]
        public IActionResult Register(LogIn userLoginInfo)
        {
            try
            {
                bool isRegister = objloginbal.Registration(userLoginInfo); 
                if (isRegister)
                {
                    return Ok("Registration is successful"); 
                }
                return BadRequest("Registration failed ! Please try again "); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetUserDetails/{username}/{password}")]
        public LogIn GetUser(string username, string password)
        {
            try
            {
                return objloginbal.GetUser(username, password);
            }
            catch (Exception)
            {
                throw;
            }
        }     
       
        [HttpGet("Isuserexisted/username")] 
        public bool Isuserexisted(string username)
        {
            try
            {
                return objloginbal.Iuserexists(username); 
            }
            catch (Exception)
            {
                throw; 
            }
        }

        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(string username,string securityAnswer)
        {
            try
            {
                var result = objloginbal.ForgotPassword(username, securityAnswer);
                if (result != null)
                {
                    return Ok(result); // Return the password or a password reset token.
                }
                return BadRequest("Invalid username or security answer.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Action to handle password change.
        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(dynamic changePasswordPayload)
        {
            try
            {
                // Parse the dynamic payload
                var payloadJson = (System.Text.Json.JsonElement)changePasswordPayload;
                // Extract properties using GetProperty
                string username = payloadJson.GetProperty("username").GetString();
                string oldPassword = payloadJson.GetProperty("oldPassword").GetString();
                string newPassword = payloadJson.GetProperty("newPassword").GetString();
                // Call your BAL method with parsed values
                var isChanged = objloginbal.ChangePassword(username, oldPassword, newPassword);
                if (isChanged)
                {
                    return Ok("Password changed successfully.");
                }
                return BadRequest("Password change failed. Please check your inputs.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            ///{ "username": "Rajup",
            //        "oldPassword": "raju123",
            //"newPassword": "raju@145"
        //}
        }
    }
}


