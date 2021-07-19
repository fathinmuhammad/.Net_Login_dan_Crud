using System;
using Dapper.Contrib.Extensions;

namespace Test_FathinMuhammadFadhlullah.Entities
{
    [Table("penerbit")]
    public class Penerbit
    {
        [Key]
        public int penerbit_id { get; set; }
        public string nama { get; set; }
        public string alamat { get; set; }
        public string created_user { get; set; }
        public DateTime? created_date { get; set; }
        public string updated_user { get; set; }
        public DateTime? updated_date { get; set; }
    }
}
