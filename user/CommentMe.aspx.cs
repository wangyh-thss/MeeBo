using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MeeboDb;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class user_CommentMe : System.Web.UI.Page
{
    protected CommentDB comDb;
    protected string btnID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        comDb = new CommentDB();
        if(IsPostBack)
            this.btnID = Request.Form["__EVENTARGUMENT"];
        UserDB comUser = new UserDB();
        NewsDB comNews = new NewsDB();
        CommentDB uncheckCom = new CommentDB();
        AtDB uncheckAt = new AtDB();
        PraiseDB uncheckZan = new PraiseDB();
        MessageDB uncheckMsg = new MessageDB();
        List<JObject> JList = new List<JObject>();
        int num = 0;
        DataSet comSet = comDb.SearchByNewsUserID((Guid)Session["id"], "comment");
        foreach (DataRow singleComment in comSet.Tables["comment"].Rows)
        {
            comUser.SearchByID("comUser", (Guid)singleComment["CUID"]);
            comNews.SearchByID((Guid)singleComment["CNID"], "comNews");
            JObject singleNewsInfo = new JObject();
            singleNewsInfo.Add(new JProperty("head", comUser.HeadPortrait.Replace("~", "..")));
            singleNewsInfo.Add(new JProperty("nickname", comUser.Nickname));
            singleNewsInfo.Add(new JProperty("userID", comUser.ID));
            singleNewsInfo.Add(new JProperty("MeeboID", singleComment["CNID"]));
            singleNewsInfo.Add(new JProperty("MeeboContent", comNews.ContentT));
            singleNewsInfo.Add(new JProperty("commentContent", singleComment["CContent"]));
            singleNewsInfo.Add(new JProperty("time", singleComment["CDate"].ToString()));
            
            JList.Add(singleNewsInfo);
            num++;
        }
        JArray array = new JArray(
                from item in JList
                orderby Convert.ToDateTime(item["time"]) descending
                select new JObject(item)
                );
        string json = array.ToString();
        comDb.clearUncheck((Guid)Session["id"]);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "getCommentMe(" + json + ");judgeNewMsg('" + uncheckCom.haveUncheck((Guid)Session["id"]).ToString() + "', '" + uncheckAt.haveUncheck((Guid)Session["id"]).ToString() + "', '" + uncheckZan.haveUncheck((Guid)Session["id"]).ToString() + "', '" + uncheckMsg.haveUncheck((Guid)Session["id"]).ToString() + "')", true);
        UserDB user = new UserDB();
        user.SearchByID("user", (Guid)Session["id"]);
        this.myName.InnerText = user.Nickname;
        this.head_potrait.ImageUrl = user.HeadPortrait;
        this.LikeNum.InnerText = user.LikesNum.ToString();
        this.FansNum.InnerText = user.FansNum.ToString();
        this.MeeBoNum.InnerText = user.NewsNum.ToString();
    }

    protected void go_user_Click(object sender, EventArgs e)
    {
        Session["otherName"] = new Guid(this.btnID);
        Response.Redirect("~/user/OthersPage.aspx");
    }

    protected void go_MeeBo_Click(object sender, EventArgs e)
    {
        Session["commentType"] = "comment";
        Session["commentMeeboID"] = new Guid(this.btnID);
        Response.Redirect("~/user/MeeBoComment.aspx");
    }

    protected void search_click(object sender, EventArgs e)
    {
        //Response.Cookies.Add(new HttpCookie("SearchWord", this.find_content.Text));
        Session["searchWord"] = this.find_content.Text;
        Response.Redirect("~/SearchPage/SearchMeebo.aspx");
    }

}