using System;
using Dapper.Contrib.Extensions;

namespace Test_FathinMuhammadFadhlullah.Entities
{
    [Table("buku")]
    public class Buku
    {
        [Key]
        public int buku_id { get; set; }
        public string judul { get; set; }
        public DateTime tanggal_terbit { get; set; }
        public int penerbit_id { get; set; }
        public string created_user { get; set; }
        public DateTime? created_date { get; set; }
        public string updated_user { get; set; }
        public DateTime? updated_date { get; set; }

        [Computed]
        public string nama { get; set; }
    }
}
