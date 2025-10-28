using EPEPITIAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace EPEPITIAPI.DBHelper
{
    public class BindDropDownListDAL
    {
        private readonly string _connectionString;

        public BindDropDownListDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public List<BindDropDownList> BindReligionDropDownList()
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindReligionDropDownList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.religion = dr["religion"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }

        public List<BindDropDownList> BindCategoryDropDownList()
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindCategoryDropDownList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.category = dr["category"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }

        public List<BindDropDownList> BindStateDropDownList()
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindStateDropDownList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.statename = dr["statename"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }


        public List<BindDropDownList> BindQualificationDropDownList()
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindQualificationDropDownList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.qualification = dr["qualification"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }


        public List<BindDropDownList> BindUserRoleDropDownList()
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindUserRoleDropDownList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.userRole = dr["userRole"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }

        public List<BindDropDownList> BindNSQFCodeDropDownList()
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindNSQFCodeDropDownList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.nsqfCode = dr["nsqfCode"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }

        public List<BindDropDownList> BindSectorDropDownList()
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindSectorDropDownList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.sectorname = dr["sectorname"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }

        public List<BindDropDownList> BindJobRoleDropDownListBySectorID(int sectorID)
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindJobRoleDropDownListBySectorID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@sectorID", SqlDbType.Int).Value = sectorID;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.jobRole = dr["jobRole"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }

        public List<BindDropDownList> BindJobDetailDropDownListByJobRoleID(int jobRoleID)
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindJobDetailDropDownListByJobRoleID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@jobRoleID", SqlDbType.Int).Value = jobRoleID;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.jobDetail = dr["jobDetail"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }

        public List<BindDropDownList> BindPartnerTypeDropDownList()
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindPartnerTypeDropDownList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.partnerType = dr["partnerType"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }

        public List<BindDropDownList> BindPartnerDropDownListByPartnerTypeID(int partnerTypeID)
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindPartnerDropDownListByPartnerTypeID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@partnerTypeID", SqlDbType.Int).Value = partnerTypeID;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.partnerName = dr["firmName"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }

        public List<BindDropDownList> BindTrainingCenterDropDownList()
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindTrainingCenterDropDownList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.trainingCenter = dr["centerName"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }

        public List<BindDropDownList> BindTrainerDropDownList()
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindTrainerDropDownList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.trainer = dr["trainer"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }

        public List<BindDropDownList> BindAssessorDropDownList()
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindAssessorDropDownList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.assessor = dr["assessor"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }

        public List<BindDropDownList> BindBatchDropDownList()
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindBatchDropDownList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.batchID = dr["batchID"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }

        public List<BindDropDownList> BindBatchDropDownListAttendance()
        {
            List<BindDropDownList> lstDDLList = new List<BindDropDownList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BindBatchDropDownListAttendance", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BindDropDownList bList = new BindDropDownList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.batchID = dr["batchID"].ToString();
                        lstDDLList.Add(bList);
                    }
                }
                conn.Close();
            }
            return lstDDLList;
        }




    }
}
