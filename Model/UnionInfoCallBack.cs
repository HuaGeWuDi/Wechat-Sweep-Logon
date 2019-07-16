using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UnionInfoCallBack
    {
        //        {
        //"openid":"OPENID",
        //"nickname":"NICKNAME",
        //"sex":1,
        //"province":"PROVINCE",
        //"city":"CITY",
        //"country":"COUNTRY",
        //"headimgurl": "http://wx.qlogo.cn/mmopen/g3MonUZtNHkdmzicIlibx6iaFqAc56vxLSUfpb6n5WKSYVY0ChQKkiaJSgQ1dZuTOgvLLrhJbERQQ4eMsv84eavHiaiceqxibJxCfHe/0",
        //"privilege":[
        //"PRIVILEGE1",
        //"PRIVILEGE2"
        //],
        //"unionid": " o6_bmasdasdsad6_2sgVt7hMZOPfL"

        //}

        public string openid { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string headimgurl { get; set; }
        //public string privilege { get; set; }
        public string unionid { get; set; }
    }
}
