namespace EPEPITIAPI.Models
{
    public class UserList
    {
        public int id { get; set; }

        public int userRoleID { get; set; }

        public string? userRole { get; set; }

        public int partnerID { get; set; }

        public string? userName { get; set; }

        public int gender { get; set; }
        public string? genderName { get; set; }

        public string? sectorName { get; set; }

        public string? partnerType { get; set; }

        public string? firmName { get; set; }
        

        public string? userMobile { get; set; }

        public string? userEmail { get; set; }

        public string? address { get; set; }

        public int sectorID { get; set; }

        public string? jobProfile { get; set; }

        public int status { get; set; }

        public int createdBy { get; set; }

        public string? createdByName { get; set; }

        public string? loginID { get; set; }

        public string? password { get; set; }

        public DateTime lastLogin { get; set; }

    }
}
