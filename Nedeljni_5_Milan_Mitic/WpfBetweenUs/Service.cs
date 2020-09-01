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
    }
}

