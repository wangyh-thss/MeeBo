using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MeeboDb;

public partial class user_MeeBoComment : System.Web.UI.Page
{
    protected NewsDB newsDb;
    protected CommentDB comDb;
    protected string btnID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        if (Session["commentType"] == "repost")
            this.send_type.Items.FindByValue("0").Selected = true;
        else
            this.send_type.Items.FindByValue("1").Selected = true;
        if (IsPostBack)
        {
            this.btnID = Request.Form["__EVENTARGUMENT"];
        }
        newsDb = new NewsDB();
        comDb = new CommentDB();
        UserDB user = new UserDB();
        List<JObject> JList = new List<JObject>();
        int num = 0;
        newsDb.SearchByID((Guid)Session["commentMeeboID"], "news");
        DataSet comSet = comDb.SearchByNewsID((Guid)Session["commentMeeboID"], "comment");
        foreach (DataRow singleCom in comSet.Tables["comment"].Rows)
        {
            JObject singleComInfo = new JObject();
            user.SearchByID("user", (Guid)singleCom["CUID"]);
            singleComInfo.Add(new JProperty("head", user.HeadPortrait.Replace("~", "..")));
            singleComInfo.Add(new JProperty("nickname", user.Nickname));
            singleComInfo.Add(new JProperty("userID", user.ID));
            singleComInfo.Add(new JProperty("content", singleCom["CContent"]));
            singleComInfo.Add(new JProperty("time", singleCom["CDate"].ToString()));
            JList.Add(singleComInfo);
            num++;
        }
        JArray array = new JArray(
            from item in JList
            orderby item["time"] descending
            select new JObject(item)
            );
        SaveDB saveDb = new SaveDB();
        JObject MeeboInfo = new JObject();
        user.SearchByID("user", newsDb.UserID);
        MeeboInfo.Add(new JProperty("head", user.HeadPortrait.Replace("~", "..")));
        MeeboInfo.Add(new JProperty("nickname", user.Nickname));
        MeeboInfo.Add(new JProperty("content", newsDb.ContentT));
        MeeboInfo.Add(new JProperty("UID", user.ID));
        MeeboInfo.Add(new JProperty("MeeboID", newsDb.ID));
        if (newsDb.ContentP != string.Empty)
        {
            string[] picUrl = newsDb.ContentP.Split(';');
            MeeboInfo.Add(new JProperty("pictures", new JArray(from url in picUrl select url.Replace("~", ".."))));
        }
        MeeboInfo.Add(new JProperty("time", newsDb.Date.ToString()));
        MeeboInfo.Add(new JProperty("praise", newsDb.ProNum));
        MeeboInfo.Add(new JProperty("comment", newsDb.ComNum));
        MeeboInfo.Add(new JProperty("repost", newsDb.TransmitNum));
        MeeboInfo.Add(new JProperty("save", newsDb.SaveNum));
        MeeboInfo.Add(new JProperty("isSave", saveDb.isSaved(user.ID, newsDb.ID)));

        JObject JsonObj = new JObject();
        JsonObj.Add(new JProperty("Meebo", MeeboInfo));
        JsonObj.Add(new JProperty("comment", array));
        string json = JsonObj.ToString();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "loadPage(" + json + ")", true);


    }
    protected void post_Click(object sender, EventArgs e)
    {
        if (this.send_type.SelectedValue == "1") //评论
        {
            CommentDB comToSend = new CommentDB();
            NewsDB commentedMeebo = new NewsDB();
            commentedMeebo.SearchByID((Guid)Session["commentMeeboID"], "Meebo");
            comToSend.Content = this.TextBox1.Text;
            comToSend.UserID = (Guid)Session["id"];
            comToSend.NewsID = (Guid)Session["commentMeeboID"];
            comToSend.NewsUserID = commentedMeebo.UserID;
            Guid comID = comToSend.Insert();
            Regex atRegex = new Regex("@[^\x20]* ");
            MatchCollection atSomeone = atRegex.Matches(this.TextBox1.Text);
            UserDB atUserNickName = new UserDB();
            AtDB atDb = new AtDB();
            for (int i = 0; i < atSomeone.Count; i++)
            {
                string atNickname = atSomeone[i].ToString().Replace("@", "");
                atUserNickName.SearchByNickName("atNickname", atNickname);
                atDb.Type = true;
                atDb.UserID = atUserNickName.ID;
                atDb.FromUserID = (Guid)Session["id"];
                atDb.FromID = comID;
                atDb.Insert();
            }
            Response.Redirect("~/user/MeeBoComment.aspx");
        }
    }

    protected void zan_Click(object sender, EventArgs e)
    {
        PraiseDB praiseDb = new PraiseDB();
        praiseDb.UserID = (Guid)Session["id"];
        praiseDb.NewsID = new Guid(this.btnID);
        praiseDb.isCheck = false;
        NewsDB newsDb = new NewsDB();
        newsDb.SearchByID(new Guid(this.btnID), "result");
        praiseDb.NewsUserID = newsDb.UserID;
        praiseDb.Insert();
        Response.Redirect("~/user/MeeBoComment.aspx");
    }

    protected void repost_Click(object sender, EventArgs e)
    {
        Session["commentMeeboID"] = new Guid(this.btnID);
        Session["commentType"] = "repost";
        Response.Redirect("~/user/MeeBoComment.aspx");
    }

    protected void comment_Click(object sender, EventArgs e)
    {
        Session["commentMeeboID"] = new Guid(this.btnID);
        Session["commentType"] = "comment";
        Response.Redirect("~/user/MeeBoComment.aspx");
    }

    protected void save_Click(object sender, EventArgs e)
    {
        SaveDB saveDb = new SaveDB();
        if (saveDb.isSaved((Guid)Session["id"], new Guid(this.btnID)))
            saveDb.Delete((Guid)Session["id"], new Guid(this.btnID));
        else
        {
            saveDb.UserID = (Guid)Session["id"];
            saveDb.NewsID = new Guid(this.btnID);
            saveDb.Insert();
        }
        NewsDB newsDb = new NewsDB();
        Response.Redirect("~/user/PersonalPage.aspx");
    }

    protected void search_click(object sender, EventArgs e)
    {
        //Response.Cookies.Add(new HttpCookie("SearchWord", this.find_content.Text));
        Session["searchWord"] = this.find_content.Text;
        Response.Redirect("~/SearchPage/SearchMeebo.aspx");
    }

    protected void user_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/user/MeeBoComment.aspx");
    }
}