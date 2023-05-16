using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Db
{
    [Table("mahasiswa")]
    public class mahasiswa
    {
        [Key]
        [Required]
        [Column("id")]
        public int id { get; set; }

        [Required]
        [Column("nama")]
        [StringLength(100)]
        public string nama { get; set; }

        [Column("alamat")]
        [StringLength(200)]
        public string alamat { get; set; }

        [Column("umur")]
        public int umur{ get; set; }

        [Column("created_date")]
        public DateTime created_date { get; set; }

        [Column("updated_date")]
        public DateTime updated_date { get; set; }

        [Column("is_active")]
        public bool is_active { get; set; }
    }
}
