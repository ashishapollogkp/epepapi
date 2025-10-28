namespace EPEPITIAPI.Models
{
    public class JobProfileList
    {
        public int id { get; set; }

        public int sectorID { get; set; }

        public string? sectorName { get; set; }
        public string? jobRole { get; set; }

        public string? jobRoleDetails { get; set; }

        public string? qpCode { get; set; }

        public string? nsqfCode { get; set; }

        public int status { get; set; }

        public int createdBy { get; set; }

    }
}
