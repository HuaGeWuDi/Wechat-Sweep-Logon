using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using PC.Common;
using PC.DBUtility;

namespace PC.DLL
{
    public class D_Project
    {
        private static object _lock = new object();

        /// <summary>
        /// 获取参与项目
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<M_Project> GetRunningSurvey(string userId)
        {
            var sql = string.Format(@"select row=row_number() over(order by ID), ID,ProjectNumber,ProjectName,Integral,ServeyLenth from Project where ID<>23573 and ProjectState=0 
and exists (select * from  ProjectSample where ProjectSample.ProjectID=Project.ID and ProjectSample.MemberID={0}) 
and (not exists(select * from ProjectJoin where ProjectJoin.ProjectId = Project.ID and ProjectJoin.MemberId = {0}) 
or exists(select * from ProjectJoin where ProjectJoin.ProjectId = Project.ID and ProjectJoin.MemberId = {0} and ProjectJoin.State = 0))", userId);
            return CommonTool.DataTableConvertToList<M_Project>(DbHelperSQL.Query(sql).Tables[0]);
        }


        /// <summary>
        /// 获取已参与的项目
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<M_Project> GetJoinedSurvey(string userId)
        {
            var sql = $@"select ID,ProjectNumber,ProjectName,Integral,ServeyLenth,JoinState=(select top 1 state from ProjectJoin where ProjectId= Project.ID and MemberId={userId} )
from Project where ID<>23573 and exists(select * from ProjectJoin where ProjectJoin.ProjectId = Project.ID and ProjectJoin.MemberId = {userId}) ";
            return CommonTool.DataTableConvertToList<M_Project>(DbHelperSQL.Query(sql).Tables[0]);
        }

        /// <summary>
        /// 获取分页参与项目
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<M_Project> GetRunningSurvey(string userId, int page, int pageSize, out int count)
        {
            page = page > 0 ? page : 1;
            var sql = string.Format(@"select row=row_number() over(order by ID), ID,ProjectNumber,ProjectName,Integral,ServeyLenth from Project where ID<>23573 and ProjectState=0 
and exists (select * from  ProjectSample where ProjectSample.ProjectID=Project.ID and ProjectSample.MemberID={0}) 
and (not exists(select * from ProjectJoin where ProjectJoin.ProjectId = Project.ID and ProjectJoin.MemberId = {0}) 
or exists(select * from ProjectJoin where ProjectJoin.ProjectId = Project.ID and ProjectJoin.MemberId = {0} and ProjectJoin.State = 0))", userId);
            var lastSql = "select * from (" + sql + $") as #temp where row between {(page - 1) * pageSize + 1} and {page * pageSize}";

            var sqlCount = string.Format(@"select count(1) from Project where ID<>23573 and ProjectState=0 
and exists (select * from  ProjectSample where ProjectSample.ProjectID=Project.ID and ProjectSample.MemberID={0}) 
and (not exists(select * from ProjectJoin where ProjectJoin.ProjectId = Project.ID and ProjectJoin.MemberId = {0}) 
or exists(select * from ProjectJoin where ProjectJoin.ProjectId = Project.ID and ProjectJoin.MemberId = {0} and ProjectJoin.State = 0))", userId);
            count = (int)DbHelperSQL.GetSingle(sqlCount);
            return CommonTool.DataTableConvertToList<M_Project>(DbHelperSQL.Query(lastSql).Tables[0]);
        }

        /// <summary>
        /// 分页已参与项目
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<M_Project> GetJoinedSurvey(string userId,int page,int pageSize,out int count)
        {
            page = page > 0 ? page : 1;
            var sql = $@"select row=row_number()over(order by ID), ID,ProjectNumber,ProjectName,Integral,ServeyLenth,JoinState=(select top 1 state from ProjectJoin where ProjectId= Project.ID and MemberId={userId} )
from Project where ID<>23573 and exists(select * from ProjectJoin where ProjectJoin.ProjectId = Project.ID and ProjectJoin.MemberId = {userId}) ";
            var lastSql = "select * from (" + sql + $") as #temp where row between {(page - 1) * pageSize + 1} and {page * pageSize}";

            var sqlCount= $@"select count(1) from Project where ID<>23573 and exists(select * from ProjectJoin where ProjectJoin.ProjectId = Project.ID and ProjectJoin.MemberId = {userId}) ";
            count = (int)DbHelperSQL.GetSingle(sqlCount);
            return CommonTool.DataTableConvertToList<M_Project>(DbHelperSQL.Query(lastSql).Tables[0]);
        }

        /// <summary>
        /// 获奖名单
        /// </summary>
        /// <returns></returns>
        public List<M_Prizes> GetM_Prizes()
        {
            var sql = @"select top 20 a.DateLine,b.Member_HandPhone,c.[Name] FROM [dbo].[Order] a 
left join MemberShip b on a.UserID=b.ID left join Gift c on a.GiftID=c.ID where a.Status=2 and a.UserType=1 ORDER BY a.DateLine desc";
            return CommonTool.GetPrizeListByDataTable(DbHelperSQL.Query(sql).Tables[0]);
        }

        /// <summary>
        /// 是否已经参与过项目
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public M_ProjectJoin GetProjectJoinModel(string pid, string userId)
        {
            var sql = @"select Top 1 * from dbo.ProjectJoin where [ProjectId]=@ProjectId and [MemberId]=@MemberId";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProjectId",pid),
                new SqlParameter("@MemberId",userId),
            };
            var dt = DbHelperSQL.Query(sql, parameters).Tables[0];
            return CommonTool.DataTableConvertToModel<M_ProjectJoin>(dt);
        }

        /// <summary>
        /// 根据ID获取参数Model
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public M_ProjectPara GetProjectParaModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ProjectID,ParaS,ParaMark,ParaUse from ProjectPara ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID",ID)
            };
            var dt = DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0];
            return CommonTool.DataTableConvertToModel<M_ProjectPara>(dt);
        }

