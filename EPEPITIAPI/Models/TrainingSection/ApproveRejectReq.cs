namespace EPEPITIAPI.Models.TrainingSection
{
    public class ApproveRejectReq
    {
        public int id { get; set; }
        public string approval_status { get; set; }
        //public DateTime? approval_date { get; set; }
        public string reject_reason { get; set; }
       
    }
}
