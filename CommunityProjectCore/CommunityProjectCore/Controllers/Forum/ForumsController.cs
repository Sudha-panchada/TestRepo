using Community_BAL.Forum;
using Community_Model;
using Community_Model.Forum;
using CommunityProjectCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityProjectCore.Controllers.Forum
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumsController : ControllerBase
    {

        private readonly ForumsBal forumsService;
        public ForumsController(CommunityDbContext communityDbCotext)
        {
            forumsService = new ForumsBal(new
                Community_DAL.Forumss.ForumsRepository(communityDbCotext));
        }
        [HttpGet(Name = "GetAllForums")]
        public List<Forums> GetForums()
        {
            try
            {
                List<Forums> forums = forumsService.GetForums();
                return forums;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// to get the all forumsreplies
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllForumsReplies")]
        public List<ForumsReply> GetForumsReplies()
        {
            try
            {
                List<ForumsReply> forumsReplies = forumsService.GetAllForumsReplies();
                return forumsReplies;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost(Name = "SaveForum")]
        /// <summary>
        ///
        /// </summary>
        /// <param name="forum"></param>
        /// <returns></returns>
        public string SaveForums(Forums forum)
        {
            string message = string.Empty;
            try
            {
                var result = forumsService.SaveForums(forum);
                if (result)
                {
                    message = Common.SuccessMessage;
                }
                else
                    message = Common.ErrorMessage;
            }
            catch (Exception)
            {

                throw;
            }
            return message;
        }
        [HttpPost("SaveForumsReply")]
        /// <summary>
        ///
        /// </summary>
        /// <param name="forumsReply"></param>
        /// <returns></returns>
        public string SaveForumsReply(ForumsReply forumsReply)
        {
            string message = string.Empty;
            try
            {
                var result = forumsService.SaveForumsReply(forumsReply);
                if (result)
                {
                    message = Common.SuccessMessage;
                }
                else
                    message = Common.ErrorMessage;
            }
            catch (Exception)
            {

                throw;
            }
            return message;
        }
        /// <summary>
        /// to save the forums data
        /// </summary>
        /// <param name="forums"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateForums")]
        public string UpdateForums(Forums forums)
        {
            string message = string.Empty;
            try
            {
                var result = forumsService.UpdateForums(forums);
                if (result)
                {
                    message = Common.SuccessMessage;
                }
                else
                    message = Common.ErrorMessage;
            }
            catch (Exception)
            {

                throw;
            }
            return message;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="forumsReply"></param>
        /// <returns></returns>
        [HttpPut("UpdateForumsReply/forumsReply")]
        public string UpdateForumsReply(ForumsReply forumsReply)
        {
            string message = string.Empty;
            try
            {
                var result = forumsService.UpdateForumsReply(forumsReply);
                if (result)
                {
                    message = Common.SuccessMessage;
                }
                else
                    message = Common.ErrorMessage;
            }
            catch (Exception)
            {

                throw;
            }
            return message;
        }
        [HttpDelete("DeleteForums")]
        public string DeleteForums(int ID)
        {
            string message = string.Empty;
            try
            {
                var result = forumsService.DeleteForum(ID);
                if (result)
                {
                    message = Common.SuccessMessage;
                }
                else
                    message = Common.ErrorMessage;
            }
            catch (Exception)
            {

                throw;
            }
            return message;
        }

        [HttpDelete("ID")]
        public string DeleteForumsReply(int ID)
        {
            string message = string.Empty;
            try
            {
                var result = forumsService.DeleteForumReply(ID);
                if (result)
                {
                    message = Common.SuccessMessage;
                }
                else
                    message = Common.ErrorMessage;
            }
            catch (Exception)
            {

                throw;
            }
            return message;
        }


    }
}
