
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

        public MahasiswaContext() { }

        public virtual DbSet<mahasiswa> mahasiswas { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<mahasiswa>().HasData(
                new mahasiswa
                {
                    id = 1,
                    nama = "Arya Santoso",
                    alamat = "Dago - Bandung",
                    umur = 20,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 2,
                    nama = "Astrid Ardia",
                    alamat = "Nginden - Surabaya",
                    umur = 21,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 3,
                    nama = "Budi Arga",
                    alamat = "Cicaheum - Bandung",
                    umur = 22,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 4,
                    nama = "Dini Andari",
                    alamat = "Menteng - Jakarta",
                    umur = 21,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 5,
                    nama = "Dwi Ciska",
                    alamat = "Merdeka - Malang",
                    umur = 22,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 6,
                    nama = "Edi Prastowo",
                    alamat = "Dago - Bandung",
                    umur = 23,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 7,
                    nama = "Eka Sapta",
                    alamat = "Setiabudi - Bandung",
                    umur = 22,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 8,
                    nama = "Fifin Aliana ",
                    alamat = "Mande - Mataram",
                    umur = 24,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 9,
                    nama = "Giri Rekso",
                    alamat = "Perak - Surabaya",
                    umur = 21,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 10,
                    nama = "Heri Ahmad Surya",
                    alamat = "Antapani - Bandung",
                    umur = 24,
                    created_date = DateTime.UtcNow,
                    is_active = true
                }
            );
        }
    }
}
