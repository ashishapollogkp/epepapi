namespace EPEPITIAPI.Models
{
    public class PartnerListDTO
    {
        public int id { get; set; }

        public int partnerTypeID { get; set; }

        public string? firmName { get; set; }

        public string? contactPerson { get; set; }

        public string? contactMobile { get; set; }

        public string? contactEmail { get; set; }

        public string? firmAddress { get; set; }

        public int createdBy { get; set; }

        
    }
}
