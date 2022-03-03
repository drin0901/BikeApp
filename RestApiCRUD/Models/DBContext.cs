using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUD.Models
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options): base(options)
        {

        }

        public DbSet<PersonalInfo> PersonalInfoList { get; set; }
    }
}
