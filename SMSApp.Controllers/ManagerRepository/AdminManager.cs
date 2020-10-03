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
    public class AdminManager
    {
        public UserInfoEntity InsertUser(UserInfoEntity entity)
        {
            return new AdminContext().InsertUser(entity);
        }

        public List<UserInfoEntity> GetUsers(int roleid)
        {
            return new AdminContext().GetUser(roleid);
        }

        public UserInfoEntity GetUsersInformation(int userID)
        {
            return new AdminContext().GetUserInfo(userID);
        }

        public  List<StudentRanks> GetRanksInformation()
        {
            return new AdminContext().GetRanksInformation();
        }

        public int UpdateUser(UserInfoEntity entity)
        {
            return new AdminContext().UpdateUser(entity);
        }

        internal void AddAnnouncement(Announcement obj)
        {
            new AdminContext().AddAnnouncement(obj);
        }
    }
}
