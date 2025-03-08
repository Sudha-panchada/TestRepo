using Community_Model.Login;
using Community_DAL.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_BAL.Login
{
    public class LoginBal
    {
        private readonly LoginRepository _objrepository;

        public LoginBal(LoginRepository objrepository)
        {
            _objrepository = objrepository;
        }
        public List<SecurityQustions> GetAllSecurityQuestions()
        {
            try
            {
                return _objrepository.GetAllSecurityQuestions();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Registration(LogIn login)
        {
            try
            {
                return _objrepository.Registration(login);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public LogIn  GetUser(string username,string password)
        {
            try
            {
                return _objrepository.GetUserDetails(username, password);
            }
            catch(Exception) { throw; }
        }
         public bool Iuserexists(string username)
        {
            try
            {
                return _objrepository.Userexists(username);
            }
            catch (Exception) { throw; }
        }
        public string ForgotPassword(string username, string securityAnswer)
        {
            try
            {
                return _objrepository.RetrievePassword(username,securityAnswer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Handles password change logic.
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            try
            {
                return _objrepository.UpdatePassword(username, oldPassword, newPassword);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}

