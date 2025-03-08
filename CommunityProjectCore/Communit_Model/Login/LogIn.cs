using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Model.Login
{
    public class LogIn
    {
        [Key]
        public int LoginId { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int QuestionId {  get; set; }

        public string? SecurityAnswer { get; set; }
        public bool Status { get; set; }
        public string? UserType { get; set; }

    }
}
