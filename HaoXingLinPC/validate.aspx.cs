using Newtonsoft.Json;
using Model;
using PC.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PC.BLL;

namespace HaoXingLinPC
{
    public partial class validate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var code = Request["code"] ?? "";
                var state = Request["state"] ?? "";         
                if (string.IsNullOrEmpty(state)||(state != Session["wechat_state"] + ""))
                {
                    Response.Redirect("error?msg=" + Server.UrlEncode("state校验失败"));
                }
                if (string.IsNullOrEmpty(code))
                {
                    Response.Redirect("error?msg=" + Server.UrlEncode("用户禁止授权"));
                }

                var appid = ConfigurationManager.AppSettings["AppId"].ToString();
                var secret= ConfigurationManager.AppSettings["AppSecret"].ToString();
                var url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", appid, secret, code);
                dynamic callback_11 = null;
                try
                {
                    var callback = JsonConvert.DeserializeObject<CodeAccessTokenCallback>(CommonTool.HttpGetByUrl(url));
                    callback_11 = callback;
                    if (callback != null)
                    {
                        if (!string.IsNullOrEmpty(callback.unionid))
                        {
                            B_Member b_Member = new B_Member();
                            var memberInfo = b_Member.GetMemberModelByUnionid(callback.unionid);
                            if (memberInfo != null)
                            {
                                Session["userId"] = memberInfo.ID;
                                Response.Redirect("list",false);
                            }
                            else
                            {
                                Response.Redirect("error?msg=" + Server.UrlEncode("登录失败,关注并绑定好杏林公众号才能登录"),false);
                            }
                        }
                        else
                        {
                            Response.Redirect("error?msg=" + Server.UrlEncode("登录失败"), false);
                        }                  
                    }
                    else
                    {
                        Response.Redirect("error?msg=" + Server.UrlEncode("登录失败"), false);
                    }
                }
                catch 
                {
                    Response.Redirect("error?msg=" + Server.UrlEncode("登录失败"),false);
                }
            }
        }
    }
}