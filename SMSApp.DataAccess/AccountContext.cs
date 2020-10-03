using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSApp.Entities;
using System.Data.SqlClient;
using SMSApp.Common;
using System.Data;

namespace SMSApp.DataAccess
{
    public class AccountContext
    {
        public bool VerifyAuthentication(string userName, string password)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.USER_AUTHENTICATION;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("UserName", userName);
                cmd.Parameters.AddWithValue("Password", EncryptionDecryption.Encrypt("&^%&", password));
                int result = cmd.ExecuteScalar().ToInt();
                if (result > 0)
                    return true;
                else
                    return false;
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
        public bool UpdatePassword(string newpwd, int membershipid)
        {
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.UPDATE_PASSWORD ;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("memid", membershipid );
                cmd.Parameters.AddWithValue("newpwd", EncryptionDecryption.Encrypt("&^%&", newpwd));
                int result = cmd.ExecuteScalar().ToInt();
                if (result > 0)
                    return true;
                else
                    return false;
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

        public UserInfoEntity GetUserDeatils(string userName, string password)
        {
            UserInfoEntity userInfo = null;
            SqlConnection con = new SqlConnection(DbActivity.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DBProcedures.GET_USER_DETAILS;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("UserName", userName);
                cmd.Parameters.AddWithValue("Password", EncryptionDecryption.Encrypt("&^%&", password));
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    userInfo = new UserInfoEntity()
                    {
                        MembershipID = dr["membership_id"].ToInt(),
                        UserName = dr["username"].ToStr(),
                        Password = dr["pwd"].ToStr(),
                        IsActive = dr["IsActive"].ToBoolean(),
                        UserID = dr["userid"].ToInt(),
                        FirstName = dr["FirstName"].ToStr(),
                        MiddleName = dr["middleName"].ToStr(),
                        LastName = dr["LastName"].ToStr(),
                        RoleID = dr["Role_Id"].ToInt(),
                        DateOfBirth = dr["DOB"].ToDateTime(),
                        EmailAddress = dr["membership_id"].ToStr(),
                        PhoneNumber = dr["membership_id"].ToStr(),
                        Gender = dr["membership_id"].ToStr(),
                        DateOfJoining = dr["membership_id"].ToDateTime(),
                        CourseID = dr["membership_id"].ToInt(),
                        DepartmentID = dr["membership_id"].ToInt(),
                        ProffesorID = dr["membership_id"].ToInt(),
                    };
                }
                return userInfo;
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
