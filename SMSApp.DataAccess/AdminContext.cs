using System;
using System.Collections.Generic;
using SMSApp.Entities;
using System.Data.SqlClient;
using SMSApp.Common;
using System.Data;

namespace SMSApp.DataAccess
{
    public class AdminContext
    {
        public UserInfoEntity InsertUser(UserInfoEntity entity)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.INSERT_USER_INFO;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("username",entity.UserName);
                cmd.Parameters.AddWithValue("pwd",entity.Password);
                cmd.Parameters.AddWithValue("FirstName", entity.FirstName);
                cmd.Parameters.AddWithValue("LastName", entity.LastName);
                cmd.Parameters.AddWithValue("middleName", entity.MiddleName);
                cmd.Parameters.AddWithValue("Role_Id", entity.RoleID);
                cmd.Parameters.AddWithValue("DOB", entity.DateOfBirth);
                cmd.Parameters.AddWithValue("email", entity.EmailAddress);
                cmd.Parameters.AddWithValue("Phoneno", entity.PhoneNumber);
                cmd.Parameters.AddWithValue("gender", entity.Gender);
                cmd.Parameters.AddWithValue("Course_Id", entity.CourseID);
                cmd.Parameters.AddWithValue("Dept_Id", entity.DepartmentID);
                cmd.Parameters.AddWithValue("Prof_Id", entity.ProffesorID);

                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "MembershipID";
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outPutParameter);

                cmd.ExecuteNonQuery();
  
                entity.MembershipID = outPutParameter.Value.ToInt();
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

        public List<StudentRanks> GetRanksInformation()
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            List<StudentRanks> obj = new List<StudentRanks>();

            SqlDataReader dr;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_RANKS;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    StudentRanks entity = new StudentRanks();
                    entity.Rank  = dr["Rank"].ToInt();
                    entity.StudentName  = dr["studentName"].ToStr();
                    entity.FinalGrade = dr["FinalGrade"].ToStr();
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

        public List<UserInfoEntity> GetUser(int roleid)
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
                cmd.CommandText = DBProcedures.GET_USERS_LIST;
                cmd.Parameters.AddWithValue("@role", roleid);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    UserInfoEntity entity = new UserInfoEntity();
                    entity.UserID = dr["userid"].ToInt();
                    entity.FirstName = dr["FirstName"].ToStr();
                    entity.MiddleName = dr["MiddleName"].ToStr();
                    entity.LastName = dr["LastName"].ToStr();
                    entity.EmailAddress = dr["email"].ToStr();
                    entity.PhoneNumber = dr["Phoneno"].ToStr();
                    entity.Gender = dr["Gender"].ToStr();
                    entity.DateOfBirth = dr["dob"].ToDateTime();
                    entity.DateOfJoining = dr["dateOfJoining"].ToDateTime();
                    entity.DepartmentID = dr["Dept_Id"].ToInt();
                    entity.DepartmentName = dr["Dept_Desc"].ToStr();
                    entity.CourseID = dr["Course_Id"].ToInt();
                    entity.CourseName = dr["CourseName"].ToStr();
                    entity.ProffesorID = dr["Prof_Id"].ToInt();
                    entity.ProfessorName = dr["ProfessorName"].ToStr();
                    entity.SportID = dr["sports_Id"].ToInt();
                    entity.SportDescription = dr["SportsDesc"].ToStr();
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

        public UserInfoEntity GetUserInfo(int userID)
        {
            UserInfoEntity entity = new UserInfoEntity();
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_USER_INFO_FOR_EDIT;
                cmd.Parameters.AddWithValue("@UserID", userID);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {            
                    entity.UserID = dr["userid"].ToInt();
                    entity.FirstName = dr["FirstName"].ToStr();
                    entity.MiddleName = dr["MiddleName"].ToStr();
                    entity.LastName = dr["LastName"].ToStr();
                    entity.EmailAddress = dr["email"].ToStr();
                    entity.PhoneNumber = dr["Phoneno"].ToStr();
                    entity.Gender = dr["Gender"].ToStr();
                    entity.DateOfBirth = dr["dob"].ToDateTime();
                    entity.DateOfJoining = dr["dateOfJoining"].ToDateTime();
                    entity.DepartmentID = dr["Dept_Id"].ToInt();
                    entity.DepartmentName = dr["Dept_Desc"].ToStr();
                    entity.CourseID = dr["Course_Id"].ToInt();
                    entity.CourseName = dr["CourseName"].ToStr();
                    entity.ProffesorID = dr["Prof_Id"].ToInt();
                    entity.ProfessorName = dr["ProfessorName"].ToStr(); 
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
            return entity;
        }

        public int UpdateUser(UserInfoEntity entity)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.UPDATE_USER_INFORMATION;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("UserID", entity.UserID);
                cmd.Parameters.AddWithValue("FirstName", entity.FirstName);
                cmd.Parameters.AddWithValue("LastName", entity.LastName);
                cmd.Parameters.AddWithValue("middleName", entity.MiddleName);
                cmd.Parameters.AddWithValue("Role_Id", entity.RoleID);
                cmd.Parameters.AddWithValue("DOB", entity.DateOfBirth);
                cmd.Parameters.AddWithValue("email", entity.EmailAddress);
                cmd.Parameters.AddWithValue("Phoneno", entity.PhoneNumber);
                cmd.Parameters.AddWithValue("gender", entity.Gender);
                cmd.Parameters.AddWithValue("Course_Id", entity.CourseID);
                cmd.Parameters.AddWithValue("Dept_Id", entity.DepartmentID);
                cmd.Parameters.AddWithValue("Prof_Id", entity.ProffesorID);
                result = cmd.ExecuteNonQuery();
                return result;
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
    }
}
