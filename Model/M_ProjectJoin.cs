using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class M_ProjectJoin
    {
        public int ID { get; set; }

        public int? ProjectId { get; set; }

        public int? MemberId { get; set; }

        public DateTime? JoinTime { get; set; }

        public int? Integral { get; set; }

        public int? State { get; set; }

        public int? ParaID { get; set; }

        /// <summary>
        /// 1-网站参与，2-邮件参与，3-手机参与
        /// </summary>
        public int? JoinType { get; set; }

        public bool IsJoin { get; set; }

        public DateTime? ReturnTime { get; set; }

        public bool IsCheck { get; set; }
    }
}
