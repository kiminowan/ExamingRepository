using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    public class ShowAdmin
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string AdminPsw { get; set; }
        public string RoleName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
    }
}
