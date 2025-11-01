namespace EPEPITIAPI.Models.BatchSection
{
    public class BatchApproveRejectReq
    {
        public int id { get; set; }
        public string approval_status { get; set; }
        public string batch_ext_id { get; set; }

        public string reject_reason { get; set; }
    }
}
