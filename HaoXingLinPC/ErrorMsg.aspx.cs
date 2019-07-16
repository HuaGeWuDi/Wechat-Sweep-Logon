using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaoXingLinPC
{
    public partial class ErrorMsg : System.Web.UI.Page
    {
        public string Msg { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var msg = Request["msg"] ?? "";
                Msg = Server.UrlDecode(msg);
            }
        }
    }
}