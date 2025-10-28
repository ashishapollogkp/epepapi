using EPEPITIAPI.Models;
using Microsoft.AspNetCore.Routing.Matching;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EPEPITIAPI.DBHelper
{
    public class CandidateListDAL
    {
        private readonly string _connectionString;

        public CandidateListDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public List<CandidateList> GetCandidateDetailAll()
        {
            List<CandidateList> lstCandidateList = new List<CandidateList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetCandidateDetailAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CandidateList lst = new CandidateList();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.candidateName = dr["candidateName"].ToString();
                        lst.mobile = dr["mobile"].ToString();                       
                        lst.aadhaar = dr["aadhaar"].ToString(); 
                        lst.aadhaarLinkedMobile = dr["aadhaarLinkedMobile"].ToString();
                        lst.dob = Convert.ToDateTime(dr["dob"]);
                        lst.gender = Convert.ToInt32(dr["gender"]);
                        lst.fhName = dr["fhName"].ToString();
                        lst.religion = dr["religion"].ToString();
                        lst.category = dr["category"].ToString();
                        lst.pan = dr["pan"].ToString();
                        lst.sectorName = dr["sectorName"].ToString();
                        lst.jobRole = dr["jobRole"].ToString();
                        lst.jobDetail = dr["jobRoleDetails"].ToString();                        
                        lst.pin = dr["pin"].ToString();
                        lst.state = dr["stateName"].ToString();
                        lst.district = dr["district"].ToString();
                        lst.address = dr["address"].ToString();
                        lst.qualification = dr["qualification"].ToString();
                        lst.disability = dr["disability"].ToString();
                        lst.profileImageName = dr["profileImage"].ToString();
                        lst.aadhaarFrontName = dr["aadhaarFront"].ToString();
                        lst.aadhaarBackName = dr["aadhaarBack"].ToString();
                        lst.status = Convert.ToInt32(dr["status"]);

                        lstCandidateList.Add(lst);
                    }

                }
                conn.Close();
            }
            return lstCandidateList;
        }

        public List<CandidateList> GetAllocatedCandidateDetailAll()
        {
            List<CandidateList> lstCandidateList = new List<CandidateList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllocatedCandidateDetailAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CandidateList lst = new CandidateList();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.candidateName = dr["candidateName"].ToString();
                        lst.batchID = dr["batchID"].ToString();
                        lst.mobile = dr["mobile"].ToString();
                        lst.aadhaar = dr["aadhaar"].ToString();
                        lst.aadhaarLinkedMobile = dr["aadhaarLinkedMobile"].ToString();
                        lst.dob = Convert.ToDateTime(dr["dob"]);
                        lst.gender = Convert.ToInt32(dr["gender"]);
                        lst.fhName = dr["fhName"].ToString();
                        lst.religion = dr["religion"].ToString();
                        lst.category = dr["category"].ToString();
                        lst.pan = dr["pan"].ToString();
                        lst.sectorName = dr["sectorName"].ToString();
                        lst.jobRole = dr["jobRole"].ToString();
                        lst.jobDetail = dr["jobRoleDetails"].ToString();
                        lst.pin = dr["pin"].ToString();
                        lst.state = dr["stateName"].ToString();
                        lst.district = dr["district"].ToString();
                        lst.address = dr["address"].ToString();
                        lst.qualification = dr["qualification"].ToString();
                        lst.disability = dr["disability"].ToString();
                        lst.profileImageName = dr["profileImage"].ToString();
                        lst.aadhaarFrontName = dr["aadhaarFront"].ToString();
                        lst.aadhaarBackName = dr["aadhaarBack"].ToString();
                        lst.status = Convert.ToInt32(dr["status"]);

                        lstCandidateList.Add(lst);
                    }

                }
                conn.Close();
            }
            return lstCandidateList;
        }

        public CandidateList GetCandidateDetailToEditByID(int id)
        {
            CandidateList cList = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetCandidateDetailToEditByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cList = new CandidateList();
                        cList.id = Convert.ToInt32(dr["id"]);
                        cList.candidateName = dr["candidateName"].ToString();
                        cList.mobile = dr["mobile"].ToString();
                        cList.aadhaar = dr["aadhaar"].ToString();
                        cList.aadhaarLinkedMobile = dr["aadhaarLinkedMobile"].ToString();
                        cList.dob = Convert.ToDateTime(dr["dob"]);
                        cList.gender = Convert.ToInt32(dr["gender"]);
                        cList.fhName = dr["fhName"].ToString();
                        cList.religionID = Convert.ToInt32(dr["religionID"]);
                        cList.categoryID = Convert.ToInt32(dr["categoryID"]);
                        cList.pan = dr["pan"].ToString();
                        cList.sectorID = Convert.ToInt32(dr["sectorID"]);
                        cList.jobRoleID = Convert.ToInt32(dr["jobRoleID"]);
                        cList.jobDetailID = Convert.ToInt32(dr["jobDetailID"]);                        
                        cList.pin = dr["pin"].ToString();
                        cList.stateID = Convert.ToInt32(dr["stateID"]);
                        cList.district = dr["district"].ToString();
                        cList.address = dr["address"].ToString();
                        cList.qualificationID = Convert.ToInt32(dr["qualificationID"]);
                        cList.disabilityYN = Convert.ToInt32(dr["disabilityYN"]);
                        cList.disability = dr["disability"].ToString();
                        cList.profileImageName = dr["profileImage"].ToString();
                        cList.aadhaarFrontName = dr["aadhaarFront"].ToString();
                        cList.aadhaarBackName = dr["aadhaarBack"].ToString();
                    }
                }
            }
            return cList;

        }

        public bool InsertCandidateData(CandidateListDTO cList)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertTMCandidate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@candidateName", SqlDbType.VarChar).Value = cList.candidateName;
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = cList.mobile;
                cmd.Parameters.Add("@aadhaar", SqlDbType.VarChar).Value = cList.aadhaar; 
                cmd.Parameters.Add("@aadhaarLinkedMobile", SqlDbType.VarChar).Value = cList.aadhaarLinkedMobile;
                cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = cList.dob;
                cmd.Parameters.Add("@gender", SqlDbType.Int).Value = cList.gender;
                cmd.Parameters.Add("@fhName", SqlDbType.VarChar).Value = cList.fhName;
                cmd.Parameters.Add("@religionID", SqlDbType.Int).Value = cList.religionID;
                cmd.Parameters.Add("@categoryID", SqlDbType.Int).Value = cList.categoryID;
                cmd.Parameters.Add("@pan", SqlDbType.VarChar).Value = cList.pan;
                cmd.Parameters.Add("@sectorID", SqlDbType.Int).Value = cList.sectorID;
                cmd.Parameters.Add("@jobRoleID", SqlDbType.Int).Value = cList.jobRoleID;
                cmd.Parameters.Add("@jobDetailID", SqlDbType.Int).Value = cList.jobDetailID;
                cmd.Parameters.Add("@pin", SqlDbType.VarChar).Value = cList.pin;
                cmd.Parameters.Add("@stateID", SqlDbType.Int).Value = cList.stateID;
                cmd.Parameters.Add("@district", SqlDbType.VarChar).Value = cList.district;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = cList.address;
                cmd.Parameters.Add("@qualificationID", SqlDbType.Int).Value = cList.qualificationID;
                cmd.Parameters.Add("@disabilityYN", SqlDbType.Int).Value = cList.disabilityYN;
                cmd.Parameters.Add("@disability", SqlDbType.VarChar).Value = cList.disability;
                cmd.Parameters.Add("@profileImage", SqlDbType.VarChar).Value = cList.profileImageName;
                cmd.Parameters.Add("@aadhaarFront", SqlDbType.VarChar).Value = cList.aadhaarFrontName;
                cmd.Parameters.Add("@aadhaarBack", SqlDbType.VarChar).Value = cList.aadhaarBackName;
                cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = cList.createdBy;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public bool UpdateCandidateData(CandidateListDTO jList)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateTMCandidate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = jList.id;
                cmd.Parameters.Add("@candidateName", SqlDbType.VarChar).Value = jList.candidateName;
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = jList.mobile;
                cmd.Parameters.Add("@aadhaar", SqlDbType.VarChar).Value = jList.aadhaar;
                cmd.Parameters.Add("@aadhaarLinkedMobile", SqlDbType.VarChar).Value = jList.aadhaarLinkedMobile;
                cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = jList.dob;
                cmd.Parameters.Add("@gender", SqlDbType.Int).Value = jList.gender;
                cmd.Parameters.Add("@fhName", SqlDbType.VarChar).Value = jList.fhName;
                cmd.Parameters.Add("@religionID", SqlDbType.Int).Value = jList.religionID;
                cmd.Parameters.Add("@categoryID", SqlDbType.Int).Value = jList.categoryID;
                cmd.Parameters.Add("@pan", SqlDbType.VarChar).Value = jList.pan;
                cmd.Parameters.Add("@sectorID", SqlDbType.Int).Value = jList.sectorID;
                cmd.Parameters.Add("@jobRoleID", SqlDbType.Int).Value = jList.jobRoleID;
                cmd.Parameters.Add("@jobDetailID", SqlDbType.Int).Value = jList.jobDetailID;
                cmd.Parameters.Add("@pin", SqlDbType.VarChar).Value = jList.pin;
                cmd.Parameters.Add("@stateID", SqlDbType.Int).Value = jList.stateID;
                cmd.Parameters.Add("@district", SqlDbType.VarChar).Value = jList.district;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = jList.address;
                cmd.Parameters.Add("@qualificationID", SqlDbType.Int).Value = jList.qualificationID;
                cmd.Parameters.Add("@disabilityYN", SqlDbType.Int).Value = jList.disabilityYN;
                cmd.Parameters.Add("@disability", SqlDbType.VarChar).Value = jList.disability;
                cmd.Parameters.Add("@profileImage", SqlDbType.VarChar).Value = jList.profileImageName;
                cmd.Parameters.Add("@aadhaarFront", SqlDbType.VarChar).Value = jList.aadhaarFrontName;
                cmd.Parameters.Add("@aadhaarBack", SqlDbType.VarChar).Value = jList.aadhaarBackName;
                cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = jList.createdBy;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public bool ChangeCandidateStatus(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_ChangeCandidateStatus", conn);
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



        public bool InsertBulkCandidate(List<CandidateListUploadDTO> candidate)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    foreach (var cList in candidate)
                    {
                        SqlCommand cmd = new SqlCommand("SP_InsertTMCandidateBulk", conn, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();

                        cmd.Parameters.Add("@candidateID", SqlDbType.VarChar).Value = cList.candidateID;
                        cmd.Parameters.Add("@candidateName", SqlDbType.VarChar).Value = cList.candidateName;
                        cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = cList.mobile;
                        cmd.Parameters.Add("@aadhaar", SqlDbType.VarChar).Value = cList.aadhaar;
                        cmd.Parameters.Add("@aadhaarLinkedMobile", SqlDbType.VarChar).Value = cList.aadhaarLinkedMobile;
                        cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = cList.dob;
                        cmd.Parameters.Add("@gender", SqlDbType.Int).Value = cList.gender;
                        cmd.Parameters.Add("@fhName", SqlDbType.VarChar).Value = cList.fhName;
                        cmd.Parameters.Add("@religionID", SqlDbType.Int).Value = cList.religionID;
                        cmd.Parameters.Add("@categoryID", SqlDbType.Int).Value = cList.categoryID;
                        cmd.Parameters.Add("@pan", SqlDbType.VarChar).Value = cList.pan;
                        cmd.Parameters.Add("@sectorID", SqlDbType.Int).Value = cList.sectorID;
                        cmd.Parameters.Add("@jobRoleID", SqlDbType.Int).Value = cList.jobRoleID;
                        cmd.Parameters.Add("@jobDetailID", SqlDbType.Int).Value = cList.jobDetailID;
                        cmd.Parameters.Add("@pin", SqlDbType.VarChar).Value = cList.pin;
                        cmd.Parameters.Add("@stateID", SqlDbType.Int).Value = cList.stateID;
                        cmd.Parameters.Add("@district", SqlDbType.VarChar).Value = cList.district;
                        cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = cList.address;
                        cmd.Parameters.Add("@qualificationID", SqlDbType.Int).Value = cList.qualificationID;
                        cmd.Parameters.Add("@disabilityYN", SqlDbType.Int).Value = cList.disabilityYN;
                        cmd.Parameters.Add("@disability", SqlDbType.VarChar).Value = cList.disability;
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

        public bool CheckDuplicateAadhaar(string aadhaar)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CheckDuplicateAadhaar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@aadhaar", SqlDbType.VarChar).Value = aadhaar;
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        return Convert.ToBoolean(dr["isDuplicateAadhaar"]);
                    }
                }
            }
            return false;
        }

    }

}
