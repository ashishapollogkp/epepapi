namespace EPEPITIAPI.Models
{
    public class UserListDTO
    {
        public int id { get; set; }

        public int userRoleID { get; set; }

        public int partnerID { get; set; }

        public string? userName { get; set; }

        public int gender { get; set; }
              

        public string? userMobile { get; set; }

        public string? userEmail { get; set; }

        public string? address { get; set; }

        public int sectorID { get; set; }

        public string? jobProfile { get; set; }

        public int createdBy { get; set; }
    }
}
