using System.ComponentModel.DataAnnotations;

namespace EPEPITIAPI.Models.BatchSection
{
    public class AddBatchRequest
    {

        [Required(ErrorMessage = "Batch ID is required.")]
        [StringLength(50, ErrorMessage = "Batch ID cannot exceed 50 characters.")]
        public string batchID { get; set; }

        [Required(ErrorMessage = "Sector ID is required.")]
        public int sectorID { get; set; }

        [Required(ErrorMessage = "Job Role ID is required.")]
        public int jobRoleID { get; set; }

        [Required(ErrorMessage = "Job Detail ID is required.")]
        public int jobDetailID { get; set; }

        [Required(ErrorMessage = "Training Center ID is required.")]
        public int trainingCenterID { get; set; }

        [Required(ErrorMessage = "Trainer ID is required.")]
        public int trainerID { get; set; }

        [Required(ErrorMessage = "Assessor ID is required.")]
        public int assessorID { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }
        public int? status { get; set; } = 1;
        public int? createdBy { get; set; }

        [StringLength(100, ErrorMessage = "Batch External ID cannot exceed 100 characters.")]
        public string? batch_ext_id { get; set; }

        [StringLength(200, ErrorMessage = "Batch Name cannot exceed 200 characters.")]
        public string? batch_name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Minimum length must be greater than 0.")]
        public int? min_length { get; set; } = 30;

        [Range(1, int.MaxValue, ErrorMessage = "Maximum length must be greater than 0.")]
        public int? max_length { get; set; } = 50;

        [StringLength(50, ErrorMessage = "Approval status cannot exceed 50 characters.")]
        public string? approval_status { get; set; } = "Pending";

        public DateTime? approval_date { get; set; } = null;

        [StringLength(500, ErrorMessage = "Reject reason cannot exceed 500 characters.")]
        public string? reject_reason { get; set; } = null;

       
        

    }

    
}

