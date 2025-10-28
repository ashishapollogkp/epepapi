using System.ComponentModel.DataAnnotations;

namespace EPEPITIAPI.Data
{
    public class request_master
    {
        [Key]
        public int pk_request_id { get; set; }
        public string request_name { get; set; }
    }
}
