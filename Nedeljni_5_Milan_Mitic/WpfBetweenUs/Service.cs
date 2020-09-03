using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}

