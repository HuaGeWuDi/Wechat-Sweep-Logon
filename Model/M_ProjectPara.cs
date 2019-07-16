using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class M_ProjectPara
    {
        public int ID { get; set; }

        public int? ProjectID { get; set; }

        public string ParaS { get; set; }

        public string ParaMark { get; set; }

        public int? ParaUse { get; set; }
    }
}
