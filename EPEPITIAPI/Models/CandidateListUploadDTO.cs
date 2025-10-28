namespace EPEPITIAPI.Models
{
    public class CandidateListUploadDTO
    {
        public int id { get; set; }
        public string? candidateID { get; set; }

        public string? candidateName { get; set; }

        public string? mobile { get; set; }

        public string? aadhaar { get; set; }

        public string? aadhaarLinkedMobile { get; set; }
        public DateTime dob { get; set; }

        public int gender { get; set; }

        public string? fhName { get; set; }

        public int religionID { get; set; }


        public int categoryID { get; set; }
        public string? pan { get; set; }

        public int sectorID { get; set; }

        public int jobRoleID { get; set; }

        public int jobDetailID { get; set; }

        public string? district { get; set; }

        public string? address { get; set; }
        public string? pin { get; set; }

        public int stateID { get; set; }

        public int qualificationID { get; set; }

        public int disabilityYN { get; set; }

        public int batchID { get; set; }

        public string? disability { get; set; }

        public int createdBy { get; set; }
    }
}
