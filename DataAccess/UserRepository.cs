using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Text;
// baseri het ashatogh class 
namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        public static void GetUserInfoFromDB(User_Account ua)
        {
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_GetUserInfo]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                  
                    cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = ua.UserID;
                    using (SqlDataReader r = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                    {
                        if (r.Read())
                        {
                            ua.UserFullName = r.GetString("U_FullName");
                            ua.UserEmail = r.GetString("U_email");
                            ua.UserImage_Url = r.IsDBNull("U_image_url") ? string.Empty : r.GetString("U_image_url");
                            ua.UserRegDate = r.GetDateTime("U_reg_date");
                        }

                    }
                }
            }
        }
       
        public object LoginInformation(string mail, string password)
        {   // null i het hamematelu hamar a kartsem,  nenc cher linum 
            object sc;
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_UserLogin]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserEmail", System.Data.SqlDbType.VarChar).Value = mail;
                    cmd.Parameters.Add("@UserPassword", System.Data.SqlDbType.VarChar).Value = password;
                    sc = cmd.ExecuteScalar();
                }
              
                return sc;
            }
        }
        //TODO - CHANGE STUFF IN DESKTOPUI
        public static void RegisteringProccess(User_Account ua)
        {
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_NewUserReg]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserFullName", System.Data.SqlDbType.NVarChar).Value = ua.UserFullName;
                    cmd.Parameters.Add("@UserEmail", System.Data.SqlDbType.VarChar).Value = ua.UserEmail;
                    cmd.Parameters.Add("@UserPassword", System.Data.SqlDbType.VarChar).Value = ua.UserPassword;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //for API 
        public User_Account GetUserInfo(int ID)
        {
            User_Account ua = new User_Account();
            ua.UserID = ID;
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_GetUserInfo]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = ua.UserID;
                    using (SqlDataReader r = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                    {
                        if (r.Read())
                        {
                            ua.UserFullName = r.GetString("U_FullName");
                            ua.UserEmail = r.GetString("U_email");
                            ua.UserImage_Url = r.IsDBNull("U_image_url") ? string.Empty : r.GetString("U_image_url");
                            ua.UserRegDate = r.GetDateTime("U_reg_date");
                        }

                    }
                }
            }
            return ua;
        }
        public  int RegisteringProccessA(User_Account ua)
        {
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_NewUserReg]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserFullName", System.Data.SqlDbType.NVarChar).Value = ua.UserFullName;
                    cmd.Parameters.Add("@UserEmail", System.Data.SqlDbType.VarChar).Value = ua.UserEmail;
                    cmd.Parameters.Add("@UserPassword", System.Data.SqlDbType.VarChar).Value = ua.UserPassword;
                    cmd.ExecuteNonQuery();
                }
            }
            return ua.UserID;
        }

    }
}
