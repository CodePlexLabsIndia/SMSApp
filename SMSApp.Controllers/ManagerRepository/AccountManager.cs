using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSApp.DataAccess;
using SMSApp.Entities;
using SMSApp.Common;

namespace SMSApp.Controllers
{
    public class AccountManager
    {
        public bool VerifyAuthentication(string userName, string password)
        {
            return new AccountContext().VerifyAuthentication(userName, password);
        }

        public UserInfoEntity GetUserDeatils(string userName, string password)
        {
            return new AccountContext().GetUserDeatils(userName, password);
        }

        internal bool UpdatePassword(string newpwd, int membershipid)
        {
            return new AccountContext().UpdatePassword(newpwd, membershipid);         
        }
    }
}
