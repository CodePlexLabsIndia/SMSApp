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
    public class StudentContext
    {
        public StudentMarks ViewMarks(int StudentId)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            StudentMarks entity = new StudentMarks();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.VIEW_MARKS;
                cmd.Parameters.AddWithValue("@studentid", StudentId);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    entity.Subject6 = dr["Subject6"].ToStr();
                    entity.Subject5 = dr["Subject5"].ToStr();
                    entity.Subject4 = dr["Subject4"].ToStr();
                    entity.Subject3 = dr["Subject3"].ToStr();
                    entity.Subject2 = dr["Subject2"].ToStr();
                    entity.Subject1 = dr["Subject1"].ToStr();
                    entity.Marks6 = dr["Marks6"].ToInt();
                    entity.Marks5 = dr["Marks5"].ToInt();
                    entity.Marks4 = dr["Marks4"].ToInt();
                    entity.Marks3 = dr["Marks3"].ToInt();
                    entity.Marks2 = dr["Marks2"].ToInt();
                    entity.Marks1 = dr["Marks1"].ToInt();
                    entity.Grade6 = dr["Grade6"].ToStr();
                    entity.Grade5 = dr["Grade5"].ToStr();
                    entity.Grade4 = dr["Grade4"].ToStr();
                    entity.Grade3 = dr["Grade3"].ToStr();
                    entity.Grade2 = dr["Grade2"].ToStr();
                    entity.Grade1 = dr["Grade1"].ToStr();
                    entity.TotalMarks= dr["TotalMarks"].ToInt();
                    entity.FinalGrade= dr["FinalGrade"].ToStr();
                    entity.Percentage= dr["Percentage"].ToInt();
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

        public int SaveEnrollSports(EnrollSports entity)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.ADD_SPORTS_ENROLL;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("SportsId", entity.SportsId);
                cmd.Parameters.AddWithValue("description", entity.description);
                cmd.Parameters.AddWithValue("StudentId", entity.Studentid);
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

        public int SaveEnrollCourse(EnrollCourse entity)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.ADD_COURSE_ENROLL;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("Studentid", entity.Studentid);
                cmd.Parameters.AddWithValue("CourseId", entity.CourseId);
                cmd.Parameters.AddWithValue("CourseType", entity.CourseType);
                cmd.Parameters.AddWithValue("SchoolName", entity.SchoolName);
                cmd.Parameters.AddWithValue("LocationName", entity.LocationName);
                cmd.Parameters.AddWithValue("Professorid", entity.Professorid);
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

        public int SaveEducationDetails(UserInfoEntity entity)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.UDATE_STUDENT_EDUCATION_INFO;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("UserID", entity.UserID);
                cmd.Parameters.AddWithValue("SSCMarks", entity.SSCMarks);
                cmd.Parameters.AddWithValue("SSCPercentage", entity.SSCPercentage);
                cmd.Parameters.AddWithValue("YearOfPassing", entity.YearofPassing);
                cmd.Parameters.AddWithValue("IntermediateMarks", entity.IntermediateMarks);
                cmd.Parameters.AddWithValue("IntermediatePercentage", entity.IntermediatePercentage);
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

        public int SaveParentDetails(UserInfoEntity entity)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.UDATE_STUDENT_PARENT_INFO;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("UserID", entity.UserID);
                cmd.Parameters.AddWithValue("FatherName", entity.FatherName);
                cmd.Parameters.AddWithValue("MotherName", entity.MotherName);
                cmd.Parameters.AddWithValue("PresentAddress", entity.PresentAddress);
                cmd.Parameters.AddWithValue("PermanentAddress", entity.PermanentAddress);
                cmd.Parameters.AddWithValue("ParentPhone", entity.ParentPhone);
                cmd.Parameters.AddWithValue("ParentEmail", entity.ParentEmail);
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

        public int UpdateDiscussion(Discussion entity)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.UPDATE_STUDENT_DISCUSSION;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("DiscussionID", entity.id);
                cmd.Parameters.AddWithValue("Answar", entity.DiscussionAnswar);
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

        public int SaveStudentFee(StudentFee entity)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.INSERT_STUDENT_FEE;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("StudentID", entity.StudentID);
                cmd.Parameters.AddWithValue("SchoolName", entity.SchoolName);
                cmd.Parameters.AddWithValue("LocationName", entity.LocationName);
                cmd.Parameters.AddWithValue("ProfessorID", entity.ProfessorID);
                cmd.Parameters.AddWithValue("CourseID", entity.CourseID);
                cmd.Parameters.AddWithValue("AdmissionNumber", entity.AdmissionNumber);
                cmd.Parameters.AddWithValue("RollNumber", entity.RollNumber);
                cmd.Parameters.AddWithValue("FeeReceiptNumber", entity.FeeReceiptNumber);
                cmd.Parameters.AddWithValue("PaymentDate", entity.PaymentDate);
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
    }
}
