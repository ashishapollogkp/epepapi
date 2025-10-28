namespace EPEPITIAPI.Models
{
    public class BatchListDTO
    {
        public int id { get; set; }
        public string? batchID { get; set; }
        public int sectorID { get; set; }
        public int jobRoleID { get; set; }
        public int jobDetailID { get; set; }

        public int trainingCenterID { get; set; }

        public int trainerID { get; set; }

        public int assessorID { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }



        public int status { get; set; }
        public int createdBy { get; set; }
    }
}
