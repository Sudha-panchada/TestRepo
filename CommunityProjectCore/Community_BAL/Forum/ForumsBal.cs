using Community_DAL.Forumss;
using Community_DAL.Login;
using Community_Model.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_BAL.Forum
{
    public class ForumsBal
    {

        //to create the repo varaible
        private readonly ForumsRepository forumsRepository;
        public ForumsBal(ForumsRepository repository)
        {
            forumsRepository = repository;
        }
        public List<Forums> GetForums()
        {
            try
            {
                List<Forums> forums = forumsRepository.GetAllForums();
                return forums;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ForumsReply> GetAllForumsReplies()
        {
            try
            {
                List<ForumsReply> forumsReplies = forumsRepository.GetAllForumReplies();
                return forumsReplies;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// to save the forums data
        /// </summary>
        /// <param name="forums">forums argument is Forum type </param>
        /// <returns></returns>
        public bool SaveForums(Forums forums)
        {
            bool isSave = false;
            try
            {
                isSave = forumsRepository.SaveForums(forums);
            }
            catch (Exception)
            {

                throw;
            }
            return isSave;
        }

        /// <summary>
        /// to save the forums reply
        /// </summary>
        /// <param name="forumsReply">forumsReply is ForumsReply type</param>
        /// <returns></returns>
        public bool SaveForumsReply(ForumsReply forumsReply)
        {
            bool isSave = false;
            try
            {
                //calling Dal layer method
                isSave = forumsRepository.SaveForumsReply(forumsReply);
            }
            catch (Exception)
            {
                throw;
            }
            return isSave;
        }
        public bool DeleteForumReply(int ID)
        {
            try
            {
                return forumsRepository.DeleteForumReply(ID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteForum(int ID)
        {
            try
            {
                return forumsRepository.DeleteForum(ID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateForumsReply(ForumsReply forumsReply)
        {
            try
            {
                return forumsRepository.UpdateForumsReply(forumsReply);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="forums"></param>
        /// <returns></returns>
        public bool UpdateForums(Forums forums)
        {
            try
            {
                return forumsRepository.UpdateForums(forums);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}

