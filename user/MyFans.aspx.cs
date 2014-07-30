using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MeeboDb;

public partial class user_MyFans : System.Web.UI.Page
{
    protected UserDB user;
    protected string btnID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        if (IsPostBack)
        {
            btnID = Request.Form["__EVENTARGUMENT"];
        }
        user = new UserDB();
        user.SearchByID("user", (Guid)Session["id"]);

    }
    protected void go_user_Click(object sender, EventArgs e)
    {
        Session["otherName"] = new Guid(this.btnID);
        Response.Redirect("~/user/OthersPage.aspx");
    }
}