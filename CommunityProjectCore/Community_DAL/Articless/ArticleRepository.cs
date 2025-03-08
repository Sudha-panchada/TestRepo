using Community_Model;
using Community_Model.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_DAL.Articless
{
    public class ArticleRepository
    {
        private readonly CommunityDbContext _objdbcontext;
        public ArticleRepository(CommunityDbContext objdbcontext)
        {
            _objdbcontext = objdbcontext;
        }
        public List<PostArticle> GetAllArticles()
        {
            try
            {
                return _objdbcontext.postArticles.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PostArticle(PostArticle article)
        {
            var post = false;
            try
            {
                _objdbcontext.postArticles.Add(article);
                _objdbcontext.SaveChanges();
                post= true;
            }
            catch (Exception)
            {
                throw;
            }
            return post;
        }

        public bool DeleteArticle(int id)
        {
            var del = false;
            var articleid =_objdbcontext.postArticles.Find(id);
            try
            {
                _objdbcontext.postArticles.Remove(articleid);
                _objdbcontext.SaveChanges();
                del = true;
            }
            catch (Exception)
            {

                throw;
            }
            return del;
        }
        public bool Update(PostArticle article)
        {
            var update=false;
            
            try
            {
                _objdbcontext.postArticles.Update(article);
                 _objdbcontext.SaveChanges();
                update = true;
            }
            catch(Exception)
            {
                throw;
            }
            return update;
        }
    }
}
