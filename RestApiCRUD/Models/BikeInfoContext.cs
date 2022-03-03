

using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class BikeInfoContext: DbContext
    {
        public BikeInfoContext(DbContextOptions<BikeInfoContext> options) : base(options)
        {
        }
        public DbSet<BikeInfo> BikeInfoList { get; set; }
    }   
}
