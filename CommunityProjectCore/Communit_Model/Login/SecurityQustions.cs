using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Model.Login
{
    public class SecurityQustions
    {
        [Key]
        public int QuestionId { get; set; }
        public string? QuestionName { get; set; }

    }
}
