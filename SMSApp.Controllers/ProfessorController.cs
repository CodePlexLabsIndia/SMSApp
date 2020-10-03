using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using SMSApp.Entities;
using SMSApp.Common;
using SMSApp.Controllers.ManagerRepository;
using System.ComponentModel;

namespace SMSApp.Controllers
{
    public class ProfessorController : BaseController
    {
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        [Authorize]
        public ActionResult Professor()
        {
            ProfessorManager manager = new ProfessorManager();
            List<UserInfoEntity> myList = new List<UserInfoEntity>();
            myList = (from x in manager.GetStudents(2)
                      where x.UserID == SessionManager.LoginUserInfo.UserID
                      select x).ToList();
            if (myList.Count > 0)
            {
                return View("Professor", myList[0]);
            }
            else
            {
                return View("Professor", new UserInfoEntity { });
            }

        }
        [HttpPost]
        public ActionResult Professor(FormCollection data, UserInfoEntity entity)
        {
            ProfessorManager manager = new ProfessorManager();
            // entity.pic = data["img"].ToStr();
            entity.DepartmentID = data["DepartmentID"].ToInt();
            entity.CourseID = data["CourseID"].ToInt();
            entity.EmailAddress = data["EmailAddress"].ToStr();
            entity.DateOfBirth = data["DateOfBirth"].ToDateTime();
            entity.DateOfJoining = data["dateOfJoining"].ToDateTime();
            entity.FirstName = data["FirstName"].ToStr();
            entity.LastName = data["LastName"].ToStr();
            entity.Gender = data["Gender"].ToStr();
            entity.PhoneNumber = data["PhoneNumber"].ToStr();
            entity.UserID = SessionManager.LoginUserInfo.UserID;

            manager.UpdateProfessor(entity);
            TempData["errorMessege"] = null;
            TempData["errorMessege"] = "Data Updated Successfully..";
            List<UserInfoEntity> myList = new List<UserInfoEntity>();
            myList = (from x in manager.GetStudents(2)
                      where x.UserID == SessionManager.LoginUserInfo.UserID
                      select x).ToList();
            if (myList.Count > 0)
            {
                return View("Professor", myList[0]);
            }
            else
            {
                return View("Professor", new UserInfoEntity { });
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult ViewStudents()
        {
            ProfessorManager manager = new ProfessorManager();
            List<UserInfoEntity> Students = new List<UserInfoEntity>();
            Students = manager.GetStudentsByProf(3, SessionManager.LoginUserInfo.UserID);
            return View("ViewStudents", Students);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ViewDiscussions()
        {
            ProfessorManager manager = new ProfessorManager();
            ViewBag.Student_id = new SelectList(manager.GetDDLStudents(2).ToList(), "UserId", "FirstName");
            List<Discussion> Students = new List<Discussion>();

            List<Discussion> Discussion = new List<Discussion>();
            ProfessorManager profManager = new ProfessorManager();
            Discussion = manager.GetDiscussion(SessionManager.LoginUserInfo.UserID, "PR");

            return View("ViewDiscussions", Discussion);
        }

        [HttpPost]
        public ActionResult ViewDiscussions(Discussion obj)
        {
            ProfessorManager manager = new ProfessorManager();
            obj.Professor_Id = SessionManager.LoginUserInfo.UserID;
            ViewBag.Student_id = new SelectList(manager.GetDDLStudents(2).ToList(), "UserId", "FirstName");
            obj = manager.AddProfDiscussion(obj);
            return RedirectToAction("ViewDiscussions");
        }

        [HttpGet]
        [Authorize]
        [ActionName("Assignment")]
        public ActionResult Assignment_Get()
        {
            return View("Assignment", new Assignment { });
        }
        [HttpPost]
        [ActionName("Assignment")]
        public ActionResult Assignment_Post(Assignment obj)
        {
            ProfessorManager manager = new ProfessorManager();
            obj.Userid = SessionManager.LoginUserInfo.UserID.ToInt();
            if (ModelState.IsValid)
            {
                manager.AddAssignment(obj);
                TempData["errorMessege"] = "Assignment Added Successfully...";
                return View("Assignment", new Assignment { });
            }
            else
            {
                return View("Assignment", obj);
            }


        }

        [HttpGet]
        [Authorize]
        [ActionName("ViewMarks")]
        public ActionResult ViewMarks_Get()
        {
            ProfessorManager manager = new ProfessorManager();
            ViewBag.StudentId = new SelectList(manager.GetDDLStudents(2).ToList(), "UserId", "FirstName");
            return View("ViewMarks", new StudentMarks { });
        }
        [HttpPost]
        [ActionName("ViewMarks")]
        public ActionResult ViewMarks_Post(StudentMarks Obj)
        {

            ProfessorManager manager = new ProfessorManager();
            Obj.Professorid = SessionManager.LoginUserInfo.UserID;
            Obj.createdDate = DateTime.Now;
            ViewBag.StudentId = new SelectList(manager.GetDDLStudents(2).ToList(), "UserId", "FirstName");
            if (ModelState.IsValid)
            {
                TempData["errorMessege"] = "Successfully Inserted..";
                manager.AddMarks(Obj);
                return View("ViewMarks", new StudentMarks { });
            }
            else
            {
                return View("ViewMarks", Obj);
            }
        }

        [HttpGet]
        [Authorize]
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
                ProfessorManager manager = new ProfessorManager();
                Obj.CreatedById = SessionManager.LoginUserInfo.UserID;
                Obj.CreatedDate = DateTime.Now;
                TempData["errorMessege"] = "Successfully Inserted..";
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
