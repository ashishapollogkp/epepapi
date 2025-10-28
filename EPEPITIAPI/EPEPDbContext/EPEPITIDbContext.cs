using EPEPITIAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EPEPITIAPI.EPEPDbContext
{
    public class EPEPITIDbContext: DbContext
    {
        public EPEPITIDbContext(DbContextOptions<EPEPITIDbContext> options) : base(options) { }

        public DbSet<request_master> request_master { get; set; }
        public DbSet<TMTrainingCenter> TMTrainingCenter { get; set; }
    }
}
