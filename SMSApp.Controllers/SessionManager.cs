using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSApp.Entities;

namespace SMSApp.Controllers
{
    public class SessionManager
    {
        public static bool IsCurrentUserSessionAlive()
        {
            return LoginUserInfo == null;
        }

        public static UserInfoEntity LoginUserInfo
        {
            get
            {
                return HttpContext.Current.Session["LoginUserInfo"] as UserInfoEntity;
            }
            set
            {
                HttpContext.Current.Session["LoginUserInfo"] = value;
            }
        }
    }
}
