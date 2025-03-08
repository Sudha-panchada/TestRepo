using Community_Model;
using Community_Model.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_DAL.Login
{
    public class LoginRepository
    {
      private readonly CommunityDbContext _communityDbContext;    
        public LoginRepository(CommunityDbContext communityDbContext)
        {
            _communityDbContext = communityDbContext;
        }
        public List<SecurityQustions> GetAllSecurityQuestions()
        {
            try
            {
                return _communityDbContext.SecurityQustions.ToList();
            }
            catch (Exception){ throw; }
        }
        public bool Registration(LogIn logIn)
        {
            try
            {
                logIn.Status = false;
                logIn.UserType = "User";
                _communityDbContext.LogIn.Add(logIn);
                _communityDbContext.SaveChanges();
                return true;
            }
            catch (Exception) { throw; }
        }
        public LogIn GetUserDetails(string? username,string? password)
        {
            try
            {
                return _communityDbContext.LogIn.FirstOrDefault(u => u.UserName == username && u.Password == password);
            }
            catch(Exception) { throw; }
        }
        public bool Userexists(string username)
        {
            try
            {
                bool isexists = false;
                var objuser = _communityDbContext.LogIn.Where(u => u.UserName == username).Select(u => u.UserName);
                if(objuser != null)
                {
                    isexists = true;
                }
                return isexists;
            }
            catch( Exception ) { throw; }
        }
        public string RetrievePassword(string username, string securityAnswer)
        {
            try
            {
                var user = _communityDbContext.LogIn.FirstOrDefault(u => u.UserName == username && u.SecurityAnswer == securityAnswer);
                return user.Password; // Return the password if the user exists.
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Updates the user's password.
        public bool UpdatePassword(string username, string oldPassword, string newPassword)
        {
            try
            {
                var user = _communityDbContext.LogIn.FirstOrDefault(u => u.UserName == username && u.Password == oldPassword);
                if (user != null)
                {
                    user.Password = newPassword;
                    _communityDbContext.SaveChanges();
                    return true;
                }
                return false; // Return false if user not found or old password doesn't match.
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
