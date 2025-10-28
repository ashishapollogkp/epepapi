using EPEPITIAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace EPEPITIAPI.DBHelper
{
    public class PartnerListDAL
    {
        private readonly string _connectionString;

        public PartnerListDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public List<PartnerList> GetPartnerDetailAll()
        {
            List<PartnerList> lstSectorList = new List<PartnerList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetPartnerDetailAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PartnerList lst = new PartnerList();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.firmName = dr["firmName"].ToString();
                        lst.partnerType = dr["partnerType"].ToString();
                        lst.contactPerson = dr["contactPerson"].ToString();
                        lst.contactMobile = dr["contactMobile"].ToString();
                        lst.contactEmail = dr["contactEmail"].ToString();
                        lst.firmAddress = dr["firmAddress"].ToString();
                        lst.status = Convert.ToInt32(dr["status"]);
                        lstSectorList.Add(lst);
                    }

                }
                conn.Close();
            }
            return lstSectorList;
        }

        public PartnerList GetPartnerDetailToViewByID(int id)
        {
            PartnerList pList = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetPartnerDetailToViewByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        pList = new PartnerList();
                        pList.id = Convert.ToInt32(dr["id"]);
                        pList.partnerType = dr["partnerType"].ToString();
                        pList.firmName = dr["firmName"].ToString();
                        pList.contactPerson = dr["contactPerson"].ToString();
                        pList.contactMobile = dr["contactMobile"].ToString();
                        pList.contactEmail = dr["contactEmail"].ToString();
                        pList.firmAddress = dr["firmAddress"].ToString();
                        pList.status = Convert.ToInt32(dr["status"]);
                        pList.createdByName = dr["createdBy"].ToString();
                        pList.createdOn = Convert.ToDateTime(dr["createdOn"]);
                        pList.updatedByName = dr["updatedBy"].ToString();
                        pList.updatedOn = Convert.ToDateTime(dr["updatedOn"]);
                    }
                }
            }
            return pList;

        }

        public PartnerList GetPartnerDetailToEditByID(int id)
        {
            PartnerList pList = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetPartnerDetailToEditByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        pList = new PartnerList();
                        pList.id = Convert.ToInt32(dr["id"]);
                        pList.partnerTypeID = Convert.ToInt32(dr["partnerTypeID"]);
                        pList.firmName = dr["firmName"].ToString();
                        pList.contactPerson = dr["contactPerson"].ToString();
                        pList.contactMobile = dr["contactMobile"].ToString();
                        pList.contactEmail = dr["contactEmail"].ToString();
                        pList.firmAddress = dr["firmAddress"].ToString();

                    }
                }
            }
            return pList;

        }

        public bool InsertPartnerData(PartnerListDTO pList)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertTMPartner", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@partnerTypeID", SqlDbType.Int).Value = pList.partnerTypeID;
                cmd.Parameters.Add("@firmName", SqlDbType.VarChar).Value = pList.firmName;
                cmd.Parameters.Add("@contactPerson", SqlDbType.VarChar).Value = pList.contactPerson;
                cmd.Parameters.Add("@contactMobile", SqlDbType.VarChar).Value = pList.contactMobile;
                cmd.Parameters.Add("@contactEmail", SqlDbType.VarChar).Value = pList.contactEmail;
                cmd.Parameters.Add("@firmAddress", SqlDbType.VarChar).Value = pList.firmAddress;
                cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = pList.createdBy;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public bool UpdatePartnerData(PartnerListDTO pList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateTMPartner", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = pList.id;
                    cmd.Parameters.Add("@partnerTypeID", SqlDbType.Int).Value = pList.partnerTypeID;
                    cmd.Parameters.Add("@firmName", SqlDbType.VarChar).Value = pList.firmName;
                    cmd.Parameters.Add("@contactPerson", SqlDbType.VarChar).Value = pList.contactPerson;
                    cmd.Parameters.Add("@contactMobile", SqlDbType.VarChar).Value = pList.contactMobile;
                    cmd.Parameters.Add("@contactEmail", SqlDbType.VarChar).Value = pList.contactEmail;
                    cmd.Parameters.Add("@firmAddress", SqlDbType.VarChar).Value = pList.firmAddress;
                    cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = pList.createdBy;
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

        public bool ChangePartnerStatus(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_ChangePartnerStatus", conn);
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
