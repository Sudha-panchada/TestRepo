using Community_DAL.Articless;
using Community_Model.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_BAL.Article
{
    public class ArticleBal
    {
        private readonly ArticleRepository _objrepository;
        public ArticleBal(ArticleRepository objrepository)
        {
            _objrepository = objrepository;
        }

        public List<PostArticle> GetArticle()
        {
            try
            {
                return _objrepository.GetAllArticles();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PostArticle(PostArticle post)
        {
            bool postarticle = false;
            try
            {
                _objrepository.PostArticle(post);
                postarticle = true;
            }
            catch(Exception)
            {
                throw;
            }
            return postarticle;
        }
        public bool Delete(int id)
        {
            bool delete=false;
            try
            {
                _objrepository.DeleteArticle(id);
                delete = true;
            }
            catch (Exception)
            {
                throw;
            }
            return delete;
        }
        public bool Updatearticle(PostArticle post)
        {
            bool updatearticle=false;
            try
            {
                _objrepository.Update(post);
                updatearticle = true;
            }
            catch (Exception)
            {
                throw;
            }
            return updatearticle;
        }
    }
}
