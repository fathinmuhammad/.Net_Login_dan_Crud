using Dapper.Contrib.Extensions;
using System;

namespace Test_FathinMuhammadFadhlullah.Entities
{
    [Table("usr")]
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public int usergroup_id { get; set; }
        public string username { get; set; }
        public string fullname { get; set; }
        public string password { get; set; }
        public string created_user { get; set; }
        public DateTime? created_date { get; set; }
        public string updated_user { get; set; }
        public DateTime? updated_date { get; set; }

        [Computed]
        public string usergroup_name { get; set; }
    }
}
