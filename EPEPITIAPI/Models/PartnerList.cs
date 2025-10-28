namespace EPEPITIAPI.Models
{
    public class PartnerList
    {
        public int id { get; set; }

        public int partnerTypeID { get; set; }

        public string? partnerType { get; set; }

        public string? firmName { get; set; }

        public string? contactPerson { get; set; }

        public string? contactMobile { get; set; }

        public string? contactEmail { get; set; }

        public string? firmAddress { get; set; }

        public int status { get; set; }

        public int createdBy { get; set; }

        public string? createdByName { get; set; }

        public DateTime createdOn { get; set; }

        public string? updatedByName { get; set; }

        public DateTime updatedOn { get; set; }
    }
}
