using Community_BAL.Article;
using Community_BAL.Forum;
using Community_Model;
using Community_Model.Articles;
using Community_Model.Forum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityProjectCore.Controllers.Articl
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleBal _objarticle;
        public ArticleController(CommunityDbContext communityDbCotext)
        {
            _objarticle = new ArticleBal(new
                Community_DAL.Articless.ArticleRepository(communityDbCotext));
        }
        [HttpGet]
        public List<PostArticle> GetAllArticle()
        {
            try
            {
                List<PostArticle> forums = _objarticle.GetArticle();
                return forums;
            }
            catch (Exception)
            {
                throw;
            }        
        }

        [HttpPost("SaveArticles")]
        public string Savearticles(PostArticle article)
        {
            string message = string.Empty;
            try
            {
                var result = _objarticle.PostArticle(article);
                if (result)
                {
                    message = "Daata Saveed";
                }
                else
                {
                    message = "Data failed to save please try again";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return message;
        }
        [HttpDelete("DeleteArticle")]
        public string DeleteArticle(int ID)
        {
            string message = string.Empty;
            try
            {
                var result = _objarticle.Delete(ID);
                if (result)
                {
                    message = "Delete successfully!";
                }
                else
                    message = "Deleted failed please try again!";
            }
            catch (Exception)
            {

                throw;
            }
            return message;
        }
        [HttpPut("UpdateArticle")]

        public string UpdateForumsReply(PostArticle article)
        {
            string message = string.Empty;
            try
            {
                var result = _objarticle.Updatearticle(article);
                if (result)
                {
                    message = "Data updated!";
                }
                else
                    message = "Data failed to update please try again!";
            }
            catch (Exception)
            {

                throw;
            }
            return message;
        }

    }
}
