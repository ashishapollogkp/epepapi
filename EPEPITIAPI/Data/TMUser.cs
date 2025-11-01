using System.ComponentModel.DataAnnotations;

namespace EPEPITIAPI.Data
{
    public class TMUser
    {
        [Key]
        public int Id { get; set; }
        public int? UserRoleId { get; set; }
        public int? PartnerId { get; set; }
        public string? UserName { get; set; }
        public int? Gender { get; set; }
        public string? UserMobile { get; set; }
        public string? UserEmail { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public int? SectorId { get; set; }
        public string? JobProfile { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
