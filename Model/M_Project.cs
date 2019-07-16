using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class M_Project
    {
        public int ID { get; set; }//项目ID
        public string ProjectNumber { get; set; }//项目编号
        public string ProjectName { get; set; }//项目名称
        public int Integral { get; set; }//积分
        public int ServeyLenth { get; set; }//问卷长度
        public int JoinState { get; set; }  //已参与项目状态
    }
}
