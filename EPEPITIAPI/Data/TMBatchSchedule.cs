using System.ComponentModel.DataAnnotations;

namespace EPEPITIAPI.Data
{
    public class TMBatchSchedule
    {
        [Key]
        public int pk_schedule_id { get; set; }
        public int? fk_batch_id { get; set; }
        public DateTime? schedule_date { get; set; }
        public string schedule_type { get; set; }
        public DateTime? created_date { get; set; }
        public DateTime? updated_date { get; set; }
        public DateTime? deleted_date { get; set; }
    }
}
