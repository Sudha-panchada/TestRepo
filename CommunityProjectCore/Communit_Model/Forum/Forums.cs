using Community_Model.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Model.Forum
{
    [Table("Forums")]
    public class Forums
    {
        [Key]
        public int QuestionId { get; set; }
        public string? Question {  get; set; }
        public int LoginId {  get; set; }

        [ForeignKey("LoginId")]
        [NotMapped]
        public virtual LogIn? LogIn { get; set; }

        //public virtual ICollection<LogIn> LogIns { get; }
    }
}
