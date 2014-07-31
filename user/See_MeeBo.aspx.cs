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
        CommentDB uncheckCom = new CommentDB();
        AtDB uncheckAt = new AtDB();
        PraiseDB uncheckZan = new PraiseDB();
        MessageDB uncheckMsg = new MessageDB();
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
                orderby Convert.ToDateTime(item["time"]) descending
                select new JObject(item)
                );
        string json = array.ToString();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "getMessage(" + json + ");judgeNewMsg('" + uncheckCom.haveUncheck((Guid)Session["id"]).ToString() + "', '" + uncheckAt.haveUncheck((Guid)Session["id"]).ToString() + "', '" + uncheckZan.haveUncheck((Guid)Session["id"]).ToString() + "', '" + uncheckMsg.haveUncheck((Guid)Session["id"]).ToString() + "')", true);
        UserDB user = new UserDB();
        user.SearchByID("user", (Guid)Session["id"]);
        this.myName.InnerText = user.Nickname;
        this.head_potrait.ImageUrl = user.HeadPortrait;
        this.LikeNum.InnerText = user.LikesNum.ToString();
        this.FansNum.InnerText = user.FansNum.ToString();
        this.MeeBoNum.InnerText = user.NewsNum.ToString();
    }

    protected void send_out_Click(object sender, EventArgs e)
    {
        MessageDB msgDb = new MessageDB();
        msgDb.FromID = (Guid)Session["id"];
        msgDb.ToID = (Guid)Session["seeMeeboID"];
        msgDb.Content = this.send_content.Text;
        msgDb.Insert();
        Response.Redirect("~/user/See_MeeBo.aspx");
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