namespace EPEPITIAPI.Models
{
    public class TrainingCenterImageList
    {
        public int id { get; set; }

        public int trainingCenterID { get; set; }
        public string? imageURLName { get; set; }

        public List<IFormFile> imageURL { get; set; }

        public int status { get; set; }

        public int createdBy { get; set; }
    }
}
