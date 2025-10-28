using EPEPITIAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace EPEPITIAPI.DBHelper
{
    public class AttendanceListDAL
    {
        private readonly string _connectionString;
        public AttendanceListDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }


        public AttendanceList GetAadhaarWiseCandidate(string aadhaar)
        {
            AttendanceList cList = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAadhaarWiseCandidate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@aadhaar", SqlDbType.VarChar).Value = aadhaar;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cList = new AttendanceList();

                        cList.id = Convert.ToInt32(dr["id"]);
                        cList.batchID = dr["batchID"].ToString();
                        cList.candidateName = dr["candidateName"].ToString();
                        cList.aadhaar = dr["aadhaar"].ToString();
                        cList.mobile = dr["mobile"].ToString();
                        cList.startDate = Convert.ToDateTime(dr["startDate"]);
                        cList.endDate = Convert.ToDateTime(dr["endDate"]);
                        cList.candidateID = dr["candidateID"].ToString();
                        cList.sectorName = dr["sectorName"].ToString();
                        cList.jobRole = dr["jobRole"].ToString();
                        cList.jobRoleDetails = dr["jobRoleDetails"].ToString();
                        cList.fhName = dr["fhName"].ToString();
                        cList.nsqfCode = dr["nsqfCode"].ToString();
                        cList.dob = Convert.ToDateTime(dr["dob"]);
                        cList.district = dr["district"].ToString();
                        cList.stateName = dr["stateName"].ToString();
                        cList.day1 = Convert.ToInt32(dr["day1"]);
                        cList.day2 = Convert.ToInt32(dr["day2"]);
                        cList.day3 = Convert.ToInt32(dr["day3"]);
                        cList.day4 = Convert.ToInt32(dr["day4"]);
                        cList.day5 = Convert.ToInt32(dr["day5"]);
                        cList.profileImage = dr["profileImage"].ToString();                        
                    }

                }
                conn.Close();
            }
            return cList;
        }

        public List<AttendanceList> GetBatchWiseCandidate(int batchID)
        {
            List<AttendanceList> bList = new List<AttendanceList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetBatchWiseCandidate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = batchID;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        AttendanceList lst = new AttendanceList();

                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.batchID = dr["batchID"].ToString();
                        lst.candidateName = dr["candidateName"].ToString();
                        lst.aadhaar = dr["aadhaar"].ToString();
                        lst.mobile = dr["mobile"].ToString();
                        lst.startDate = Convert.ToDateTime(dr["startDate"]);
                        lst.endDate = Convert.ToDateTime(dr["endDate"]);
                        lst.candidateID = dr["candidateID"].ToString();
                        lst.sectorName = dr["sectorName"].ToString();
                        lst.jobRole = dr["jobRole"].ToString();
                        lst.jobRoleDetails = dr["jobRoleDetails"].ToString();
                        lst.fhName = dr["fhName"].ToString();
                        lst.nsqfCode = dr["nsqfCode"].ToString();
                        lst.dob = Convert.ToDateTime(dr["dob"]);
                        lst.district = dr["district"].ToString();
                        lst.stateName = dr["stateName"].ToString();
                        lst.day1 = Convert.ToInt32(dr["day1"]);
                        lst.day2 = Convert.ToInt32(dr["day2"]);
                        lst.day3 = Convert.ToInt32(dr["day3"]);
                        lst.day4 = Convert.ToInt32(dr["day4"]);
                        lst.day5 = Convert.ToInt32(dr["day5"]);
                        lst.profileImage = dr["profileImage"].ToString();

                        bList.Add(lst);
                    }

                }
                conn.Close();
            }
            return bList;
        }
        public List<AttendanceList> GetBatchWiseAttendance(int batchID)
        {
            List<AttendanceList> bList = new List<AttendanceList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetBatchWiseAttendance", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@batchID", SqlDbType.Int).Value = batchID;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        AttendanceList lst = new AttendanceList();
                        
                        lst.batchID = dr["batchID"].ToString();
                        lst.candidateName = dr["candidateName"].ToString();
                        lst.aadhaar = dr["aadhaar"].ToString();
                        lst.mobile = dr["mobile"].ToString();
                        lst.startDate = Convert.ToDateTime(dr["startDate"]);
                        lst.endDate = Convert.ToDateTime(dr["endDate"]);
                        lst.day1 = Convert.ToInt32(dr["day1"]);
                        lst.day2 = Convert.ToInt32(dr["day2"]);
                        lst.day3 = Convert.ToInt32(dr["day3"]);
                        lst.day4 = Convert.ToInt32(dr["day4"]);
                        lst.day5 = Convert.ToInt32(dr["day5"]);

                        bList.Add(lst);
                    }

                }
                conn.Close();
            }
            return bList;
        }
        public bool MarkAttendance(AttendanceListDTO aList)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_MarkAttendance", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@batchID", SqlDbType.VarChar).Value = aList.batchID;
                cmd.Parameters.Add("@candidateID", SqlDbType.Int).Value = aList.candidateID;
                cmd.Parameters.Add("@dayNo", SqlDbType.Int).Value = aList.dayNo;
                cmd.Parameters.Add("@lat", SqlDbType.VarChar).Value = aList.latitude;
                cmd.Parameters.Add("@long", SqlDbType.VarChar).Value = aList.longitude;
                cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = aList.createdBy;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }
        public bool UnMarkAttendance(AttendanceListDTO aList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_UnMarkAttendance", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@batchID", SqlDbType.VarChar).Value = aList.batchID;
                    cmd.Parameters.Add("@candidateID", SqlDbType.Int).Value = aList.candidateID;
                    cmd.Parameters.Add("@dayNo", SqlDbType.Int).Value = aList.dayNo;
                    cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = aList.createdBy;
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
        public List<AttendanceList> GetCandidateToAllocateBatch(int batchID)
        {
            List<AttendanceList> bList = new List<AttendanceList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetCandidateToAllocateBatch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = batchID;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        AttendanceList lst = new AttendanceList();

                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.candidateID = dr["candidateID"].ToString();
                        lst.candidateName = dr["candidateName"].ToString();
                        lst.aadhaar = dr["aadhaar"].ToString();
                        lst.aadhaarLinkedMobile = dr["aadhaarLinkedMobile"].ToString(); 
                        lst.mobile = dr["mobile"].ToString();                        
                        lst.address = dr["address"].ToString();
                        lst.batchIDInt = Convert.ToInt32(dr["batchID"]);
                        lst.gender = dr["gender"].ToString();
                        lst.dob = Convert.ToDateTime(dr["dob"]);
                        lst.fhName = dr["fhName"].ToString();
                        lst.religion = dr["religion"].ToString();
                        lst.category = dr["category"].ToString();
                        lst.pan = dr["pan"].ToString();
                        lst.sectorName = dr["sectorName"].ToString();
                        lst.jobRole = dr["jobRole"].ToString();
                        lst.jobRoleDetails = dr["jobRoleDetails"].ToString();
                        lst.pin = dr["pin"].ToString();

                        lst.stateName = dr["stateName"].ToString();
                        lst.district = dr["district"].ToString();
                        lst.qualification = dr["qualification"].ToString();
                        lst.disabilityYN = dr["disabilityYN"].ToString();
                        lst.disability = dr["disability"].ToString();


                        bList.Add(lst);
                    }

                }
                conn.Close();
            }
            return bList;
        }


        public bool AllocateBatchToCandidates(List<AttendanceListDTO> candidate)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    foreach (var cList in candidate)
                    {
                        SqlCommand cmd = new SqlCommand("SP_AllocateBatchToCandidate", conn, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();

                        cmd.Parameters.Add("@candidateID", SqlDbType.Int).Value = cList.candidateID;
                        cmd.Parameters.Add("@batchID", SqlDbType.Int).Value = cList.batchID;
                        cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = cList.createdBy;

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

    }
}
