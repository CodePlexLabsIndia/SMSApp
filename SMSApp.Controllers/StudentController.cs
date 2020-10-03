namespace SMSApp.Controllers
{
    #region Namespaces

    using System.Web.Mvc;
    using SMSApp.Entities;
    using SMSApp.Common;
    using System.Collections.Generic;
    using SMSApp.Controllers.ManagerRepository;

    #endregion
    public class StudentController : BaseController
    {
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Authorize]
        public ActionResult EducationDetails()
        {

            return View();
        }
        [HttpGet]
        [Authorize]
        public ActionResult EnrollCourse()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult EnrollCourse(EnrollCourse entity)
        {
            if (ModelState.IsValid)
            {
                StudentManager manager = new StudentManager();
                entity.Studentid = SessionManager.LoginUserInfo.UserID;
                int result = manager.SaveEnrollCourse(entity);
                if (result > 0)
                    TempData["errorMessege"] = "Course Enrolled Sucessfully.";
                else
                    TempData["errorMessege"] = "Some error occured.";
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult EnrollSports()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult EnrollSports(EnrollSports entity)
        {
            if (ModelState.IsValid)
            {
                StudentManager manager = new StudentManager();
                entity.Studentid = SessionManager.LoginUserInfo.UserID;
                int result = manager.SaveEnrollSports(entity);
                if (result > 0)
                    TempData["errorMessege"] = "Sports Enrolled Sucessfully.";
                else
                    TempData["errorMessege"] = "Some error occured.";
            }
            return View();
        }


        [HttpPost]
        [Authorize]
        public ActionResult EducationDetails(UserInfoEntity entity)
        {
            StudentManager manager = new StudentManager();
            entity.UserID = SessionManager.LoginUserInfo.UserID;
            int result = manager.SaveEducationInfo(entity);
            if (result > 0)
                TempData["errorMessege"] = "Education Details Added Sucessfully.";
            else
                TempData["errorMessege"] = "Some error occured.";
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult ParentsDetails()
        {

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult ParentsDetails(UserInfoEntity entity)
        {
            StudentManager manager = new StudentManager();
            entity.UserID = SessionManager.LoginUserInfo.UserID;
            int result = manager.SaveParentsInfo(entity);
            if (result > 0)
                TempData["errorMessege"] = "Guardian Details Added Sucessfully.";
            else
                TempData["errorMessege"] = "Some error occured.";
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult ViewGrade()
        {
            StudentManager manager = new StudentManager();
            StudentMarks obj = manager.ViewMarks(SessionManager.LoginUserInfo.UserID);
            return View("ViewGrade", obj);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ViewStudent()
        {
            AdminManager manager = new AdminManager();
            UserInfoEntity users = manager.GetUsersInformation(SessionManager.LoginUserInfo.UserID);
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
            return RedirectToAction("ViewStudent");
        }

        [HttpGet]
        [Authorize]
        public ActionResult SubmitAssignment()
        {
            return View(new Assignment { });
        }

        [HttpPost]
        public ActionResult SubmitAssignment(Assignment obj)
        {
            ProfessorManager manager = new ProfessorManager();
            obj.Userid = SessionManager.LoginUserInfo.UserID.ToInt();
            if (ModelState.IsValid)
            {
                manager.AddAssignment(obj);
                TempData["errorMessege"] = "Assignment Added Successfully...";
                return View("SubmitAssignment", new Assignment { });
            }
            else
            {
                return View("SubmitAssignment", obj);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Discussion()
        {
            List<Discussion> Discussion = new List<Discussion>();
            ProfessorManager manager = new ProfessorManager();
            Discussion = manager.GetDiscussion(SessionManager.LoginUserInfo.UserID, "ST");
            TempData["Discussion"] = Discussion;
            return View();
        }

        [HttpPost]
        public ActionResult Discussion(Discussion obj, FormCollection form)
        {
            StudentManager manager = new StudentManager();
            obj.Student_id = SessionManager.LoginUserInfo.UserID.ToInt();
            obj.id = form["Topic"].ToInt();
            manager.UpdateDiscussion(obj);
            TempData["errorMessege"] = "Discussion Added Successfully...";
            return RedirectToAction("Discussion");
        }

        [HttpGet]
        [Authorize]
        public ActionResult StudentFee()
        {
            return View(new StudentFee { });
        }

        [HttpPost]
        public ActionResult StudentFee(StudentFee obj, FormCollection form)
        {
            StudentManager manager = new StudentManager();
            obj.StudentID = SessionManager.LoginUserInfo.UserID.ToInt();
            obj.ProfessorID = form["ddlProfessor"].ToInt();
            obj.CourseID = form["ddlCourse"].ToInt();
            manager.InsertStudentFee(obj);
            TempData["errorMessege"] = "Student Fee Added Successfully...";
            return RedirectToAction("StudentFee");
        }

    }
}
