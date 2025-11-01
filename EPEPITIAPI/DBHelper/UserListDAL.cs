using EPEPITIAPI.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace EPEPITIAPI.DBHelper
{
    public class UserListDAL
    {
        private readonly string _connectionString;

        public UserListDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public List<UserList> GetUserDetailAll()
        {
            List<UserList> lstSectorList = new List<UserList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetUserDetailAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        UserList lst = new UserList();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.userName = dr["userName"].ToString();
                        lst.genderName = dr["gender"].ToString();
                        lst.sectorName = dr["sectorName"].ToString();
                        lst.jobProfile = dr["jobProfile"].ToString();
                        lst.userRole = dr["userRole"].ToString();
                        lst.firmName = dr["firmName"].ToString();
                        lst.userMobile = dr["userMobile"].ToString();
                        lst.userEmail = dr["userEmail"].ToString();
                        lst.status = Convert.ToInt32(dr["status"]);
                        lstSectorList.Add(lst);
                    }

                }
                conn.Close();
            }
            return lstSectorList;
        }



        public List<UserList> GetUserDetail_Trainer()
        {
            List<UserList> lstSectorList = new List<UserList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetUserDetail_Trainer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        UserList lst = new UserList();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.userName = dr["userName"].ToString();
                        lst.genderName = dr["gender"].ToString();
                        lst.sectorName = dr["sectorName"].ToString();
                        lst.jobProfile = dr["jobProfile"].ToString();
                        lst.userRole = dr["userRole"].ToString();
                        lst.firmName = dr["firmName"].ToString();
                        lst.userMobile = dr["userMobile"].ToString();
                        lst.userEmail = dr["userEmail"].ToString();
                        lst.status = Convert.ToInt32(dr["status"]);
                        lstSectorList.Add(lst);
                    }

                }
                conn.Close();
            }
            return lstSectorList;
        }

        public UserList GetUserDetailToViewByID(int id)
        {
            UserList uList = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetUserDetailToViewByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        uList = new UserList();
                        uList.id = Convert.ToInt32(dr["id"]);
                        uList.userName = dr["userName"].ToString();
                        uList.genderName = dr["gender"].ToString();
                        uList.sectorName = dr["sectorName"].ToString();
                        uList.jobProfile = dr["jobProfile"].ToString();
                        uList.userRole = dr["userRole"].ToString();
                        uList.firmName = dr["firmName"].ToString();
                        uList.userMobile = dr["userMobile"].ToString();
                        uList.userEmail = dr["userEmail"].ToString();
                        uList.address = dr["address"].ToString();
                        uList.status = Convert.ToInt32(dr["status"]);
                        uList.createdByName = dr["createdBy"].ToString();
                    }
                }
            }
            return uList;

        }

        public UserList GetUserDetailToEditByID(int id)
        {
            UserList uList = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetUserDetailToEditByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        uList = new UserList();
                        uList.id = Convert.ToInt32(dr["id"]);
                        uList.userRoleID = Convert.ToInt32(dr["userRoleID"]);
                        uList.partnerID = Convert.ToInt32(dr["partnerID"]);
                        uList.userName = dr["userName"].ToString();
                        uList.gender = Convert.ToInt32(dr["gender"]);
                        uList.userMobile = dr["userMobile"].ToString();
                        uList.userEmail = dr["userEmail"].ToString();
                        uList.sectorID = Convert.ToInt32(dr["sectorID"]);
                        uList.jobProfile = dr["jobProfile"].ToString();
                    }
                }
            }
            return uList;

        }


        public bool InsertUserData(UserListDTO uList)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertTMUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@userRoleID", SqlDbType.Int).Value = uList.userRoleID;
                cmd.Parameters.Add("@partnerID", SqlDbType.Int).Value = uList.partnerID;
                cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = uList.userName;
                cmd.Parameters.Add("@gender", SqlDbType.Int).Value = uList.gender;
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = uList.userMobile;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = uList.userEmail;
                cmd.Parameters.Add("@sectorID", SqlDbType.Int).Value = uList.sectorID;
                cmd.Parameters.Add("@jobProfile", SqlDbType.VarChar).Value = uList.jobProfile;
                cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = uList.createdBy;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public bool UpdateUserData(UserListDTO uList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateTMUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = uList.id;
                    cmd.Parameters.Add("@userRoleID", SqlDbType.Int).Value = uList.userRoleID;
                    cmd.Parameters.Add("@partnerID", SqlDbType.Int).Value = uList.partnerID;
                    cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = uList.userName;
                    cmd.Parameters.Add("@gender", SqlDbType.Int).Value = uList.gender;
                    cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = uList.userMobile;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = uList.userEmail;
                    cmd.Parameters.Add("@sectorID", SqlDbType.Int).Value = uList.sectorID;
                    cmd.Parameters.Add("@jobProfile", SqlDbType.VarChar).Value = uList.jobProfile;
                    cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = uList.createdBy;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool ChangeUserStatus(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_ChangeUserStatus", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public UserList ValidateUser(string loginID, string password)
        {
            UserList uDetails = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_SelectToValidateUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@loginID", SqlDbType.VarChar).Value = loginID;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        uDetails = new UserList();
                        uDetails.id = Convert.ToInt32(dr["id"]);
                        uDetails.userRoleID = Convert.ToInt32(dr["userRoleID"]);
                        uDetails.userName = dr["userName"].ToString();
                        uDetails.userRole = dr["userRole"].ToString();
                        uDetails.userMobile = dr["userMobile"].ToString();
                        uDetails.userEmail = dr["userEmail"].ToString();
                        uDetails.lastLogin = Convert.ToDateTime(dr["lastLogin"]);
                    }
                }
                conn.Close();
            }
            return uDetails;
        }


    }
}
