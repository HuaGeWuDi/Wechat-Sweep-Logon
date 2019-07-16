using Model;
using Newtonsoft.Json;
using PC.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaoXingLinPC
{
    public partial class SurveyList : System.Web.UI.Page
    {
        protected string Name { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["userId"] = "29453";
            if (Session["userId"] == null)
            {
                Response.Redirect("index");
            }
            if (!IsPostBack)
            {
                B_Member _Member = new B_Member();
                var model = _Member.Get_MemberById(Session["userId"] + "");
                Name = model?.UserName;
            }
        }

        protected List<M_Prizes> GetM_Prizes()
        {
            B_Project b_Project = new B_Project();
            return b_Project.GetM_Prizes();
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("index");
        }
    }
}