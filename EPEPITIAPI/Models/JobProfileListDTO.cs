namespace EPEPITIAPI.Models
{
    public class JobProfileListDTO
    {
        public int id { get; set; }
        public int sectorID { get; set; }

        public int jobRoleID { get; set; }

        public string? jobRole {  get; set; }

        public string? jobDetail { get; set; }

        public string? qpCode { get; set; }

        public int nsqfID { get; set; }

        public int createdBy { get; set; }

    }
}
