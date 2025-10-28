using EPEPITIAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace EPEPITIAPI.DBHelper
{
    public class JobProfileListDAL
    {
        private readonly string _connectionString;

        public JobProfileListDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public List<JobProfileList> GetJobRoleAll()
        {
            List<JobProfileList> lstSectorList = new List<JobProfileList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetJobRoleAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        JobProfileList lst = new JobProfileList();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.jobRole = dr["jobRole"].ToString();
                        lst.sectorName = dr["sectorName"].ToString();
                        lst.status = Convert.ToInt32(dr["status"]);
                        lstSectorList.Add(lst);
                    }

                }
                conn.Close();
            }
            return lstSectorList;
        }

        public JobProfileList GetJobRoleToEditByID(int id)
        {
            JobProfileList sList = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetJobRoleToEditByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sList = new JobProfileList();
                        sList.id = Convert.ToInt32(dr["id"]);
                        sList.sectorID = Convert.ToInt32(dr["sectorID"]);
                        sList.jobRole = dr["jobRole"].ToString();
                    }
                }
            }
            return sList;

        }

        public int InsertJobRoleData(JobProfileListDTO jList)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertTMJobRole", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@sectorID", SqlDbType.Int).Value = jList.sectorID;
                cmd.Parameters.Add("@jobRole", SqlDbType.VarChar).Value = jList.jobRole;
                cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = jList.createdBy;
                conn.Open();
                //cmd.ExecuteNonQuery();
                //conn.Close();
                //return true;

                object result = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(result);
            }
        }

        public int UpdateJobRoleData(JobProfileListDTO jList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateTMJobRole", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = jList.id;
                    cmd.Parameters.Add("@sectorID", SqlDbType.Int).Value = jList.sectorID;
                    cmd.Parameters.Add("@jobRole", SqlDbType.VarChar).Value = jList.jobRole;
                    cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = jList.createdBy;
                    conn.Open();
                    // Read DuplicateCount from the stored procedure
                    object result = cmd.ExecuteScalar();
                    conn.Close();
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public bool ChangeJobRoleStatus(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_ChangeJobRoleStatus", conn);
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

        public List<JobProfileList> GetJobDetailsAll()
        {
            List<JobProfileList> lstSectorList = new List<JobProfileList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetJobDetailsAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        JobProfileList lst = new JobProfileList();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.jobRoleDetails = dr["jobRoleDetails"].ToString();
                        lst.qpCode = dr["qpCode"].ToString();
                        lst.nsqfCode = dr["nsqfCode"].ToString();
                        lst.jobRole = dr["jobRole"].ToString();
                        lst.sectorName = dr["sectorName"].ToString();
                        lst.status = Convert.ToInt32(dr["status"]);
                        lstSectorList.Add(lst);
                    }

                }
                conn.Close();
            }
            return lstSectorList;
        }

        public JobProfileListDTO GetJobDetailToEditByID(int id)
        {
            JobProfileListDTO sList = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetJobDetailToEditByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sList = new JobProfileListDTO();
                        sList.id = Convert.ToInt32(dr["id"]);
                        sList.jobDetail = dr["jobRoleDetails"].ToString();
                        sList.qpCode = dr["qpCode"].ToString();
                        sList.nsqfID = Convert.ToInt32(dr["nsqfID"]);
                        sList.sectorID = Convert.ToInt32(dr["sectorID"]);
                        sList.jobRoleID = Convert.ToInt32(dr["jobRoleID"]);
                    }
                }
            }
            return sList;

        }

        public int InsertJobDetailData(JobProfileListDTO jList)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertTMJobDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@jobRoleDetails", SqlDbType.VarChar).Value = jList.jobDetail;
                cmd.Parameters.Add("@qpCode", SqlDbType.VarChar).Value = jList.qpCode;
                cmd.Parameters.Add("@nsqfID", SqlDbType.Int).Value = jList.nsqfID;
                cmd.Parameters.Add("@sectorID", SqlDbType.Int).Value = jList.sectorID;
                cmd.Parameters.Add("@jobRoleID", SqlDbType.Int).Value = jList.jobRoleID;
                cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = jList.createdBy;
                conn.Open();
                //cmd.ExecuteNonQuery();
                //conn.Close();
                //return true;

                object result = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(result);
            }
        }

        public int UpdateJobDetailsData(JobProfileListDTO jList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateTMJobDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = jList.id;
                    cmd.Parameters.Add("@jobRoleDetails", SqlDbType.VarChar).Value = jList.jobDetail;
                    cmd.Parameters.Add("@qpCode", SqlDbType.VarChar).Value = jList.qpCode;
                    cmd.Parameters.Add("@nsqfID", SqlDbType.Int).Value = jList.nsqfID;
                    cmd.Parameters.Add("@sectorID", SqlDbType.Int).Value = jList.sectorID;
                    cmd.Parameters.Add("@jobRoleID", SqlDbType.Int).Value = jList.jobRoleID;
                    cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = jList.createdBy;
                    conn.Open();
                    // Read DuplicateCount from the stored procedure
                    object result = cmd.ExecuteScalar();
                    conn.Close();
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public bool ChangeJobDetailStatus(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_ChangeJobDetailStatus", conn);
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

    }
}
