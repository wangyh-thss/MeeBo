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

public partial class user_AtMe : System.Web.UI.Page
{
    protected AtDB atDb;
    protected UserDB userDb;
    protected string btnID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        if (IsPostBack)
            this.btnID = Request.Form["__EVENTARGUMENT"];
        atDb = new AtDB();
        userDb = new UserDB();
        NewsDB newsDb = new NewsDB();
        CommentDB commentDb = new CommentDB();
        UserDB atUser = new UserDB();
        CommentDB uncheckCom = new CommentDB();
        AtDB uncheckAt = new AtDB();
        PraiseDB uncheckZan = new PraiseDB();
        MessageDB uncheckMsg = new MessageDB();
        List<JObject> JList = new List<JObject>();
        int num = 0;
        userDb.SearchByName((string)Session["name"], "result");
        DataSet atNewsSet = atDb.SearchByUserID("atResult", (Guid)Session["id"]);
        foreach (DataRow singleAt in atNewsSet.Tables["atResult"].Rows)
        {
            if (singleAt["AType"].ToString() == "False")    //MeeBo
            {
                newsDb.SearchByID((Guid)singleAt["AFID"], "news");
                atUser.SearchByID("atUser", newsDb.UserID);
                JObject singleNewsInfo = new JObject();
                singleNewsInfo.Add(new JProperty("head", atUser.HeadPortrait.Replace("~", "..")));
                singleNewsInfo.Add(new JProperty("nickname", atUser.Nickname));
                singleNewsInfo.Add(new JProperty("userID", atUser.ID));
                singleNewsInfo.Add(new JProperty("type", "MeeBo"));
                singleNewsInfo.Add(new JProperty("MeeboID", singleAt["AFID"]));
                singleNewsInfo.Add(new JProperty("content", newsDb.ContentT));
                singleNewsInfo.Add(new JProperty("pictures", newsDb.ContentP));
                singleNewsInfo.Add(new JProperty("time", singleAt["ADate"].ToString()));
                JList.Add(singleNewsInfo);
                num++;
            }
            else
            {
                commentDb.SearchByID((Guid)singleAt["AFID"], "comment");
                newsDb.SearchByID(commentDb.NewsID, "news");
                atUser.SearchByID("atUser", commentDb.UserID);
                JObject singleNewsInfo = new JObject();
                singleNewsInfo.Add(new JProperty("head", atUser.HeadPortrait.Replace("~", "..")));
                singleNewsInfo.Add(new JProperty("nickname", atUser.Nickname));
                singleNewsInfo.Add(new JProperty("userID", atUser.ID));
                singleNewsInfo.Add(new JProperty("type", "Comment"));
                singleNewsInfo.Add(new JProperty("MeeboID", newsDb.ID));
                singleNewsInfo.Add(new JProperty("content", commentDb.Content));
                singleNewsInfo.Add(new JProperty("time", singleAt["ADate"].ToString()));
                JList.Add(singleNewsInfo);
                num++;
            }
        }
        JArray array = new JArray(
                from item in JList
                orderby Convert.ToDateTime(item["time"]) descending
                select new JObject(item)
                );
        string json = array.ToString();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "getAtMe(" + json + ");judgeNewMsg('" + uncheckCom.haveUncheck((Guid)Session["id"]).ToString() + "', '" + uncheckAt.haveUncheck((Guid)Session["id"]).ToString() + "', '" + uncheckZan.haveUncheck((Guid)Session["id"]).ToString() + "', '" + uncheckMsg.haveUncheck((Guid)Session["id"]).ToString() + "')", true);
        atDb.clearUncheck((Guid)Session["id"]);
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