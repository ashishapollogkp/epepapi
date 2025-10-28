namespace EPEPITIAPI.Models
{
    public class CandidateList
    {
        public int id { get; set; }
        public string? candidateName { get; set; }

        public string? mobile { get; set; }

        public string? aadhaar { get; set; }

        public string? aadhaarLinkedMobile { get; set; }

        public DateTime dob { get; set; }

        public int gender { get; set; }

        public string? fhName { get; set; }

        public int religionID { get; set; }
        public string? religion { get; set; }

        public int categoryID { get; set; }

        public string? category { get; set; }
        public string? pan { get; set; }

        public string? sectorName { get; set; }

        public int sectorID { get; set; }

        public string? jobRole { get; set; }

        public int jobRoleID { get; set; }

        public string? jobDetail { get; set; }

        public int jobDetailID { get; set; }

        public string? batchID { get; set; }




        public string? pin { get; set; }

        public int stateID { get; set; }

        public string? state { get; set; }

        public string? district { get; set; }

        public string? address { get; set; }
        public int qualificationID { get; set; }

        public string? qualification { get; set; }

        public int disabilityYN { get; set; }

        public string? disability { get; set; }

        public string? profileImageName { get; set; }

        public string? profileImage { get; set; }

        public string? aadhaarFront { get; set; }

        public string? aadhaarFrontName { get; set; }
        public string? aadhaarBack { get; set; }

        public string? aadhaarBackName { get; set; }

        public int status { get; set; }

        public int createdBy { get; set; }

    }
}

