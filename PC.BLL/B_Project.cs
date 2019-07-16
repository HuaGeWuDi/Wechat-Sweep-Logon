using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using PC.DLL;


namespace PC.BLL
{
   public class B_Project
    {
        private readonly D_Project da = new D_Project();

        /// <summary>
        /// 获取可参与项目
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<M_Project> GetRunningSurvey(string userId)
        {
            return da.GetRunningSurvey(userId);
        }

        /// <summary>
        /// 获取已参加项目
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<M_Project> GetJoinedSurvey(string userId)
        {
            return da.GetJoinedSurvey(userId);
        }

        /// <summary>
        /// 分页获取可参与项目
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<M_Project> GetRunningSurvey(string userId, int page, int pageSize, out int count)
        {
            return da.GetRunningSurvey(userId, page, pageSize, out count);
        }

        /// <summary>
        /// 分页获取已参加项目
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<M_Project> GetJoinedSurvey(string userId, int page, int pageSize, out int count)
        {
            return da.GetJoinedSurvey(userId, page, pageSize, out count);
        }

        /// <summary>
        /// 获奖名单
        /// </summary>
        /// <returns></returns>
        public List<M_Prizes> GetM_Prizes()
        {
            return da.GetM_Prizes();
        }

        /// <summary>
        /// 是否参与过项目
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public M_ProjectJoin GetProjectJoinModel(string pid, string userId)
        {
            return da.GetProjectJoinModel(pid, userId);
        }

        /// <summary>
        /// 获取参数Model
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public M_ProjectPara GetProjectParaModel(int ID)
        {
            return da.GetProjectParaModel(ID);
        }

        /// <summary>
        /// 参与问卷
        /// </summary>
        /// <param name="model"></param>
        /// <param name="joinLink"></param>
        /// <returns></returns>
        public bool JoinSurvey(M_ProjectJoin model,out string joinLink)
        {
            return da.JoinSurvey(model, out joinLink);
        }
    }
}
