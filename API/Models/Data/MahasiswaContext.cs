using API.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Data
{
    public class MahasiswaContext : DbContext
    {
        public MahasiswaContext(DbContextOptions<MahasiswaContext> options) : base(options) 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); //for set timestamp without timezone
        }

        public DbSet<mahasiswa> mahasiswas { get; set; }
    }
}
