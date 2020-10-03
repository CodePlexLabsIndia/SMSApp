namespace SMSApp.Controllers
{
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        protected override bool DisableAsyncSupport
        {
            get { return true; }
        }
    }
}
