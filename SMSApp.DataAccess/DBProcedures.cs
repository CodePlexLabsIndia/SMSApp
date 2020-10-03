using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.DataAccess
{
    public static class DBProcedures
    {
        public static string GET_RANKS = "[ASP].[GET_RANKS]";
        public static string USER_AUTHENTICATION = "[ASP].[Verify_Authentication]";
        public static string UPDATE_PASSWORD = "sp_UpdatePassword";
        public static string GET_USER_DETAILS = "[ASP].[Get_User_Details]";
        public static string INSERT_USER_INFO = "[ASP].[Insert_User_Details]";
        public static string GET_USERS_LIST = "[ASP].[Get_UsersInformation]";
        public static string UPDATE_PROFESSOR = "[ASP].[Update_Professor_Details]";
        public static string GET_STUDENTS = "[ASP].[Get_Students_Information]";
        public static string ADD_DISCUSSION_PROFESSOR = "[ASP].[Add_Discussion_Profosser]";
        public static string ADD_ASSIGNMENT = "[ASP].[Add_Assignment]";
        public static string GET_DDL_USERS = "[ASP].[Get_DDL_Users]";
        public static string GET_DDL_COURSE = "[ASP].[Get_DDL_Course]";
        public static string GET_DDL_Announcement = "[ASP].[GET_DDL_Announcement]";
        public static string GET_DDL_DEPARTMENT = "[ASP].[Get_DDL_Department]";
        public static string ADD_MARKS = "[ASP].[Add_Student_Marks]";
        public static string GET_USER_INFO_FOR_EDIT = "[ASP].[Get_User_Information_For_Edit]";
        public static string UPDATE_USER_INFORMATION = "[ASP].[Update_User_Details]";
        public static string ADD_ANNOUNCEMENT = "[ASP].[ADD_ANNOUNCEMENT]";
        public static string VIEW_MARKS = "[ASP].[VIEW_MARKS]";
        public static string UDATE_STUDENT_EDUCATION_INFO = "[ASP].[UDATE_STUDENT_EDUCATION_INFO]";
        public static string UDATE_STUDENT_PARENT_INFO = "[ASP].[UDATE_STUDENT_PARENT_INFO]";
        public static string ADD_COURSE_ENROLL = "[ADD_COURSE_ENROLL]";
        public static string GET_DDL_SPORTSTYPE = "GET_DDL_SPORTSTYPE";
        public static string ADD_SPORTS_ENROLL = "ADD_SPORTS_ENROLL";
        public static string GET_STUDENT_ASSIGNMENT_TOPIC = "[ASP].[Get_Student_Topic]";
        public static string GET_STUDENT_ASSIGNMENT_WORK = "[ASP].[Get_Student_AssigmentWork]";
        public static string GET_STUDENT_DISCUSSION = "ASP.Get_Student_Discussions";
        public static string UPDATE_STUDENT_DISCUSSION = "ASP.Update_Student_Discussions";
        public static string INSERT_STUDENT_FEE = "ASP.Insert_Student_Fee";
        public static string GET_ANNOUCEMNET = "ASP.View_Annoucement";
        public static string GET_STUDENT_BY_PROFESSOR = "[ASP].[Get_Students_Information_By_Prof]";
        public static string GET_DISCUSSION_GRID = "[ASP].[GET_DISCUSSION]";
    }
}
