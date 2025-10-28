namespace EPEPITIAPI.Models
{
    public class BatchImageDTO
    {
        public int id { get; set; }
        public int batchID { get; set; }
        public string? imageURLName { get; set; }

        public List<IFormFile> imageURL { get; set; }

        public int createdBy { get; set; }

        public DateTime createdOn { get; set; }
    }
}
