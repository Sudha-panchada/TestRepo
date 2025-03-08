using Community_Model.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Model.Forum
{
    public class ForumsReply
    {
        [Key]
        public int ReplyId {  get; set; }
        public int QuestionId {  get; set; }
        public string? Reply {  get; set; }
        public int LoginId {  get; set; }

        //public virtual ICollection<Forums> Forums { get; }
        //public virtual ICollection<LogIn> LogIns { get; }
    }
}
