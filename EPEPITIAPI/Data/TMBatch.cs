using System.ComponentModel.DataAnnotations;

namespace EPEPITIAPI.Data
{
    public class TMBatch
    {
        [Key]
        public int id { get; set; }
        public string? batchID { get; set; }
        public int? sectorID { get; set; }
        public int? jobRoleID { get; set; }
        public int? jobDetailID { get; set; }
        public int? trainingCenterID { get; set; }
        public int? trainerID { get; set; }
        public int? assessorID { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public int? status { get; set; }
        public int? createdBy { get; set; }
        public DateTime? createdOn { get; set; }
        public int? updatedBy { get; set; }
        public DateTime? updatedOn { get; set; }
        public string? batch_ext_id { get; set; }
        public string? batch_name { get; set; }
        public int? min_length { get; set; }
        public int? max_length { get; set; }
        public string? approval_status { get; set; }
        public DateTime? approval_date { get; set; }
        public string? reject_reason { get; set; }
    }
}
