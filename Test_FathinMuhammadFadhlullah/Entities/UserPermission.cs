using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Entities
{
    [Table("usrp")]
    public class UserPermission
    {
        [Key]
        public int usergroupmenu_id { get; set; }
        public int usergroup_id { get; set; }
        public int menu_id { get; set; }
        public int create_perm { get; set; }
        public int edit_perm { get; set; }
        public int delete_perm { get; set; }
        public int view_perm { get; set; }
        public int cancel_perm { get; set; }
        public int created_user { get; set; }
        public DateTime created_date { get; set; }
        public int updated_user { get; set; }
        public DateTime? updated_date { get; set; }

        [Computed]
        public string usergroup_name { get; set; }
        [Computed]
        public string menu_name { get; set; }

    }
}
