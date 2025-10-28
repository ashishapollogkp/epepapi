using EPEPITIAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EPEPITIAPI.DBHelper
{
    public class TrainingCenterListDAL
    {
        private readonly string _connectionString;

        public TrainingCenterListDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public List<TrainingCenterList> GetTrainingCenterDetailAll()
        {
            List<TrainingCenterList> lstCenterList = new List<TrainingCenterList>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_GetTrainingCenterDetailAll", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var lst = new TrainingCenterList();

                        lst.id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0;
                        lst.centerName = dr["centerName"]?.ToString();
                        lst.contactName = dr["contactName"]?.ToString();
                        lst.mobile = dr["mobile"]?.ToString();
                        lst.email = dr["email"]?.ToString();
                        lst.address = dr["address"]?.ToString();
                        lst.longitude = dr["long"]?.ToString();
                        lst.latitude = dr["lat"]?.ToString();
                        lst.pin = dr["pin"]?.ToString();
                        lst.stateName = dr["stateName"]?.ToString();
                        lst.district = dr["district"]?.ToString();
                        lst.status = dr["status"] != DBNull.Value ? Convert.ToInt32(dr["status"]) : 0;
                        lst.tc_id = dr["tc_id"]?.ToString();
                        lst.approval_status = dr["approval_status"]?.ToString();

                        lst.approval_date = dr["approval_date"] != DBNull.Value
                            ? Convert.ToDateTime(dr["approval_date"])
                            : (DateTime?)null;

                        lst.reject_reason = dr["reject_reason"]?.ToString();

                        // ✅ Fixed image paths and null handling
                        lst.image_path1 = !string.IsNullOrEmpty(dr["image_path1"]?.ToString())
                            ? "/Traning/" + dr["image_path1"].ToString()
                            : string.Empty;

                        lst.image_path2 = !string.IsNullOrEmpty(dr["image_path2"]?.ToString())
                            ? "/Traning/" + dr["image_path2"].ToString()
                            : string.Empty;

                        lst.image_path3 = !string.IsNullOrEmpty(dr["image_path3"]?.ToString())
                            ? "/Traning/" + dr["image_path3"].ToString()
                            : string.Empty;

                        lstCenterList.Add(lst);
                    }
                }
            }

            return lstCenterList;
        }


        public List<TrainingCenterList> GetTrainingCenterDetailToViewByID(int id)
        {
            List<TrainingCenterList> lstCenterImgList = new List<TrainingCenterList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetTrainingCenterDetailToViewByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TrainingCenterList lst = new TrainingCenterList();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.centerName = dr["centerName"].ToString();
                        lst.contactName = dr["contactName"].ToString();
                        lst.mobile = dr["mobile"].ToString();
                        lst.email = dr["email"].ToString();
                        lst.address = dr["address"].ToString();
                        lst.longitude = dr["long"].ToString();
                        lst.latitude = dr["lat"].ToString();
                        lst.pin = dr["pin"].ToString();
                        lst.stateName = dr["stateName"].ToString();
                        lst.district = dr["district"].ToString();
                       // lst.imageURL = dr["imageURL"].ToString();

                        lst.tc_id = dr["tc_id"]?.ToString();
                        lst.approval_status = dr["approval_status"]?.ToString();

                        lst.approval_date = dr["approval_date"] != DBNull.Value
                            ? Convert.ToDateTime(dr["approval_date"])
                            : (DateTime?)null;

                        lst.reject_reason = dr["reject_reason"]?.ToString();

                        // ✅ Fixed image paths and null handling
                        lst.image_path1 = !string.IsNullOrEmpty(dr["image_path1"]?.ToString())
                            ? "/Traning/" + dr["image_path1"].ToString()
                            : string.Empty;

                        lst.image_path2 = !string.IsNullOrEmpty(dr["image_path2"]?.ToString())
                            ? "/Traning/" + dr["image_path2"].ToString()
                            : string.Empty;

                        lst.image_path3 = !string.IsNullOrEmpty(dr["image_path3"]?.ToString())
                            ? "/Traning/" + dr["image_path3"].ToString()
                            : string.Empty;


                        lstCenterImgList.Add(lst);
                    }

                }
                conn.Close();
            }
            return lstCenterImgList;
        }

        public TrainingCenterList GetTrainingCenterDetailToEditByID(int id)
        {
            TrainingCenterList cList = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetTrainingCenterDetailToEditByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cList = new TrainingCenterList();
                        cList.id = Convert.ToInt32(dr["id"]);
                        cList.centerName = dr["centerName"].ToString();
                        cList.contactName = dr["contactName"].ToString();
                        cList.mobile = dr["mobile"].ToString();
                        cList.email = dr["email"].ToString();
                        cList.address = dr["address"].ToString();
                        cList.longitude = dr["long"].ToString();
                        cList.latitude = dr["lat"].ToString();
                        cList.pin = dr["pin"].ToString();
                        cList.stateID = Convert.ToInt32(dr["stateID"]);
                        cList.district = dr["district"].ToString();



                        cList.tc_id = dr["tc_id"]?.ToString();
                        cList.approval_status = dr["approval_status"]?.ToString();

                        cList.approval_date = dr["approval_date"] != DBNull.Value
                            ? Convert.ToDateTime(dr["approval_date"])
                            : (DateTime?)null;

                        cList.reject_reason = dr["reject_reason"]?.ToString();

                        // ✅ Fixed image paths and null handling
                        cList.image_path1 = !string.IsNullOrEmpty(dr["image_path1"]?.ToString())
                            ? "/Traning/" + dr["image_path1"].ToString()
                            : string.Empty;

                        cList.image_path2 = !string.IsNullOrEmpty(dr["image_path2"]?.ToString())
                            ? "/Traning/" + dr["image_path2"].ToString()
                            : string.Empty;

                        cList.image_path3 = !string.IsNullOrEmpty(dr["image_path3"]?.ToString())
                            ? "/Traning/" + dr["image_path3"].ToString()
                            : string.Empty;


                    }
                }
            }
            return cList;

        }

        public bool InsertTrainingCenterDetail(TrainingCenterList cList)
        {

            if (cList.image_path1_byte != null && cList.image_path1_byte.Length > 0)
                cList.image_path1 = SaveImageProfile(cList.image_path1_byte);

            if (cList.image_path2_byte != null && cList.image_path2_byte.Length > 0)
                cList.image_path2 = SaveImageProfile(cList.image_path2_byte);

            if (cList.image_path3_byte != null && cList.image_path3_byte.Length > 0)
                cList.image_path3 = SaveImageProfile(cList.image_path3_byte);





            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertTMTrainingCenter", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@centerName", SqlDbType.VarChar).Value = cList.centerName;
                cmd.Parameters.Add("@contactName", SqlDbType.VarChar).Value = cList.contactName;
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = cList.mobile;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = cList.email;
                cmd.Parameters.Add("@long", SqlDbType.VarChar).Value = cList.longitude;
                cmd.Parameters.Add("@lat", SqlDbType.VarChar).Value = cList.latitude;
                cmd.Parameters.Add("@pin", SqlDbType.VarChar).Value = cList.pin;
                cmd.Parameters.Add("@stateID", SqlDbType.Int).Value = cList.stateID;
                cmd.Parameters.Add("@district", SqlDbType.VarChar).Value = cList.district;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = cList.address;
                cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = cList.createdBy;
                cmd.Parameters.Add("@tc_id", SqlDbType.NVarChar).Value = cList.tc_id;

                cmd.Parameters.Add("@image_path1", SqlDbType.NVarChar).Value = cList.image_path1;
                cmd.Parameters.Add("@image_path2", SqlDbType.NVarChar).Value = cList.image_path2;
                cmd.Parameters.Add("@image_path3", SqlDbType.NVarChar).Value = cList.image_path3;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public bool UpdateTrainingCenterDetail(TrainingCenterList cList)
        {

            if (cList.image_path1_byte != null && cList.image_path1_byte.Length > 0)
                cList.image_path1 = SaveImageProfile(cList.image_path1_byte);

            if (cList.image_path2_byte != null && cList.image_path2_byte.Length > 0)
                cList.image_path2 = SaveImageProfile(cList.image_path2_byte);

            if (cList.image_path3_byte != null && cList.image_path3_byte.Length > 0)
                cList.image_path3 = SaveImageProfile(cList.image_path3_byte);


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateTMTrainingCenter", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = cList.id;
                cmd.Parameters.Add("@centerName", SqlDbType.VarChar).Value = cList.centerName;
                cmd.Parameters.Add("@contactName", SqlDbType.VarChar).Value = cList.contactName;
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = cList.mobile;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = cList.email;
                cmd.Parameters.Add("@long", SqlDbType.VarChar).Value = cList.longitude;
                cmd.Parameters.Add("@lat", SqlDbType.VarChar).Value = cList.latitude;
                cmd.Parameters.Add("@pin", SqlDbType.VarChar).Value = cList.pin;
                cmd.Parameters.Add("@stateID", SqlDbType.Int).Value = cList.stateID;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = cList.address;
                cmd.Parameters.Add("@district", SqlDbType.VarChar).Value = cList.district;
                cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = cList.createdBy;

                cmd.Parameters.Add("@tc_id", SqlDbType.NVarChar).Value = cList.tc_id;

                cmd.Parameters.Add("@image_path1", SqlDbType.NVarChar).Value = cList.image_path1;
                cmd.Parameters.Add("@image_path2", SqlDbType.NVarChar).Value = cList.image_path2;
                cmd.Parameters.Add("@image_path3", SqlDbType.NVarChar).Value = cList.image_path3;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }

        public bool ChangeTrainingCenterStatus(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_ChangeTrainingCenterStatus", conn);
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

        public List<TrainingCenterImageList> GetTrainingCenterImageByCenterID(int trainingCenterID)
        {
            List<TrainingCenterImageList> centerList = new List<TrainingCenterImageList>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetTrainingCenterImageByCenterID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@trainingCenterID", SqlDbType.Int).Value = trainingCenterID;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TrainingCenterImageList lst = new TrainingCenterImageList();
                        lst.id = Convert.ToInt32(dr["id"]);
                        lst.imageURLName = dr["imageURL"].ToString();
                        centerList.Add(lst);
                    }

                }
                conn.Close();
            }
            return centerList;

        }

        public bool InsertTrainingCenterImage(int trainingCenterID, int createdBy, List<string> imageFileNames)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                foreach (string image in imageFileNames)
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertTDTrainingCenterImage", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@trainingCenterID", SqlDbType.Int).Value = trainingCenterID;
                    cmd.Parameters.Add("@imageURL", SqlDbType.VarChar).Value = image;
                    cmd.Parameters.Add("@createdBy", SqlDbType.Int).Value = createdBy;
                    
                    cmd.ExecuteNonQuery();                 
                   
                }
                conn.Close();
                return true;
            }
        }


        public bool DeleteTrainingCenterImageByID(int trainingCenterID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_DeleteTrainingCenterImageByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = trainingCenterID;
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


        private string SaveImageProfile(byte[] ImageData)
        {
            try
            {
                string fileMapPath = Path.Combine(Environment.CurrentDirectory, @$"Uploads\Traning\");
                //string fileMapPath = "~/Image/InfractionImages/";

                if (!Directory.Exists(fileMapPath))
                    Directory.CreateDirectory(fileMapPath); //Create directory if it doesn't exist

                string imageName = "Traning_" + Guid.NewGuid().ToString() + ".jpg";  /*String.Format("{0:yyyyMMddhhmmss}", DateTime.Now)*/
                string imgPath = Path.Combine(fileMapPath, imageName);
                System.IO.File.WriteAllBytes(imgPath, ImageData);
                return Path.GetFileName(imgPath);
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
