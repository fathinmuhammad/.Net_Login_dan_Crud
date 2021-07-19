using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Entities
{
    public class MenuTree
    {
        public String id { get; set; }
        public List<MenuTree> children { get; set; }
    }
}
