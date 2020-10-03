namespace SMSApp.Controllers
{
    #region Namespaces

    using System.Web.Mvc;
    using SMSApp.Entities;
    using SMSApp.Common;
    using System.Collections.Generic;
    using System;

    #endregion

    public class AdminController : BaseController
    {
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Authorize]
        public ActionResult ViewRank()
        {
            AdminManager manager = new AdminManager();
            List<StudentRanks> ranks = manager.GetRanksInformation();
            return View("StudentRank",ranks);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddProfessor()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddProfessor(FormCollection data, UserInfoEntity entity)
        {
            AdminManager manager = new AdminManager();
            entity.DepartmentID = data["ddlDepartment"].ToInt();
            entity.CourseID = data["ddlCourse"].ToInt();
            entity.Password = EncryptionDecryption.Encrypt("&^%&", TypeCommonExtensions.GeneratePassword(6).ToStr());
            entity.RoleID = (int)Role.Professor;
            entity.UserName = entity.LastName + entity.FirstName;
            entity.Gender = data["ddlGender"].ToStr();
            manager.InsertUser(entity);
            if (entity.MembershipID > 0)
                TempData["errorMessege"] = "Professor Added Sucessfully.";
            else
                TempData["errorMessege"] = "Some error occured.";
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddStudent(FormCollection data, UserInfoEntity entity)
        {
            AdminManager manager = new AdminManager();
            entity.DepartmentID = data["ddlDepartment"].ToInt();
            entity.CourseID = data["ddlCourse"].ToInt();
            entity.Password = EncryptionDecryption.Encrypt("&^%&", TypeCommonExtensions.GeneratePassword(6).ToStr());
            entity.RoleID = (int)Role.Student;
            entity.UserName = entity.LastName + entity.FirstName;
            entity.Gender = data["ddlGender"].ToStr();
            entity.ProffesorID = data["ddlProfessor"].ToInt();
            manager.InsertUser(entity);
            if (entity.MembershipID > 0)
                TempData["errorMessege"] = "Student Added Sucessfully.";
            else
                TempData["errorMessege"] = "Some error occured.";
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult ViewEditProfessor()
        {
            AdminManager manager = new AdminManager();
            List<UserInfoEntity> users = manager.GetUsers((int)Role.Professor);
            return View(users);
        }

        public ActionResult EditProfessor(int UserID)
        {
            AdminManager manager = new AdminManager();
            UserInfoEntity users = manager.GetUsersInformation(UserID);
            return View(users);
        }

        public ActionResult UpdateProfessor(FormCollection data, UserInfoEntity entity)
        {
            AdminManager manager = new AdminManager();
            entity.DepartmentID = data["ddlDepartment"].ToInt();
            entity.CourseID = data["ddlCourse"].ToInt();
            entity.Gender = data["ddlGender"].ToStr();
            int result = manager.UpdateUser(entity);
            if (result > 0)
                TempData["errorMessege"] = "Professor Updated Sucessfully.";
            else
                TempData["errorMessege"] = "Some error occured.";
            return RedirectToAction("ViewEditProfessor");
        }

        [HttpGet]
        [Authorize]
        public ActionResult ViewEditStudent()
        {
            AdminManager manager = new AdminManager();
            List<UserInfoEntity> users = manager.GetUsers((int)Role.Student);
            return View(users);
        }

        public ActionResult EditStudent(int UserID)
        {
            AdminManager manager = new AdminManager();
            UserInfoEntity users = manager.GetUsersInformation(UserID);
            return View(users);
        }

        public ActionResult UpdateStudent(FormCollection data, UserInfoEntity entity)
        {
            AdminManager manager = new AdminManager();
            entity.DepartmentID = data["ddlDepartment"].ToInt();
            entity.CourseID = data["ddlCourse"].ToInt();
            entity.Gender = data["ddlGender"].ToStr();
            entity.ProffesorID = data["ddlProfessor"].ToInt();
            int result = manager.UpdateUser(entity);
            if (result > 0)
                TempData["errorMessege"] = "Student Updated Sucessfully.";
            else
                TempData["errorMessege"] = "Some error occured.";
            return RedirectToAction("ViewEditStudent");
        }

        [HttpGet]
        [ActionName("Announcement")]
        public ActionResult Announcement_Get()
        {
            return View("Announcement", new Announcement { });
        }
        [HttpPost]
        [ActionName("Announcement")]
        public ActionResult Announcement_Post(Announcement Obj)
        {
            if (ModelState.IsValid)
            {
                TempData["errorMessege"] = null;
                AdminManager manager = new AdminManager();
                Obj.CreatedById = SessionManager.LoginUserInfo.UserID;
                Obj.CreatedDate = DateTime.Now;
                TempData["errorMessege"] = "Successfully Inserted.";
                manager.AddAnnouncement(Obj);
                return View("Announcement", new Announcement { });
            }
            else
            {
                return View("Announcement", Obj);
            }
        }
    }
}
