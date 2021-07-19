using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Entities
{
    [Table("menu")]
    public class Menu
    {
        [Key]
        public int menu_id { get; set; }

        public int pid { get; set; }
        public string menu_name { get; set; }
        public string menu_title { get; set; }
        public string menu_url { get; set; }
        public string menu_url_target { get; set; }
        public string menu_icon { get; set; }
        public int menu_position { get; set; }
        public string menu_label_html { get; set; }
        public string created_user { get; set; }
        public DateTime created_date { get; set; }
        public string updated_user { get; set; }
        public DateTime updated_date { get; set; }

        [Computed]
        public List<Menu> ChildMenus { get; set; }

        [Computed]
        public List<int> ParentIDs { get; set; }

        [Computed]
        public string icon { get; set; }
        [Computed]
        public int level { get; set; }
        [Computed]
        public string hierarcy { get; set; }
        [Computed]
        public string concatenador { get; set; }
        [Computed]
        public bool hasChild { get; set; }
        [Computed]
        public string title { get; set; }
    }
}
