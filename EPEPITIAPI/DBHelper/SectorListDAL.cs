using EPEPITIAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace EPEPITIAPI.DBHelper
{
    public class SectorListDAL
    {
        private readonly string _connectionString;

        public SectorListDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public List<SectorList> GetSectorAll()
        {
            List<SectorList> lstSectorList = new List<SectorList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetSectorAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SectorList lst = new SectorList();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.sectorName = dr["sectorName"].ToString();
                        lst.status = Convert.ToInt32(dr["status"]);
                        lstSectorList.Add(lst);
                    }

                }
                conn.Close();
            }
            return lstSectorList;
        }

        public SectorList GetSectorToEditByID(int id)
        {
            SectorList sList = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetSectorToEditByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sList = new SectorList();
                        sList.id = Convert.ToInt32(dr["id"]);
                        sList.sectorName = dr["sectorName"].ToString();
                    }
                }
            }
            return sList;

        }

        public int InsertSectorData(SectorList sList)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertTMSector", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add("@sectorName", SqlDbType.VarChar).Value = sList.sectorName;
                cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = sList.createdBy;
                conn.Open();
                //cmd.ExecuteNonQuery();
                //conn.Close();
                //return true;
                object result = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(result);
            }
        }

        public int UpdateSectorData(SectorList sList)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateTMSector", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = sList.id;
                    cmd.Parameters.Add("@sectorName", SqlDbType.VarChar).Value = sList.sectorName;
                    cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = sList.createdBy;
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


        public bool ChangeSectorStatus(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_ChangeSectorStatus", conn);
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
