using System.ComponentModel.DataAnnotations;

namespace EPEPITIAPI.Data
{
    public class TMTrainingCenter
    {
        [Key]
        public int id { get; set; }
        public string centerName { get; set; }
        public string pin { get; set; }
        public string district { get; set; }
        public int? stateID { get; set; }
        public string address { get; set; }
        public string longitude { get; set; } 
        public string latitude { get; set; }
        public string contactName { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public int? status { get; set; }
        public int? createdBy { get; set; }
        public DateTime? createdOn { get; set; }
        public int? updatedBy { get; set; }
        public DateTime? updatedOn { get; set; }
        public string? approval_status { get; set; }
        public DateTime? approval_date { get; set; }
        public string? reject_reason { get; set; }
        public string? tc_id { get; set; }
        public string? image_path1 { get; set; }
        public string? image_path2 { get; set; }
        public string? image_path3 { get; set; }
        public string? image_path4 { get; set; }
    }
}
