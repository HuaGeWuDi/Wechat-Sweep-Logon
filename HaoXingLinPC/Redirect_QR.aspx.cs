using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaoXingLinPC
{
    public partial class Redirect_QR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var appid = ConfigurationManager.AppSettings["AppId"].ToString();
                var redirect_uri = Server.UrlEncode(ConfigurationManager.AppSettings["Domain"].ToString() + "/validate.aspx");
                var state = Guid.NewGuid().ToString().ToUpper().Replace("-", "").ToLower();
                Session["wechat_state"] = state;
                var url = string.Format("https://open.weixin.qq.com/connect/qrconnect?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_login&state={2}#wechat_redirect",
                                       appid, redirect_uri, state);
                Response.Redirect(url);
            }
        }
    }
}