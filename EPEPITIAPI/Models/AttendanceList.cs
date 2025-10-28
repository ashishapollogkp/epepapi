namespace EPEPITIAPI.Models
{
    public class AttendanceList
    {
        public int id {  get; set; }

        public string? batchID { get; set; }

        public int batchIDInt { get; set; }

        public string? sectorName { get; set; }

        public string? jobRole { get; set; }

        public string? jobRoleDetails { get; set; }

        public string? candidateID { get; set; }

        public int candidateIDInt { get; set; }

        public string? candidateName { get; set; }

        public string? gender { get; set; }

        public DateTime dob { get; set; }

        public string? fhName { get; set; }

        public string? religion { get; set; }

        public string? category { get; set; }

        public string? pan { get; set; }

        public string? pin { get; set; }

        public string? stateName { get; set; }

        public string? district { get; set; }

        public string? qualification { get; set; }

        public string? disabilityYN { get; set; }

        public string? disability { get; set; }

        public string? mobile { get; set; }

        public string? aadhaar { get; set; }

        public string? nsqfCode { get; set; }
        

        public string? aadhaarLinkedMobile { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public int day1 {  get; set; }

        public int day2 { get; set; }

        public int day3 { get; set; }

        public int day4 { get; set; }

        public int day5 { get; set; }

        public string? profileImage { get; set; }

        public string? address { get; set; }

        public int createdBy { get; set; }
    }
    
}
