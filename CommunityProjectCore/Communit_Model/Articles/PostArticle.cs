using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Model.Articles
{
    [Table("PostArticle")]
    public class PostArticle
    {
        [Key]
        public int articleId { get; set; }

        public string? ArticleType { get; set; }

        public string? ArticleDescripstion { get; set; }

        public DateTime CurrentDate { get; set; }

        public int LoginId { get; set; }
        //public virtual ICollection<LogIn> LogIn { get; }
    }
}
