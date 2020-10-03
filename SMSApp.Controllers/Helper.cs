namespace SMSApp.Controllers
{
    using SMSApp.DataAccess;
    using SMSApp.Entities;
    using SMSApp.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public static class Helper
    {
        public static List<Professor> GetDDLProfessor(int role)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            List<Professor> obj = new List<Professor>();
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_DDL_USERS;
                cmd.Parameters.AddWithValue("@role", role);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Professor entity = new Professor();
                    entity.ProffesorID = dr["userid"].ToInt();
                    entity.ProffesorName = dr["FirstName"].ToStr();
                    obj.Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                cmd.Dispose();
            }
            return obj;
        }

        public static List<Course> GetDDLCourse()
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            List<Course> obj = new List<Course>();
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_DDL_COURSE;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Course entity = new Course();
                    entity.CourseID = dr["Course_Id"].ToInt();
                    entity.CourseName = dr["CourseName"].ToStr();
                    obj.Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                cmd.Dispose();
            }
            return obj;
        }

        public static List<Course> GetDDLSportsType()
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            List<Course> obj = new List<Course>();
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_DDL_SPORTSTYPE;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Course entity = new Course();
                    entity.CourseID = dr["sports_Id"].ToInt();
                    entity.CourseName = dr["Name"].ToStr();
                    obj.Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                cmd.Dispose();
            }
            return obj;
        }

        public static List<AnnouncementType> GetDDLAnnouncement()
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            List<AnnouncementType> obj = new List<AnnouncementType>();
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_DDL_Announcement;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AnnouncementType entity = new AnnouncementType();
                    entity.AnnouncementID  = dr["A_Id"].ToInt();
                    entity.AnnouncementName  = dr["AName"].ToStr();
                    obj.Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                cmd.Dispose();
            }
            return obj;
        }

        public static List<Department> GetDDLDepartment()
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            List<Department> obj = new List<Department>();
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_DDL_DEPARTMENT;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Department entity = new Department();
                    entity.DepartmentID = dr["Dept_Id"].ToInt();
                    entity.DepartmentName = dr["Dept_Desc"].ToStr();
                    obj.Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                cmd.Dispose();
            }
            return obj;
        }

        public static List<Assignment> GetStudentAssigmentTopic(int studentID)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            List<Assignment> obj = new List<Assignment>();
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_STUDENT_ASSIGNMENT_TOPIC;
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Assignment entity = new Assignment();
                    entity.assignment_Id = dr["assignment_id"].ToInt();
                    entity.Topic = dr["Topic"].ToStr();
                    obj.Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                cmd.Dispose();
            }
            return obj;
        }

        public static List<Assignment> GetStudentAssigmentWork(int studentID)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            List<Assignment> obj = new List<Assignment>();
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_STUDENT_ASSIGNMENT_WORK;
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Assignment entity = new Assignment();
                    entity.assignment_Id = dr["assignment_id"].ToInt();
                    entity.AssignmentWork = dr["AssignmentWork"].ToStr();
                    obj.Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                cmd.Dispose();
            }
            return obj;
        }

        public static List<Discussion> GetStudentDiscussion(int studentID)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            List<Discussion> obj = new List<Discussion>();
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_STUDENT_DISCUSSION;
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Discussion entity = new Discussion();
                    entity.id = dr["id"].ToInt();
                    entity.Discussion_topic = dr["Discussion_topic"].ToStr();
                    obj.Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                cmd.Dispose();
            }
            return obj;
        }

        public static string GetAnnoucement(int userID, int roleID)
        {
            string messege = string.Empty;
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_ANNOUCEMNET;
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@RoleID", roleID);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    messege = dr["Description"].ToStr();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                cmd.Dispose();
            }
            return messege;
        }
    }
}
