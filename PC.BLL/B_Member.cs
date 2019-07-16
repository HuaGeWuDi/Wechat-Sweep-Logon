using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC.DLL;
using Model;

namespace PC.BLL
{
    public class B_Member
    {
        private readonly D_Member da = new D_Member();

        /// <summary>
        /// 根据UnionId获取会员实体
        /// </summary>
        /// <param name="unionid"></param>
        /// <returns></returns>
        public M_Member GetMemberModelByUnionid(string unionid)
        {
            return da.GetMemberModelByUnionid(unionid);
        }

        /// <summary>
        ///  根据Id获取会员实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public M_Member Get_MemberById(string Id)
        {
            return da.Get_MemberById(Id);
        }
    }
}
