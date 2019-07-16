using Model;
using PC.Common;
using PC.DBUtility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DLL
{
    public class D_Member
    {
        /// <summary>
        /// 根据UnionId获取会员实体
        /// </summary>
        /// <param name="unionid"></param>
        /// <returns></returns>
        public M_Member GetMemberModelByUnionid(string unionid)
        {
            var sql = @"select ID,UserName,WeChatID=WeiXinID,Unionid from MemberLogin where Unionid=@Unionid";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Unionid",unionid)
            };
            var dt = DbHelperSQL.Query(sql, parameters).Tables[0];
            return CommonTool.DataTableConvertToModel<M_Member>(dt);
        }

        /// <summary>
        /// 根据ID获取会员实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public M_Member Get_MemberById(string id)
        {
            var sql = @"select ID,UserName,WeChatID=WeiXinID,Unionid from MemberLogin where ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID",id)
            };
            var dt = DbHelperSQL.Query(sql, parameters).Tables[0];
            return CommonTool.DataTableConvertToModel<M_Member>(dt);
        }

    }
}
