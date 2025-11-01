namespace EPEPITIAPI.Models.userInfoSection
{
    public class TrainerInfoReq
    {
        public int pk_trainer_info_id { get; set; }
        public int? fk_user_id { get; set; }
        public string? official_Name { get; set; }
        public string? official_id { get; set; }
        public DateTime? dob { get; set; }
        public string? gender { get; set; }
        public string? qualification { get; set; }
        public string? adddhar_no { get; set; }
        public string? official_mobileno { get; set; }
        public bool? is_certify { get; set; }
        public string? certificate_no { get; set; }
       
    }
}
