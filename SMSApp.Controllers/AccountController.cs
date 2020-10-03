namespace SMSApp.Controllers
{
    using System.Web.Mvc;
    using SMSApp.Common;
    using System.Web.Security;

    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View("Index");
        }

        [HttpGet]     
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
         [Authorize]
         [ActionName("ChangePassword")]
        public ActionResult ChangePassword_POST()
        {
            string newpwd = Request.Form["txtNewPwd"].ToStr();
            int membershipid = SessionManager.LoginUserInfo.MembershipID;
            AccountManager mgr = new AccountManager();
            bool res=mgr.UpdatePassword(newpwd, membershipid);
            TempData["errorMessege"] = "Password updated Sucessfully.";
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection data)
        {
            TempData.Clear();
            AccountManager manager = new AccountManager();
            if (manager.VerifyAuthentication(data[0].ToStr(), data[1].ToStr()))
            {
                FormsAuthentication.SetAuthCookie(data[0].ToStr(), false);
                SessionManager.LoginUserInfo = manager.GetUserDeatils(data[0].ToStr(), data[1].ToStr());
                switch (SessionManager.LoginUserInfo.RoleID)
                {
                    case 1:
                        return RedirectToAction("Index", "Admin");
                    case 2:
                        return RedirectToAction("Index", "Professor");
                    case 3:
                        return RedirectToAction("Index", "Student");
                    default:
                        return View("NotImplemented");
                }
            }
            else
            {
                TempData["ErrorMessege"] = "Invalid Login Credentials";
                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Index");
        }      
    }
}
