namespace EPEPITIAPI.Models
{
    public class BatchList
    {

        public int id { get; set; }
        public string? batchID { get; set; }
        public int sectorID { get; set; }

        public string? sectorName { get; set; }
        public int jobRoleID { get; set; }

        public string? jobRole { get; set; }
        public int jobDetailID { get; set; }

        public string? jobDetail { get; set; }

        public int trainingCenterID { get; set; }

        public string? trainingCenter { get; set; }

        public int trainerID { get; set; }

        public string? trainer { get; set; }

        public int assessorID { get; set; }

        public string? assessor { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public int status { get; set; }
        public int createdBy {  get; set; }
    }
}
