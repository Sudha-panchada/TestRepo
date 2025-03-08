using Community_Model;
using Community_Model.Forum;
using Community_Model.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_DAL.Forumss
{
    public class ForumsRepository
    {
      

        private readonly CommunityDbContext _communityDbContext;
        public ForumsRepository(CommunityDbContext communityDbContext)
        {
            _communityDbContext = communityDbContext;
        }
        public List<Forums> GetAllForums()
        {
            List<Forums> objforums = new List<Forums>();
            try
            {
                objforums = (from f in _communityDbContext.Forums
                             join users in _communityDbContext.LogIn on f.LoginId equals users.LoginId
                             select (new Forums
                             {
                                 QuestionId = f.QuestionId,
                                 Question = f.Question,
                                 LoginId = f.LoginId,
                                 LogIn = users
                             })).ToList();
                return objforums;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool SaveForums(Forums forums)
        {
            bool issave = false;
            try
            {
                _communityDbContext.Forums.Add(forums);
                _communityDbContext.SaveChanges();
                issave = true;
            }
            catch (Exception)
            {
                throw;
            }
            return issave;
        }

        public bool SaveForumsReply(ForumsReply forumsreply)
        {
            bool result = false;
            try
            {
                _communityDbContext.ForumsReply.Add(forumsreply);
                _communityDbContext.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<ForumsReply> GetAllForumReplies()
        {
            List<ForumsReply> forumsReplies = new List<ForumsReply>();
            try
            {
                forumsReplies = _communityDbContext.ForumsReply.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return forumsReplies;
        }

        public bool DeleteForum(int ID)
        {
            bool isDeleted = false;
            try
            {
                var forums = _communityDbContext.Forums.Find(ID);
                if (forums != null)
                {
                    _communityDbContext.Forums.Remove(forums);
                    _communityDbContext.SaveChanges(true);
                    isDeleted = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isDeleted;
        }


        public bool DeleteForumReply(int id)
        {
            bool isdelete = false;
            var forumreply = _communityDbContext.ForumsReply.Find(id);
            try
            {
                _communityDbContext.ForumsReply.Remove(forumreply);
                _communityDbContext.SaveChanges();
                isdelete = true;
            }
            catch (Exception)
            {
                throw;
            }
            return isdelete;
        }

        public bool UpdateForumsReply(ForumsReply forumsReply)
        {
            bool isupdate = false;
            try
            {
                _communityDbContext.ForumsReply.Update(forumsReply);
                _communityDbContext.SaveChanges();
                isupdate = true;
            }
            catch (Exception)
            {
                throw;
            }
            return isupdate;
        }

        public bool UpdateForums(Forums forums)
        {
            bool isupdate = false;
            try
            {
                _communityDbContext.Forums.Update(forums);
                _communityDbContext.SaveChanges();
                isupdate = true;
            }
            catch (Exception) { throw; }
            return isupdate;
        }

    }
}
