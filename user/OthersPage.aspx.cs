using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MeeboDb;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public partial class user_OthersPage : System.Web.UI.Page
{
    protected string btnNewsID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        if(Session["otherName"] == null)
            this.RegisterClientScriptBlock("E", "<script language=javascript>history.go(-2);</script>");
        if ((Guid)Session["otherName"] == (Guid)Session["id"])
        {
            Response.Redirect("~/user/MyMeeBo.aspx");
        }
        if (IsPostBack)
            this.btnNewsID = Request.Form["__EVENTARGUMENT"];

        UserDB targetUser = new UserDB();
        UserDB originUser = new UserDB();
        targetUser.SearchByID("user", (Guid)Session["otherName"]);
        this.userHead.ImageUrl = targetUser.HeadPortrait;
        this.user_nickname.InnerText = targetUser.Nickname;
        this.likesNum.InnerText = targetUser.LikesNum.ToString();
        this.fansNum.InnerText = targetUser.FansNum.ToString();
        this.newsNum.InnerText = targetUser.NewsNum.ToString();
        if (targetUser.Gender == false)
            this.gender.InnerText = "女";
        else
            this.gender.InnerText = "男";
        this.birthday.InnerText = targetUser.Birthday.ToLongDateString().ToString();

        NewsDB newsDb = new NewsDB();
        NewsDB newsInfo = new NewsDB();
        NewsDB originNewsInfo = new NewsDB();
        SaveDB saveDb = new SaveDB();
        DataSet newsSet = newsDb.SearchUnDeleteByUserID((Guid)Session["otherName"], "newsSet");
        List<JObject> JList = new List<JObject>();
        foreach (DataRow singleNews in newsSet.Tables["newsSet"].Rows)
        {
            JObject singleNewsInfo = new JObject();
            if (singleNews["NIsTransmit"].ToString() == "False")
            {
                newsInfo.SearchByID((Guid)singleNews["NID"], "news");
                singleNewsInfo.Add(new JProperty("type", "Meebo"));
                singleNewsInfo.Add(new JProperty("content", newsInfo.ContentT));
                singleNewsInfo.Add(new JProperty("MeeboID", newsInfo.ID));
                if (newsInfo.ContentP != string.Empty)
                {
                    string[] picUrl = newsInfo.ContentP.Split(';');
                    singleNewsInfo.Add(new JProperty("pictures", new JArray(from url in picUrl select url.Replace("~", ".."))));
                }
                singleNewsInfo.Add(new JProperty("time", newsInfo.Date));
                singleNewsInfo.Add(new JProperty("praiseNum", newsInfo.ProNum));
                singleNewsInfo.Add(new JProperty("comNum", newsInfo.ComNum));
                singleNewsInfo.Add(new JProperty("transNum", newsInfo.TransmitNum));
                singleNewsInfo.Add(new JProperty("saveNum", newsInfo.SaveNum));
                singleNewsInfo.Add(new JProperty("isSave", saveDb.isSaved((Guid)Session["id"], newsInfo.ID)));
            }
            else
            {
                newsInfo.SearchByID((Guid)singleNews["NID"], "news");
                originNewsInfo.SearchByID(newsInfo.From, "originNews");
                singleNewsInfo.Add(new JProperty("type", "trans"));
                singleNewsInfo.Add(new JProperty("content", newsInfo.TransmitInf));
                singleNewsInfo.Add(new JProperty("MeeboID", newsInfo.ID));
                singleNewsInfo.Add(new JProperty("time", newsInfo.Date));
                singleNewsInfo.Add(new JProperty("praiseNum", newsInfo.ProNum));
                singleNewsInfo.Add(new JProperty("comNum", newsInfo.ComNum));
                singleNewsInfo.Add(new JProperty("transNum", newsInfo.TransmitNum));
                singleNewsInfo.Add(new JProperty("saveNum", newsInfo.SaveNum));
                singleNewsInfo.Add(new JProperty("isSave", saveDb.isSaved((Guid)Session["id"], newsInfo.ID)));
                originUser.SearchByID("user", originNewsInfo.UserID);
                singleNewsInfo.Add(new JProperty("originUser", originUser.Nickname));
                singleNewsInfo.Add(new JProperty("originUserID", originUser.ID));
                singleNewsInfo.Add(new JProperty("originContent", originNewsInfo.ContentT));
                if (originNewsInfo.ContentP != string.Empty)
                {
                    string[] picUrl = originNewsInfo.ContentP.Split(';');
                    singleNewsInfo.Add(new JProperty("originpictures", new JArray(from url in picUrl select url.Replace("~", ".."))));
                }
                singleNewsInfo.Add(new JProperty("originTime", originNewsInfo.Date));
            }
            JList.Add(singleNewsInfo);
        }
        JArray array = new JArray(
                from item in JList
                orderby Convert.ToDateTime(item["time"]) descending
                select new JObject(item)
                );
        string json = array.ToString();
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "getMeebo(" + json + ")", true);
        LikeDB likeDb = new LikeDB();
        if(likeDb.isPraise((Guid)Session["id"], (Guid)Session["otherName"]))
            Page.ClientScript.RegisterStartupScript(this.GetType(), "change", "changeBtnText(true);" + "getMeebo(" + json + ")", true);
        else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "change", "changeBtnText(false);" + "getMeebo(" + json + ")", true);
        
    }
    protected void like_Click(object sender, EventArgs e)
    {
        LikeDB likeDb = new LikeDB();
        if(likeDb.isPraise((Guid)Session["id"], (Guid)Session["otherName"]))
        {
            likeDb.Delete((Guid)Session["id"], (Guid)Session["otherName"]);
        }
        else
        {
            likeDb.FanID = (Guid)Session["id"];
            likeDb.StarID = (Guid)Session["otherName"];
            likeDb.Insert();
        }
        Response.Redirect("~/user/OthersPage.aspx");
    }
    protected void search_click(object sender, EventArgs e)
    {
        //Response.Cookies.Add(new HttpCookie("SearchWord", this.find_content.Text));
        Session["searchWord"] = this.find_content.Text;
        Response.Redirect("~/SearchPage/SearchMeebo.aspx");
    }

    protected void zan_Click(object sender, EventArgs e)
    {
        PraiseDB praiseDb = new PraiseDB();
        praiseDb.UserID = (Guid)Session["id"];
        praiseDb.NewsID = new Guid(this.btnNewsID);
        praiseDb.isCheck = false;
        NewsDB newsDb = new NewsDB();
        newsDb.SearchByID(new Guid(this.btnNewsID), "result");
        praiseDb.NewsUserID = newsDb.UserID;
        praiseDb.Insert();
        Response.Redirect("~/user/OthersPage.aspx");
    }

    protected void repost_Click(object sender, EventArgs e)
    {
        Session["commentMeeboID"] = new Guid(this.btnNewsID);
        Session["commentType"] = "repost";
        Response.Redirect("~/user/MeeBoComment.aspx");
    }

    protected void comment_Click(object sender, EventArgs e)
    {
        Session["commentMeeboID"] = new Guid(this.btnNewsID);
        Session["commentType"] = "comment";
        Response.Redirect("~/user/MeeBoComment.aspx");
    }

    protected void save_Click(object sender, EventArgs e)
    {
        SaveDB saveDb = new SaveDB();
        if (saveDb.isSaved((Guid)Session["id"], new Guid(this.btnNewsID)))
            saveDb.Delete((Guid)Session["id"], new Guid(this.btnNewsID));
        else
        {
            saveDb.UserID = (Guid)Session["id"];
            saveDb.NewsID = new Guid(this.btnNewsID);
            saveDb.Insert();
        }
        NewsDB newsDb = new NewsDB();
        Response.Redirect("~/user/OthersPage.aspx");
    }

    protected void go_user_Click(object sender, EventArgs e)
    {
        Session["otherName"] = new Guid(this.btnNewsID);
        Response.Redirect("~/user/OthersPage.aspx");
    }
}