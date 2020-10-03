
﻿namespace SMSApp.Controllers
{
    using System.Web.Mvc;  
    public class HomeController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Sports()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Academic()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult AboutUs()
        {
            return View();
        }
        [HttpGet]
        
        public ActionResult Home()
        {
            return View();
        }
    }
}


