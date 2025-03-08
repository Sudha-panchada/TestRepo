using Community_Model.Login;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Community_Model.Forum;
using Community_Model.Articles;



namespace Community_Model
{
    public class CommunityDbContext:DbContext
    {

        public CommunityDbContext(DbContextOptions<CommunityDbContext> options) : base(options) { }
        public DbSet<SecurityQustions>  SecurityQustions { get; set; }
        public DbSet<LogIn> LogIn { get; set; }
        
        public DbSet<Forums> Forums { get; set; }
        public DbSet<ForumsReply> ForumsReply { get; set; } 
        public DbSet<PostArticle> postArticles { get; set; }

    }
}
