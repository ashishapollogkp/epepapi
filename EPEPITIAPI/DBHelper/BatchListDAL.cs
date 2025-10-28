using EPEPITIAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace EPEPITIAPI.DBHelper
{
    public class BatchListDAL
    {
        private readonly string _connectionString;
        public BatchListDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public List<BatchList> GetTrainedBatchDetail()
        {
            List<BatchList> bList = new List<BatchList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetTrainedBatchDetail", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BatchList lst = new BatchList();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.batchID = dr["batchID"].ToString();
                        lst.sectorName = dr["sectorName"].ToString();
                        lst.jobRole = dr["jobRole"].ToString();
                        lst.jobDetail = dr["jobRoleDetails"].ToString();
                        lst.trainingCenter = dr["centerName"].ToString();
                        lst.trainer = dr["trainer"].ToString();
                        lst.assessor = dr["assessor"].ToString();
                        lst.startDate = Convert.ToDateTime(dr["startDate"]);
                        lst.endDate = Convert.ToDateTime(dr["endDate"]);
                        lst.status = Convert.ToInt32(dr["status"]);
                        bList.Add(lst);
                    }

                }
                conn.Close();
            }
            return bList;
        }

        public List<BatchList> GetBatchDetailAll()
        {
            List<BatchList> bList = new List<BatchList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetBatchDetailAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BatchList lst = new BatchList();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.batchID = dr["batchID"].ToString();
                        lst.sectorName = dr["sectorName"].ToString();
                        lst.jobRole = dr["jobRole"].ToString();
                        lst.jobDetail = dr["jobRoleDetails"].ToString();
                        lst.trainingCenter = dr["centerName"].ToString();
                        lst.trainer = dr["trainer"].ToString();
                        lst.assessor = dr["assessor"].ToString();
                        lst.startDate = Convert.ToDateTime(dr["startDate"]);
                        lst.endDate = Convert.ToDateTime(dr["endDate"]);
                        lst.status = Convert.ToInt32(dr["status"]);
                        bList.Add(lst);
                    }

                }
                conn.Close();
            }
            return bList;
        }

        public List<BatchList> GetBatchDetailByTrainerID(int trainerID)
        {
            List<BatchList> bList = new List<BatchList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetBatchDetailByTrainerID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@trainerID", SqlDbType.Int).Value = trainerID;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BatchList lst = new BatchList();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.batchID = dr["batchID"].ToString();
                        lst.sectorName = dr["sectorName"].ToString();
                        lst.jobRole = dr["jobRole"].ToString();
                        lst.jobDetail = dr["jobRoleDetails"].ToString();
                        lst.trainingCenter = dr["centerName"].ToString();
                        lst.trainer = dr["trainer"].ToString();
                        lst.assessor = dr["assessor"].ToString();
                        lst.startDate = Convert.ToDateTime(dr["startDate"]);
                        lst.endDate = Convert.ToDateTime(dr["endDate"]);
                        lst.status = Convert.ToInt32(dr["status"]);
                        bList.Add(lst);
                    }

                }
                conn.Close();
            }
            return bList;
        }

        public List<BatchList> GetBatchDetailByAssessorID(int assessorID)
        {
            List<BatchList> bList = new List<BatchList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetBatchDetailByAssessorID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@assessorID", SqlDbType.Int).Value = assessorID;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BatchList lst = new BatchList();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.batchID = dr["batchID"].ToString();
                        lst.sectorName = dr["sectorName"].ToString();
                        lst.jobRole = dr["jobRole"].ToString();
                        lst.jobDetail = dr["jobRoleDetails"].ToString();
                        lst.trainingCenter = dr["centerName"].ToString();
                        lst.trainer = dr["trainer"].ToString();
                        lst.assessor = dr["assessor"].ToString();
                        lst.startDate = Convert.ToDateTime(dr["startDate"]);
                        lst.endDate = Convert.ToDateTime(dr["endDate"]);
                        lst.status = Convert.ToInt32(dr["status"]);
                        bList.Add(lst);
                    }

                }
                conn.Close();
            }
            return bList;
        }

        public BatchList GetBatchDetailToViewByID(int id)
        {
            BatchList bList = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetBatchDetailToViewByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        bList = new BatchList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.batchID = dr["batchID"].ToString();
                        bList.sectorName = dr["sectorName"].ToString();
                        bList.jobRole = dr["jobRole"].ToString();
                        bList.jobDetail = dr["jobRoleDetails"].ToString();
                        bList.trainingCenter = dr["centerName"].ToString();
                        bList.trainer = dr["trainer"].ToString();
                        bList.assessor = dr["assessor"].ToString();
                        bList.startDate = Convert.ToDateTime(dr["startDate"]);
                        bList.endDate = Convert.ToDateTime(dr["endDate"]);
                        bList.status = Convert.ToInt32(dr["status"]);
                        
                    }
                }
            }
            return bList;

        }
        public BatchList GetBatchDetailToEditByID(int id)
        {
            BatchList bList = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetBatchDetailToEditByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        bList = new BatchList();
                        bList.id = Convert.ToInt32(dr["id"]);
                        bList.sectorID = Convert.ToInt32(dr["sectorID"]);
                        bList.jobRoleID = Convert.ToInt32(dr["jobRoleID"]);

                        bList.jobDetailID = Convert.ToInt32(dr["jobDetailID"]);
                        bList.trainingCenterID = Convert.ToInt32(dr["trainingCenterID"]);
                        bList.trainerID = Convert.ToInt32(dr["trainerID"]);
                        bList.assessorID = Convert.ToInt32(dr["assessorID"]);

                        bList.startDate = Convert.ToDateTime(dr["startDate"]);
                        bList.endDate = Convert.ToDateTime(dr["endDate"]);
                    }
                }
            }
            return bList;

        }

        public bool InsertBatchDetail(BatchListDTO bList)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertTMBatch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@batchID", SqlDbType.VarChar).Value = bList.batchID;
                cmd.Parameters.Add("@sectorID", SqlDbType.Int).Value = bList.sectorID;
                cmd.Parameters.Add("@jobRoleID", SqlDbType.Int).Value = bList.jobRoleID;
                cmd.Parameters.Add("@jobDetailID", SqlDbType.Int).Value = bList.jobDetailID;
                cmd.Parameters.Add("@trainingCenterID", SqlDbType.Int).Value = bList.trainingCenterID;
                cmd.Parameters.Add("@trainerID", SqlDbType.Int).Value = bList.trainerID;
                cmd.Parameters.Add("@assessorID", SqlDbType.Int).Value = bList.assessorID;
                cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = bList.startDate;
                cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = bList.endDate;
                cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = bList.createdBy;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }
        public bool UpdateBatchDetail(BatchListDTO bList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateTMBatch", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = bList.id;
                    cmd.Parameters.Add("@sectorID", SqlDbType.Int).Value = bList.sectorID;
                    cmd.Parameters.Add("@jobRoleID", SqlDbType.Int).Value = bList.jobRoleID;
                    cmd.Parameters.Add("@jobDetailID", SqlDbType.Int).Value = bList.jobDetailID;
                    cmd.Parameters.Add("@trainingCenterID", SqlDbType.Int).Value = bList.trainingCenterID;
                    cmd.Parameters.Add("@trainerID", SqlDbType.Int).Value = bList.trainerID;
                    cmd.Parameters.Add("@assessorID", SqlDbType.Int).Value = bList.assessorID;
                    cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = bList.startDate;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = bList.endDate;
                    cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = bList.createdBy;
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

        public bool ChangeBatchStatus(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_ChangeBatchStatus", conn);
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


        public List<BatchImageDTO> GetBatchWiseImages(int batchID)
        {
            List<BatchImageDTO> bList = new List<BatchImageDTO>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetBatchWiseImages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@batchID", SqlDbType.Int).Value = batchID;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BatchImageDTO lst = new BatchImageDTO();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.batchID = Convert.ToInt32(dr["batchID"]);
                        lst.imageURLName = dr["imageURL"].ToString();                        
                        lst.createdOn = Convert.ToDateTime(dr["createdOn"]);
                        bList.Add(lst);
                    }

                }
                conn.Close();
            }
            return bList;
        }

        public bool InsertBatchImages(int batchID, int createdBy, List<string> imageFileNames)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                foreach (string image in imageFileNames)
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertTDTrainingCenterImage", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@batchID", SqlDbType.Int).Value = batchID;
                    cmd.Parameters.Add("@imageURL", SqlDbType.VarChar).Value = image;
                    cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = createdBy;

                    cmd.ExecuteNonQuery();

                }
                conn.Close();
                return true;
            }
        }

        public bool DeleteBatchInages(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_DeleteTDBatchImage", conn);
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
