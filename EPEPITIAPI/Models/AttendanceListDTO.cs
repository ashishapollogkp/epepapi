namespace EPEPITIAPI.Models
{
    public class AttendanceListDTO
    {
        public int id { get; set; }

        public int batchID { get; set; }

        public int candidateID { get; set; }

        public int dayNo { get; set; }

        public string? latitude { get; set; }

        public string? longitude { get; set; }

        public int createdBy { get; set; }
    }
}
