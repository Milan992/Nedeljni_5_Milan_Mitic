using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfBetweenUs.Model;

namespace WpfBetweenUs
{
    class Service
    {
        /// <summary>
        /// Adds new account to a database table.
        /// </summary>
        /// <param name="account"></param>
        public void AddAccount(tblAccount account)
        {
            using (BetweenUsEntities context = new BetweenUsEntities())
            {
                tblAccount newAccount = new tblAccount
                {
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Gender = account.Gender,
                    UserName = account.UserName,
                    Pass = account.Pass
                };
                context.tblAccounts.Add(newAccount);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Checks if account with username and password exists in tblAccount in database BetweenUs.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsUser(string username, string password, out tblAccount account)
        {
            try
            {
                using (BetweenUsEntities context = new BetweenUsEntities())
                {
                    tblAccount accountToLogIn = (from a in context.tblAccounts where a.UserName == username && a.Pass == password select a).First();
                    account = accountToLogIn;
                    return true;
                }
            }
            catch 
            {
                account = null;
                return false;
            }
        }

        /// <summary>
        /// Adds new post to tblPost in database.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="text"></param>
        public void Post(tblAccount account, string text)
        {
            using (BetweenUsEntities context = new BetweenUsEntities())
            {
                tblPost post = new tblPost
                {
                    AccountID = account.AccountID,
                    Content = text,
                    PostTime = DateTime.Now,
                    LikesNumber = 0
                };
                context.tblPosts.Add(post);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets all posts from view vwPost in database.
        /// </summary>
        /// <returns></returns>
        public List<vwPost> GetAllPosts()
        {
            try
            {
                using (BetweenUsEntities context = new BetweenUsEntities())
                {
                    return (from l in context.vwPosts select l).ToList();
                }
            }
            catch 
            {
                return null;
            }
        }

        public void Like(vwPost post, tblAccount account)
        {
            using (BetweenUsEntities context = new BetweenUsEntities())
            {
                try
                {
                    tblLike like = (from l in context.tblLikes where l.PostID == post.PostID && l.AccountID == account.AccountID select l).First();
                    MessageBox.Show("You already like this post");
                }
                catch
                {
                    tblLike like = new tblLike
                    {
                        PostID = post.PostID,
                        AccountID = account.AccountID
                    };
                    context.tblLikes.Add(like);

                    tblPost postToLike = (from p in context.tblPosts where p.PostID == post.PostID select p).First();
                    postToLike.LikesNumber++;
                    context.SaveChanges();
                }
            }
        }
    }
}