        /// <summary>
        /// 答问卷，分配参数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="joinLink"></param>
        /// <returns></returns>
        public bool JoinSurvey(M_ProjectJoin model, out string joinLink)
        {

            /*
            * 参与流程
            * 1.分配参数
            * 2.更新参数
            * 3.添加参与记录
            * 4.更新抽样
            */
            lock (_lock)
            {
                var res = false;
                joinLink = "";

                //获取一个未使用的参数
                string query = "select top 1 * from dbo.ProjectPara where [ProjectID]=@ProjectID and [ParaUse]=@ParaUse Order By ID";
                SqlParameter[] parameters =
                   {
                       new SqlParameter("@ProjectID",model.ProjectId),
                       new SqlParameter("@ParaUse","0"),
                    };
                var dt = DbHelperSQL.Query(query.ToString(), parameters).Tables[0];
                var paraInfo = CommonTool.DataTableConvertToModel<M_ProjectPara>(dt);
                if (paraInfo == null)
                {
                    joinLink = "参数已分配完";
                    return res;
                }

                //更新参数使用状态
                string update1 = "update dbo.ProjectPara set [ParaUse]=@ParaUseNew where ID=@ID and ParaUse=@ParaUseOld";
                SqlParameter[] parameters1 = {
                     new SqlParameter("@ParaUseNew","1"),
                     new SqlParameter("@ID",paraInfo.ID),
                     new SqlParameter("@ParaUseOld","0"),
                };

                //添加参与记录
                string add1 = "insert into ProjectJoin(ProjectId,MemberId,JoinTime,Integral,State,ParaID,JoinType,IsJoin,ReturnTime,IsCheck) values (@ProjectId,@MemberId,@JoinTime,@Integral,@State,@ParaID,@JoinType,@IsJoin,@ReturnTime,@IsCheck);";
                SqlParameter[] parameters2 = {
                     new SqlParameter("@ProjectId",model.ProjectId),
                     new SqlParameter("@MemberId",model.MemberId),
                     new SqlParameter("@JoinTime",model.JoinTime),
                     new SqlParameter("@Integral",model.Integral),
                     new SqlParameter("@State",model.State),
                     new SqlParameter("@ParaID",paraInfo.ID),
                     new SqlParameter("@JoinType",model.JoinType),
                     new SqlParameter("@IsJoin",model.IsJoin),
                     new SqlParameter("@ReturnTime",model.ReturnTime),
                     new SqlParameter("@IsCheck",model.IsCheck),
                };

                //更新抽样信息
                string update2 = "update dbo.ProjectSample set [ParaID]=@ParaID,[IsJoin]=@IsJoin where [ProjectID]=@ProjectID and [MemberID]=@MemberID";
                SqlParameter[] parameters3 = {
                     new SqlParameter("@ParaID", paraInfo.ID),
                     new SqlParameter("@IsJoin",1),
                     new SqlParameter("@ProjectID",model.ProjectId),
                     new SqlParameter("@MemberID",model.MemberId),
                };

                List<string> sqlList = new List<string>();
                List<SqlParameter[]> spaList = new List<SqlParameter[]>();
                sqlList.AddRange(new string[] { update1, add1, update2 });
                spaList.AddRange(new List<SqlParameter[]> { parameters1, parameters2, parameters3 });

                var msg = "";
                var num = DbHelperSQL.ExecuteSqlTran(sqlList, spaList, out msg);
                if (num > 0)
                {
                    res = true;
                    joinLink = paraInfo.ParaS;
                }
                else
                {
                    joinLink = msg;
                }
                return res;
            }
        }


    }
}
