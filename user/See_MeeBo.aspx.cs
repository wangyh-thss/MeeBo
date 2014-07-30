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


public partial class user_See_MeeBo : System.Web.UI.Page
{
    protected string btnID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        if (IsPostBack)
            this.btnID = Request.Form["__EVENTARGUMENT"];
        MessageDB msgDb = new MessageDB();
        UserDB msgUser = new UserDB();
        List<JObject> JList = new List<JObject>();
        DataSet msgSet = msgDb.SearchByAllUesr((Guid)Session["id"], (Guid)Session["seeMeeboID"], "msgDialogue");
        foreach (DataRow singleMsg in msgSet.Tables["msgDialogue"].Rows)
        {
            JObject singleMsgInfo = new JObject();
            msgUser.SearchByID("msgUser", (Guid)singleMsg["MFromUID"]);
            singleMsgInfo.Add(new JProperty("head", msgUser.HeadPortrait.Replace("~", "..")));
            singleMsgInfo.Add(new JProperty("nickname", msgUser.Nickname));
            singleMsgInfo.Add(new JProperty("userID", msgUser.ID));
            singleMsgInfo.Add(new JProperty("content", singleMsg["MContent"]));
            singleMsgInfo.Add(new JProperty("time", singleMsg["MDate"].ToString()));
            if ((Guid)singleMsg["MFromUID"] == (Guid)Session["id"]) //我发出去的
                singleMsgInfo.Add(new JProperty("type", "send"));
            else
                singleMsgInfo.Add(new JProperty("type", "receive"));
            JList.Add(singleMsgInfo);
        }
        JArray array = new JArray(
                from item in JList
                orderby item["time"] descending
                select new JObject(item)
                );
        string json = array.ToString();
    }

    protected void send_out_Click(object sender, EventArgs e)
    {
        MessageDB msgDb = new MessageDB();
        msgDb.FromID = (Guid)Session["id"];
        msgDb.ToID = (Guid)Session["seeMeeboID"];
        msgDb.Content = this.send_content.Text;
        msgDb.Insert();
    }
    protected void search_click(object sender, EventArgs e)
    {
        //Response.Cookies.Add(new HttpCookie("SearchWord", this.find_content.Text));
        Session["searchWord"] = this.find_content.Text;
        Response.Redirect("~/SearchPage/SearchMeebo.aspx");
    }
    protected void go_user_Click(object sender, EventArgs e)
    {
        Session["otherName"] = new Guid(this.btnID);
        Response.Redirect("~/user/OthersPage.aspx");
    }
}