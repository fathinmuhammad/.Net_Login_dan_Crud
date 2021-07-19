using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Entities
{
    [Table("usergroup")]
    public class UserGroup
    {
        [Key]
        public int usergroup_id { get; set; }

        public string usergroup_name { get; set; }
        public string created_user { get; set; }
        public DateTime created_date { get; set; }
        public string updated_user { get; set; }
        public DateTime updated_date { get; set; }

        [Computed]
        public UserPermission usrPer { get; set; }

        [Computed]
        public List<UserPermission> ListPermission { get; set; }
    }
}
