using SMSApp.Common;
using SMSApp.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.DataAccess
{
    public class ProfessorContext
    {
        public UserInfoEntity UpdateProfessor(UserInfoEntity entity)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.UPDATE_PROFESSOR;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("FirstName", entity.FirstName);
                cmd.Parameters.AddWithValue("LastName", entity.LastName);
                //cmd.Parameters.AddWithValue("middleName", entity.MiddleName);
                cmd.Parameters.AddWithValue("dateOfJoining", entity.DateOfJoining);
                cmd.Parameters.AddWithValue("DOB", entity.DateOfBirth);
                cmd.Parameters.AddWithValue("email", entity.EmailAddress);
                cmd.Parameters.AddWithValue("Phoneno", entity.PhoneNumber);
                cmd.Parameters.AddWithValue("gender", entity.Gender);
                cmd.Parameters.AddWithValue("Course_Id", entity.CourseID);
                cmd.Parameters.AddWithValue("Dept_Id", entity.DepartmentID);
                cmd.Parameters.AddWithValue("pic", entity.DepartmentID);
                cmd.ExecuteNonQuery();
                return entity;
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
        }

        public void AddAnnouncement(Announcement entity)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.ADD_ANNOUNCEMENT;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("DestinationId", entity.DestinationId);
                cmd.Parameters.AddWithValue("CreatedById", entity.CreatedById);
                cmd.Parameters.AddWithValue("AnnouncementType", entity.AnnouncementType);
                cmd.Parameters.AddWithValue("Description", entity.Description);
                cmd.Parameters.AddWithValue("AnnounceDate", entity.AnnounceDate);
                cmd.Parameters.AddWithValue("CreatedDate", entity.CreatedDate);
                cmd.ExecuteNonQuery();

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
        }

        public void AddAssignment(Assignment entity)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.ADD_ASSIGNMENT;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("Userid", entity.Userid );
                cmd.Parameters.AddWithValue("SchoolName", entity.SchoolName);
                cmd.Parameters.AddWithValue("Location", entity.Location);
                cmd.Parameters.AddWithValue("ProfessorId", entity.ProfessorId);
                cmd.Parameters.AddWithValue("Course", entity.Course);
                cmd.Parameters.AddWithValue("StudentId", entity.StudentId);
                cmd.Parameters.AddWithValue("Year", entity.Year);
                cmd.Parameters.AddWithValue("AssignmentDate", entity.AssignmentDate);
                cmd.Parameters.AddWithValue("Topic", entity.Topic);
                cmd.Parameters.AddWithValue("AssignmentWork", entity.AssignmentWork);
                cmd.Parameters.AddWithValue("createdDatetime", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                cmd.ExecuteNonQuery();

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
        }

        //AddMarks
        public void AddMarks(StudentMarks  entity)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.ADD_MARKS  ;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@StudentId", entity.StudentId);
                cmd.Parameters.AddWithValue("@Professorid", entity.Professorid);
                cmd.Parameters.AddWithValue("@createdDate", entity.createdDate);
                cmd.Parameters.AddWithValue("@Subject6", entity.Subject6);
                cmd.Parameters.AddWithValue("@Subject5", entity.Subject5);
                cmd.Parameters.AddWithValue("@Subject4", entity.Subject4);
                cmd.Parameters.AddWithValue("@Subject3", entity.Subject3);
                cmd.Parameters.AddWithValue("@Subject2", entity.Subject2);
                cmd.Parameters.AddWithValue("@Subject1", entity.Subject1);
                cmd.Parameters.AddWithValue("@Marks6", entity.Marks6);
                cmd.Parameters.AddWithValue("@Marks5", entity.Marks5);
                cmd.Parameters.AddWithValue("@Marks4", entity.Marks4);
                cmd.Parameters.AddWithValue("@Marks3", entity.Marks3);
                cmd.Parameters.AddWithValue("@Marks2", entity.Marks2);
                cmd.Parameters.AddWithValue("@Marks1", entity.Marks1);
                cmd.Parameters.AddWithValue("@Grade6", entity.Grade6);
                cmd.Parameters.AddWithValue("@Grade5", entity.Grade5);
                cmd.Parameters.AddWithValue("@Grade4", entity.Grade4);
                cmd.Parameters.AddWithValue("@Grade3", entity.Grade3);
                cmd.Parameters.AddWithValue("@Grade2", entity.Grade2);
                cmd.Parameters.AddWithValue("@Grade1", entity.Grade1);

                cmd.Parameters.AddWithValue("@TotalMarks", entity.TotalMarks);
                cmd.Parameters.AddWithValue("@FinalGrade", entity.FinalGrade);
                cmd.Parameters.AddWithValue("@Percentage", entity.Percentage);
                cmd.ExecuteNonQuery();

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
        }

        public List<UserInfoEntity> GetStudents(int roleid)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            List<UserInfoEntity> obj = new List<UserInfoEntity>();
           
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_STUDENTS;
                cmd.Parameters.AddWithValue("@role", roleid);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    UserInfoEntity entity = new UserInfoEntity();
                    entity.UserID = dr["UserID"].ToInt();
                    entity.FirstName = dr["FirstName"].ToStr();
                    entity.MiddleName = dr["MiddleName"].ToStr();
                    entity.LastName = dr["LastName"].ToStr();
                    entity.EmailAddress = dr["email"].ToStr();
                    entity.PhoneNumber = dr["Phoneno"].ToStr();
                    entity.Gender = dr["Gender"].ToStr().Trim();
                    entity.DateOfBirth = dr["dob"].ToDateTime();
                    entity.CourseID = dr["Course_ID"].ToInt();
                    entity.DepartmentID  = dr["Dept_ID"].ToInt();
                    if (!DBNull.Value.Equals(dr["dateOfJoining"]))
                    {
                        entity.DateOfJoining = Convert.ToDateTime( dr["dateOfJoining"]);
                    }

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

        public List<UserInfoEntity> GetDDLStudents(int role)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            List<UserInfoEntity> obj = new List<UserInfoEntity>();
            
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_STUDENTS;
                cmd.Parameters.AddWithValue("@role", role);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    UserInfoEntity entity = new UserInfoEntity();
                    entity.UserID = dr["userid"].ToInt();
                    entity.FirstName = dr["FirstName"].ToStr();
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

        public Discussion AddProfDiscussion(Discussion entity)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.ADD_DISCUSSION_PROFESSOR;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("Student_id", entity.Student_id);
                cmd.Parameters.AddWithValue("Professor_Id", entity.Professor_Id);
                cmd.Parameters.AddWithValue("Discussion_topic", entity.Discussion_topic);
                cmd.Parameters.AddWithValue("Discussion_msg", entity.Discussion_msg);

                cmd.ExecuteNonQuery();
                return entity;
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
        }

        public List<UserInfoEntity> GetStudentByProf(int roleID,int profID)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            List<UserInfoEntity> obj = new List<UserInfoEntity>();
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_STUDENT_BY_PROFESSOR;
                cmd.Parameters.AddWithValue("@role", roleID);
                cmd.Parameters.AddWithValue("@ProfId", profID);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    UserInfoEntity entity = new UserInfoEntity();
                    entity.UserID = dr["UserID"].ToInt();
                    entity.FirstName = dr["FirstName"].ToStr();
                    entity.MiddleName = dr["MiddleName"].ToStr();
                    entity.LastName = dr["LastName"].ToStr();
                    entity.EmailAddress = dr["email"].ToStr();
                    entity.PhoneNumber = dr["Phoneno"].ToStr();
                    entity.Gender = dr["Gender"].ToStr().Trim();
                    entity.DateOfBirth = dr["dob"].ToDateTime();
                    entity.CourseID = dr["Course_ID"].ToInt();
                    entity.DepartmentID = dr["Dept_ID"].ToInt();
                    entity.ProffesorID = dr["Prof_Id"].ToInt();
                    if (!DBNull.Value.Equals(dr["dateOfJoining"]))
                    {
                        entity.DateOfJoining = Convert.ToDateTime(dr["dateOfJoining"]);
                    }

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

        public List<Discussion> GetDiscussion(int userID, string Type)
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
                cmd.CommandText = DBProcedures.GET_DISCUSSION_GRID;
                cmd.Parameters.AddWithValue("@StudentID", userID);
                cmd.Parameters.AddWithValue("@Type", Type);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Discussion entity = new Discussion();
                    entity.Student_id = dr["Student_id"].ToInt();
                    entity.StudentName = dr["StudentName"].ToStr(true);
                    entity.Professor_Id = dr["Professor_Id"].ToInt();
                    entity.ProfessorName = dr["ProfessorName"].ToStr(true);
                    entity.Discussion_msg = dr["Discussion_msg"].ToStr(true);
                    entity.Discussion_topic = dr["Discussion_topic"].ToStr(true);
                    entity.DiscussionAnswar = dr["Discussion_Ans"].ToStr(true);
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
    }
}
