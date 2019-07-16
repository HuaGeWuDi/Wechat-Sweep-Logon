using Model;
using Newtonsoft.Json;
using PC.BLL;
using PC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.SessionState;

namespace HaoXingLinPC.Ashx
{
    /// <summary>
    /// iService 的摘要说明
    /// </summary>
    public class iService : IHttpHandler, IRequiresSessionState
    {
        protected HttpRequest Request => HttpContext.Current.Request;

        protected HttpSessionState Session => HttpContext.Current.Session;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var act = Request["act"];
            if (!string.IsNullOrEmpty(act))
            {
                try
                {
                    var res = this.GetType().GetMethod(act, BindingFlags.Public | BindingFlags.Instance).Invoke(this, null);
                    if (res != null)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(res));
                    }
                }
                catch (Exception ex)
                {
                    context.Response.Write(JsonConvert.SerializeObject(ex));
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 参与项目
        /// </summary>
        /// <returns></returns>
        public string JoinSurvey()
        {
            if (Session["userId"] == null)
            {
                return Json("-1","登录超时,请重新登录!");
            }
            var id = Request["id"] ?? "0";
            if (CommonTool.IsNumber(id))
            {
                //是否参与过项目
                B_Project b_Project = new B_Project();
                var m_pjoin = b_Project.GetProjectJoinModel(id, Session["userId"] + "");
                if (m_pjoin != null)//重新参与
                {
                    if (m_pjoin.State > 0)
                    {
                        return Json("0", "您已参与过本次调查");
                    }
                    else {
                        var paraInfo = b_Project.GetProjectParaModel(m_pjoin.ParaID ?? 0);
                        if (paraInfo == null)
                        {
                            return Json("0", "参数不存在");
                        }
                        else
                        {
                            return Json("1", "[{\"link\":\"" + paraInfo.ParaS + "\"}]", "问卷继续跳转");
                        }
                    }
                }
                else {
                    //新参与的
                    m_pjoin = new M_ProjectJoin();
                    string joinLink = "";
                    m_pjoin.MemberId = Convert.ToInt32(Session["userId"]);
                    m_pjoin.ProjectId = Convert.ToInt32(id);
                    m_pjoin.JoinTime = DateTime.Now;
                    m_pjoin.Integral = 0;
                    m_pjoin.State = 0;
                    m_pjoin.ParaID = 0;//事务分配
                    m_pjoin.JoinType = 1;
                    m_pjoin.IsJoin = true;
                    m_pjoin.ReturnTime = DateTime.Parse("1900-01-01");
                    m_pjoin.IsCheck = false;
                    var res = b_Project.JoinSurvey(m_pjoin, out joinLink);
                    if (res&&!string.IsNullOrEmpty(joinLink))
                    {
                        return Json("1", "[{\"link\":\"" + joinLink + "\"}]", "问卷跳转");
                    }
                    else {
                        return Json("0", "参与问卷失败!",joinLink);
                    }
                }
            }
            else
            {
                return Json("0", "调查ID有误!");
            }
        }

        /// <summary>
        /// 分页可参与项目
        /// </summary>
        /// <returns></returns>
        public string GetRunningSurvey()
        {
            if (Session["userId"] == null)
            {
                return Json("-1", "登录超时,请重新登录!");
            }
            var page = Request["page"] ?? "1";
            var pageSize = Request["pageSize"] ?? "0";
            if (!CommonTool.IsNumber(page) || !CommonTool.IsNumber(pageSize))
            {
                return Json("0", "请求数据错误");
            }
            B_Project b_Project = new B_Project();
            var count = 0;
            var list = b_Project.GetRunningSurvey(Session["userId"] + "", Convert.ToInt32(page), Convert.ToInt32(pageSize), out count);
            return Json("1", "", new { count = count, list = list });
        }

        /// <summary>
        /// 分页已参与项目
        /// </summary>
        /// <returns></returns>
        public string GetJoinedSurvey()
        {
            if (Session["userId"] == null)
            {
                return Json("-1", "登录超时,请重新登录!");
            }
            var page = Request["page"] ?? "1";
            var pageSize = Request["pageSize"] ?? "0";
            if (!CommonTool.IsNumber(page) || !CommonTool.IsNumber(pageSize))
            {
                return Json("0", "请求数据错误");
            }
            B_Project b_Project = new B_Project();
            var count = 0;
            var list = b_Project.GetJoinedSurvey(Session["userId"] + "", Convert.ToInt32(page), Convert.ToInt32(pageSize), out count);
            return Json("1", "", new { count = count, list = list });
        }

        protected string Json(string code, string msg, object detail = null)
        {
            return JsonConvert.SerializeObject(new
            {
                code = code,
                msg = msg,
                detail = detail ?? ""
            });
        }

    }
}